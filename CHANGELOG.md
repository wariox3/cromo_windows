# Registro de cambios

El proyecto usa [versionado semántico](https://semver.org/lang/es/): `MAYOR.MENOR.PARCHE`.

## [2.2.2] - 2026-10-27

### Corregido
- El inicio de sesión fallaba porque Fluor ya no acepta `client_type: "integration"`; ahora se envía `"api"`.
- La sesión ya no vence a la hora: con `client_type: "api"` Fluor entrega el refresh token y Cromo renueva el token automáticamente.

## [2.2.1] - 2026-10-26

### Cambiado
- La impresión masiva y la vista previa ya no limitan la cantidad de guías del rango en Cromo (antes 30): el máximo lo valida Fluor y su mensaje se muestra al imprimir.

## [2.2.0] - 2026-10-26

### Agregado
- Impresión masiva: botón Vista previa que abre el PDF del rango en el lector de PDF antes de imprimir.

### Corregido
- Impresión masiva: si desde o hasta no eran números, la pantalla fallaba; ahora avisa y lleva al campo.

## [2.1.1] - 2026-10-26

### Cambiado
- Seleccionar empresa muestra una tabla con la empresa, el usuario del ERP (`codigo_usuario_fk`, columna UsuarioERP) y si el usuario es control en esa empresa (SI/NO).
- Al crear guías y guías operador, el campo `usuario` lleva el `codigo_usuario_fk` de la empresa o, si no tiene, los primeros 25 caracteres del correo del usuario autenticado.

## [2.1.0] - 2026-10-24

### Agregado
- Pantalla de selección de empresa: después de iniciar sesión siempre se muestra, aunque el usuario tenga una sola empresa. Consulta las empresas del usuario (`/mas/user-tenant/lista`) y, al aceptar, descarga los catálogos de la empresa elegida con su barra de progreso. Sin empresas activas no se permite el ingreso.
- Menú Archivo > Cambiar empresa: cierra las ventanas abiertas y abre la misma pantalla. Si la descarga falla se sigue trabajando con la empresa anterior.
- La barra de estado muestra la empresa activa.
- Crear cliente: Enter pasa al siguiente campo, como en la guía; en el último campo lleva a Guardar.
- Crear cliente: abre con cédula como identificación.
- Crear cliente: el tercero se crea con pago contado y pago destino habilitados (`guia_pago_contado` y `guia_pago_destino` en true); crédito, cortesía y recogida siguen deshabilitados.
- Crear cliente: al salir del nombre corto, si el nombre extendido está vacío se llena con el nombre corto.
- Crear cliente: al salir del número de identificación se consulta en Fluor (`/gen/tercero/lista`); si ya existe un tercero con ese número se avisa con su código y nombre y no se deja continuar.

### Eliminado
- Campos y catálogos de tipo de persona y régimen: al crear el cliente se envían según la identificación (cédula: persona natural `N` y régimen simple `S`; NIT: persona jurídica `J` y régimen ordinario `O`).

### Cambiado
- Cada petición a Fluor envía la empresa en el encabezado `X-Tenant-ID`; el login ya no entrega la empresa.
- Los catálogos y la configuración se descargan después de elegir la empresa.
- El código de usuario para la configuración del usuario sale de la empresa elegida (`codigo_usuario_fk` de user-tenant).
- Al crear guías, guías operador, clientes y destinatarios se envía ese código en el campo `usuario`.

## [2.0.2] - 2026-10-22

### Corregido
- El acceso directo seguía mostrando el ícono anterior después de instalar o actualizar, por la caché de íconos de Windows. Ahora Cromo le pide a Windows que refresque los íconos al terminar la instalación o la actualización.

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
