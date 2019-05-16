using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiCondicionFlete
    {
        public string codigoCondicionFletePk { get; set; }
        public string ciudadOrigenNombre { get; set; }
        public string ciudadDestinoNombre { get; set; }
        public string zonaNombre { get; set; }
        public double descuentoPeso { get; set; }
        public double descuentoUnidad { get; set; }
        public int pesoMinimo { get; set; }
        public int pesoMinimoGuia { get; set; }
        public double fleteMinimo { get; set; }
        public double fleteMinimoGuia { get; set; }
        public string error { get; set; }
    }
}
