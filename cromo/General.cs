using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using MySql.Data.MySqlClient;
namespace cromo
{
	class General
	{
		private static string v_CodigoCliente = "";
		public static string CodigoCliente
		{
			get { return v_CodigoCliente; }
			set { v_CodigoCliente = value; }
		}

		private static string v_CodigoCiudad = "";
		public static string CodigoCiudad
		{
			get { return v_CodigoCiudad; }
			set { v_CodigoCiudad = value; }
		}

		private static int v_CodigoGuia = 0;
		public static int CodigoGuia
		{
			get { return v_CodigoGuia; }
			set { v_CodigoGuia = value; }
		}

		private static int v_NumeroGuia = 0;
		public static int NumeroGuia
		{
			get { return v_NumeroGuia; }
			set { v_NumeroGuia = value; }
		}

		private static int v_CodigoReporte = 0;
		public static int CodigoReporte
		{
			get { return v_CodigoReporte; }
			set { v_CodigoReporte = value; }
		}

		private static string v_Sql = "";
		public static string Sql
		{
			get { return v_Sql; }
			set { v_Sql = value; }
		}

		private static string v_UsuarioActivo = "";
		public static string UsuarioActivo
		{
			get { return v_UsuarioActivo; }
			set { v_UsuarioActivo = value; }
		}

		private static string v_DocumentoCliente = "";
		public static string DocumentoCliente
		{
			get { return v_DocumentoCliente; }
			set { v_DocumentoCliente = value; }
		}

		private static string v_CodigoCondicion = "";
		public static string CodigoCondicion
		{
			get { return v_CodigoCondicion; }
			set { v_CodigoCondicion = value; }
		}

	}

	class Impresion
	{
		public void FormatoGuia(string codigoGuia)
		{
			string servirdor = cromo.Properties.Settings.Default.servidorBaseDatos;
			string puerto = cromo.Properties.Settings.Default.puertoBaseDatos;
			string usuario = cromo.Properties.Settings.Default.usuarioBaseDatos;
			string clave = cromo.Properties.Settings.Default.claveBaseDatos;
			string baseDatos = cromo.Properties.Settings.Default.baseDatos;
			string driver = cromo.Properties.Settings.Default.driverBaseDatos;
			string rutaReportes = cromo.Properties.Settings.Default.rutaReportes;
			string ruta = "";
			DataSet dsReporte = Utilidades.Ejecutar("SELECT modulo, nombre, archivo " +
				"FROM gen_reporte WHERE codigo_reporte_pk = 2");
			DataTable dt = dsReporte.Tables[0];
			if (dt.Rows.Count > 0)
			{
				ruta = rutaReportes + dt.Rows[0]["modulo"].ToString() + @"\" + dt.Rows[0]["archivo"].ToString();
			}
			string path = Directory.GetCurrentDirectory();
			GuiaRepositorio guiaRepositorio = new GuiaRepositorio();
			DataSet ds;
			string strSql = string.Format(guiaRepositorio.sqlFormato(codigoGuia));			
			ds = Utilidades.Ejecutar(strSql);

			ReportDocument rpt = new ReportDocument();
			rpt.Load(ruta);
			rpt.SetDataSource(ds.Tables[0]);						
			foreach (CrystalDecisions.CrystalReports.Engine.Table item in rpt.Database.Tables)
			{				
				var tliCurrent = item.LogOnInfo;
				tliCurrent.ConnectionInfo.ServerName = "DRIVER=" + driver + "; SERVER=" + servirdor + ";Port=" + puerto + ";UID=" + usuario + ";";
				tliCurrent.ConnectionInfo.UserID = usuario;
				tliCurrent.ConnectionInfo.Password = clave;
				tliCurrent.ConnectionInfo.DatabaseName = baseDatos;

				item.ApplyLogOnInfo(tliCurrent);
			}
			rpt.PrintToPrinter(1, false, 0, 1);
			MySqlCommand cmd = new MySqlCommand("UPDATE tte_guia SET estado_impreso = 1 WHERE codigo_guia_pk = " + codigoGuia,
			BdCromo.ObtenerConexion());
			cmd.ExecuteNonQuery();
		}

		public void Formato(int codigo, string sql)
		{
			General.CodigoReporte = codigo;
			General.Sql = sql;
			FrmReporte frm = new FrmReporte();
			frm.ShowDialog();

		}
	}

	class FuncionesGuia
	{
		private static int v_CodigoGuia = 0;
		public static int CodigoGuia
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

		public void DevolverGuia()
		{
			FrmDevolverGuia frm = new FrmDevolverGuia();
			frm.ShowDialog();

		}

	}

}
