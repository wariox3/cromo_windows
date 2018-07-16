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
	public partial class FrmDevolverGuiaCodigo : Form
	{
		public FrmDevolverGuiaCodigo()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			General.CodigoGuia = 0;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void BtnAceptar_Click(object sender, EventArgs e)
		{
			if(TxtCodigoGuia.Text != "")
			{
				if (Convert.ToInt32(TxtCodigoGuia.Text) != 0)
				{
					General.CodigoGuia = Convert.ToInt32(TxtCodigoGuia.Text);
					DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					MessageBox.Show("Debe seleccionar el numero para la guia");
				}
			} else
			{
				MessageBox.Show("Debe digitar un codigo de guia");
			}
		}

		private void TxtCodigoGuia_Enter(object sender, EventArgs e)
		{
			TxtCodigoGuia.SelectionStart = 0;
			TxtCodigoGuia.SelectionLength = TxtCodigoGuia.Text.Length;
		}
	}
}
