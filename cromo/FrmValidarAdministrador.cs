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
	public partial class FrmValidarAdministrador : Form
	{
		public FrmValidarAdministrador()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnValidar_Click(object sender, EventArgs e)
		{
			if(TxtClave.Text == "smt489")
			{
				DialogResult = DialogResult.OK;
				Close();
			} else
			{
				MessageBox.Show("Clave incorrecta");
			}
		}
	}
}
