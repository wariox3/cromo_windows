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
			string sql = "SELECT * FROM tte_ciudad ";
			if(txtNombre.Text != "")
			{
				sql = sql + "WHERE nombre LIKE '%" + txtNombre.Text + "%'";
			}
			DataSet ds;
            string strSql = string.Format(sql);
            ds = Utilidades.Ejecutar(strSql);
            return ds;
        }

        private void frmBuscarCiudad_Load(object sender, EventArgs e)
        {
            dgCiudades.DataSource = LlenarDatos().Tables[0];            
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

		private void dgCiudades_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.codigoCiudad = dgCiudades.Rows[dgCiudades.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnFiltrar_Click(object sender, EventArgs e)
		{
			dgCiudades.DataSource = LlenarDatos().Tables[0];
		}

		private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				dgCiudades.DataSource = LlenarDatos().Tables[0];
			}
		}

		private void txtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Down)
			{
				dgCiudades.Focus();
			}
		}
	}
}
