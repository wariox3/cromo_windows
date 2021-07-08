using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiDespacho
    {
        public int codigoDespachoPk { get; set; }
        public string despachoTipo { get; set; }
        public string codigoOperacionFk { get; set; }
        public string codigoVehiculoFk { get; set; }
        public string codigoVehiculoRemolqueFk { get; set; }
        public int numero { get; set; }
        public DateTime? fechaSalida { get; set; }
        public DateTime? fechaEntrega { get; set; }
        public string ciudadOrigen { get; set; }
        public string ciudadDestino { get; set; }
        public string conductorNombre { get; set; }
        public string error { get; set; }
    }
}
