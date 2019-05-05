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
        public string codigoGuiaPk { get; set; }
        public int numero { get; set; }        
        public string codigoOperacionIngresoFk { get; set; }
        public string codigoOperacionCargoFk { get; set; }
        public string codigoClienteFk { get; set; }
        public string codigoCondicionFk { get; set; }
        public string codigoCiudadOrigenFk { get; set; }
        public string codigoCiudadDestinoFk { get; set; }
        public string codigoRutaFk { get; set; }
        public string codigoGuiaTipoFk { get; set; }
        public string codigoServicioFk { get; set; }
        public string codigoProductoFk { get; set; }
        public string codigoEmpaqueFk { get; set; }
        public string documentoCliente { get; set; }
        public string relacionCliente { get; set; }
        public string remitente { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime? fechaDespacho { get; set; }
        public DateTime? fechaEntrega { get; set; }
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
        public string vrAbono { get; set; }
        public string usuario { get; set; }
        public string empaqueReferencia { get; set; }
        public string tipoLiquidacion { get; set; }
        public string comentario { get; set; }
        public bool factura { get; set; }
        public bool reexpedicion { get; set; }
        public bool cortesia  { get; set; }
        public bool mercanciaPeligrosa { get; set; }
        public string ordenRuta { get; set; }
        public string numeroFactura { get; set; }
        public string codigoDespachoFk { get; set; }
        public bool estadoImpreso { get; set; }
        public bool estadoEmbarcado { get; set; }
        public bool estadoDespachado { get; set; }
        public bool estadoEntregado { get; set; }
        public bool estadoSoporte { get; set; }
        public bool estadoCumplido { get; set; }
        public bool estadoFacturado { get; set; }
        public bool estadoFacturaGenerada { get; set; }
        public bool estadoAnulado { get; set; }
        public string clienteNombreCorto { get; set; }
        public string ciudadOrigenNombre { get; set; }
        public string ciudadDestinoNombre { get; set; }
        public string condicionNombre { get; set; }
        public string codigoZonaFk { get; set; }
        public string codigoDestinatarioFk { get; set; }
        public string error { get; set; }
    }

    class ApiGuiaRespuesta
    {
        public string codigoGuiaPk { get; set; }
        public string numero { get; set; }
        public string numeroFactura { get; set; }
        public string error { get; set; }
    }
}
