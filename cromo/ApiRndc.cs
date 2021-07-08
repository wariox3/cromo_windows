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
        public ApiVehiculoRndc remolque { get; set; }
        public List<ApiTerceroRndc> terceros { get; set; }
    }

    class ApiConfiguracionRndc
    {
        public string claveRndc { get; set; }
        public string usuarioRndc { get; set; }
        public string empresaRndc { get; set; }
        public string numeroPoliza { get; set; }
        public string fechaVencePoliza { get; set; }
        public string numeroIdentificacionAseguradora { get; set; }
    }

    class ApiDespachoRndc
    {
        public string codigoDespachoPk { get; set; }
        public string fechaSalida { get; set; }
        public string fechaEntrega { get; set; }
        public string codigoConductorFk { get; set; }
        public string codigoPoseedorFk { get; set; }
        public string codigoPropietarioFk { get; set; }
        public string codigoVehiculoFk { get; set; }
        public string pesoReal { get; set; }
        public string numero { get; set; }
        public string vrFletePago { get; set; }
        public string vrAnticipo { get; set; }
        public string vrRetencionFuente { get; set; }
        public string codigoCiudadOrigenFk { get; set; }
        public string codigoCiudadDestinoFk { get; set; }
        public string codigoCiudadOrigen { get; set; }
        public string codigoCiudadDestino { get; set; }
        public string poseedorTipoIdentificacion { get; set; }
        public string poseedorNumeroIdentificacion { get; set; }
        public string conductorTipoIdentificacion { get; set; }
        public string conductorNumeroIdentificacion { get; set; }   
        public string fechaLlegadaCargue { get; set; }
        public string horaLlegadaCargue { get; set; }
        public string fechaEntradaCargue { get; set; }
        public string horaEntradaCargue { get; set; }
        public string fechaSalidaCargue { get; set; }
        public string horaSalidaCargue { get; set; }
        public string fechaLlegadaDescargue { get; set; }
        public string horaLlegadaDescargue { get; set; }
        public string fechaEntradaDescargue { get; set; }
        public string horaEntradaDescargue { get; set; }
        public string fechaSalidaDescargue { get; set; }
        public string horaSalidaDescargue { get; set; }
    }

    class ApiVehiculoRndc
    {
        public string codigoVehiculoPk { get; set; }
        public string configuracion { get; set; }
        public string numeroEjes { get; set; }
        public string codigoMarca { get; set; }
        public string codigoLinea { get; set; }
        public string codigoColor { get; set; }
        public string tipoCombustible { get; set; }
        public string tipoCarroceria { get; set; }
        public string pesoVacio { get; set; }
        public string modelo { get; set; }
        public string tipoIdentificacionPropietario { get; set; }
        public string numeroIdentificacionPropietario { get; set; }
        public string tipoIdentificacionPoseedor { get; set; }
        public string numeroIdentificacionPoseedor { get; set; }
        public string numeroPoliza { get; set; }
        public string fechaVencePoliza { get; set; }
        public string numeroIdentificacionAseguradora { get; set; }
        public string capacidad { get; set; }

    }

    class ApiTerceroRndc
    {
        public string codigoTerceroPk { get; set; }
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
        public string fechaVenceLicencia { get; set; }
        public string numeroLicencia { get; set; }
        public string categoriaLicencia { get; set; }
        public string codigoSede { get; set; }
        public string nombreSede { get; set; }
        public string rndc { get; set; }
    }
}
