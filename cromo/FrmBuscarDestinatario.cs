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
	public partial class FrmBuscarDestinatario : Form
	{

        public FrmBuscarDestinatario()
		{
			InitializeComponent();
		}

		private void FrmBuscarDestinatario_Load(object sender, EventArgs e)
		{
            DgDestinatarios.AutoGenerateColumns = false;
            ChkTodosClientes.Checked = cromo.Properties.Settings.Default.destinatarioTodosClientes;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            var filtros = new Dictionary<string, object>
            {
                { "size", 200 },
                { "nombre_corto", TxtNombre.Text },
                { "numero_identificacion", TxtNumeroIdentificacion.Text },
                { "estado_inactivo", "false" }
            };
            if (!ChkTodosClientes.Checked && int.TryParse(General.CodigoCliente?.Trim(), out int codigoCliente))
                filtros["codigo_tercero_fk"] = codigoCliente;

            try
            {
                DgDestinatarios.DataSource = Fluor.GetLista("/tte/destinatario/lista", filtros)
                    .Select(d => new ApiDestinatario
                    {
                        codigoDestinatarioPk = Fluor.Texto(d, "codigo_destinatario_pk"),
                        numeroIdentificacion = Fluor.Texto(d, "numero_identificacion"),
                        nombreCorto = Fluor.Texto(d, "nombre_corto"),
                        direccion = Fluor.Texto(d, "direccion"),
                        telefono = Fluor.Texto(d, "telefono"),
                        ciudadNombre = Fluor.Texto(d, "ciudad_nombre"),
                        codigoTerceroFk = Fluor.Texto(d, "codigo_tercero_fk")
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudieron consultar los destinatarios: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnSeleccionar_Click(object sender, EventArgs e)
		{
            if(DgDestinatarios.Rows.Count > 0)
            {                
                General.CodigoDestinatario = DgDestinatarios.Rows[DgDestinatarios.CurrentRow.Index].Cells[0].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

		private void DgDestinatarios_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                if (DgDestinatarios.Rows.Count > 0)
                {
                    General.CodigoDestinatario = DgDestinatarios.Rows[DgDestinatarios.CurrentRow.Index].Cells[0].Value.ToString();
                    DialogResult = DialogResult.OK;
                    Close();
                }
			}
		}

		private void BtnFiltrar_Click(object sender, EventArgs e)
		{
            LlenarDatosApi();
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				DgDestinatarios.Focus();
			}
		}

		private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
                LlenarDatosApi();
            }
		}

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmDestinatarioNuevo frmDestinatarioNuevo = new FrmDestinatarioNuevo();
            frmDestinatarioNuevo.ShowDialog();
            if (frmDestinatarioNuevo.DialogResult == DialogResult.OK)
            {
                TxtNombre.Text = General.NombreDestinatario;
                LlenarDatosApi();
            }
        }

        private void ChkTodosClientes_CheckedChanged(object sender, EventArgs e)
        {
            cromo.Properties.Settings.Default.destinatarioTodosClientes = ChkTodosClientes.Checked;
            cromo.Properties.Settings.Default.Save();
        }

        private void TxtNumeroIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DgDestinatarios.Focus();
            }
        }

        private void TxtNumeroIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                LlenarDatosApi();
            }
        }
    }
}
