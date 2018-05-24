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
			}
		}
	}
}
