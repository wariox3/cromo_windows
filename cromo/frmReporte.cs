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
using System.IO;
namespace cromo
{
	public partial class FrmReporte : Form
	{
		public FrmReporte()
		{
			InitializeComponent();			
		}

		private void FrmReporte_Load(object sender, EventArgs e)
		{
			/* http://csharp.net-informations.com/crystal-reports/csharp-crystal-reports-string-parameter.htm */
			/* https:/www.youtube.com/watch?v=iisXC_RsZ3w */
			/*ReportDocument rpt = new ReportDocument();
			rpt.Load(@"C:\Users\desarrollo\source\repos\cromo\cromo\FormatoGuia.rpt");
			crystalReportViewer1.ReportSource = rpt;
			crystalReportViewer1.Refresh();*/			
			string servirdor = cromo.Properties.Settings.Default.servidorBaseDatos;
			string puerto = cromo.Properties.Settings.Default.puertoBaseDatos;
			string usuario = cromo.Properties.Settings.Default.usuarioBaseDatos;
			string clave = cromo.Properties.Settings.Default.claveBaseDatos;
			string baseDatos = cromo.Properties.Settings.Default.baseDatos;
			string driver = cromo.Properties.Settings.Default.driverBaseDatos;
			string rutaReportes = cromo.Properties.Settings.Default.rutaReportes;
			string ruta = "";
			DataSet dsReporte = Utilidades.Ejecutar("SELECT modulo, nombre, archivo " +
				"FROM gen_reporte WHERE codigo_reporte_pk = " + General.CodigoReporte.ToString());
			DataTable dt = dsReporte.Tables[0];
			if (dt.Rows.Count > 0)
			{
				ruta = rutaReportes + dt.Rows[0]["modulo"].ToString() + @"\" + dt.Rows[0]["archivo"].ToString();
			}
			string path = Directory.GetCurrentDirectory();

			DataSet ds;
			string strSql = string.Format(General.Sql);
			ds = Utilidades.Ejecutar(strSql);

			ReportDocument rpt = new ReportDocument();
			if (File.Exists(ruta))
			{
				rpt.Load(ruta);
				rpt.SetDataSource(ds.Tables[0]);
				crvReporte.ReportSource = rpt;
				crvReporte.Refresh();
				foreach (CrystalDecisions.CrystalReports.Engine.Table item in rpt.Database.Tables)
				{					
					var tliCurrent = item.LogOnInfo;
					//tliCurrent.ConnectionInfo.ServerName = "DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=190.85.62.78;Port=3306;UID=administrador;";					
					//tliCurrent.ConnectionInfo.UserID = "administrador";
					//tliCurrent.ConnectionInfo.Password = "Nor4m628";
					//tliCurrent.ConnectionInfo.DatabaseName = "bdlogicuartas";

					tliCurrent.ConnectionInfo.ServerName = "DRIVER=" + driver + "; SERVER=" + servirdor + ";Port=" + puerto + ";UID=" + usuario + ";";
					tliCurrent.ConnectionInfo.UserID = usuario;
					tliCurrent.ConnectionInfo.Password = clave;
					tliCurrent.ConnectionInfo.DatabaseName = baseDatos;

					item.ApplyLogOnInfo(tliCurrent);
				}
			}
			else
			{
				MessageBox.Show("No se encuentra el archivo" + ruta);
			}
		}
	}
}
