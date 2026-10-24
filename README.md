# Cromo

Aplicación de escritorio para Windows de Semántica para la operación de transporte: creación e impresión de guías, guías de operador logístico, clientes y destinatarios. Trabaja contra la API de Fluor (`https://api.semanticaapi.com.co`).

## Descarga

**[Descargar Cromo para Windows](https://cdn-semantica.tor1.digitaloceanspaces.com/cromo/descargas/Cromo-win-Setup.exe)**

- El instalador siempre entrega la última versión.
- La aplicación se actualiza sola al abrir: descarga solo lo que cambió y se reinicia.
- Las versiones y sus cambios están en [Releases](https://github.com/wariox3/cromo_windows/releases) y en el [CHANGELOG](CHANGELOG.md).

## Requisitos

- Windows 10 u 11.
- .NET Framework 4.8 (el instalador lo instala si falta).
- Un usuario de Fluor con acceso a al menos una empresa activa.

## Funciones

- **Ingreso:** usuario y contraseña de Fluor (JWT). Después se elige la empresa y se descargan sus catálogos; se puede cambiar en Archivo > Cambiar empresa.
- **Guía y guía operador:** liquidación con precios y condiciones del cliente, guardado e impresión con el PDF que genera Fluor (vista previa o directo a la impresora predeterminada).
- **Clientes y destinatarios:** creación con validación del número de identificación.
- **Configuración:** operación de ingreso y código de cliente del operador logístico, validados contra Fluor.

## Desarrollo

Requiere Visual Studio 2022 o posterior con el componente de escritorio .NET (.NET Framework 4.8).

1. Abrir `cromo.sln`.
2. Restaurar los paquetes NuGet (la carpeta `packages` no está en el repositorio).
3. Compilar y ejecutar el proyecto `cromo`.

Desde la línea de comandos (usar el MSBuild de Visual Studio, no el de `dotnet`, porque el proyecto tiene recursos que este último no compila):

```powershell
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" cromo\cromo.csproj /t:Build /p:Configuration=Release
```

### Archivos principales

| Archivo | Para qué sirve |
|---|---|
| `cromo/Fluor.cs` | Cliente de la API: login, token, empresa seleccionada, consultas y errores |
| `cromo/ApiControlador.cs` | Peticiones HTTP; agrega `Authorization`, `X-Tenant-ID` y la versión de la aplicación |
| `cromo/CatalogoManager.cs` | Descarga y guarda en memoria los catálogos de la empresa |
| `cromo/FrmIngreso.cs` | Inicio de sesión |
| `cromo/FrmSeleccionarEmpresa.cs` | Selección de empresa y carga de catálogos |
| `cromo/frmGuia.cs`, `cromo/FrmGuiaOperador.cs` | Creación de guías |
| `cromo/ImpresionGuia.cs` | Vista previa e impresión de guías |
| `cromo/Actualizacion.cs` | Actualizaciones automáticas con Velopack |

## Versiones y publicación

El proyecto usa [versionado semántico](https://semver.org/lang/es/) (`MAYOR.MENOR.PARCHE`). La versión vive en `cromo/Properties/AssemblyInfo.cs` (`AssemblyVersion`, `AssemblyFileVersion` y `AssemblyInformationalVersion`) y cada cambio se anota en el [CHANGELOG](CHANGELOG.md).

El instalador y las actualizaciones se generan con [Velopack](https://velopack.io) y se publican en DigitalOcean Spaces (`cdn-semantica/cromo/descargas`).

### Requisitos para publicar (una sola vez)

```powershell
dotnet tool install -g vpk --version 1.2.161
winget install Rclone.Rclone
winget install GitHub.cli
gh auth login
.\publicar.ps1 -GuardarLlave
```

`-GuardarLlave` pide la Access Key y la Secret Key del Space y las guarda cifradas con el usuario de Windows en `%APPDATA%\Cromo\spaces-llave.xml`, fuera del repositorio.

### Pasos para publicar una versión

1. Subir la versión en `AssemblyInfo.cs` y poner la fecha en su sección del `CHANGELOG.md`.
2. Publicar el instalador y la actualización:
   ```powershell
   powershell -ExecutionPolicy Bypass -File .\publicar.ps1
   ```
3. Hacer el commit, la etiqueta `vX.Y.Z` y subirlos:
   ```powershell
   git tag -a vX.Y.Z -m "Cromo X.Y.Z"
   git push origin master vX.Y.Z
   ```
4. Crear el release en GitHub con las notas del CHANGELOG:
   ```powershell
   powershell -ExecutionPolicy Bypass -File .\publicar.ps1 -SoloRelease
   ```

`.\publicar.ps1 -SoloEmpaquetar` genera el instalador en `instalador\Releases` sin subirlo.
