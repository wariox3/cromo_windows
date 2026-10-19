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
                // Validación 1: Campos no pueden estar vacíos
                if (string.IsNullOrWhiteSpace(TxtUsuario.Text) || string.IsNullOrWhiteSpace(TxtContraseña.Text))
                {
                    MessageBox.Show(this, "Email y contraseña son requeridos", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Feedback 2: Mostrar que está cargando
                BtnIngresar.Enabled = false;
                BtnIngresar.Text = "Ingresando...";
                BtnCancelar.Enabled = false;
                BtnConfigurar.Enabled = false;

                string parametrosJson;
                string jsonRespuesta;
                // === NUEVO: Login con Fluor usando JWT ===
                if (Fluor.Login(TxtUsuario.Text, TxtContraseña.Text))
                {
                    // Login exitoso - Fluor administra el token internamente

                    // Guardar email si "Recordar" está marcado (NO contraseña)
                    if (ChkRecordar.Checked)
                    {
                        cromo.Properties.Settings.Default.usuario = TxtUsuario.Text;
                        // NO guardar contraseña
                        cromo.Properties.Settings.Default.recordarClave = ChkRecordar.Checked;
                        cromo.Properties.Settings.Default.Save();
                    }
                    else
                    {
                        cromo.Properties.Settings.Default.usuario = null;
                        cromo.Properties.Settings.Default.recordarClave = false;
                        cromo.Properties.Settings.Default.Save();
                    }

                    // Limpiar 4: Borrar contraseña de memoria por seguridad
                    TxtContraseña.Text = "";

                    // Validar logo (opcional)
                    string logo = Directory.GetCurrentDirectory() + @"\logo.jpg";
                    if (!File.Exists(logo))
                    {
                        try
                        {
                            jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/general/configuracion", "");
                            ApiConfiguracion apiConfiguracion = ser.Deserialize<ApiConfiguracion>(jsonRespuesta);
                            if (apiConfiguracion.error == null)
                            {
                                string base64 = apiConfiguracion.logo;
                                byte[] bytes = Convert.FromBase64String(base64);
                                using (Image image = Image.FromStream(new MemoryStream(bytes)))
                                {
                                    image.Save(Directory.GetCurrentDirectory() + @"\logo.jpg", ImageFormat.Jpeg);
                                }
                            }
                        }
                        catch { /* Ignorar error al descargar logo */ }
                    }

                    // Validar operación (si es necesario)
                    parametrosJson = "{\"codigoOperacion\":\"" + cromo.Properties.Settings.Default.centroOperacion + "\"}";
                    try
                    {
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/operacion/validar", parametrosJson);
                        ApiOperacion apiOperacion = ser.Deserialize<ApiOperacion>(jsonRespuesta);
                        if (apiOperacion.error == null)
                        {
                            // Cargar configuración
                            General.UsuarioActivo = TxtUsuario.Text;
                            General.CodigoCiudadOrigenParametro = apiOperacion.codigoCiudadFk;
                            General.CodigoOperacionIngreso = apiOperacion.codigoOperacionPk;
                            General.CodigoOperacionCargo = apiOperacion.codigoOperacionCargoFk;

                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "Inconvenientes con la operacion " + apiOperacion.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        // Si validación de operación falla, permitir continuar
                        General.UsuarioActivo = TxtUsuario.Text;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    // Error 3: Mensaje específico para credenciales inválidas
                    MessageBox.Show(this, "Email o contraseña inválidos. Verifique e intente nuevamente.",
                        "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Re-habilitar botones para reintentar
                    BtnIngresar.Enabled = true;
                    BtnIngresar.Text = "Ingresar";
                    BtnCancelar.Enabled = true;
                    BtnConfigurar.Enabled = true;
                    TxtContraseña.Focus();
                }
            }
			catch (Exception error)
			{
				// Error 3: Manejo de excepciones específicas
				string mensaje = "Se produjo un error durante el login";

				if (error is TimeoutException || error.Message.Contains("timeout"))
					mensaje = "Tiempo de espera agotado. Verifique su conexión e intente de nuevo.";
				else if (error is System.Net.WebException)
					mensaje = "Error de conexión. Verifique que el servidor esté disponible.";
				else if (error.Message.Contains("401") || error.Message.Contains("Unauthorized"))
					mensaje = "Email o contraseña inválidos.";
				else
					mensaje = "Error: " + error.Message;

				MessageBox.Show(this, mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				// Re-habilitar botones para reintentar
				BtnIngresar.Enabled = true;
				BtnIngresar.Text = "Ingresar";
				BtnCancelar.Enabled = true;
				BtnConfigurar.Enabled = true;
				TxtContraseña.Focus();
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
            TxtUsuario.Text = cromo.Properties.Settings.Default.usuario;
            // NO cargar contraseña (ya no la guardamos por seguridad)
            ChkRecordar.Checked = cromo.Properties.Settings.Default.recordarClave;
            this.Text = this.Text + " " + Application.ProductVersion;
        }
    }
}
