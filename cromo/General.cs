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

		private static int v_CodigoGuia = 0;
		public static int codigoGuia
		{
			get { return v_CodigoGuia; }
			set { v_CodigoGuia = value; }
		}

		private static int v_NumeroGuia = 0;
		public static int numeroGuia
		{
			get { return v_NumeroGuia; }
			set { v_NumeroGuia = value; }
		}

		private static int v_CodigoReporte = 0;
		public static int codigoReporte
		{
			get { return v_CodigoReporte; }
			set { v_CodigoReporte = value; }
		}

		private static string v_Sql = "";
		public static string sql
		{
			get { return v_Sql; }
			set { v_Sql = value; }
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
			string sql = "SELECT tte_guia.codigo_guia_pk, tte_guia.numero, tte_guia.documento_cliente, tte_guia.fecha_ingreso, " +
				"ciudad_origen.nombre as ciudad_origen_nombre, ciudad_destino.nombre as ciudad_destino_nombre, " +
				"tte_guia.remitente, tte_cliente.nombre_corto as cliente_nombre,  tte_cliente.direccion as cliente_direccion, " +
				"tte_cliente.telefono as cliente_telefono, tte_guia.nombre_destinatario, tte_guia.direccion_destinatario, " +
				"tte_guia.telefono_destinatario, tte_guia.comentario, tte_guia.factura, tte_guia.unidades, tte_guia.vr_flete, " +
				"tte_guia.vr_manejo, tte_guia.vr_abono, tte_guia.vr_recaudo " +
				"FROM tte_guia " +
				"LEFT JOIN tte_ciudad as ciudad_origen ON tte_guia.codigo_ciudad_origen_fk = ciudad_origen.codigo_ciudad_pk " +
				"LEFT JOIN tte_ciudad as ciudad_destino ON tte_guia.codigo_ciudad_destino_fk = ciudad_destino.codigo_ciudad_pk " +
				"LEFT JOIN tte_cliente ON tte_guia.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
				"WHERE codigo_guia_pk = " + codigoGuia.ToString(); 
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			objRpt.SetDataSource(ds.Tables[0]);
			objRpt.PrintToPrinter(1,false, 0, 1);

			//crystalReportViewer1.ReportSource = objRpt;
			//crystalReportViewer1.Refresh();
			//crystalReportViewer1.PrintReport();
		}

		public void formato(int codigo, string sql)
		{
			General.codigoReporte = codigo;
			General.sql = sql;
			frmReporte frm = new frmReporte();
			frm.ShowDialog();

		}
	}

	class FuncionesGuia
	{
		private static int v_CodigoGuia = 0;
		public static int codigoGuia
		{
			get { return v_CodigoGuia; }
			set { v_CodigoGuia = value; }
		}

		public int Ultima()
		{
			int ultimaGuia = 0;
			string sql = "SELECT MAX(codigo_guia_pk) AS ultima FROM tte_guia";
			DataSet ds = Utilidades.Ejecutar(sql);
			DataTable dt = ds.Tables[0];
			if(dt.Rows[0]["ultima"] != DBNull.Value)			
			{
				ultimaGuia = Convert.ToInt32(dt.Rows[0]["ultima"]);
			}			
			return ultimaGuia;
		}

		public void devolverGuia()
		{
			frmDevolverGuia frm = new frmDevolverGuia();
			frm.ShowDialog();

		}

	}

}
