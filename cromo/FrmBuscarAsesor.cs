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
    public partial class FrmBuscarAsesor : Form
    {

        public FrmBuscarAsesor()
        {
            InitializeComponent();
        }

        public void LlenarDatosApi()
        {
            DgAsesores.DataSource = CatalogoManager.Asesores.Where(a => CatalogoManager.Contiene(a.nombre, TxtNombre.Text)).ToList();
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
            if (DgAsesores.CurrentRow != null)
            {
                General.CodigoAsesor = DgAsesores.CurrentRow.Cells[0].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
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
