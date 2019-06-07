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
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            txtCentroOperacion.Text = cromo.Properties.Settings.Default.centroOperacion;			
			txtCodigoCiudadOrigen.Text = cromo.Properties.Settings.Default.ciudadOrigen;
			txtRutaReportes.Text = cromo.Properties.Settings.Default.rutaReportes;
            ChkServidorManual.Checked = cromo.Properties.Settings.Default.servidorManual;
            TxtRutaServidorManual.Text = cromo.Properties.Settings.Default.rutaServidorManual;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cromo.Properties.Settings.Default.centroOperacion = txtCentroOperacion.Text;
			cromo.Properties.Settings.Default.ciudadOrigen = txtCodigoCiudadOrigen.Text;
			cromo.Properties.Settings.Default.rutaReportes = txtRutaReportes.Text;
            cromo.Properties.Settings.Default.servidorManual = ChkServidorManual.Checked;
            cromo.Properties.Settings.Default.rutaServidorManual = TxtRutaServidorManual.Text;
            cromo.Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

	}
}
