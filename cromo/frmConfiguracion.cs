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
            TxtCodigoCliente.Text = cromo.Properties.Settings.Default.codigoCliente;
            ChkBloquearFlete.Checked = cromo.Properties.Settings.Default.bloquearFlete;
            ChkBloquearManejo.Checked = cromo.Properties.Settings.Default.bloquearManejo;
            ChkOperadorLogistico.Checked = cromo.Properties.Settings.Default.operadorLogistico;
            ChkValidarProductoCliente.Checked = cromo.Properties.Settings.Default.validarProductoCliente;
            ChkValidarProductoLista.Checked = cromo.Properties.Settings.Default.validarProductoLista;
            ChkGuiaIngreso.Checked = cromo.Properties.Settings.Default.guiaIngreso;
            ChkGuiaRecogida.Checked = cromo.Properties.Settings.Default.guiaRecogida;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string operacion = txtCentroOperacion.Text.Trim();
            if (operacion != "")
            {
                try
                {
                    Fluor.GetDetalle("/tte/operacion/detalle/" + Uri.EscapeDataString(operacion));
                }
                catch (Exception ex)
                {
                    tabConfiguracion.SelectedTab = tbpOperacion;
                    txtCentroOperacion.Focus();
                    MessageBox.Show(this, "No se puede guardar la configuracion, la operacion '" + operacion + "' no es valida: " + Fluor.MensajeError(ex),
                        "Operacion de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string cliente = TxtCodigoCliente.Text.Trim();
            string errorCliente = null;
            if (cliente == "")
            {
                if (ChkOperadorLogistico.Checked)
                    errorCliente = "el operador logistico requiere el codigo del cliente";
            }
            else if (!int.TryParse(cliente, out int codigoCliente))
            {
                errorCliente = "el codigo del cliente '" + cliente + "' debe ser numerico";
            }
            else
            {
                try
                {
                    Fluor.GetDetalle("/gen/tercero/detalle/" + codigoCliente);
                }
                catch (Exception ex)
                {
                    errorCliente = "el cliente '" + cliente + "' no es valido: " + Fluor.MensajeError(ex);
                }
            }
            if (errorCliente != null)
            {
                tabConfiguracion.SelectedTab = tabOperador;
                TxtCodigoCliente.Focus();
                MessageBox.Show(this, "No se puede guardar la configuracion, " + errorCliente,
                    "Codigo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cromo.Properties.Settings.Default.centroOperacion = operacion;
            cromo.Properties.Settings.Default.codigoCliente = cliente;
            cromo.Properties.Settings.Default.bloquearFlete = ChkBloquearFlete.Checked;
            cromo.Properties.Settings.Default.bloquearManejo = ChkBloquearManejo.Checked;
            cromo.Properties.Settings.Default.operadorLogistico = ChkOperadorLogistico.Checked;
            cromo.Properties.Settings.Default.validarProductoCliente = ChkValidarProductoCliente.Checked;
            cromo.Properties.Settings.Default.validarProductoLista = ChkValidarProductoLista.Checked;
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
