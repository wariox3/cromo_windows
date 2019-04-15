using System;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Collections.Generic;
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
                if(TxtOperador.Text != "")
                {
                    string parametrosJson = "{\"operador\":\"" + TxtOperador.Text + "\"}";
                    string jsonRespuesta = ApiControlador.ApiPostCesio("/api/windows/transporte/operador/validar", parametrosJson);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    ApiOperador apiOperador = ser.Deserialize<ApiOperador>(jsonRespuesta);
                    if(apiOperador.error == null)
                    {
                        cromo.Properties.Settings.Default.operador = TxtOperador.Text;                        
                        cromo.Properties.Settings.Default.Save();
                        General.UrlServicio = apiOperador.urlServicio;
                        General.UrlServicio = "http://192.168.15.43/cromo/public/index.php";
                        General.UrlServicio = "http://localhost/cromo/public";

                        parametrosJson = "{\"usuario\":\"" + TxtUsuario.Text + "\",\"clave\":\"" + TxtContraseña.Text + "\"}";
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/usuario/validar", parametrosJson);                        
                        ApiUsuario apiUsuario = ser.Deserialize<ApiUsuario>(jsonRespuesta);
                        if (apiUsuario.error == null)
                        {
                            if(ChkRecordar.Checked)
                            {
                                cromo.Properties.Settings.Default.usuario = TxtUsuario.Text;
                                cromo.Properties.Settings.Default.clave = TxtContraseña.Text;
                                cromo.Properties.Settings.Default.recordarClave = ChkRecordar.Checked;
                                cromo.Properties.Settings.Default.Save();
                            } else
                            {
                                cromo.Properties.Settings.Default.usuario = null;
                                cromo.Properties.Settings.Default.clave = null;
                                cromo.Properties.Settings.Default.recordarClave = false;
                                cromo.Properties.Settings.Default.Save();
                            }
                            if (apiUsuario.versionBaseDatos <= 3)
                            {
                                General.UsuarioActivo = TxtUsuario.Text;                                    
                                General.NumeroUnicoGuia = apiUsuario.numeroUnicoGuia;
                                General.CodigoPrecioGeneral = apiUsuario.codigoPrecioGeneral;
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else
                            {
                                DialogResult resultado = MessageBox.Show(this, "La base de datos conectada require de una actualizacion de la aplicacion de escritorio desea descargar la actualizacion?",
                                                                    "Actualizacion requerida", MessageBoxButtons.YesNo,
                                                                    MessageBoxIcon.Question);
                                if (resultado == DialogResult.Yes)
                                {
                                    System.Diagnostics.Process.Start("https://github.com/wariox3/cromo_windows/tree/master/InstaladorCromo/Debug");
                                    Close();
                                }
                            }                            
                        } else
                        {
                            MessageBox.Show(this, "Usuario o contraseña invalidos " + apiUsuario.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    } else
                    {
                        MessageBox.Show(this, "El operador no existe " + apiOperador.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show(this, "Debe especificar un operador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtOperador.Focus();
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

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            TxtOperador.Text = cromo.Properties.Settings.Default.operador;
            TxtUsuario.Text = cromo.Properties.Settings.Default.usuario;
            TxtContraseña.Text = cromo.Properties.Settings.Default.clave;
            ChkRecordar.Checked = cromo.Properties.Settings.Default.recordarClave;
        }
    }
}
