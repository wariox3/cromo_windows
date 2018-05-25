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
	public partial class frmDevolverGuia : Form
	{
		public frmDevolverGuia()
		{
			InitializeComponent();
		}

		private void frmDevolverGuia_Load(object sender, EventArgs e)
		{
			string query = "SELECT codigo_guia_tipo_pk, nombre FROM tte_guia_tipo ORDER BY orden";
			MySqlConnection bd = BdCromo.ObtenerConexion();

			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			cboGuiaTipo.ValueMember = "codigo_guia_tipo_pk";
			cboGuiaTipo.DisplayMember = "nombre";
			cboGuiaTipo.DataSource = dt;
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			try
			{				
				string cmd = string.Format("SELECT codigo_guia_pk FROM tte_guia WHERE codigo_guia_tipo_fk = '" + cboGuiaTipo.SelectedValue + "' AND numero = " + txtNumero.Text);
				DataSet ds = Utilidades.Ejecutar(cmd);
				FuncionesGuia.codigoGuia = Convert.ToInt32(ds.Tables[0].Rows[0]["codigo_guia_pk"].ToString());				
				DialogResult = DialogResult.OK;
				Close();
			} catch (Exception error)
			{
				MessageBox.Show("No se encontro la guia Error(" + error.Message + ")");
			}

		}
	}
}
