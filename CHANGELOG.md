# Registro de cambios

El proyecto usa [versionado semántico](https://semver.org/lang/es/): `MAYOR.MENOR.PARCHE`.

## [2.0.1] - 2026-10-22

### Cambiado
- Nuevo ícono de la aplicación: camión con el distintivo de Semántica. Se usa en el ejecutable, el instalador, el acceso directo y todas las ventanas.

## [2.0.0] - 2026-10-22

Migración completa a la API de Fluor (`api.semanticaapi.com.co`). Esta versión no es compatible con la API anterior.

### Cambiado
- Inicio de sesión con usuario y contraseña de Fluor (JWT). El token se renueva automáticamente y no se guarda la contraseña.
- Al iniciar sesión se descargan los catálogos (ciudades, identificaciones, tipos de guía, servicios, productos, empaques, asesores, tipos de persona, regímenes) y la configuración de guías y del usuario. Sin catálogos no se entra a la aplicación.
- Guía, guía operador, búsquedas, crear cliente y crear destinatario usan Fluor para consultar, liquidar y guardar.
- La operación de ingreso de la guía sale de Configuración y se valida contra Fluor; la operación de cargo y la ciudad origen salen de la operación.
- La impresión de guías usa el PDF que genera Fluor: Previsualizar lo abre en el lector de PDF y Imprimir lo envía directo a la impresora predeterminada. La impresión masiva queda limitada a 30 guías.
- Configuración valida la operación de ingreso y el código de cliente antes de guardar.
- Cada petición a Fluor envía la versión de la aplicación en el encabezado `X-Client-Version`.
- Instalador y actualizaciones con Velopack (reemplaza ClickOnce), publicados en `https://cdn-semantica.tor1.digitaloceanspaces.com/cromo/descargas/` con `publicar.ps1`. La aplicación revisa si hay versión nueva antes de abrir, la instala y se reinicia; las actualizaciones descargan solo lo que cambió. La configuración se conserva entre versiones.
- El instalador verifica e instala .NET Framework 4.8 si falta.

### Eliminado
- API anterior, selección de operador y configuración de servidor manual.
- Recibos, precarga de guías, búsqueda de remitente, detalle de productos de la guía, número único de guía y número de factura.
- Envío al RNDC del Ministerio de Transporte.
- Reportes locales (ReportViewer), ruta de reportes, logo de la empresa y formulario de conexión.
- Menú Ayuda y botón Configurar del inicio de sesión.
- Instalador MSI anterior (proyecto `instalador.vdproj`) y la configuración de ClickOnce; los reemplaza Velopack.
