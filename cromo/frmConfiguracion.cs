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
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            txtCentroOperacion.Text = cromo.Properties.Settings.Default.centroOperacion;
			txtServidor.Text = cromo.Properties.Settings.Default.servidorBaseDatos;
			txtUsuario.Text = cromo.Properties.Settings.Default.usuarioBaseDatos;
			txtClave.Text = cromo.Properties.Settings.Default.claveBaseDatos;
			txtBaseDatos.Text = cromo.Properties.Settings.Default.baseDatos;
			txtCodigoCiudadOrigen.Text = cromo.Properties.Settings.Default.ciudadOrigen;
		}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cromo.Properties.Settings.Default.centroOperacion = txtCentroOperacion.Text;
			cromo.Properties.Settings.Default.servidorBaseDatos = txtServidor.Text;
			cromo.Properties.Settings.Default.usuarioBaseDatos = txtUsuario.Text;
			cromo.Properties.Settings.Default.claveBaseDatos = txtClave.Text;
			cromo.Properties.Settings.Default.baseDatos = txtBaseDatos.Text;
			cromo.Properties.Settings.Default.ciudadOrigen = txtCodigoCiudadOrigen.Text;
			cromo.Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
