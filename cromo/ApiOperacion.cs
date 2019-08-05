using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiOperacion
    {
        public string codigoOperacionPk { get; set; }
        public string codigoOperacionCargoFk { get; set; }
        public string codigoCiudadFk { get; set; }
        public string error { get; set; }
    }
}
