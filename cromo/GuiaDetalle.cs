using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    public class GuiaDetalle
    {        
        public string codigoProductoFk { get; set; }
        public string producto { get; set; }
        public int pesoReal { get; set; }
        public int pesoVolumen { get; set; }
        public int pesoFacturado { get; set; }
        public int unidades { get; set; }       
        public Double vrFlete { get; set; }       
        public string error { get; set; }
    }
}
