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
	public partial class FrmBuscarGuia : Form
	{
		public FrmBuscarGuia()
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

		private void FrmBuscarGuia_Load(object sender, EventArgs e)
		{
			DgGuias.DataSource = LlenarDatos().Tables[0];
		}
	}
}
