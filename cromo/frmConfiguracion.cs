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
            TxtTokenServidorManual.Text = cromo.Properties.Settings.Default.tokenServidorManual;
            TxtCodigoCliente.Text = cromo.Properties.Settings.Default.codigoCliente;
            ChkBloquearFlete.Checked = cromo.Properties.Settings.Default.bloquearFlete;
            ChkBloquearManejo.Checked = cromo.Properties.Settings.Default.bloquearManejo;
            ChkOperadorLogistico.Checked = cromo.Properties.Settings.Default.operadorLogistico;
            ChkValidarProductoCliente.Checked = cromo.Properties.Settings.Default.validarProductoCliente;
            ChkValidarProductoLista.Checked = cromo.Properties.Settings.Default.validarProductoLista;
            TxtUsuarioServidorManual.Text = cromo.Properties.Settings.Default.usuarioServidorManual;
            TxtClaveServidorManual.Text = cromo.Properties.Settings.Default.claveServidorManual;
            ChkGuiaIngreso.Checked = cromo.Properties.Settings.Default.guiaIngreso;
            ChkGuiaRecogida.Checked = cromo.Properties.Settings.Default.guiaRecogida;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cromo.Properties.Settings.Default.centroOperacion = txtCentroOperacion.Text;			
			cromo.Properties.Settings.Default.rutaReportes = txtRutaReportes.Text;
            cromo.Properties.Settings.Default.servidorManual = ChkServidorManual.Checked;
            cromo.Properties.Settings.Default.rutaServidorManual = TxtRutaServidorManual.Text;
            cromo.Properties.Settings.Default.tokenServidorManual = TxtTokenServidorManual.Text;
            cromo.Properties.Settings.Default.codigoCliente = TxtCodigoCliente.Text;
            cromo.Properties.Settings.Default.bloquearFlete = ChkBloquearFlete.Checked;
            cromo.Properties.Settings.Default.bloquearManejo = ChkBloquearManejo.Checked;
            cromo.Properties.Settings.Default.operadorLogistico = ChkOperadorLogistico.Checked;
            cromo.Properties.Settings.Default.validarProductoCliente = ChkValidarProductoCliente.Checked;
            cromo.Properties.Settings.Default.validarProductoLista = ChkValidarProductoLista.Checked;
            cromo.Properties.Settings.Default.usuarioServidorManual = TxtUsuarioServidorManual.Text;
            cromo.Properties.Settings.Default.claveServidorManual = TxtClaveServidorManual.Text;
            cromo.Properties.Settings.Default.guiaIngreso = ChkGuiaIngreso.Checked;
            cromo.Properties.Settings.Default.guiaRecogida = ChkGuiaRecogida.Checked;
            cromo.Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
