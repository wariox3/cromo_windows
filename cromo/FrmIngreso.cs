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
	public partial class FrmIngreso : Form
	{
		public FrmIngreso()
		{
			InitializeComponent();
		}

		private void BtnIngresar_Click(object sender, EventArgs e)
		{
			try
			{
				DataSet ds = Utilidades.Ejecutar("SELECT username, clave_escritorio " +
					"FROM usuario " +
					"WHERE username = '" + TxtUsuario.Text + "'");
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count > 0)
				{
					if(dt.Rows[0]["clave_escritorio"].ToString() == TxtContraseña.Text)
					{
						General.UsuarioActivo = TxtUsuario.Text;
						DialogResult = DialogResult.OK;
						Close();						
					} else
					{
						MessageBox.Show("Clave incorrecta");
					}
				} else
				{
					MessageBox.Show("El usuario no existe");
				}								
			}
			catch (Exception error)
			{
				MessageBox.Show("Se produjo un error (" + error.Message + ")");
			}
		}

		private void BtnConfigurar_Click(object sender, EventArgs e)
		{
			FrmValidarAdministrador frmValidarAdministrador = new FrmValidarAdministrador();
			frmValidarAdministrador.ShowDialog();
			if (frmValidarAdministrador.DialogResult == DialogResult.OK)
			{
				FrmConfiguracion frmConfiguracion = new FrmConfiguracion();
				frmConfiguracion.ShowDialog();
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
