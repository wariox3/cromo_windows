using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace cromo
{
	public partial class FrmIngreso : Form
	{
        public FrmIngreso()
		{            
            InitializeComponent();
            PrgCarga.Maximum = CatalogoManager.Pasos + 1;
		}

		private async void BtnIngresar_Click(object sender, EventArgs e)
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

                HabilitarControles(false);
                MostrarProgreso(0, "Iniciando sesión...");

                string usuario = TxtUsuario.Text;
                string clave = TxtContraseña.Text;

                if (await Task.Run(() => Fluor.Login(usuario, clave)))
                {
                    var progreso = new Progress<KeyValuePair<int, string>>(p => MostrarProgreso(p.Key, p.Value));
                    if (!await Task.Run(() => CatalogoManager.CargarCatalogos(progreso)))
                    {
                        Fluor.Logout();
                        HabilitarControles(true);
                        MessageBox.Show(this, "No se pudieron cargar los catálogos, no es posible continuar.\n\n" + CatalogoManager.UltimoError,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MostrarProgreso(PrgCarga.Maximum, "Finalizando...");

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

                    General.UsuarioActivo = TxtUsuario.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    HabilitarControles(true);
                    MessageBox.Show(this, "Email o contraseña inválidos. Verifique e intente nuevamente.",
                        "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

				HabilitarControles(true);
				MessageBox.Show(this, mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				TxtContraseña.Focus();
			}
		}

        private void HabilitarControles(bool habilitar)
        {
            BtnIngresar.Enabled = habilitar;
            BtnIngresar.Text = habilitar ? "Ingresar" : "Ingresando...";
            BtnCancelar.Enabled = habilitar;
            TxtUsuario.Enabled = habilitar;
            TxtContraseña.Enabled = habilitar;
            ChkRecordar.Enabled = habilitar;
            LblEstado.Visible = !habilitar;
            PrgCarga.Visible = !habilitar;
        }

        private void MostrarProgreso(int paso, string texto)
        {
            PrgCarga.Value = Math.Min(paso, PrgCarga.Maximum);
            LblEstado.Text = texto;
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
