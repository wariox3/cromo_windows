using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiUsuario
    {
        public string error { get; set; }
        public string nombreCorto { get; set; }
        public int versionBaseDatos { get; set; }
        public bool numeroUnicoGuia { get; set; }
        public int codigoPrecioGeneral { get; set; }
        public int codigoCondicionGeneral { get; set; }
        public string codigoFormatoGuia { get; set; }
        public double porcentajeManejoMinimo { get; set; }
        public double descuentoPesoMaximo { get; set; }
    }

    class ApiUsuarioConfigurcion
    {
        public bool error { get; set; }
        public string errorMensaje { get; set; }
        public double porcentajeManejoMinimo { get; set; }
        public double descuentoPesoMaximo { get; set; }
        public double manejoMinimoUnidad { get; set; }
        public double manejoMinimoDespacho { get; set; }
    }
}
