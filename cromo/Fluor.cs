using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace cromo
{
    /// <summary>
    /// Cliente centralizado para integración con API Fluor
    /// Maneja: autenticación JWT, refresh tokens, y operaciones
    /// </summary>
    public static class Fluor
    {
        private static string _accessToken = "";
        private static string _refreshToken = "";
        private static DateTime _tokenExpireTime = DateTime.MinValue;

        public static DateTime TokenExpireTime => _tokenExpireTime;

        private static readonly JavaScriptSerializer _serializer = new JavaScriptSerializer();
        private const string FLUOR_API_URL = "https://api.semanticaapi.com.co";
        private const string FLUOR_AUTH_URL = FLUOR_API_URL + "/auth/seguridad";

        // ============ AUTENTICACIÓN ============

        /// <summary>
        /// Autentica un usuario con email/password contra Fluor
        /// Retorna true si login exitoso, false si falló
        /// </summary>
        public static bool Login(string email, string password)
        {
            try
            {
                var loginRequest = new
                {
                    email = email,
                    password = password,
                    // "api": Fluor devuelve access_token y refresh_token en el cuerpo (sin cookies ni Turnstile)
                    client_type = "api"
                };

                string json = _serializer.Serialize(loginRequest);
                string response = ApiControlador.ApiPostPlain(
                    FLUOR_AUTH_URL + "/login",
                    json
                );

                if (string.IsNullOrWhiteSpace(response))
                    return false;

                var loginResp = _serializer.Deserialize<dynamic>(response);

                if (loginResp != null && loginResp.ContainsKey("access_token"))
                {
                    _accessToken = loginResp["access_token"].ToString();
                    _tokenExpireTime = DateTime.Now.AddMinutes(60);

                    if (loginResp.ContainsKey("refresh_token"))
                    {
                        _refreshToken = loginResp["refresh_token"].ToString();
                    }

                    // La empresa (tenant) se elige después del login con SeleccionarEmpresa
                    EmpresaActual = null;

                    // Correo del usuario autenticado según Fluor (si no viene, el que digitó)
                    CorreoUsuario = email?.Trim() ?? "";
                    var user = loginResp.ContainsKey("user") ? loginResp["user"] as IDictionary<string, object> : null;
                    string correo = user != null ? Texto(user, "email") : null;
                    if (!string.IsNullOrWhiteSpace(correo))
                        CorreoUsuario = correo.Trim();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogError("Login failed", ex);
                return false;
            }
        }

        /// <summary>
        /// Renueva el access token usando el refresh token
        /// </summary>
        public static bool RefreshAccessToken()
        {
            if (string.IsNullOrWhiteSpace(_refreshToken))
                return !string.IsNullOrWhiteSpace(_accessToken);

            try
            {
                // Si token va a expirar en <5 minutos, renovar
                if (DateTime.Now.AddMinutes(5) < _tokenExpireTime)
                    return true;

                var refreshRequest = new { refresh_token = _refreshToken };
                string json = _serializer.Serialize(refreshRequest);
                string response = ApiControlador.ApiPostPlain(
                    FLUOR_AUTH_URL + "/refresh",
                    json
                );

                if (string.IsNullOrWhiteSpace(response))
                    return false;

                var refreshResp = _serializer.Deserialize<dynamic>(response);

                if (refreshResp != null && refreshResp.ContainsKey("access_token"))
                {
                    _accessToken = refreshResp["access_token"].ToString();
                    _tokenExpireTime = DateTime.Now.AddMinutes(60);


                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogError("Token refresh failed", ex);
                return false;
            }
        }

        /// <summary>
        /// Obtiene el token de acceso actual (válido)
        /// Si está a punto de expirar, intenta renovar
        /// </summary>
        public static string GetAccessToken()
        {
            RefreshAccessToken();

            if (string.IsNullOrWhiteSpace(_accessToken))
                throw new InvalidOperationException("No hay token de acceso válido. Debe autenticarse primero.");

            return _accessToken;
        }

        // ============ EMPRESA (TENANT) ============

        /// <summary>Empresa a la que tiene acceso el usuario (registro de /mas/user-tenant/lista)</summary>
        public class Empresa
        {
            public int TenantId { get; set; }
            public string Nombre { get; set; }
            public string CodigoUsuario { get; set; }
            public bool Control { get; set; }
            public override string ToString() => Nombre;
        }

        /// <summary>Empresa seleccionada; su tenant_id se envía en el encabezado X-Tenant-ID de cada petición</summary>
        public static Empresa EmpresaActual { get; private set; }

        /// <summary>Código del usuario en la empresa seleccionada (codigo_usuario_fk de user-tenant)</summary>
        public static string CodigoUsuario => EmpresaActual?.CodigoUsuario ?? "";

        /// <summary>Correo del usuario autenticado</summary>
        public static string CorreoUsuario { get; private set; } = "";

        /// <summary>Valor del campo "usuario" al crear clientes y destinatarios (null si no tiene código)</summary>
        public static string UsuarioCreacion => string.IsNullOrWhiteSpace(CodigoUsuario) ? null : CodigoUsuario.Trim();

        /// <summary>
        /// Valor del campo "usuario" al crear guías: el código de usuario de la empresa o, si no tiene,
        /// los primeros 25 caracteres del correo del usuario autenticado (el campo usuario de la guía es de 25)
        /// </summary>
        public static string UsuarioGuia
        {
            get
            {
                string usuario = UsuarioCreacion ?? CorreoUsuario;
                if (string.IsNullOrWhiteSpace(usuario))
                    return null;
                return usuario.Length > 25 ? usuario.Substring(0, 25) : usuario;
            }
        }

        /// <summary>Empresas activas del usuario autenticado, ordenadas por nombre</summary>
        public static List<Empresa> Empresas()
        {
            var empresas = new List<Empresa>();
            foreach (var r in GetLista("/mas/user-tenant/lista", new Dictionary<string, object> { { "size", 200 } }))
            {
                if (!Booleano(r, "activo"))
                    continue;
                empresas.Add(new Empresa
                {
                    TenantId = Entero(r, "tenant_id"),
                    Nombre = Texto(r, "tenant_nombre") ?? ("Empresa " + Texto(r, "tenant_id")),
                    CodigoUsuario = Texto(r, "codigo_usuario_fk"),
                    Control = Booleano(r, "control")
                });
            }
            return empresas;
        }

        public static void SeleccionarEmpresa(Empresa empresa)
        {
            EmpresaActual = empresa;
        }

        /// <summary>
        /// Cierra la sesión y limpia tokens
        /// </summary>
        public static void Logout()
        {
            EmpresaActual = null;
            CorreoUsuario = "";
            _accessToken = "";
            _refreshToken = "";
            _tokenExpireTime = DateTime.MinValue;
        }

        // ============ OPERACIONES ============

        public static string Get(string ruta)
        {
            return ApiControlador.ApiGetWithToken(FLUOR_API_URL + ruta, GetAccessToken());
        }

        public static byte[] GetBytes(string ruta)
        {
            return ApiControlador.ApiGetBytesWithToken(FLUOR_API_URL + ruta, GetAccessToken());
        }

        // Consulta un /lista o /buscar paginado de Fluor; omite los filtros vacíos y devuelve los "items"
        public static List<Dictionary<string, object>> GetLista(string ruta, IDictionary<string, object> filtros)
        {
            var query = new List<string>();
            foreach (var filtro in filtros)
            {
                string valor = filtro.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(valor))
                    query.Add(filtro.Key + "=" + Uri.EscapeDataString(valor.Trim()));
            }

            string json = Get(ruta + (query.Count > 0 ? "?" + string.Join("&", query) : ""));
            object raiz = _serializer.DeserializeObject(json);
            if (raiz is IDictionary<string, object> pagina && pagina.ContainsKey("items"))
                raiz = pagina["items"];

            var lista = new List<Dictionary<string, object>>();
            if (raiz is System.Collections.IList registros)
                foreach (var registro in registros)
                    if (registro is Dictionary<string, object> r)
                        lista.Add(r);
            return lista;
        }

        public static Dictionary<string, object> GetDetalle(string ruta)
        {
            return _serializer.Deserialize<Dictionary<string, object>>(Get(ruta));
        }

        internal static ApiGuia DetalleGuia(int codigoGuia)
        {
            var g = GetDetalle("/tte/guia/detalle/" + codigoGuia);
            return new ApiGuia
            {
                codigoGuiaPk = Texto(g, "codigo_guia_pk"),
                codigoGuiaTipoFk = Texto(g, "codigo_guia_tipo_fk"),
                codigoOperacionIngresoFk = Texto(g, "codigo_operacion_ingreso_fk"),
                codigoOperacionCargoFk = Texto(g, "codigo_operacion_cargo_fk"),
                codigoTerceroFk = Texto(g, "codigo_tercero_fk"),
                clienteNombreCorto = Texto(g, "tercero_nombre"),
                codigoAdquirienteFk = Texto(g, "codigo_adquiriente_fk"),
                adquirienteNombreCorto = Texto(g, "adquiriente_nombre"),
                codigoAsesorFk = Texto(g, "codigo_asesor_fk"),
                codigoCondicionFk = Texto(g, "codigo_condicion_fk"),
                condicionNombre = Texto(g, "condicion_nombre"),
                factura = Booleano(g, "factura"),
                codigoCiudadOrigenFk = Texto(g, "codigo_ciudad_origen_fk"),
                ciudadOrigenNombre = Texto(g, "ciudad_origen_nombre"),
                codigoCiudadDestinoFk = Texto(g, "codigo_ciudad_destino_fk"),
                ciudadDestinoNombre = Texto(g, "ciudad_destino_nombre"),
                codigoServicioFk = Texto(g, "codigo_servicio_fk"),
                codigoProductoFk = Texto(g, "codigo_producto_fk"),
                codigoEmpaqueFk = Texto(g, "codigo_empaque_fk"),
                empaqueReferencia = Texto(g, "empaque_referencia"),
                codigoRutaFk = Texto(g, "codigo_ruta_fk"),
                codigoZonaFk = Texto(g, "codigo_zona_fk"),
                ordenRuta = Texto(g, "orden_ruta"),
                codigoDespachoFk = Texto(g, "codigo_despacho_fk"),
                documentoCliente = Texto(g, "documento_cliente"),
                relacionCliente = Texto(g, "relacion_cliente"),
                remitente = Texto(g, "remitente"),
                nombreRemitente = Texto(g, "remitente"),
                direccionRemitente = Texto(g, "direccion_remitente"),
                telefonoRemitente = Texto(g, "telefono_remitente"),
                codigoDestinatarioFk = Texto(g, "codigo_destinatario_fk"),
                nombreDestinatario = Texto(g, "nombre_destinatario"),
                direccionDestinatario = Texto(g, "direccion_destinatario"),
                telefonoDestinatario = Texto(g, "telefono_destinatario"),
                fechaIngreso = Fecha(g, "fecha_ingreso") ?? DateTime.MinValue,
                fechaDespacho = Fecha(g, "fecha_despacho"),
                fechaEntrega = Fecha(g, "fecha_entrega"),
                unidades = Numero(g, "unidades").ToString(),
                pesoReal = Numero(g, "peso_real").ToString(),
                pesoVolumen = Numero(g, "peso_volumen").ToString(),
                pesoFacturado = Numero(g, "peso_facturado").ToString(),
                vrDeclara = Numero(g, "vr_declara").ToString(),
                vrFlete = Numero(g, "vr_flete").ToString(),
                vrManejo = Numero(g, "vr_manejo").ToString(),
                vrRecaudo = Numero(g, "vr_recaudo").ToString(),
                vrAbono = Numero(g, "vr_abono").ToString(),
                vrOtros = Numero(g, "vr_otros").ToString(),
                usuario = Texto(g, "usuario"),
                comentario = Texto(g, "comentario"),
                reexpedicion = Booleano(g, "reexpedicion"),
                cortesia = Booleano(g, "cortesia"),
                estadoImpreso = Booleano(g, "estado_impreso"),
                estadoEmbarcado = Booleano(g, "estado_embarcado"),
                estadoDespachado = Booleano(g, "estado_despachado"),
                estadoEntregado = Booleano(g, "estado_entregado"),
                estadoSoporte = Booleano(g, "estado_soporte"),
                estadoCumplido = Booleano(g, "estado_cumplido"),
                estadoFacturado = Booleano(g, "estado_facturado"),
                estadoFacturaGenerada = Booleano(g, "estado_factura_generada"),
                estadoAnulado = Booleano(g, "estado_anulado")
            };
        }

        private static DateTime? Fecha(IDictionary<string, object> registro, string campo)
        {
            string texto = Texto(registro, campo);
            return DateTime.TryParse(texto, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime fecha)
                ? (DateTime?)fecha : null;
        }

        public static string Texto(IDictionary<string, object> registro, string campo)
        {
            return registro.TryGetValue(campo, out object valor) ? valor?.ToString() : null;
        }

        public static bool Booleano(IDictionary<string, object> registro, string campo)
        {
            return registro.TryGetValue(campo, out object valor) && valor is bool b && b;
        }

        public static double Numero(IDictionary<string, object> registro, string campo)
        {
            return registro.TryGetValue(campo, out object valor) && valor != null
                ? Convert.ToDouble(valor, System.Globalization.CultureInfo.InvariantCulture) : 0;
        }

        public static int Entero(IDictionary<string, object> registro, string campo)
        {
            return (int)Numero(registro, campo);
        }

        public static string Post(string ruta, string json)
        {
            return ApiControlador.ApiPostWithToken(FLUOR_API_URL + ruta, json, GetAccessToken());
        }

        public static string MensajeError(Exception ex)
        {
            var webEx = ex as WebException;
            if (webEx?.Response == null)
                return ex.Message;

            string cuerpo;
            using (var reader = new System.IO.StreamReader(webEx.Response.GetResponseStream()))
                cuerpo = reader.ReadToEnd();

            try
            {
                var json = _serializer.Deserialize<System.Collections.Generic.Dictionary<string, object>>(cuerpo);

                // Formato Fluor: { "success": false, "error": { "code", "message" } }
                if (json.TryGetValue("error", out object error) && error is System.Collections.Generic.IDictionary<string, object> err
                    && err.TryGetValue("message", out object mensaje))
                    return mensaje.ToString();

                // Validación (422): { "detail": [ { "loc": [...], "msg": "..." } ] } o { "detail": "..." }
                if (json.TryGetValue("detail", out object detail))
                {
                    if (detail is System.Collections.ArrayList lista)
                    {
                        var mensajes = new System.Collections.Generic.List<string>();
                        foreach (System.Collections.Generic.IDictionary<string, object> d in lista)
                        {
                            string campo = d.ContainsKey("loc") && d["loc"] is System.Collections.ArrayList loc && loc.Count > 0
                                ? loc[loc.Count - 1].ToString() + ": " : "";
                            mensajes.Add(campo + d["msg"]);
                        }
                        return string.Join("\n", mensajes);
                    }
                    return detail.ToString();
                }
            }
            catch { }

            return ex.Message + (string.IsNullOrWhiteSpace(cuerpo) ? "" : "\n" + cuerpo);
        }

        // ============ HELPERS ============

        private static void LogError(string message, Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[Fluor] {message}: {ex.Message}");
        }
    }
}
