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
	public partial class FrmBuscarDestinatario : Form
	{
		public FrmBuscarDestinatario()
		{
			InitializeComponent();
		}

		private void FrmBuscarDestinatario_Load(object sender, EventArgs e)
		{
            DgDestinatarios.AutoGenerateColumns = false;
            DgDestinatarios.DataSource = LlenarDatos().Tables[0];
		}

		public DataSet LlenarDatos()
		{
			string sql = "SELECT * FROM tte_destinatario";
			if (TxtNombre.Text != "")
			{
				sql = sql + " WHERE nombre_corto LIKE '%" + TxtNombre.Text + "%'";
			}
			sql = sql + " limit 20";
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			return ds;
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnSeleccionar_Click(object sender, EventArgs e)
		{
			General. CodigoDestinatario = DgDestinatarios.Rows[DgDestinatarios.CurrentRow.Index].Cells[0].Value.ToString();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void DgDestinatarios_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.CodigoDestinatario = DgDestinatarios.Rows[DgDestinatarios.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void BtnFiltrar_Click(object sender, EventArgs e)
		{
			DgDestinatarios.DataSource = LlenarDatos().Tables[0];
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
				DgDestinatarios.DataSource = LlenarDatos().Tables[0];
			}
		}
	}
}
