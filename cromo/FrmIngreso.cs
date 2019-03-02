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
						DataSet dsVersion = Utilidades.Ejecutar("SELECT version_base_datos FROM gen_configuracion where codigo_configuracion_pk=1");
						DataTable dtConfiguracion = dsVersion.Tables[0];
						if (dtConfiguracion.Rows.Count > 0)
						{
							if (Convert.ToInt32(dtConfiguracion.Rows[0]["version_base_datos"].ToString()) <= 2)
							{
								General.UsuarioActivo = TxtUsuario.Text;
								string sql = "SELECT numero_unico_guia FROM tte_configuracion WHERE codigo_configuracion_pk = 1";
								DataSet dsConfiguracionTransporte = Utilidades.Ejecutar(sql);
								DataTable dtConfiguracionTransporte = dsConfiguracionTransporte.Tables[0];
								if (dtConfiguracionTransporte.Rows.Count > 0)
								{
									General.NumeroUnicoGuia = Convert.ToBoolean(dtConfiguracionTransporte.Rows[0]["numero_unico_guia"]);
								}
								DialogResult = DialogResult.OK;
								Close();
							} else {								
								DialogResult resultado = MessageBox.Show(this, "La base de datos conectada require de una actualizacion de la aplicacion de escritorio desea descargar la actualizacion?",
																   "Actualizacion requerida", MessageBoxButtons.YesNo,
																   MessageBoxIcon.Question);
								if(resultado == DialogResult.Yes)
								{
									System.Diagnostics.Process.Start("https://github.com/wariox3/cromo_windows/tree/master/InstaladorCromo/Debug");
									Close();
								}
							}
						}						
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
