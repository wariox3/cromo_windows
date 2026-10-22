# Publica una versión de Cromo con Velopack en DigitalOcean Spaces.
#
# Requisitos (una sola vez):
#   dotnet tool install -g vpk --version 1.2.161
#   winget install Rclone.Rclone
#
# Llave del Space: se guarda una vez, cifrada con el usuario de Windows (DPAPI), fuera del repositorio:
#   .\publicar.ps1 -GuardarLlave      (usuario = Access Key, contraseña = Secret Key)
# También se puede pasar en variables de entorno: $env:SPACES_KEY y $env:SPACES_SECRET
#
# Uso:  .\publicar.ps1            (toma la versión de AssemblyInformationalVersion)
#       .\publicar.ps1 -SoloEmpaquetar   (genera el instalador sin subirlo)

param([switch]$SoloEmpaquetar, [switch]$GuardarLlave)

$ErrorActionPreference = 'Stop'
$archivoLlave = Join-Path $env:APPDATA 'Cromo\spaces-llave.xml'

if ($GuardarLlave) {
    $credencial = Get-Credential -Message 'Llave del Space cdn-semantica: usuario = Access Key, contraseña = Secret Key'
    if (-not $credencial) { throw 'No se ingresó la llave' }
    New-Item -ItemType Directory -Force (Split-Path $archivoLlave) | Out-Null
    $credencial | Export-Clixml $archivoLlave
    Write-Host "Llave guardada cifrada en $archivoLlave (solo la puede leer este usuario en este equipo)" -ForegroundColor Green
    return
}

if ((-not $env:SPACES_KEY -or -not $env:SPACES_SECRET) -and (Test-Path $archivoLlave)) {
    $credencial = Import-Clixml $archivoLlave
    $env:SPACES_KEY = $credencial.UserName
    $env:SPACES_SECRET = $credencial.GetNetworkCredential().Password
}
$raiz = $PSScriptRoot
$proyecto = Join-Path $raiz 'cromo'
$releases = Join-Path $raiz 'instalador\Releases'

$bucket = 'cdn-semantica'
$region = 'tor1'
$endpoint = "https://$region.digitaloceanspaces.com"
$prefijo = 'cromo/descargas'
$versionVpk = '1.2.161'

$info = Get-Content (Join-Path $proyecto 'Properties\AssemblyInfo.cs') -Raw
if ($info -notmatch '(?m)^\[assembly: AssemblyInformationalVersion\("([^"]+)"\)\]') { throw 'No se encontró AssemblyInformationalVersion en AssemblyInfo.cs' }
$version = $Matches[1]
Write-Host "Publicando Cromo $version" -ForegroundColor Cyan

# Se recarga el PATH del sistema: una terminal abierta antes de instalar rclone o vpk no los vería
$env:PATH = [Environment]::GetEnvironmentVariable('PATH', 'Machine') + ';' + [Environment]::GetEnvironmentVariable('PATH', 'User') + ";$env:USERPROFILE\.dotnet\tools"
if (-not (Get-Command vpk -ErrorAction SilentlyContinue)) { throw "Falta vpk: dotnet tool install -g vpk --version $versionVpk" }
$instalada = (dotnet tool list -g | Select-String '^vpk\s+(\S+)').Matches.Groups[1].Value
if ($instalada -ne $versionVpk) { throw "vpk debe ser $versionVpk (la misma versión del paquete Velopack del proyecto); instalada: $instalada" }
if (-not $SoloEmpaquetar) {
    if (-not (Get-Command rclone -ErrorAction SilentlyContinue)) { throw 'Falta rclone: winget install Rclone.Rclone' }
    if (-not $env:SPACES_KEY -or -not $env:SPACES_SECRET) { throw 'Falta la llave del Space: ejecute .\publicar.ps1 -GuardarLlave' }
}

$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuild = & $vswhere -latest -products * -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
if (-not $msbuild) { throw 'No se encontró MSBuild de Visual Studio' }

Write-Host '1/4 Compilando en Release...' -ForegroundColor Cyan
& $msbuild (Join-Path $proyecto 'cromo.csproj') /t:Rebuild /p:Configuration=Release /verbosity:minimal /nologo
if ($LASTEXITCODE -ne 0) { throw 'La compilación falló' }

# Se parte siempre de lo publicado en el Space, nunca de empaquetados locales anteriores
Remove-Item -Recurse -Force $releases -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force $releases | Out-Null
if (-not $SoloEmpaquetar) {
    Write-Host '2/4 Descargando la versión publicada anterior (para la actualización diferencial)...' -ForegroundColor Cyan
    # Antes de descargar se prueba la llave: un error de llave no debe confundirse con "no hay versión anterior"
    $env:RCLONE_S3_PROVIDER = 'DigitalOcean'
    $env:RCLONE_S3_ENDPOINT = "$region.digitaloceanspaces.com"
    $env:RCLONE_S3_ACCESS_KEY_ID = $env:SPACES_KEY
    $env:RCLONE_S3_SECRET_ACCESS_KEY = $env:SPACES_SECRET
    $env:RCLONE_S3_ACL = 'public-read'
    $ErrorActionPreference = 'Continue'   # en PowerShell 5.1 los avisos de un programa externo redirigidos detienen el script con Stop
    rclone lsf ":s3:$bucket/$prefijo/" --max-depth 1 *> $null
    $llaveValida = $LASTEXITCODE -eq 0
    if ($llaveValida) { vpk download s3 --outputDir $releases --bucket $bucket --region $region --endpoint $endpoint --prefix $prefijo --keyId $env:SPACES_KEY --secret $env:SPACES_SECRET *> $null }
    $hayAnterior = $LASTEXITCODE -eq 0
    $ErrorActionPreference = 'Stop'
    if (-not $llaveValida) { throw 'El Space rechazó la llave (Access Key o Secret Key incorrecta, o sin permiso sobre cdn-semantica). Vuelva a guardarla con .\publicar.ps1 -GuardarLlave' }
    if (-not $hayAnterior) { Write-Warning 'No hay una versión anterior publicada: se publica sin actualización diferencial' }
}

Write-Host '3/4 Empaquetando...' -ForegroundColor Cyan
vpk pack --packId Cromo --packVersion $version --packTitle 'Cromo' --packAuthors 'Semantica' `
    --packDir (Join-Path $proyecto 'bin\Release') --mainExe cromo.exe `
    --icon (Join-Path $proyecto 'Resources\cromo.ico') --framework net48 --outputDir $releases
if ($LASTEXITCODE -ne 0) { throw 'El empaquetado falló' }

if ($SoloEmpaquetar) { Write-Host "Listo, instalador en $releases" -ForegroundColor Green; return }

Write-Host '4/4 Subiendo al Space (lectura pública)...' -ForegroundColor Cyan
# copy (no sync): nunca borra versiones anteriores publicadas
rclone copy $releases ":s3:$bucket/$prefijo" --progress
if ($LASTEXITCODE -ne 0) { throw 'La subida falló' }

$url = "https://$bucket.$region.digitaloceanspaces.com/$prefijo"
$estado = (Invoke-WebRequest "$url/releases.win.json" -UseBasicParsing).StatusCode
Write-Host "Publicado Cromo $version (releases.win.json responde $estado)" -ForegroundColor Green
Write-Host "Instalador: $url/Cromo-win-Setup.exe" -ForegroundColor Green
