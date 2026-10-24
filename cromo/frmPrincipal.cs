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
    public partial class FrmPrincipal : Form
    {
        bool operadoLogistico = cromo.Properties.Settings.Default.operadorLogistico;
        private System.Windows.Forms.Timer tokenRefreshTimer;

        public FrmPrincipal()
        {
            InitializeComponent();
            InitializeTokenRefreshTimer();
        }

        private void InitializeTokenRefreshTimer()
        {
            tokenRefreshTimer = new System.Windows.Forms.Timer();
            tokenRefreshTimer.Interval = 55 * 60 * 1000; // 55 minutos
            tokenRefreshTimer.Tick += TokenRefreshTimer_Tick;
        }

        private void TokenRefreshTimer_Tick(object sender, EventArgs e)
        {
            // Renovar token automáticamente antes de que expire
            try
            {
                Fluor.RefreshAccessToken();
                ActualizarEstadoUsuario();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error renovando token: " + ex.Message);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(General.RestringirGuiaNueva == false)
            {
                if (!OperacionConfigurada()) return;
                FrmGuia frmGuia = new FrmGuia();
                frmGuia.MdiParent = this;
                frmGuia.Show();
            } else
            {
                MessageBox.Show(this, "No tiene permisos para crear guias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuArchivoConfigurcion_Click(object sender, EventArgs e)
        {
		    FrmConfiguracion frmConfiguracion = new FrmConfiguracion();
		    frmConfiguracion.ShowDialog();
        }

		private void FrmPrincipal_Load(object sender, EventArgs e)
		{
			FrmIngreso FrmIngreso = new FrmIngreso();
            this.Text = this.Text + " " + Application.ProductVersion;
            FrmIngreso.ShowDialog();
            if (FrmIngreso.DialogResult != DialogResult.OK)
			{
				Close();
				return;
			}

            // Inicializar UI con usuario autenticado
            ActualizarEstadoUsuario();

            // Iniciar timer de renovación de token
            tokenRefreshTimer.Start();

            if(operadoLogistico)
            {
                mnuGuia.Enabled = false;
                utilidadesToolStripMenuItem.Enabled = false;
            }
		}

        private void ActualizarEstadoUsuario()
        {
            // Mostrar empresa y usuario autenticado en la barra de estado
            toolStripStatusLabel.Text = "Empresa: " + (Fluor.EmpresaActual?.Nombre ?? "") +
                                       " | Usuario: " + General.UsuarioActivo +
                                       " | Token expira: " + Fluor.TokenExpireTime.ToString("HH:mm");
        }

        private void Logout()
        {
            // Detener timer
            tokenRefreshTimer.Stop();

            Fluor.Logout();
            CatalogoManager.LimpiarCatalogos();

            // Cerrar todas las ventanas abiertas
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }

            // Mostrar login nuevamente
            FrmIngreso frmIngreso = new FrmIngreso();
            if (frmIngreso.ShowDialog() != DialogResult.OK)
            {
                // Usuario canceló login, cerrar aplicación
                Close();
            }
            else
            {
                ActualizarEstadoUsuario();
                tokenRefreshTimer.Start();
            }
        }

        private void mnuImpresionMasiva_Click(object sender, EventArgs e)
        {
            FrmImpresionMasiva frmImpresionMasiva = new FrmImpresionMasiva();
            frmImpresionMasiva.ShowDialog();
            
        }

        private void MenuCrearCliente_Click(object sender, EventArgs e)
        {
            FrmClienteNuevo frmClienteNuevo = new FrmClienteNuevo();
            frmClienteNuevo.ShowDialog();
        }

        private void MenuCrearDestinatario_Click(object sender, EventArgs e)
        {
            General.CodigoCliente = "";
            FrmDestinatarioNuevo frmDestinatarioNuevo = new FrmDestinatarioNuevo();
            frmDestinatarioNuevo.ShowDialog();
        }

        private void MnuGuiaOperador_Click(object sender, EventArgs e)
        {
            if (General.RestringirGuiaNueva == false)
            {
                if (!OperacionConfigurada()) return;
                FrmGuiaOperador frmGuiaOperador = new FrmGuiaOperador();
                frmGuiaOperador.MdiParent = this;
                frmGuiaOperador.Show();
            }
            else
            {
                MessageBox.Show(this, "No tiene permisos para crear guias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool OperacionConfigurada()
        {
            if (!string.IsNullOrWhiteSpace(cromo.Properties.Settings.Default.centroOperacion))
                return true;
            MessageBox.Show(this, "Debe configurar una operación de ingreso para las guias en Archivo > Configuracion > Operacion", "Operacion de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void mnuCambiarEmpresa_Click(object sender, EventArgs e)
        {
            // Las ventanas abiertas tienen datos de la empresa actual: se cierran antes de cambiar
            if (MdiChildren.Length > 0)
            {
                if (MessageBox.Show(this, "Para cambiar de empresa se cerrarán las ventanas abiertas. ¿Desea continuar?", "Cambiar empresa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                foreach (Form childForm in MdiChildren)
                    childForm.Close();
                if (MdiChildren.Length > 0)
                    return;
            }

            using (var frmEmpresa = new FrmSeleccionarEmpresa())
            {
                if (frmEmpresa.ShowDialog(this) == DialogResult.OK)
                    ActualizarEstadoUsuario();
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            // Confirmar logout
            DialogResult resultado = MessageBox.Show(this,
                "¿Deseas cerrar la sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Logout();
            }
        }
    }
}
