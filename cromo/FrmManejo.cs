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
    public partial class FrmManejo : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        double porcentajeManejoMinimoUsuario = 0;
        double manejoMinimoUnidadMinimoUsuario = 0;
        double manejoMinimoDespachoMinimoUsuario = 0;

        public FrmManejo()
        {
            InitializeComponent();
        }

        private void FrmManejo_Load(object sender, EventArgs e)
        {
            TxtManejo.Text = General.Manejo.ToString();
            TxtManejoMinimoUnidad.Text = General.ManejoMinimoUnidad.ToString();
            TxtManejoMinioDespacho.Text = General.ManejoMinimoDespacho.ToString();
            string parametrosJson = "{\"usuario\":\"" + General.UsuarioActivo + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/usuario/configuracion", parametrosJson);
            ApiUsuarioConfigurcion apiUsuarioConfiguracion = ser.Deserialize<ApiUsuarioConfigurcion>(jsonRespuesta);
            if (apiUsuarioConfiguracion.error == false)
            {
                porcentajeManejoMinimoUsuario = apiUsuarioConfiguracion.porcentajeManejoMinimo;
                manejoMinimoUnidadMinimoUsuario = apiUsuarioConfiguracion.manejoMinimoUnidad;
                manejoMinimoDespachoMinimoUsuario = apiUsuarioConfiguracion.manejoMinimoDespacho;
            } else
            {
                MessageBox.Show(this, "El usuario no tiene configuracion para modificar parametros de manejo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtManejo.Text) >= porcentajeManejoMinimoUsuario)
            {
                if (Convert.ToDouble(TxtManejoMinimoUnidad.Text) >= manejoMinimoUnidadMinimoUsuario)
                {
                    if (Convert.ToDouble(TxtManejoMinioDespacho.Text) >= manejoMinimoDespachoMinimoUsuario)
                    {
                        General.Manejo = Convert.ToDouble(TxtManejo.Text);
                        General.ManejoMinimoUnidad = Convert.ToDouble(TxtManejoMinimoUnidad.Text);
                        General.ManejoMinimoDespacho = Convert.ToDouble(TxtManejoMinioDespacho.Text);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "El porcentaje de manejo minimo permitido para el usuario es " + manejoMinimoDespachoMinimoUsuario, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "El manejo minimo por unidad permitido para el usuario es " + manejoMinimoUnidadMinimoUsuario, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "El porcentaje de manejo minimo permitido para el usuario es " + porcentajeManejoMinimoUsuario, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
