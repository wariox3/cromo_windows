using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace cromo
{
    static class CatalogoManager
    {
        private static readonly JavaScriptSerializer _serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

        public static List<ApiCiudad> Ciudades { get; private set; } = new List<ApiCiudad>();
        public static List<ApiIdentificacion> Identificaciones { get; private set; } = new List<ApiIdentificacion>();
        public static List<ApiGuiaTipo> GuiaTipos { get; private set; } = new List<ApiGuiaTipo>();
        public static List<ApiServicio> Servicios { get; private set; } = new List<ApiServicio>();
        public static List<ApiProducto> Productos { get; private set; } = new List<ApiProducto>();
        public static List<ApiEmpaque> Empaques { get; private set; } = new List<ApiEmpaque>();

        public static bool CatalogosCargados { get; private set; }
        public static string UltimoError { get; private set; } = "";

        public const int Pasos = 12;

        public static List<ApiAsesor> Asesores { get; private set; } = new List<ApiAsesor>();
        public static List<TipoPersona> TiposPersona { get; private set; } = new List<TipoPersona>();
        public static List<Regimen> Regimenes { get; private set; } = new List<Regimen>();

        // Ciudades generales (gen/ciudad): las usan los terceros. Las de transporte (tte/ciudad) las usan guías y destinatarios
        public static List<ApiCiudad> CiudadesGenerales { get; private set; } = new List<ApiCiudad>();

        // null cuando el usuario no tiene configuración en Fluor (no puede modificar descuento ni manejo)
        public static ApiUsuarioConfigurcion UsuarioConfiguracion { get; private set; }

        public static bool CargarCatalogos(IProgress<KeyValuePair<int, string>> progreso = null)
        {
            if (CatalogosCargados)
                return true;

            UltimoError = "";
            int paso = 0;
            Action<string> avanzar = nombre =>
                progreso?.Report(new KeyValuePair<int, string>(++paso, "Descargando " + nombre + " (" + paso + " de " + Pasos + ")..."));

            try
            {
                avanzar("ciudades");
                var ciudades = Descargar("/tte/ciudad/descargar", "codigo_ciudad_pk",
                    (pk, nombre, r) => new ApiCiudad
                    {
                        codigoCiudadPk = pk,
                        nombre = nombre,
                        departamentoNombre = Texto(r, "departamento_nombre"),
                        codigoRutaFk = Texto(r, "codigo_ruta_fk"),
                        ordenRuta = Entero(r, "orden_ruta"),
                        codigoZonaFk = Texto(r, "codigo_zona_fk"),
                        reexpedicion = Booleano(r, "reexpedicion")
                    });
                ciudades.Sort((a, b) => string.Compare(a.nombre, b.nombre, StringComparison.CurrentCultureIgnoreCase));

                avanzar("ciudades generales");
                var ciudadesGenerales = Descargar("/gen/ciudad/descargar", "codigo_ciudad_pk",
                    (pk, nombre) => new ApiCiudad { codigoCiudadPk = pk, nombre = nombre });
                ciudadesGenerales.Sort((a, b) => string.Compare(a.nombre, b.nombre, StringComparison.CurrentCultureIgnoreCase));

                avanzar("identificaciones");
                var identificaciones = Descargar("/gen/identificacion/descargar", "codigo_identificacion_pk",
                    (pk, nombre) => new ApiIdentificacion { codigoIdentificacionPk = pk, nombre = nombre });

                avanzar("tipos de guía");
                var guiaTipos = Descargar("/tte/guia-tipo/descargar", "codigo_guia_tipo_pk",
                    (pk, nombre, r) => new ApiGuiaTipo
                    {
                        codigoGuiaTipoPk = pk,
                        nombre = nombre,
                        codigoPagoFk = Texto(r, "codigo_pago_fk"),
                        codigoFormaPago = Texto(r, "codigo_forma_pago"),
                        validarFlete = Booleano(r, "validar_flete"),
                        generaCobro = Booleano(r, "genera_cobro")
                    });

                avanzar("servicios");
                var servicios = Descargar("/tte/servicio/descargar", "codigo_servicio_pk",
                    (pk, nombre) => new ApiServicio { codigoServicioPk = pk, nombre = nombre });

                avanzar("productos");
                var productos = Descargar("/tte/producto/descargar", "codigo_producto_pk",
                    (pk, nombre) => new ApiProducto { codigoProductoPk = pk, nombre = nombre });

                avanzar("empaques");
                var empaques = Descargar("/tte/empaque/descargar", "codigo_empaque_pk",
                    (pk, nombre) => new ApiEmpaque { codigoEmpaquePk = pk, nombre = nombre });

                avanzar("asesores");
                var asesores = Descargar("/gen/asesor/descargar", "codigo_asesor_pk",
                    (pk, nombre) => new ApiAsesor { codigoAsesorPk = pk, nombre = nombre });
                asesores.Sort((a, b) => string.Compare(a.nombre, b.nombre, StringComparison.CurrentCultureIgnoreCase));

                avanzar("tipos de persona");
                var tiposPersona = Descargar("/gen/tipo-persona/descargar", "codigo_tipo_persona_pk",
                    (pk, nombre) => new TipoPersona { codigoTipoPersonaPk = pk, nombre = nombre });

                avanzar("regímenes");
                var regimenes = Descargar("/gen/regimen/descargar", "codigo_regimen_pk",
                    (pk, nombre) => new Regimen { codigoRegimenPk = pk, nombre = nombre });

                avanzar("configuración");
                var configuracion = Fluor.GetDetalle("/gen/configuracion/guia-nuevo");

                avanzar("configuración del usuario");
                // Sin codigo_usuario_fk o sin configuración (404) se trata como usuario sin topes: no se restringe la guía ni se permite modificar descuento o manejo
                Dictionary<string, object> usuario = null;
                if (!string.IsNullOrWhiteSpace(Fluor.CodigoUsuario))
                {
                    try
                    {
                        usuario = Fluor.GetDetalle("/seg/usuario-configuracion/detalle/" + Uri.EscapeDataString(Fluor.CodigoUsuario));
                    }
                    catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
                    {
                    }
                }

                General.CodigoPrecioGeneral = Fluor.Entero(configuracion, "codigo_precio_general_fk");
                General.RestringirGuiaNueva = usuario != null && Fluor.Booleano(usuario, "restringir_guia_nueva");
                UsuarioConfiguracion = usuario == null ? null : new ApiUsuarioConfigurcion
                {
                    porcentajeManejoMinimo = Fluor.Numero(usuario, "porcentaje_manejo_minimo"),
                    manejoMinimoUnidad = Fluor.Numero(usuario, "manejo_minimo_unidad"),
                    manejoMinimoDespacho = Fluor.Numero(usuario, "manejo_minimo_despacho"),
                    descuentoPesoMaximo = Fluor.Numero(usuario, "descuento_peso_maximo")
                };
                General.CodigoCondicionGeneral = Fluor.Entero(configuracion, "codigo_condicion_general_fk");
                Ciudades = ciudades;
                CiudadesGenerales = ciudadesGenerales;
                Asesores = asesores;
                TiposPersona = tiposPersona;
                Regimenes = regimenes;
                Identificaciones = identificaciones;
                GuiaTipos = guiaTipos;
                Servicios = servicios;
                Productos = productos;
                Empaques = empaques;
                CatalogosCargados = true;
                return true;
            }
            catch (Exception ex)
            {
                UltimoError = ex.Message;
                return false;
            }
        }

        private static List<T> Descargar<T>(string ruta, string campoPk, Func<string, string, T> crear)
        {
            return Descargar(ruta, campoPk, (pk, nombre, registro) => crear(pk, nombre));
        }

        private static string Texto(IDictionary<string, object> registro, string campo)
        {
            return registro.TryGetValue(campo, out object valor) ? valor?.ToString() : null;
        }

        private static int Entero(IDictionary<string, object> registro, string campo)
        {
            return registro.TryGetValue(campo, out object valor) && valor != null ? Convert.ToInt32(valor) : 0;
        }

        public static ApiCiudad BuscarCiudad(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;
            codigo = codigo.Trim();
            return Ciudades.Find(c => c.codigoCiudadPk == codigo);
        }

        private static bool Booleano(IDictionary<string, object> registro, string campo)
        {
            return registro.TryGetValue(campo, out object valor) && valor is bool b && b;
        }

        // Todos los /descargar de Fluor devuelven [{ "<campoPk>": "...", "nombre": "...", ...extras }]
        private static List<T> Descargar<T>(string ruta, string campoPk, Func<string, string, IDictionary<string, object>, T> crear)
        {
            string json;
            try
            {
                json = Fluor.Get(ruta);
            }
            catch (WebException ex) when (ex.Response is HttpWebResponse resp)
            {
                throw new Exception(ruta + ": HTTP " + (int)resp.StatusCode + " " + resp.StatusDescription);
            }

            object raiz = _serializer.DeserializeObject(json);
            if (raiz is IDictionary<string, object> obj && obj.ContainsKey("data"))
                raiz = obj["data"];

            var registros = raiz as IList;
            if (registros == null)
                throw new Exception(ruta + ": respuesta inesperada: " + Recortar(json));
            if (registros.Count == 0)
                throw new Exception(ruta + ": el catálogo llegó vacío");

            var lista = new List<T>(registros.Count);
            foreach (var item in registros)
            {
                var registro = item as IDictionary<string, object>;
                if (registro == null || !registro.TryGetValue(campoPk, out object pk) || pk == null)
                    throw new Exception(ruta + ": los campos no coinciden con el modelo. Registro: "
                        + Recortar(_serializer.Serialize(item)));

                registro.TryGetValue("nombre", out object nombre);
                string codigo = pk.ToString();
                lista.Add(crear(codigo, nombre?.ToString() ?? codigo, registro));
            }
            return lista;
        }

        public static bool Contiene(string texto, string buscado)
        {
            if (string.IsNullOrWhiteSpace(buscado))
                return true;
            return texto != null && System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                texto, buscado.Trim(), System.Globalization.CompareOptions.IgnoreCase | System.Globalization.CompareOptions.IgnoreNonSpace) >= 0;
        }

        private static string Recortar(string texto)
        {
            return texto.Length > 300 ? texto.Substring(0, 300) + "..." : texto;
        }

        public static void LimpiarCatalogos()
        {
            Ciudades = new List<ApiCiudad>();
            CiudadesGenerales = new List<ApiCiudad>();
            Asesores = new List<ApiAsesor>();
            TiposPersona = new List<TipoPersona>();
            Regimenes = new List<Regimen>();
            Identificaciones = new List<ApiIdentificacion>();
            GuiaTipos = new List<ApiGuiaTipo>();
            Servicios = new List<ApiServicio>();
            Productos = new List<ApiProducto>();
            Empaques = new List<ApiEmpaque>();
            General.CodigoPrecioGeneral = 0;
            General.CodigoCondicionGeneral = 0;
            General.RestringirGuiaNueva = false;
            UsuarioConfiguracion = null;
            CatalogosCargados = false;
        }
    }
}
