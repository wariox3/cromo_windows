using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiUsuario
    {
        public string error { get; set; }
        public string nombreCorto { get; set; }
        public int versionBaseDatos { get; set; }
        public bool numeroUnicoGuia { get; set; }
        public bool restringirGuiaNueva { get; set; }
        public int codigoPrecioGeneral { get; set; }
        public int codigoCondicionGeneral { get; set; }
        public string codigoFormatoGuia { get; set; }
        public double porcentajeManejoMinimo { get; set; }
        public double descuentoPesoMaximo { get; set; }
    }

    class ApiUsuarioConfigurcion
    {
        public bool error { get; set; }
        public string errorMensaje { get; set; }
        public double porcentajeManejoMinimo { get; set; }
        public double descuentoPesoMaximo { get; set; }
        public double manejoMinimoUnidad { get; set; }
        public double manejoMinimoDespacho { get; set; }
    }

    /// <summary>
    /// Respuesta del login en Fluor con JWT
    /// </summary>
    class ApiLoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public ApiUserInfo user { get; set; }
    }

    /// <summary>
    /// Información del usuario autenticado en Fluor
    /// </summary>
    class ApiUserInfo
    {
        public int id { get; set; }
        public string email { get; set; }
        public int tenant_id { get; set; }
        public string tenant_nombre { get; set; }
        public string role { get; set; }
        public int empleado_id { get; set; }
    }
}
