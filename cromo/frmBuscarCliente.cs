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
    public partial class FrmBuscarCliente : Form
    {
        public FrmBuscarCliente()
        {
            InitializeComponent();
        }

        public DataSet LlenarDatos()
        {
			string sql = "SELECT * FROM tte_cliente";
			if(TxtNombre.Text != "")
			{
				sql = sql + " WHERE nombre_corto LIKE '%" + TxtNombre.Text + "%'";
			}
			sql = sql + " limit 20";
			DataSet ds;
            string strSql = string.Format(sql);
            ds = Utilidades.Ejecutar(strSql);
            return ds;
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            DgClientes.DataSource = LlenarDatos().Tables[0];
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
			DgClientes.DataSource = LlenarDatos().Tables[0];
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
				DgClientes.DataSource = LlenarDatos().Tables[0];
			}
		}

	}
}
