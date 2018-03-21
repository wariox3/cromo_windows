using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;
namespace cromo
{
    public partial class frmBuscarCiudad : Form
    {
        public frmBuscarCiudad()
        {
            InitializeComponent();
        }

        public DataSet LlenarDatos()
        {
            DataSet ds;
            string strSql = string.Format("SELECT * FROM ciudad");
            ds = Utilidades.Ejecutar(strSql);
            return ds;
        }

        private void frmBuscarCiudad_Load(object sender, EventArgs e)
        {
            dgCiudades.DataSource = LlenarDatos().Tables[0];
            dgCiudades.Focus();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgCiudades_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
