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
	public partial class frmDevolverNumero : Form
	{
		public frmDevolverNumero()
		{
			InitializeComponent();
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if(Convert.ToInt32(txtNumero.Text) != 0)
			{
				General.numeroGuia = Convert.ToInt32(txtNumero.Text);
				DialogResult = DialogResult.OK;
				Close();
			} else
			{
				MessageBox.Show("Debe serleccionar el numero para la guia");
			}
		}

		private void frmDevolverNumero_Load(object sender, EventArgs e)
		{
			if(General.numeroGuia != 0)
			{
				txtNumero.Text = (General.numeroGuia + 1).ToString();
			}			
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			General.numeroGuia = 0;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void txtNumero_Enter(object sender, EventArgs e)
		{
			txtNumero.SelectionStart = 0;
			txtNumero.SelectionLength = txtNumero.Text.Length;
		}
	}
}
