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
    public partial class FrmBuscarCliente : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmBuscarCliente()
        {
            InitializeComponent();
        }

        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"nombre\":\"" + TxtNombre.Text + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/cliente/buscar", parametrosJson);
            List<ApiCliente> apiClienteLista = ser.Deserialize<List<ApiCliente>>(jsonRespuesta);
            DgClientes.DataSource = apiClienteLista;
            
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            DgClientes.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
			General.CodigoCliente = DgClientes.Rows[DgClientes.CurrentRow.Index].Cells[0].Value.ToString(); 
			DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void DgClientes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.CodigoCliente = DgClientes.Rows[DgClientes.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void BtnFiltrar_Click(object sender, EventArgs e)
		{
            LlenarDatosApi();
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Down)
			{
				DgClientes.Focus();
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
