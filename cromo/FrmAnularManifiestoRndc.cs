using cromo.WsRndc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace cromo
{
    public partial class FrmAnularManifiestoRndc : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmAnularManifiestoRndc()
        {
            InitializeComponent();
        }

        private void FrmAnularManifiestoRndc_Load(object sender, EventArgs e)
        {
            DgDespachos.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"codigoDespacho\":\"" + TxtCodigoDespacho.Text + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcpendienteanular", null);
            List<ApiDespacho> apiDespachoLista = ser.Deserialize<List<ApiDespacho>>(jsonRespuesta);
            DgDespachos.DataSource = apiDespachoLista;
        }

        private void DgDespachos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {        
            FrmAnularManifiestoMotivo frmAnularManifiestoMotivo = new FrmAnularManifiestoMotivo();
            frmAnularManifiestoMotivo.ShowDialog();
            if (frmAnularManifiestoMotivo.DialogResult == DialogResult.OK)
            {               

                string codigo = DgDespachos.Rows[DgDespachos.CurrentRow.Index].Cells[0].Value.ToString();
                RespuestaRndc retorno = new RespuestaRndc();
                BPMServicesClient client = new BPMServicesClient();
                string parametrosJson = "{\"codigoDespacho\":\"" + codigo + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcanular", parametrosJson);
                ApiElementosRndc apiElementosRndc = ser.Deserialize<ApiElementosRndc>(jsonRespuesta);

                string xmlAnularManifiesto = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                <root>
                    <acceso>
                            <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                            <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                    </acceso>
                    <solicitud>
                        <tipo>1</tipo>
                        <procesoid>32</procesoid>
                    </solicitud>
                    <variables>
                        <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                        <NUMMANIFIESTOCARGA>" + apiElementosRndc.despacho.numero + @"</NUMMANIFIESTOCARGA>
                        <MOTIVOANULACIONMANIFIESTO>" + General.CodigoMotivo + @"</MOTIVOANULACIONMANIFIESTO>
                        <OBSERVACIONES>NO HAY NINGUNA EN PARTICULAR</OBSERVACIONES>
                    </variables>
                    </root>";
                AtenderMensajeRNDCRequest solicitudAnulacionManifiesto = new AtenderMensajeRNDCRequest(xmlAnularManifiesto);
                var respuestaManifiesto = client.AtenderMensajeRNDC(solicitudAnulacionManifiesto);
                var textXmlManifiesto = respuestaManifiesto.@return;
                XmlSerializer serializerGuia = new XmlSerializer(typeof(RespuestaRndc));
                using (TextReader reader = new StringReader(textXmlManifiesto))
                {
                    retorno = (RespuestaRndc)serializerGuia.Deserialize(reader);
                    if (retorno.ErrorMSG != null)
                    {
                        string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                        if (mensajeError != "DUPLICADO")
                        {
                            MessageBox.Show(this, "Se presento un error " + apiElementosRndc.despacho.codigoDespachoPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                            
                        } else
                        {
                            ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcasignaranular", "{\"codigoDespacho\":\"" + apiElementosRndc.despacho.codigoDespachoPk + "\"}");
                            MessageBox.Show(this, "El manifiesto ya estaba anulado", "Anulado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LlenarDatosApi();
                        }
                    } else
                    {                        
                        ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcasignaranular", "{\"codigoDespacho\":\"" + apiElementosRndc.despacho.codigoDespachoPk + "\"}");
                        MessageBox.Show(this, "El manifiesto quedo anulado", "Anulado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDatosApi();
                    }
                }

            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            LlenarDatosApi();
        }
    }
}
