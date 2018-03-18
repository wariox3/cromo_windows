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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cromo.Properties.Settings.Default.centroOperacion = txtCentroOperacion.Text;
            cromo.Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
