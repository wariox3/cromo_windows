using System;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using System.Deployment.Application;

namespace cromo
{
	public partial class FrmIngreso : Form
	{
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmIngreso()
		{            
            InitializeComponent();
		}

		private void BtnIngresar_Click(object sender, EventArgs e)
		{
			try
			{
                bool servidorManual = cromo.Properties.Settings.Default.servidorManual;

                if (TxtOperador.Text != "" || servidorManual)
                {
                    string parametrosJson;
                    string jsonRespuesta;
                    cromo.Properties.Settings.Default.operador = TxtOperador.Text;
                    cromo.Properties.Settings.Default.Save();
                    
                    if (servidorManual)
                    {
                        General.UrlServicio = cromo.Properties.Settings.Default.rutaServidorManual;
                        General.TokenServicio = cromo.Properties.Settings.Default.tokenServidorManual;
                        General.UsuarioServicio = cromo.Properties.Settings.Default.usuarioServidorManual;
                        General.ClaveServicio = cromo.Properties.Settings.Default.claveServidorManual;
                    } else
                    {
                        parametrosJson = "{\"codigoOperador\":\"" + TxtOperador.Text + "\"}";
                        jsonRespuesta = ApiControlador.ApiPostRubidio("/api/cliente/servicio", parametrosJson);                        
                        ApiOperador apiOperador = ser.Deserialize<ApiOperador>(jsonRespuesta);
                        if (apiOperador.error == false)
                        {
                            General.UrlServicio = apiOperador.puntoServicio;
                            General.TokenServicio = apiOperador.puntoServicioToken;
                            General.UsuarioServicio = apiOperador.puntoServicioUsuario;
                            General.ClaveServicio = apiOperador.puntoServicioClave;
                        }
                        else
                        {
                            MessageBox.Show(this, apiOperador.errorMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                            
                        }
                    }

                    if (General.UrlServicio != "")
                    {
                        //Validar logo
                        string logo = Directory.GetCurrentDirectory() + @"\logo.jpg";
                        if (!File.Exists(logo))
                        {
                            jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/general/configuracion", "");
                            ApiConfiguracion apiConfiguracion = ser.Deserialize<ApiConfiguracion>(jsonRespuesta);
                            if (apiConfiguracion.error == null)
                            {
                                string base64 = apiConfiguracion.logo;
                                byte[] bytes = Convert.FromBase64String(base64);
                                using (Image image = Image.FromStream(new MemoryStream(bytes)))
                                {
                                    image.Save(Directory.GetCurrentDirectory() + @"\logo.jpg", ImageFormat.Jpeg);  // Or Png
                                }
                            }
                        }

                        parametrosJson = "{\"usuario\":\"" + TxtUsuario.Text + "\",\"clave\":\"" + TxtContraseña.Text + "\"}";
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/usuario/validar", parametrosJson);
                        ApiUsuario apiUsuario = ser.Deserialize<ApiUsuario>(jsonRespuesta);
                        if (apiUsuario.error == null)
                        {
                            if (ChkRecordar.Checked)
                            {
                                cromo.Properties.Settings.Default.usuario = TxtUsuario.Text;
                                cromo.Properties.Settings.Default.clave = TxtContraseña.Text;
                                cromo.Properties.Settings.Default.recordarClave = ChkRecordar.Checked;
                                cromo.Properties.Settings.Default.Save();
                            }
                            else
                            {
                                cromo.Properties.Settings.Default.usuario = null;
                                cromo.Properties.Settings.Default.clave = null;
                                cromo.Properties.Settings.Default.recordarClave = false;
                                cromo.Properties.Settings.Default.Save();
                            }
                            if (apiUsuario.versionBaseDatos <= 3)
                            {
                                parametrosJson = "{\"codigoOperacion\":\"" + cromo.Properties.Settings.Default.centroOperacion + "\"}";
                                jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/operacion/validar", parametrosJson);
                                ApiOperacion apiOperacion = ser.Deserialize<ApiOperacion>(jsonRespuesta);
                                if (apiOperacion.error == null)
                                {
                                    General.UsuarioActivo = TxtUsuario.Text;
                                    General.NumeroUnicoGuia = apiUsuario.numeroUnicoGuia;
                                    General.CodigoPrecioGeneral = apiUsuario.codigoPrecioGeneral;
                                    General.CodigoCondicionGeneral = apiUsuario.codigoCondicionGeneral;
                                    General.CodigoFormatoGuia = apiUsuario.codigoFormatoGuia;

                                    General.CodigoCiudadOrigenParametro = apiOperacion.codigoCiudadFk;
                                    General.CodigoOperacionIngreso = apiOperacion.codigoOperacionPk;
                                    General.CodigoOperacionCargo = apiOperacion.codigoOperacionCargoFk;

                                    General.RestringirGuiaNueva = apiUsuario.restringirGuiaNueva;

                                    DialogResult = DialogResult.OK;
                                    Close();
                                } else
                                {
                                    MessageBox.Show(this, "Inconvenientes con la operacion " + apiOperacion.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
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
                        }
                        else
                        {
                            MessageBox.Show(this, "Usuario o contraseña invalidos " + apiUsuario.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show(this, "No se ha especificado una url para el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } else
                {
                    MessageBox.Show(this, "Debe especificar un operador o configurar uno manual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
		    FrmConfiguracion frmConfiguracion = new FrmConfiguracion();
		    frmConfiguracion.ShowDialog();			
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
            this.Text = this.Text + " " + Application.ProductVersion;
        }
    }
}
