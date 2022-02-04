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
    public partial class FrmCumplirRndc : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmCumplirRndc()
        {
            InitializeComponent();
        }

        private void FrmCumplirRndc_Load(object sender, EventArgs e)
        {
            DgDespachos.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcpendientecumplir", null);
            List<ApiDespacho> apiDespachoLista = ser.Deserialize<List<ApiDespacho>>(jsonRespuesta);
            DgDespachos.DataSource = apiDespachoLista;

        }

        private void BtnCumplir_Click(object sender, EventArgs e)
        {
            string codigo = DgDespachos.Rows[DgDespachos.CurrentRow.Index].Cells[0].Value.ToString();     
            bool validacion = true;
            RespuestaRndc retorno = new RespuestaRndc();
            BPMServicesClient client = new BPMServicesClient();
            //Buscamos los terceros de ese despacho para transmitirlos
            string parametrosJson = "{\"codigoDespacho\":\"" + codigo + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndccumplir", parametrosJson);
            ApiElementosRndc apiElementosRndc = ser.Deserialize<ApiElementosRndc>(jsonRespuesta);           
            string xmlGuia = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                <root>
                    <acceso>
                            <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                            <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                    </acceso>
                    <solicitud>
                        <tipo>1</tipo>
                        <procesoid>5</procesoid>
                    </solicitud>
                    <variables>
                        <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                        <CONSECUTIVOREMESA>" + apiElementosRndc.despacho.numero + @"</CONSECUTIVOREMESA>
                        <NUMMANIFIESTOCARGA>" + apiElementosRndc.despacho.numero + @"</NUMMANIFIESTOCARGA>
                        <TIPOCUMPLIDOREMESA>C</TIPOCUMPLIDOREMESA>
                        <FECHALLEGADACARGUE>" + apiElementosRndc.despacho.fechaLlegadaCargue + @"</FECHALLEGADACARGUE>
                        <HORALLEGADACARGUEREMESA>" + apiElementosRndc.despacho.horaLlegadaCargue + @"</HORALLEGADACARGUEREMESA>
                        <FECHAENTRADACARGUE>" + apiElementosRndc.despacho.fechaEntradaCargue + @"</FECHAENTRADACARGUE>
                        <HORAENTRADACARGUEREMESA>" + apiElementosRndc.despacho.horaEntradaCargue + @"</HORAENTRADACARGUEREMESA>
                        <FECHASALIDACARGUE>" + apiElementosRndc.despacho.fechaSalidaCargue + @"</FECHASALIDACARGUE>
                        <HORASALIDACARGUEREMESA>" + apiElementosRndc.despacho.horaSalidaCargue + @"</HORASALIDACARGUEREMESA>
                                                                       
                        <FECHALLEGADADESCARGUE>" + apiElementosRndc.despacho.fechaLlegadaDescargue + @"</FECHALLEGADADESCARGUE>
                        <HORALLEGADADESCARGUECUMPLIDO>" + apiElementosRndc.despacho.horaLlegadaDescargue + @"</HORALLEGADADESCARGUECUMPLIDO>
                        <FECHAENTRADADESCARGUE>" + apiElementosRndc.despacho.fechaEntradaDescargue + @"</FECHAENTRADADESCARGUE>
                        <HORAENTRADADESCARGUECUMPLIDO>" + apiElementosRndc.despacho.horaEntradaDescargue + @"</HORAENTRADADESCARGUECUMPLIDO>
                        <FECHASALIDADESCARGUE>" + apiElementosRndc.despacho.fechaSalidaDescargue + @"</FECHASALIDADESCARGUE>
                        <HORASALIDADESCARGUECUMPLIDO>" + apiElementosRndc.despacho.horaSalidaDescargue + @"</HORASALIDADESCARGUECUMPLIDO>                                    
                        <CANTIDADENTREGADA>" + apiElementosRndc.despacho.pesoReal + @"</CANTIDADENTREGADA></variables>
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
                        MessageBox.Show(this, "Guia " + apiElementosRndc.despacho.codigoDespachoPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        validacion = false;
                    }
                }
            }

            if(validacion == true) {
                string xmlManifiesto = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                    <root>
                        <acceso>
                            <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                            <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                        </acceso >
                        <solicitud>
                            <tipo>1</tipo>
                            <procesoid>6</procesoid>
                        </solicitud>
                        <variables>
                            <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                            <NUMMANIFIESTOCARGA>" + apiElementosRndc.despacho.numero + @"</NUMMANIFIESTOCARGA>                    
                            <TIPOCUMPLIDOMANIFIESTO>C</TIPOCUMPLIDOMANIFIESTO>   
                            <FECHAENTREGADOCUMENTOS>" + apiElementosRndc.despacho.fechaEntrega + @"</FECHAENTREGADOCUMENTOS>
                            <VALORADICIONALHORASCARGUE>0</VALORADICIONALHORASCARGUE> 
                            <VALORSOBREANTICIPO>0</VALORSOBREANTICIPO>
                        </variables>
                    </root>";                
                AtenderMensajeRNDCRequest solicitudManifiesto = new AtenderMensajeRNDCRequest(xmlManifiesto);
                var respuestaManifiesto = client.AtenderMensajeRNDC(solicitudManifiesto);
                var textXmlManifiesto = respuestaManifiesto.@return;
                XmlSerializer serializerManifiesto = new XmlSerializer(typeof(RespuestaRndc));
                using (TextReader reader = new StringReader(textXmlManifiesto))
                {
                    //de esta manera se deserializa
                    retorno = (RespuestaRndc)serializerManifiesto.Deserialize(reader);
                    if (retorno.ErrorMSG != null)
                    {
                        string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                        if (mensajeError != "DUPLICADO")
                        {
                            MessageBox.Show(this, "Manifiesto cumplido " + apiElementosRndc.despacho.codigoDespachoPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else
                        {
                            MessageBox.Show(this, "Manifinifiesto ya fue cumplido con anterioridad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcasignarcumplido", "{\"codigoDespacho\":\"" + apiElementosRndc.despacho.codigoDespachoPk + "\"}");
                            LlenarDatosApi();
                        }
                    } else
                    {
                        ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcasignarcumplido", "{\"codigoDespacho\":\"" + apiElementosRndc.despacho.codigoDespachoPk + "\"}");
                        LlenarDatosApi();
                    }
                }
            }
            
        }

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            string codigo = DgDespachos.Rows[DgDespachos.CurrentRow.Index].Cells[0].Value.ToString();
            RespuestaRndc retorno = new RespuestaRndc();
            BPMServicesClient client = new BPMServicesClient();
            ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcdescartarcumplido", "{\"codigoDespacho\":\"" + codigo + "\"}");
            LlenarDatosApi();
        }
    }
}
