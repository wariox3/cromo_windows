using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
namespace cromo
{
	public partial class FrmBuscarCondicion : Form
	{
        JavaScriptSerializer ser = new JavaScriptSerializer();

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
			General.CodigoCondicion = DgCondiciones.Rows[DgCondiciones.CurrentRow.Index].Cells[0].Value.ToString();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void FrmBuscarCondicion_Load(object sender, EventArgs e)
		{
            DgCondiciones.AutoGenerateColumns = false;
            LlenarDatosApi();
		}


        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"nombre\":\"" + TxtNombre.Text + "\",\"cliente\":\"" + General.CodigoCliente + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/condicion/buscar", parametrosJson);
            List<ApiCondicion> apiCondicionLista = ser.Deserialize<List<ApiCondicion>>(jsonRespuesta);
            DgCondiciones.DataSource = apiCondicionLista;

        }

		private void DgCondiciones_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.CodigoCondicion = DgCondiciones.Rows[DgCondiciones.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
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
