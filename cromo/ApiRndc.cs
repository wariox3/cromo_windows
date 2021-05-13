using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiElementosRndc
    {
        public ApiConfiguracionRndc configuracion { get; set; }
        public ApiDespachoRndc despacho { get; set; }
        public ApiVehiculoRndc vehiculo { get; set; }
        public List<ApiTerceroRndc> terceros { get; set; }
    }

    class ApiConfiguracionRndc
    {
        public string claveRndc { get; set; }
        public string usuarioRndc { get; set; }
        public string empresaRndc { get; set; }
    }

    class ApiDespachoRndc
    {
        public string codigoDespachoPk { get; set; }
    }

    class ApiVehiculoRndc
    {
        public string codigoVehiculoPk { get; set; }
    }

    class ApiTerceroRndc
    {
        public string identificacionTipo { get; set; }
        public string identificacion { get; set; }
        public string nombre1 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string telefono { get; set; }
        public string movil { get; set; }
        public string direccion { get; set; }
        public string codigoCiudad { get; set; }
        public string conductor { get; set; }
        public DateTime? fechaVenceLicencia { get; set; }
        public string numeroLicencia { get; set; }
        public string categoriaLicencia { get; set; }
        public string codigoSede { get; set; }
        public string nombreSede { get; set; }
    }
}
