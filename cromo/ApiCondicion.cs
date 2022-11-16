using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiCondicion
    {
        public string codigoClienteCondicionPk { get; set; }
        public string codigoCondicionFk { get; set; }
        public string nombre { get; set; }
        public double porcentajeManejo { get; set; }
        public double manejoMinimoUnidad { get; set; }
        public double manejoMinimoDespacho { get; set; }
        public int pesoMinimo { get; set; }
        public double descuentoPeso { get; set; }
        public int codigoPrecioFk { get; set; }
        public bool precioGeneral { get; set; }
        public bool precioPeso { get; set; }
        public bool precioUnidad { get; set; }
        public bool precioAdicional { get; set; }
        public bool limitarDescuentoReexpedicion { get; set; }
        public string error { get; set; }
    }
}
