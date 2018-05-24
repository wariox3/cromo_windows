using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace cromo
{
	public partial class frmBuscarGuia : Form
	{
		public frmBuscarGuia()
		{
			InitializeComponent();
		}
		public DataSet LlenarDatos()
		{
			string sql = "SELECT * FROM tte_guia";
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			return ds;
		}

		private void frmBuscarGuia_Load(object sender, EventArgs e)
		{
			dgGuias.DataSource = LlenarDatos().Tables[0];
		}
	}
}
