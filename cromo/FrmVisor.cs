using Microsoft.Reporting.WinForms;
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

namespace cromo
{
    public partial class FrmVisor : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        public FrmVisor()
        {
            InitializeComponent();
        }

        private void FrmVisor_Load(object sender, EventArgs e)
        {
            
            if (General.Formato.tipo == "Guia")
            {                
                string parametrosJson = "{\"codigoGuiaPk\":\""+ General.Formato.codigo +"\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/imprimir", parametrosJson);                
                ApiGuiaImprimir apiGuia = ser.Deserialize<ApiGuiaImprimir>(jsonRespuesta);
                if (apiGuia.error == null)
                {
                    List<ApiGuiaImprimir> listaGuias = new List<ApiGuiaImprimir>();
                    listaGuias.Add(apiGuia);
                    string ruta = cromo.Properties.Settings.Default.rutaReportes;
                    ruta = ruta + @"Transporte\Guia" + General.Formato.codigoFormato + ".rdlc";
                    if(File.Exists(ruta))
                    {
                        this.reportViewer1.LocalReport.ReportPath = ruta;
                        ReportParameter param = new ReportParameter("rutaImagen", @"file:\" + Directory.GetCurrentDirectory() + @"\logo.jpg", true);
                        this.reportViewer1.LocalReport.SetParameters(param);
                        ReportDataSource rds1 = new ReportDataSource("GuiaImprimir", listaGuias);
                        this.reportViewer1.LocalReport.DataSources.Clear();
                        this.reportViewer1.LocalReport.DataSources.Add(rds1);
                        this.reportViewer1.RefreshReport();
                    } else
                    {
                        MessageBox.Show(this, "No se encontro el reporte, verifique la ruta de reportes en configuracion: " + ruta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (General.Formato.tipo == "Recibo")
            {
                string parametrosJson = "{\"codigoGuia\":\"" + General.CodigoGuia + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/recibo/imprimir", parametrosJson);
                List<ApiReciboImprimir> apiReciboImprimir = ser.Deserialize<List<ApiReciboImprimir>>(jsonRespuesta);
                string ruta = cromo.Properties.Settings.Default.rutaReportes;
                ruta = ruta + @"Transporte\Recibo" + General.Formato.codigoFormato + ".rdlc";
                if (File.Exists(ruta))
                {
                    this.reportViewer1.LocalReport.ReportPath = ruta;
                    ReportParameter param = new ReportParameter("rutaImagen", @"file:\" + Directory.GetCurrentDirectory() + @"\logo.jpg", true);
                    this.reportViewer1.LocalReport.SetParameters(param);
                    ReportDataSource rds1 = new ReportDataSource("ReciboImprimir", apiReciboImprimir);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(rds1);
                    this.reportViewer1.RefreshReport();
                } else
                {
                    MessageBox.Show(this, "No se encontro el reporte, verifique la ruta de reportes en configuracion: " + ruta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }


    }
}
