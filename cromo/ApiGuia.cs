using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    public class ApiGuia
    {
        public bool numeroUnicoGuia { get; set; }
        public int numero { get; set; }
        public string codigoOperacionIngreso { get; set; }
        public string codigoCliente { get; set; }
        public string codigoCondicion { get; set; }
        public string codigoCiudadOrigen { get; set; }
        public string codigoCiudadDestino { get; set; }
        public string codigoRuta { get; set; }
        public string codigoGuiaTipo { get; set; }
        public string codigoServicio { get; set; }
        public string codigoProducto { get; set; }
        public string codigoEmpaque { get; set; }
        public string documentoCliente { get; set; }
        public string relacionCliente { get; set; }
        public string remitente { get; set; }
        public string nombreDestinatario { get; set; }
        public string direccionDestinatario { get; set; }
        public string telefonoDestinatario { get; set; }
        public string pesoReal { get; set; }
        public string pesoVolumen { get; set; }
        public string pesoFacturado { get; set; }
        public string unidades { get; set; }
        public string vrRecaudo { get; set; }
        public string vrDeclara { get; set; }
        public string vrFlete { get; set; }
        public string vrManejo { get; set; }
        public string vrCostoReexpedicion { get; set; }
        public string vrCobroEntrega { get; set; }
        public string usuario { get; set; }
        public string empaqueReferencia { get; set; }
        public string tipoLiquidacion { get; set; }
        public string comentario { get; set; }
        public bool factura { get; set; }
        public bool reexpedicion { get; set; }
        public bool cortesia  { get; set; }
        public bool mercanciaPeligrosa { get; set; }
        public string ordenRuta { get; set; }
    }
}
