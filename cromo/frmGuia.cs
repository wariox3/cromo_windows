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
    public partial class frmGuia : Form
    {
        public frmGuia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BdCromo.ObtenerConexion();
            //MessageBox.Show("Conectado");
            DataSet ds = Utilidades.Ejecutar("SELECT guia.codigo_guia_pk FROM guia");
            
        }

        private void Guia_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frmBuscarCliente = new frmBuscarCliente();            
            frmBuscarCliente.ShowDialog();
            if (frmBuscarCliente.DialogResult == DialogResult.OK)
            {
                txtCodigoCliente.Text = frmBuscarCliente.dgClientes.Rows[frmBuscarCliente.dgClientes.CurrentRow.Index].Cells[0].Value.ToString();
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                frmBuscarCliente frmBuscarCliente = new frmBuscarCliente();
                frmBuscarCliente.ShowDialog();
                if (frmBuscarCliente.DialogResult == DialogResult.OK)
                {
                    txtCodigoCliente.Text = frmBuscarCliente.dgClientes.Rows[frmBuscarCliente.dgClientes.CurrentRow.Index].Cells[0].Value.ToString();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtCodigoCliente.Text = "";
        }
    }
}
