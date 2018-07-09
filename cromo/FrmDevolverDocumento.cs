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
	public partial class FrmDevolverDocumento : Form
	{
		public FrmDevolverDocumento()
		{
			InitializeComponent();
		}

		private void BtnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtDocumento.Text != "")
			{
				General.DocumentoCliente = TxtDocumento.Text;
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show("Debe seleccionar el documento");
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			General.DocumentoCliente = "";
			DialogResult = DialogResult.OK;
			Close();
		}

		private void FrmDevolverDocumento_Load(object sender, EventArgs e)
		{

		}
	}
}
