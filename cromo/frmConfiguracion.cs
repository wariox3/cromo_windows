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
			txtRutaReportes.Text = cromo.Properties.Settings.Default.rutaReportes;
            ChkServidorManual.Checked = cromo.Properties.Settings.Default.servidorManual;
            TxtRutaServidorManual.Text = cromo.Properties.Settings.Default.rutaServidorManual;
            TxtCodigoCliente.Text = cromo.Properties.Settings.Default.codigoCliente;
            ChkBloquearFlete.Checked = cromo.Properties.Settings.Default.bloquearFlete;
            ChkBloquearManejo.Checked = cromo.Properties.Settings.Default.bloquearManejo;
            ChkOperadorLogistico.Checked = cromo.Properties.Settings.Default.operadorLogistico;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cromo.Properties.Settings.Default.centroOperacion = txtCentroOperacion.Text;			
			cromo.Properties.Settings.Default.rutaReportes = txtRutaReportes.Text;
            cromo.Properties.Settings.Default.servidorManual = ChkServidorManual.Checked;
            cromo.Properties.Settings.Default.rutaServidorManual = TxtRutaServidorManual.Text;
            cromo.Properties.Settings.Default.codigoCliente = TxtCodigoCliente.Text;
            cromo.Properties.Settings.Default.bloquearFlete = ChkBloquearFlete.Checked;
            cromo.Properties.Settings.Default.bloquearManejo = ChkBloquearManejo.Checked;
            cromo.Properties.Settings.Default.operadorLogistico = ChkOperadorLogistico.Checked;
            cromo.Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
