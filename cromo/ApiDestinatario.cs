using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiDestinatario
    {
        public string codigoDestinatarioPk { get; set; }
        public string codigoIdentificacionFk { get; set; }
        public string numeroIdentificacion { get; set; }
        public string nombreCorto { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string codigoCiudadFk { get; set; }
        public string ciudadNombre { get; set; }          
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string correo { get; set; }
        public string codigoTerceroFk { get; set; }
        public string error { get; set; }
    }

    class ApiDestinatarioRespuesta
    {
        public string codigoDestinatarioPk { get; set; }
        public string error { get; set; }
    }
}
