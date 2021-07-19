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
	public partial class FrmBuscarDestinatario : Form
	{
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmBuscarDestinatario()
		{
			InitializeComponent();
		}

		private void FrmBuscarDestinatario_Load(object sender, EventArgs e)
		{
            DgDestinatarios.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"nombre\":\"" + TxtNombre.Text + "\",\"cliente\":\"" + General.CodigoCliente + "\"}";          
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/destinatario/buscar", parametrosJson);
            List<ApiDestinatario> apiDestinatarioLista = ser.Deserialize<List<ApiDestinatario>>(jsonRespuesta);
            DgDestinatarios.DataSource = apiDestinatarioLista;

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
    }
}
