using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
    class ApiGuiaImprimir
    {
        public string codigoGuiaPk { get; set; }
        public string empresaNit { get; set; }
        public string empresaNombre { get; set; }
        public string empresaDireccion { get; set; }
        public string empresaTelefono { get; set; }
        public int numero { get; set; }
        public string codigoBarras { get; set; }
        public string tituloFactura { get; set; }
        public string numeroFactura { get; set; }
        public string codigoFacturaTipoFk { get; set; }
        public string guiaTipoNombre { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string codigoOrigen { get; set; }
        public string ciudadOrigenNombre { get; set; }
        public string codigoDestino { get; set; }
        public string ciudadDestinoNombre { get; set; }
        public string codigoZona { get; set; }
        public string codigoEmpaque { get; set; }
        public string remitente { get; set; }
        public string nombreDestinatario { get; set; }
        public string telefonoDestinatario { get; set; }
        public string direccionDestinatario { get; set; }
        public string clienteIdentificacion { get; set; }
        public string clienteNumeroIdentificacion { get; set; }
        public string clienteNombre { get; set; }
        public string clienteDireccion { get; set; }
        public string clienteTelefono { get; set; }
        public string clienteFormaPago { get; set; }
        public string documentoCliente { get; set; }
        public double vrDeclara { get; set; }
        public double vrFlete { get; set; }
        public double vrManejo { get; set; }
        public double vrTotal { get; set; }
        public double vrFleteFactura { get; set; }
        public double vrManejoFactura { get; set; }
        public double vrTotalFactura { get; set; }
        public double vrCobroEntrega { get; set; }
        public double pesoReal { get; set; }
        public double pesoVolumen { get; set; }
        public double pesoFacturado { get; set; }
        public double unidades { get; set; }
        public string comentario { get; set; }
        public string resolucionFactura { get; set; }        
        public string error { get; set; }
    }
}
