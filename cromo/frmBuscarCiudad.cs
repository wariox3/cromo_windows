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
    public partial class FrmBuscarCiudad : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmBuscarCiudad()
        {
            InitializeComponent();
        }

        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"nombre\":\"" + TxtNombre.Text + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/buscar", parametrosJson);
            List<ApiCiudad> apiCiudadLista = ser.Deserialize<List<ApiCiudad>>(jsonRespuesta);
            DgCiudades.DataSource = apiCiudadLista;

        }

        private void FrmBuscarCiudad_Load(object sender, EventArgs e)
        {
            DgCiudades.AutoGenerateColumns = false;
            LlenarDatosApi();            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSeleccionar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

		private void DgCiudades_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.CodigoCiudad = DgCiudades.Rows[DgCiudades.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void BtnFiltrar_Click(object sender, EventArgs e)
		{
            LlenarDatosApi();
		}

		private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
                LlenarDatosApi();
			}
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Down)
			{
				DgCiudades.Focus();
			}
		}

	}
}
