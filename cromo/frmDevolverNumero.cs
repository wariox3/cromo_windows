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
	public partial class FrmDevolverNumero : Form
	{
		public FrmDevolverNumero()
		{
			InitializeComponent();
		}

		private void BtnAceptar_Click(object sender, EventArgs e)
		{
			if(Convert.ToInt32(TxtNumero.Text) != 0)
			{
				General.NumeroGuia = Convert.ToInt32(TxtNumero.Text);
				DialogResult = DialogResult.OK;
				Close();
			} else
			{
				MessageBox.Show("Debe seleccionar el numero para la guia");
			}
		}



		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			General.NumeroGuia = 0;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void TxtNumero_Enter(object sender, EventArgs e)
		{
			TxtNumero.SelectionStart = 0;
			TxtNumero.SelectionLength = TxtNumero.Text.Length;
		}

		private void TxtNumero_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
