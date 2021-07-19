using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace cromo
{
    public partial class FrmDestinatarioNuevo : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmDestinatarioNuevo()
        {
            InitializeComponent();
        }

        public bool ValidarGuardar()
        {
            if (TxtNumeroIdentificacion.Text == "")
            {
                TxtNumeroIdentificacion.Focus();
                return false;
            }
            else
            {
                if (TxtNombreCorto.Text == "")
                {
                    TxtNombreCorto.Focus();
                    return false;
                }
                else
                {
                    if (TxtDireccion.Text == "")
                    {
                        TxtDireccion.Focus();
                        return false;
                    }
                    else
                    {
                        if (CboIdentificacion.SelectedIndex < 0)
                        {
                            CboIdentificacion.Focus();
                            return false;
                        }
                        else
                        {
                            if (CboIdentificacion.SelectedIndex < 0)
                            {
                                CboIdentificacion.Focus();
                                return false;
                            }
                            else
                            {
                                if (TxtTelefono.Text == "")
                                {
                                    TxtTelefono.Focus();
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FrmDestinatarioNuevo_Load(object sender, EventArgs e)
        {
            string jsonRespuesta = ApiControlador.ApiPost("/general/api/windows/identificacion/lista", null);
            List<ApiIdentificacion> apiIdentificacionLista = ser.Deserialize<List<ApiIdentificacion>>(jsonRespuesta);
            CboIdentificacion.ValueMember = "codigoIdentificacionPk";
            CboIdentificacion.DisplayMember = "nombre";
            CboIdentificacion.DataSource = apiIdentificacionLista;

            jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/lista", null);
            List<ApiCiudad> apiCiudadLista = ser.Deserialize<List<ApiCiudad>>(jsonRespuesta);
            CboCiudad.ValueMember = "codigoCiudadPk";
            CboCiudad.DisplayMember = "nombre";
            CboCiudad.DataSource = apiCiudadLista;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarGuardar())
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();

                ApiDestinatario apiDestinatario = new ApiDestinatario();
                apiDestinatario.codigoIdentificacionFk = CboIdentificacion.SelectedValue.ToString();
                apiDestinatario.numeroIdentificacion = TxtNumeroIdentificacion.Text;
                apiDestinatario.codigoCiudadFk = CboCiudad.SelectedValue.ToString();
                apiDestinatario.nombreCorto = TxtNombreCorto.Text;
                apiDestinatario.nombre1 = TxtNombre1.Text;
                apiDestinatario.nombre2 = TxtNombre2.Text;
                apiDestinatario.apellido1 = TxtApellido1.Text;
                apiDestinatario.apellido2 = TxtApellido2.Text;
                apiDestinatario.direccion = TxtDireccion.Text;
                apiDestinatario.telefono = TxtTelefono.Text;
                apiDestinatario.correo = TxtCorreo.Text;
                if(General.CodigoCliente != "")
                {
                    apiDestinatario.codigoTerceroFk = General.CodigoCliente;
                }

                string parametrosJson = ser.Serialize(apiDestinatario);
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/destinatario/nuevo", parametrosJson);
                ApiDestinatarioRespuesta apiDestinatarioRespuesta = ser.Deserialize<ApiDestinatarioRespuesta>(jsonRespuesta);
                if (apiDestinatarioRespuesta.error == null)
                {
                    MessageBox.Show(this, "El destinatario se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    General.CodigoDestinatario = apiDestinatarioRespuesta.codigoDestinatarioPk;
                    General.NombreDestinatario = TxtNombreCorto.Text;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(this, "Ocurrio un error al guardar el destinatario: " + apiDestinatarioRespuesta.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
