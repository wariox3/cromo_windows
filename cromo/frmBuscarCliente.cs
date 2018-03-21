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
            DataSet ds;
            string strSql = string.Format("SELECT * FROM cliente");
            ds = Utilidades.Ejecutar(strSql);
            return ds;
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            dgClientes.DataSource = LlenarDatos().Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgClientes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgClientes_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
