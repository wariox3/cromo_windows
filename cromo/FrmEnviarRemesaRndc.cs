using cromo.WsRndc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace cromo
{
    public partial class FrmEnviarRemesaRndc : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmEnviarRemesaRndc()
        {
            InitializeComponent();
        }

        private void FrmEnviarRemesaRndc_Load(object sender, EventArgs e)
        {
            DgGuias.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/rndcpendiente", null);
            List<ApiGuiaRndc> apiGuiaLista = ser.Deserialize<List<ApiGuiaRndc>>(jsonRespuesta);
            DgGuias.DataSource = apiGuiaLista;

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            bool validacion = true;
            string codigo = DgGuias.Rows[DgGuias.CurrentRow.Index].Cells[0].Value.ToString();        
            RespuestaRndc retorno = new RespuestaRndc();
            BPMServicesClient client = new BPMServicesClient();        
            //Buscamos los terceros de ese despacho para transmitirlos
            string parametrosJson = "{\"codigoGuia\":\"" + codigo + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/rndc", parametrosJson);
            ApiGuiaRndc apiGuiaRndc = ser.Deserialize<ApiGuiaRndc>(jsonRespuesta);
            List<ApiTerceroRndc> apiTerceroLista = ser.Deserialize<List<ApiTerceroRndc>>(jsonRespuesta);
            foreach (ApiTerceroRndc apiTercero in apiGuiaRndc.terceros)
            {
                string xmlTercero = "";
                xmlTercero = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                        <root>
                            <acceso>
                                <username>" + apiGuiaRndc.usuarioRndc + @"</username>
                                <password>" + apiGuiaRndc.claveRndc + @"</password>
                            </acceso>
                            <solicitud>
                                <tipo>1</tipo>
                                <procesoid>11</procesoid>
                            </solicitud>
                            <variables>
                                <NUMNITEMPRESATRANSPORTE>" + apiGuiaRndc.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                <CODTIPOIDTERCERO>" + apiTercero.identificacionTipo + @"</CODTIPOIDTERCERO>
                                <NUMIDTERCERO>" + apiTercero.identificacion + @"</NUMIDTERCERO>
                                <NOMIDTERCERO>" + apiTercero.nombre1 + @"</NOMIDTERCERO>
                                <PRIMERAPELLIDOIDTERCERO>" + apiTercero.apellido1 + @"</PRIMERAPELLIDOIDTERCERO>    
                                <SEGUNDOAPELLIDOIDTERCERO> " + apiTercero.apellido2 + @"</SEGUNDOAPELLIDOIDTERCERO>
                                <CODSEDETERCERO>" + apiTercero.codigoSede + @"</CODSEDETERCERO>
                                <NOMSEDETERCERO>" + apiTercero.nombreSede + @"</NOMSEDETERCERO>
                                <NUMTELEFONOCONTACTO>" + apiTercero.telefono + @"</NUMTELEFONOCONTACTO>
                                <NOMENCLATURADIRECCION>" + apiTercero.direccion + @"</NOMENCLATURADIRECCION>
                                <CODMUNICIPIORNDC>" + apiTercero.codigoCiudad + @"</CODMUNICIPIORNDC>
                                </variables>
                            </root>";                            
                AtenderMensajeRNDCRequest solicitudTercero = new AtenderMensajeRNDCRequest(xmlTercero);
                var respuestaTercero = client.AtenderMensajeRNDC(solicitudTercero);
                var textXmlTercero = respuestaTercero.@return;
                XmlSerializer serializerTercero = new XmlSerializer(typeof(RespuestaRndc));
                using (TextReader reader = new StringReader(textXmlTercero))
                {
                    //de esta manera se deserializa
                    retorno = (RespuestaRndc)serializerTercero.Deserialize(reader);
                    if (retorno.ErrorMSG != null)
                    {
                        string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                        if (mensajeError != "DUPLICADO" && mensajeError != "Access vi")
                        {
                            MessageBox.Show(this, "Tercero " + apiTercero.identificacion + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            validacion = false;
                        }
                    }
                }
            }

            if (validacion == true)
            {
                //Transmitir guia
                string xmlGuia = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                <root>
                    <acceso>
                        <username>" + apiGuiaRndc.usuarioRndc + @"</username>
                        <password>" + apiGuiaRndc.claveRndc + @"</password>
                    </acceso>
                    <solicitud>
                        <tipo>1</tipo>
                        <procesoid>3</procesoid>
                    </solicitud>
                    <variables>
                        <NUMNITEMPRESATRANSPORTE>" + apiGuiaRndc.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                        <CONSECUTIVOREMESA>" + apiGuiaRndc.codigoGuiaPk + @"</CONSECUTIVOREMESA>
                        <CODOPERACIONTRANSPORTE>G</CODOPERACIONTRANSPORTE>
                        <CODTIPOEMPAQUE>17</CODTIPOEMPAQUE>
                        <CODNATURALEZACARGA>1</CODNATURALEZACARGA>                                                  
                        <DESCRIPCIONCORTAPRODUCTO>" + apiGuiaRndc.productoNombre + @"</DESCRIPCIONCORTAPRODUCTO>
                        <MERCANCIAREMESA>" + apiGuiaRndc.productoCodigoTransporte + @"</MERCANCIAREMESA>
                        <CANTIDADCARGADA>" + apiGuiaRndc.pesoReal + @"</CANTIDADCARGADA>
                        <UNIDADMEDIDACAPACIDAD>1</UNIDADMEDIDACAPACIDAD>
                        <CODTIPOIDREMITENTE>" + apiGuiaRndc.terceroTipoIdentificacion + @"</CODTIPOIDREMITENTE>
                        <NUMIDREMITENTE>" + apiGuiaRndc.terceroNumeroIdentificacion + @"</NUMIDREMITENTE>
                        <CODSEDEREMITENTE>" + apiGuiaRndc.codigoCiudadOrigenFk + @"</CODSEDEREMITENTE>
                        <CODTIPOIDDESTINATARIO>C</CODTIPOIDDESTINATARIO>
                        <NUMIDDESTINATARIO>333333333</NUMIDDESTINATARIO>
                        <CODSEDEDESTINATARIO>" + apiGuiaRndc.codigoCiudadDestinoFk + @"</CODSEDEDESTINATARIO>
                        <CODTIPOIDPROPIETARIO>" + apiGuiaRndc.terceroTipoIdentificacion + @"</CODTIPOIDPROPIETARIO>
                        <NUMIDPROPIETARIO>" + apiGuiaRndc.terceroNumeroIdentificacion + @"</NUMIDPROPIETARIO>
                        <CODSEDEPROPIETARIO>1</CODSEDEPROPIETARIO>
                        <DUENOPOLIZA>E</DUENOPOLIZA>
                        <NUMPOLIZATRANSPORTE>" + apiGuiaRndc.numeroPoliza + @"</NUMPOLIZATRANSPORTE>
                        <FECHAVENCIMIENTOPOLIZACARGA>" + apiGuiaRndc.fechaVencePoliza + @"</FECHAVENCIMIENTOPOLIZACARGA>
                        <COMPANIASEGURO>" + apiGuiaRndc.numeroIdentificacionAseguradora + @"</COMPANIASEGURO>
                        <HORASPACTOCARGA>1</HORASPACTOCARGA>
                        <MINUTOSPACTOCARGA>1</MINUTOSPACTOCARGA>
                        <FECHACITAPACTADACARGUE>" + apiGuiaRndc.fechaIngreso + @"</FECHACITAPACTADACARGUE>
                        <HORACITAPACTADACARGUE>08:00</HORACITAPACTADACARGUE>
                        <HORASPACTODESCARGUE>1</HORASPACTODESCARGUE>
                        <MINUTOSPACTODESCARGUE>1</MINUTOSPACTODESCARGUE>
                        <FECHACITAPACTADADESCARGUE>" + apiGuiaRndc.fechaIngreso + @"</FECHACITAPACTADADESCARGUE>
                        <HORACITAPACTADADESCARGUEREMESA>10:00</HORACITAPACTADADESCARGUEREMESA>
                    </variables>
                </root>";

                AtenderMensajeRNDCRequest solicitudGuia = new AtenderMensajeRNDCRequest(xmlGuia);
                var respuestaGuia = client.AtenderMensajeRNDC(solicitudGuia);
                var textXmlGuia = respuestaGuia.@return;
                XmlSerializer serializerGuia = new XmlSerializer(typeof(RespuestaRndc));
                using (TextReader reader = new StringReader(textXmlGuia))
                {
                    //de esta manera se deserializa
                    retorno = (RespuestaRndc)serializerGuia.Deserialize(reader);
                    if (retorno.ErrorMSG != null)
                    {
                        string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                        if (mensajeError != "DUPLICADO")
                        {
                            MessageBox.Show(this, "Guia " + apiGuiaRndc.codigoGuiaPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ApiControlador.ApiPost("/transporte/api/windows/guia/rndcasignar", "{\"codigoGuia\":\"" + apiGuiaRndc.codigoGuiaPk + "\",\"id\":\"" + apiGuiaRndc.codigoGuiaPk + "\"}");
                            MessageBox.Show(this, "Se transmitio correctamente la guia", "Envio correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LlenarDatosApi();
                        }
                    } else {
                        ApiControlador.ApiPost("/transporte/api/windows/guia/rndcasignar", "{\"codigoGuia\":\"" + apiGuiaRndc.codigoGuiaPk + "\",\"id\":\"" + retorno.ingresoid + "\"}");
                        MessageBox.Show(this, "Se transmitio correctamente la guia", "Envio correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDatosApi();                        
                    }
                }
                LlenarDatosApi();
            }             
        }

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            string codigo = DgGuias.Rows[DgGuias.CurrentRow.Index].Cells[0].Value.ToString();
            RespuestaRndc retorno = new RespuestaRndc();
            BPMServicesClient client = new BPMServicesClient();
            ApiControlador.ApiPost("/transporte/api/windows/guia/rndcdescartar", "{\"codigoGuia\":\"" + codigo + "\"}");
            LlenarDatosApi();
        }
    }
}
