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
	public partial class FrmBuscarCondicion : Form
	{

        public FrmBuscarCondicion()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnSeleccionar_Click(object sender, EventArgs e)
		{
            if(DgCondiciones.Rows.Count > 0)
            {
                General.CodigoCondicion = DgCondiciones.Rows[DgCondiciones.CurrentRow.Index].Cells[0].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
		}

		private void FrmBuscarCondicion_Load(object sender, EventArgs e)
		{
            DgCondiciones.AutoGenerateColumns = false;
            LlenarDatosApi();
		}


        private List<ApiCondicion> condiciones;

        // /tte/cliente-condicion/buscar no filtra por nombre: se traen las del cliente y se filtra en memoria
        public void LlenarDatosApi()
        {
            if (condiciones == null)
            {
                var filtros = new Dictionary<string, object>();
                if (int.TryParse(General.CodigoCliente?.Trim(), out int codigoCliente))
                    filtros["codigo_tercero_fk"] = codigoCliente;

                try
                {
                    condiciones = Fluor.GetLista("/tte/cliente-condicion/buscar", filtros)
                        .Select(c => new ApiCondicion
                        {
                            codigoCondicionFk = Fluor.Texto(c, "codigo_condicion_fk"),
                            nombre = Fluor.Texto(c, "condicion_nombre")
                        })
                        .GroupBy(c => c.codigoCondicionFk)
                        .Select(g => g.First())
                        .ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudieron consultar las condiciones: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DgCondiciones.DataSource = condiciones.Where(c => CatalogoManager.Contiene(c.nombre, TxtNombre.Text)).ToList();
        }

		private void DgCondiciones_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                if (DgCondiciones.Rows.Count > 0)
                {
                    General.CodigoCondicion = DgCondiciones.Rows[DgCondiciones.CurrentRow.Index].Cells[0].Value.ToString();
                    DialogResult = DialogResult.OK;
                    Close();
                }
			}
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				DgCondiciones.Focus();
			}
		}

		private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
                LlenarDatosApi();
            }
		}
	}
}
