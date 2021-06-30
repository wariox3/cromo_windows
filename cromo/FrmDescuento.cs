using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace cromo
{
    public partial class FrmDescuento : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

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
            string parametrosJson = "{\"usuario\":\"" + General.UsuarioActivo + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/usuario/configuracion", parametrosJson);
            ApiUsuarioConfigurcion apiUsuarioConfiguracion = ser.Deserialize<ApiUsuarioConfigurcion>(jsonRespuesta);
            if (apiUsuarioConfiguracion.error == false)
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
