using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiGuiaTipo
    {
        public string error { get; set; }
        public string codigoGuiaTipoPk { get; set; }
        public string nombre { get; set; }
        public bool exigeNumero { get; set; }
        public bool validarFlete { get; set; }
        public bool factura { get; set; }
        public bool cortesia { get; set; }
        public bool generaCobro { get; set; }
        public string codigoFormaPago { get; set; }
        public string codigoPagoFk { get; set; }
    }

}
