using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiRecibo
    {
        public string codigoReciboPk { get; set; }
        public string codigoOperacionFk { get; set; }
        public string codigoClienteFk { get; set; }
        public string codigoGuiaFk { get; set; }
        public double vrFlete { get; set; }
        public double vrManejo { get; set; }
        public double vrTotal { get; set; }
        public string error { get; set; }
    }
}
