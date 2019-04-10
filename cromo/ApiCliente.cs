using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiCliente
    {        
        public string codigoClientePk { get; set; }
        public string nombreCorto { get; set; }
        public string codigoCondicionFk { get; set; }
        public bool estadoInactivo { get; set; }
        public bool guiaPagoContado { get; set; }
        public bool guiaPagoCortesia { get; set; }
        public bool guiaPagoCredito { get; set; }
        public bool guiaPagoDestino { get; set; }
        public bool guiaPagoRecogida { get; set; }
        public string error { get; set; }
    }
}
