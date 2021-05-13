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
using System.Xml;
using System.Xml.Serialization;

namespace cromo
{
    public partial class FrmEnviarRndc : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmEnviarRndc()
        {
            InitializeComponent();
        }

        private void FrmEnviarRndc_Load(object sender, EventArgs e)
        {
            DgDespachos.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcpendiente", null);
            List<ApiDespacho> apiDespachoLista = ser.Deserialize<List<ApiDespacho>>(jsonRespuesta);
            DgDespachos.DataSource = apiDespachoLista;

        }

        private void DgDespachos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            string codigo = DgDespachos.Rows[DgDespachos.CurrentRow.Index].Cells[0].Value.ToString();     
            //Buscamos los terceros de ese despacho para transmitirlos
            string parametrosJson = "{\"codigoDespacho\":\"" + codigo + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndc", parametrosJson);
            ApiElementosRndc apiElementosRndc = ser.Deserialize<ApiElementosRndc>(jsonRespuesta);
            List<ApiTerceroRndc> apiTerceroLista = ser.Deserialize<List<ApiTerceroRndc>>(jsonRespuesta);
            foreach (ApiTerceroRndc apiTercero in apiElementosRndc.terceros)
            {
                //MessageBox.Show(this, apiTercero.identificacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string entrada = "";
                if (apiTercero.conductor == "0")
                {
                        entrada = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                            <root>
                                <acceso>
                                    <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                    <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                                </acceso>
                                <solicitud>
                                    <tipo>1</tipo>
                                    <procesoid>11</procesoid>
                                </solicitud>
                                <variables>
                                    <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                    <CODTIPOIDTERCERO>" + apiTercero.identificacionTipo + @"</CODTIPOIDTERCERO>
                                    <NUMIDTERCERO>" + apiTercero.identificacion + @"</NUMIDTERCERO>
                                    <NOMIDTERCERO>" + apiTercero.nombre1 + @"</NOMIDTERCERO>
                                    <CODSEDETERCERO>" + apiTercero.codigoSede + @"</CODSEDETERCERO>
                                    <NOMSEDETERCERO>" + apiTercero.nombreSede + @"</NOMSEDETERCERO>
                                    <NUMTELEFONOCONTACTO>" + apiTercero.telefono + @"</NUMTELEFONOCONTACTO>
                                    <NOMENCLATURADIRECCION>" + apiTercero.direccion + @"</NOMENCLATURADIRECCION>
                                    <CODMUNICIPIORNDC>" + apiTercero.codigoCiudad + @"</CODMUNICIPIORNDC>
                                 </variables>
                              </root>";
                }

                if (apiTercero.conductor == "1")
                {
                    entrada = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                            <root>
                                <acceso>
                                    <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                    <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                                </acceso>
                                <solicitud>
                                    <tipo>1</tipo>
                                    <procesoid>11</procesoid>
                                </solicitud>
                                <variables>
                                    <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                    <CODTIPOIDTERCERO>" + apiTercero.identificacionTipo + @"</CODTIPOIDTERCERO>
                                    <NUMIDTERCERO>" + apiTercero.identificacion + @"</NUMIDTERCERO>
                                    <NOMIDTERCERO>" + apiTercero.nombre1 + @"</NOMIDTERCERO>
                                    <CODSEDETERCERO>" + apiTercero.codigoSede + @"</CODSEDETERCERO>
                                    <NOMSEDETERCERO>" + apiTercero.nombreSede + @"</NOMSEDETERCERO>
                                    <NUMTELEFONOCONTACTO>" + apiTercero.telefono + @"</NUMTELEFONOCONTACTO>
                                    <NOMENCLATURADIRECCION>" + apiTercero.direccion + @"</NOMENCLATURADIRECCION>
                                    <CODMUNICIPIORNDC>" + apiTercero.codigoCiudad + @"</CODMUNICIPIORNDC>
                                 </variables>
                              </root>";
                }


                RespuestaRndc retorno = new RespuestaRndc();
                BPMServicesClient client = new BPMServicesClient();
                AtenderMensajeRNDCRequest solicitud = new AtenderMensajeRNDCRequest(entrada);
                
                var respuesta = client.AtenderMensajeRNDC(solicitud);
                var textXml = respuesta.@return;
                XmlSerializer serializer = new XmlSerializer(typeof(RespuestaRndc));
                using (TextReader reader = new StringReader(textXml))
                {
                    //de esta manera se deserializa
                    retorno = (RespuestaRndc)serializer.Deserialize(reader);
                }
                
                //Respuesta.Text = retorno.ingresoid;
                //Salida.Text = textXml;


            }
            
            //DgClientes.DataSource = apiTerceroLista;

            //MessageBox.Show(this, codigo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //DialogResult = DialogResult.OK;
        }
    }
}
