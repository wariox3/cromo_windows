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
    public partial class FrmClienteNuevo : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmClienteNuevo()
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



        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarGuardar())
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();

                ApiCliente apiCliente = new ApiCliente();
                apiCliente.codigoIdentificacionFk = CboIdentificacion.SelectedValue.ToString();
                apiCliente.numeroIdentificacion = TxtNumeroIdentificacion.Text;
                apiCliente.codigoCiudadFk = CboCiudad.SelectedValue.ToString();
                apiCliente.nombreCorto = TxtNombreCorto.Text;
                apiCliente.nombre1 = TxtNombre1.Text;
                apiCliente.nombre2 = TxtNombre2.Text;
                apiCliente.apellido1 = TxtApellido1.Text;
                apiCliente.apellido2 = TxtApellido2.Text;
                apiCliente.direccion = TxtDireccion.Text;
                apiCliente.telefono = TxtTelefono.Text;
                apiCliente.correo = TxtCorreo.Text;
                apiCliente.codigoCondicionFk = General.CodigoCondicionGeneral.ToString();
                apiCliente.codigoOperacionFk = cromo.Properties.Settings.Default.centroOperacion;

                string parametrosJson = ser.Serialize(apiCliente);
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/cliente/nuevo", parametrosJson);
                ApiClienteRespuesta apiClienteRespuesta = ser.Deserialize<ApiClienteRespuesta>(jsonRespuesta);
                if (apiClienteRespuesta.error == null)
                {
                    MessageBox.Show(this, "El cliente se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    General.CodigoCliente = apiClienteRespuesta.codigoClientePk;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(this, "Ocurrio un error al guardar el cliente: " + apiClienteRespuesta.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                                                                                        
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmClienteNuevo_Load(object sender, EventArgs e)
        {
            string jsonRespuesta = ApiControlador.ApiPost("/general/api/windows/identificacion/lista", null);
            List<ApiIdentificacion> apiIdentificacionLista = ser.Deserialize<List<ApiIdentificacion>>(jsonRespuesta);
            CboIdentificacion.ValueMember = "codigoIdentificacionPk";
            CboIdentificacion.DisplayMember = "nombre";
            CboIdentificacion.DataSource = apiIdentificacionLista;

            jsonRespuesta = ApiControlador.ApiPost("/general/api/windows/ciudad/lista", null);
            List<ApiCiudad> apiCiudadLista = ser.Deserialize<List<ApiCiudad>>(jsonRespuesta);
            CboCiudad.ValueMember = "codigoCiudadPk";
            CboCiudad.DisplayMember = "nombre";
            CboCiudad.DataSource = apiCiudadLista;
        }
    }
}
