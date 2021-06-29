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
    public partial class FrmManejo : Form
    {
        public FrmManejo()
        {
            InitializeComponent();
        }

        private void FrmManejo_Load(object sender, EventArgs e)
        {
            TxtManejo.Text = General.Manejo.ToString();
            TxtManejoMinimoUnidad.Text = General.ManejoMinimoUnidad.ToString();
            TxtManejoMinioDespacho.Text = General.ManejoMinimoDespacho.ToString();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtManejo.Text) >= General.PorcentajeManejoMinimo)
            {
                General.Manejo = Convert.ToDouble(TxtManejo.Text);
                General.ManejoMinimoUnidad = Convert.ToDouble(TxtManejoMinimoUnidad.Text);
                General.ManejoMinimoDespacho = Convert.ToDouble(TxtManejoMinioDespacho.Text);               
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this, "El porcentaje de manejo minimo permitido para el usuario es " + General.PorcentajeManejoMinimo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
