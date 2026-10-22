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

        double descuentoPesoMaximo = 0;

        public FrmDescuento()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {            
            if(Convert.ToDouble(TxtDescuento.Text)  <= descuentoPesoMaximo)
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
            ApiUsuarioConfigurcion apiUsuarioConfiguracion = CatalogoManager.UsuarioConfiguracion;
            if (apiUsuarioConfiguracion != null)
            {
                descuentoPesoMaximo = apiUsuarioConfiguracion.descuentoPesoMaximo;
            }
            else
            {
                MessageBox.Show(this, "El usuario no tiene configuracion para modificar parametros de descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
