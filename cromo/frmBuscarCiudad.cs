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
    public partial class FrmBuscarCiudad : Form
    {
        public FrmBuscarCiudad()
        {
            InitializeComponent();
        }

        public DataSet LlenarDatos()
        {
			string sql = "SELECT codigo_ciudad_pk, tte_ciudad.nombre as ciudad_nombre, tte_departamento.nombre as departamento_nombre FROM tte_ciudad LEFT JOIN tte_departamento ON codigo_departamento_fk = codigo_departamento_pk ";
			if(TxtNombre.Text != "")
			{
				sql = sql + "WHERE tte_ciudad.nombre LIKE '%" + TxtNombre.Text + "%'";
			}
			sql = sql + " limit 20";
			DataSet ds;
            string strSql = string.Format(sql);
            ds = Utilidades.Ejecutar(strSql);
            return ds;
        }

        private void FrmBuscarCiudad_Load(object sender, EventArgs e)
        {
            DgCiudades.DataSource = LlenarDatos().Tables[0];            
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
			DgCiudades.DataSource = LlenarDatos().Tables[0];
		}

		private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				DgCiudades.DataSource = LlenarDatos().Tables[0];
			}
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Down)
			{
				DgCiudades.Focus();
			}
		}

		private void DgCiudades_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
