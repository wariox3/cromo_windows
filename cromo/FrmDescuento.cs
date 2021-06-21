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
    public partial class FrmDescuento : Form
    {
        public FrmDescuento()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {            
            if(Convert.ToDouble(TxtDescuento.Text)  <= General.DescuentoPesoMaximo)
            {
                General.Descuento = Convert.ToDouble(TxtDescuento.Text);
                DialogResult = DialogResult.OK;
                Close();                
            } else
            {
                MessageBox.Show(this, "El descuento maximo permitido para el usuario es " + General.DescuentoPesoMaximo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDescuento_Load(object sender, EventArgs e)
        {

            TxtDescuento.Text = General.Descuento.ToString();
        }
    }
}
