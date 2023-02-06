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
    public partial class FrmAnularManifiestoMotivo : Form
    {
        public FrmAnularManifiestoMotivo()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if(CboMotivo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un motivo");
            } else
            {
                switch (CboMotivo.SelectedIndex)
                {
                    case 0:
                        General.CodigoMotivo = "D";
                        break;
                    case 1:
                        General.CodigoMotivo = "S";
                        break;
                    case 2:
                        General.CodigoMotivo = "R";
                        break;
                    case 3:
                        General.CodigoMotivo = "T";
                        break;
                    case 4:
                        General.CodigoMotivo = "G";
                        break;
                    case 5:
                        General.CodigoMotivo = "C";
                        break;
                    case 6:
                        General.CodigoMotivo = "V";
                        break;
                    default:
                        General.CodigoMotivo = "D";
                        break;
                }             
                DialogResult = DialogResult.OK;
                Close();
            }                           
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
