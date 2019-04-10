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
        public string nombreCorto { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string codigoCiudadFk { get; set; }
        public string error { get; set; }
    }
}
