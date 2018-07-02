using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace cromo
{
	public partial class FrmImprimirGuia : Form
	{
		public FrmImprimirGuia()
		{
			InitializeComponent();
		}

		private void frmImprimirGuia_Load(object sender, EventArgs e)
		{
			dgGuias.DataSource = LlenarDatos().Tables[0];
		}


		public DataSet LlenarDatos()
		{
			string sql = "SELECT codigo_guia_pk FROM tte_guia WHERE estado_impreso = 0";
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			return ds;
		}

		private void btnCambiarEstado_Click(object sender, EventArgs e)
		{
			string codigoGuia = "";
			foreach (DataGridViewRow row in dgGuias.Rows)
			{				 
				codigoGuia =  row.Cells["codigo_guia_pk"].Value.ToString();
				//MessageBox.Show(codigoGuia);
				MySqlCommand cmd = new MySqlCommand("UPDATE tte_guia SET estado_impreso = 1 WHERE codigo_guia_pk = " + codigoGuia,
				BdCromo.ObtenerConexion());
				cmd.ExecuteNonQuery();
			}
			dgGuias.DataSource = LlenarDatos().Tables[0];
		}
	}
}
