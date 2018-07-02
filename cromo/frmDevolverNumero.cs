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
				MessageBox.Show("Debe serleccionar el numero para la guia");
			}
		}

		private void FrmDevolverNumero_Load(object sender, EventArgs e)
		{
			if(General.NumeroGuia != 0)
			{
				TxtNumero.Text = (General.NumeroGuia + 1).ToString();
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
	}
}
