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
	public partial class FrmBuscarCondicion : Form
	{
		public FrmBuscarCondicion()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnSeleccionar_Click(object sender, EventArgs e)
		{
			General.CodigoCondicion = DgCondiciones.Rows[DgCondiciones.CurrentRow.Index].Cells[0].Value.ToString();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void FrmBuscarCondicion_Load(object sender, EventArgs e)
		{
			DgCondiciones.DataSource = LlenarDatos().Tables[0];
		}

		public DataSet LlenarDatos()
		{
			string sql = "SELECT codigo_condicion_fk, tte_condicion.nombre " +
				"FROM tte_cliente_condicion " +
				"LEFT JOIN  tte_condicion ON tte_cliente_condicion.codigo_condicion_fk = tte_condicion.codigo_condicion_pk " +
				"WHERE codigo_cliente_fk =" + General.CodigoCliente;
			if (TxtNombre.Text != "")
			{
				sql = sql + " AND tte_condicion.nombre LIKE '%" + TxtNombre.Text + "%'";
			}
			sql = sql + " limit 20";
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			return ds;
		}

		private void DgCondiciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void DgCondiciones_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.CodigoCondicion = DgCondiciones.Rows[DgCondiciones.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				DgCondiciones.Focus();
			}
		}

		private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				DgCondiciones.DataSource = LlenarDatos().Tables[0];
			}
		}
	}
}
