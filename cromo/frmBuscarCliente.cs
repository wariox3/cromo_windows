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
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        public DataSet LlenarDatos()
        {
			string sql = "SELECT * FROM tte_cliente";
			if(txtNombre.Text != "")
			{
				sql = sql + " WHERE nombre_corto LIKE '%" + txtNombre.Text + "%'";
			}
			DataSet ds;
            string strSql = string.Format(sql);
            ds = Utilidades.Ejecutar(strSql);
            return ds;
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            dgClientes.DataSource = LlenarDatos().Tables[0];
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
			General.codigoCliente = dgClientes.Rows[dgClientes.CurrentRow.Index].Cells[0].Value.ToString(); 
			DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


		private void dgClientes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.codigoCliente = dgClientes.Rows[dgClientes.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnFiltrar_Click(object sender, EventArgs e)
		{
			dgClientes.DataSource = LlenarDatos().Tables[0];
		}

		private void txtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Down)
			{
				dgClientes.Focus();
			}
		}

		private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				dgClientes.DataSource = LlenarDatos().Tables[0];
			}
		}

		private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
