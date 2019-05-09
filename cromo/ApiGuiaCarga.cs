using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiGuiaCarga
    {
        
        public string codigoGuiaCargaPk { get; set; }
        public string numero { get; set; }
        public string documentoCliente { get; set; }       
        public string remitente { get; set; }
        public string relacionCliente { get; set; }
        public string nombreDestinatario { get; set; }
        public string direccionDestinatario { get; set; }
        public string telefonoDestinatario { get; set; }        
        public double vrDeclarado { get; set; }
        public string comentario { get; set; }
        public string error { get; set; }
    }
}
