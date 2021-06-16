using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace cromo
{
    public partial class FrmBuscarRemitente : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        public FrmBuscarRemitente()
        {
            InitializeComponent();
        }

        private void FrmBuscarRemitente_Load(object sender, EventArgs e)
        {
            DgRemitentes.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"nombre\":\"" + TxtNombre.Text + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/remitente/buscar", parametrosJson);
            List<ApiRemitente> apiRemitenteLista = ser.Deserialize<List<ApiRemitente>>(jsonRespuesta);
            DgRemitentes.DataSource = apiRemitenteLista;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgRemitentes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DgRemitentes.Rows.Count > 0)
                {
                    General.CodigoRemitente = DgRemitentes.Rows[DgRemitentes.CurrentRow.Index].Cells[0].Value.ToString();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            LlenarDatosApi();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DgRemitentes.Rows.Count > 0)
            {
                General.CodigoRemitente = DgRemitentes.Rows[DgRemitentes.CurrentRow.Index].Cells[0].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DgRemitentes.Focus();
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
