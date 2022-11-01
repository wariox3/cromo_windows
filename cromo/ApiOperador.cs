using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiOperador
    {
        public bool error { get; set; }
        public string errorMensaje { get; set; }
        public string codigoOperadorPk { get; set; }
        public string nombre { get; set; }
        public string puntoServicio { get; set; }
        public string puntoServicioToken { get; set; }
        public string puntoServicioUsuario { get; set; }
        public string puntoServicioClave { get; set; }
    }
}
