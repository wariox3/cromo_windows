using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiCiudad
    {
        public string codigoCiudadPk { get; set; }
        public string nombre { get; set; }
        public string departamentoNombre { get; set; }
        public string codigoRutaFk { get; set; }
        public int ordenRuta { get; set; }
        public bool reexpedicion { get; set; }
        public string error { get; set; }
    }
}
