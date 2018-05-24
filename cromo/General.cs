using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace cromo
{
	class General
	{
		private static string v_CodigoCliente = "";
		public static string codigoCliente
		{
			get { return v_CodigoCliente; }
			set { v_CodigoCliente = value; }
		}

		private static string v_CodigoCiudad = "";
		public static string codigoCiudad
		{
			get { return v_CodigoCiudad; }
			set { v_CodigoCiudad = value; }
		}

	}

	class BuscarGuia
	{

		private static int v_CodigoGuia = 0;
		public static int codigoGuia
		{
			get { return v_CodigoGuia; }
			set { v_CodigoGuia = value; }
		}

		public void devolverGuia()
		{
			frmDevolverGuia frm = new frmDevolverGuia();
			frm.ShowDialog();

		}
	}

	class Impresion
	{
		public void formatoGuia(int codigoGuia)
		{
			/* http://csharp.net-informations.com/crystal-reports/csharp-crystal-reports-string-parameter.htm */
			/* https:/www.youtube.com/watch?v=iisXC_RsZ3w */
			/*ReportDocument rpt = new ReportDocument();
			rpt.Load(@"C:\Users\desarrollo\source\repos\cromo\cromo\FormatoGuia.rpt");
			crystalReportViewer1.ReportSource = rpt;
			crystalReportViewer1.Refresh();*/

			FormatoGuia objRpt = new FormatoGuia();
			string sql = "SELECT tte_guia.codigo_guia_pk, tte_guia.numero, tte_guia.documento_cliente FROM tte_guia WHERE codigo_guia_pk = 1";
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			objRpt.SetDataSource(ds.Tables[0]);
			objRpt.PrintToPrinter(1,false, 0, 1);

			//crystalReportViewer1.ReportSource = objRpt;
			//crystalReportViewer1.Refresh();
			//crystalReportViewer1.PrintReport();
		}
	}
}
