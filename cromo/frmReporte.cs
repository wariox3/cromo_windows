using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
namespace cromo
{
	public partial class frmReporte : Form
	{
		public frmReporte()
		{
			InitializeComponent();
		}

		private void frmReporte_Load(object sender, EventArgs e)
		{
			/* http://csharp.net-informations.com/crystal-reports/csharp-crystal-reports-string-parameter.htm */
			/* https:/www.youtube.com/watch?v=iisXC_RsZ3w */
			/*ReportDocument rpt = new ReportDocument();
			rpt.Load(@"C:\Users\desarrollo\source\repos\cromo\cromo\FormatoGuia.rpt");
			crystalReportViewer1.ReportSource = rpt;
			crystalReportViewer1.Refresh();*/

			/*FormatoGuia objRpt = new FormatoGuia();
			string sql = "SELECT tte_guia.codigo_guia_pk, tte_guia.numero, tte_guia.documento_cliente FROM tte_guia WHERE codigo_guia_pk = 1";			
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			objRpt.SetDataSource(ds.Tables[0]);*/

			//crystalReportViewer1.PrintReport();
			DataSet ds;
			string strSql = string.Format(General.sql);
			ds = Utilidades.Ejecutar(strSql);
			switch (General.codigoReporte)
			{
				case 1:
					FormatoRecibo objRpt = new FormatoRecibo();					
					objRpt.SetDataSource(ds.Tables[0]);
					crystalReportViewer1.ReportSource = objRpt;
					crystalReportViewer1.Refresh();
					break;
				case 2:
					/*FormatoGuia reporteGuia = new FormatoGuia();
					reporteGuia.SetDataSource(ds.Tables[0]);
					crystalReportViewer1.ReportSource = reporteGuia;
					crystalReportViewer1.Refresh();*/

					/*string servirdor = cromo.Properties.Settings.Default.servidorBaseDatos;
					string puerto = cromo.Properties.Settings.Default.puertoBaseDatos;
					string usuario = cromo.Properties.Settings.Default.usuarioBaseDatos;
					string clave = cromo.Properties.Settings.Default.claveBaseDatos;
					string baseDatos = cromo.Properties.Settings.Default.baseDatos;
					MySqlConnection bd = new MySqlConnection("server=" + servirdor + "; database=" + baseDatos + "; Uid=" + usuario + "; pwd=" + clave + "; port=" + puerto + "; SslMode=none;");
					bd.Open();*/

					ReportDocument rpt = new ReportDocument();
					rpt.Load(@"C:\reportes\FormatoGuia.rpt");
					rpt.SetDataSource(ds.Tables[0]);
					crystalReportViewer1.ReportSource = rpt;
					crystalReportViewer1.Refresh();

					//crystalReportViewer1.ReportSource = rpt;
					//crystalReportViewer1.Refresh();

					break;
			}
		}
	}
}
