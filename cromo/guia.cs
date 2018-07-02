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
		public int numero { get; set; }
		public string codigoOperacionIngresoFk { get; set; }
        public string codigoOperacionCargoFk { get; set; }
        public int codigoClienteFk { get; set; }        
        public string codigoCiudadOrigenFk { get; set; }
        public string codigoCiudadDestinoFk { get; set; }
        public string documentoCliente { get; set; }
        public string remitente { get; set; }
		public string codigoServicioFk { get; set; }
		public string codigoGuiaTipoFk { get; set; }
		public string codigoProductoFk { get; set; }
		public string codigoEmpaqueFk { get; set; }
		public string nombreDestinatario { get; set; }
		public string direccionDestinatario { get; set; }
		public string telefonoDestinatario { get; set; }
		public int unidades { get; set; }
		public int pesoReal { get; set; }
		public int pesoVolumen { get; set; }
		public int pesoFacturar { get; set; }
		public double vrFlete { get; set; }
		public double vrManejo { get; set; }
		public double vrDeclara { get; set; }
		public double vrRecaudo { get; set; }
		public string codigoRutaFk { get; set; }
		public int ordenRuta { get; set; }
		public bool reexpedicion { get; set; }
		public int codigoCondicionFk { get; set; }
		public bool factura { get; set; }
		public string comentario { get; set; }
		public string usuario { get; set; }
		public guia() { }

        public guia(int pcodigoGuiaPk, string pcodigoOperacionIngresoFk, string pcodigoOperacionCargoFk,
            int pcodigoClienteFk, string pcodigoCiudadOrigenFk, string pcodigoCiudadDestinoFk, string pdocumentoCliente,
            string premitente, string pcodigoServicioFk, string pcodigoGuiaTipoFk, string pcodigoProductoFk, string pcodigoEmpaqueFk, string pnombreDestinatario,
			string pdireccionDestinatario, string ptelefonoDestinatario, string pfechaIngreso, int punidades, int ppesoReal, 
			int ppesovolumen, int ppesoFacturar, double pvrFlete, double pvrManejo, double pvrDeclara, double pvrRecaudo,
			string pcodigoRutaFk, int pordenRuta, bool preexpedicion, int pcodigoCondicionFk, bool pfactura, int pnumero,
			string pcomentario, string pusuario)
        {
            this.codigoGuiaPk = pcodigoGuiaPk;
			this.numero = pnumero;
            this.codigoOperacionIngresoFk = pcodigoOperacionIngresoFk;
            this.codigoOperacionCargoFk = pcodigoOperacionCargoFk;
            this.codigoClienteFk = pcodigoClienteFk;
            this.codigoCiudadOrigenFk = pcodigoCiudadOrigenFk;
            this.codigoCiudadDestinoFk = pcodigoCiudadDestinoFk;
            this.documentoCliente = pdocumentoCliente;
            this.remitente = premitente;
			this.codigoServicioFk = pcodigoServicioFk;
			this.codigoGuiaTipoFk = pcodigoGuiaTipoFk;
			this.codigoProductoFk = pcodigoProductoFk;
			this.codigoEmpaqueFk = pcodigoEmpaqueFk;
			this.nombreDestinatario = pnombreDestinatario;
			this.direccionDestinatario = pdireccionDestinatario;
			this.telefonoDestinatario = ptelefonoDestinatario;
			this.unidades = punidades;
			this.pesoReal = ppesoReal;
			this.pesoVolumen = ppesovolumen;
			this.pesoFacturar = ppesoFacturar;
			this.vrFlete = pvrFlete;
			this.vrManejo = pvrManejo;
			this.vrDeclara = pvrDeclara;
			this.vrRecaudo = pvrRecaudo;
			this.codigoRutaFk = pcodigoRutaFk;
			this.ordenRuta = pordenRuta;
			this.reexpedicion = preexpedicion;
			this.codigoCondicionFk = pcodigoCondicionFk;
			this.factura = pfactura;
			this.usuario = pusuario;
			this.comentario = pcomentario;
		}

	}
}
