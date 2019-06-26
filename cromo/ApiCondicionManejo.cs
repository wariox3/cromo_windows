using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiCondicionManejo
    {
        public string codigoCondicionManejoPk { get; set; }
        public string ciudadOrigenNombre { get; set; }
        public string ciudadDestinoNombre { get; set; }
        public string zonaNombre { get; set; }
        public double porcentaje { get; set; }
        public double minimoUnidad { get; set; }
        public double minimoDespacho { get; set; }
        public string error { get; set; }

    }
}
