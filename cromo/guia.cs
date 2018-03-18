using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class guia
    {
        public int codigoGuiaPk { get; set; }
        public string codigoOperacionIngresoFk { get; set; }
        public string codigoOperacionCargoFk { get; set; }
        public int codigoClienteFk { get; set; }        
        public string codigoCiudadOrigenFk { get; set; }
        public string codigoCiudadDestinoFk { get; set; }

        public guia() { }

        public guia(int pcodigoGuiaPk, string pcodigoOperacionIngresoFk, string pcodigoOperacionCargoFk,
            int pcodigoClienteFk, string pcodigoCiudadOrigenFk, string pcodigoCiudadDestinoFk)
        {
            this.codigoGuiaPk = pcodigoGuiaPk;
            this.codigoOperacionIngresoFk = pcodigoOperacionIngresoFk;
            this.codigoOperacionCargoFk = pcodigoOperacionCargoFk;
            this.codigoClienteFk = pcodigoClienteFk;
            this.codigoCiudadOrigenFk = pcodigoCiudadOrigenFk;
            this.codigoCiudadDestinoFk = pcodigoCiudadDestinoFk;
        }
    }
}
