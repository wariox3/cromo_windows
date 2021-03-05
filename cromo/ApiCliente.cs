using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiCliente
    {        
        public string codigoTerceroPk { get; set; }        
        public string numeroIdentificacion { get; set; }
        public string codigoIdentificacionFk { get; set; }
        public string nombreCorto { get; set; }
        public string nombreExtendido { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string codigoCiudadFk { get; set; }
        public string codigoAsesorFk { get; set; }
        public string correo { get; set; }
        public string codigoCondicionFk { get; set; }
        public string codigoOperacionFk { get; set; }
        public string codigoTipoPersonaFk { get; set; }
        public string codigoRegimenFk { get; set; }
        public string codigoPostal { get; set; }
        public bool estadoInactivo { get; set; }
        public bool guiaPagoContado { get; set; }
        public bool guiaPagoCortesia { get; set; }
        public bool guiaPagoCredito { get; set; }
        public bool guiaPagoDestino { get; set; }
        public bool guiaPagoRecogida { get; set; }
        public string error { get; set; }
    }

    class ApiClienteRespuesta
    {
        public string codigoTerceroPk { get; set; }
        public string error { get; set; }
    }
}
