using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiPrecioDetalle
    {
        public string codigoPrecioDetallePk { get; set; }
        public double minimo { get; set; }
        public double vrPeso { get; set; }
        public double vrUnidad { get; set; }
        public double vrPesoTope { get; set; }
        public double vrPesoTopeAdicional { get; set; }
        public double pesoTope { get; set; }
        public string productoNombre { get; set; }
        public string error { get; set; }
    }
}
