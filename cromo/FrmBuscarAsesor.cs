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
    public partial class FrmBuscarAsesor : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmBuscarAsesor()
        {
            InitializeComponent();
        }

        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"nombre\":\"" + TxtNombre.Text + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/asesor/buscar", parametrosJson);
            List<ApiAsesor> apiAsesorLista = ser.Deserialize<List<ApiAsesor>>(jsonRespuesta);
            DgAsesores.DataSource = apiAsesorLista;
        }

        private void FrmBuscarAsesor_Load(object sender, EventArgs e)
        {
            DgAsesores.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DgAsesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                General.CodigoAsesor = DgAsesores.Rows[DgAsesores.CurrentRow.Index].Cells[0].Value.ToString();
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
            if (e.KeyCode == Keys.Down)
            {
                DgAsesores.Focus();
            }
        }
    }
}
