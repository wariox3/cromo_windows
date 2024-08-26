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
using System.Globalization;
using System.Text.RegularExpressions;

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
                    if (TxtNombreExtendido.Text == "")
                    {
                        TxtNombreExtendido.Focus();
                        return false;
                    } else
                    {
                        if (TxtDireccion.Text == "")
                        {
                            TxtDireccion.Focus();
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
                                            if (TxtCorreo.Text == "")
                                            {
                                                TxtCorreo.Focus();
                                                return false;
                                            }
                                            else
                                            {
                                                if (!IsValidEmail(TxtCorreo.Text))
                                                {
                                                    MessageBox.Show(this, "Debe digitar un correo electronico valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    TxtCorreo.Focus();
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
                apiCliente.codigoAsesorFk = CboAsesor.SelectedValue.ToString();
                apiCliente.nombreCorto = TxtNombreCorto.Text;
                apiCliente.nombreExtendido = TxtNombreExtendido.Text;
                apiCliente.nombre1 = TxtNombre1.Text;
                apiCliente.nombre2 = TxtNombre2.Text;
                apiCliente.apellido1 = TxtApellido1.Text;
                apiCliente.apellido2 = TxtApellido2.Text;
                apiCliente.direccion = TxtDireccion.Text;
                apiCliente.telefono = TxtTelefono.Text;
                apiCliente.correo = TxtCorreo.Text;
                apiCliente.codigoCondicionFk = General.CodigoCondicionGeneral.ToString();
                apiCliente.codigoOperacionFk = cromo.Properties.Settings.Default.centroOperacion;         
                apiCliente.codigoTipoPersonaFk = CboTipoPersona.SelectedValue.ToString();
                apiCliente.codigoRegimenFk = CboRegimen.SelectedValue.ToString();
                apiCliente.codigoPostal = TxtCodigoPostal.Text;
                apiCliente.usuario = General.UsuarioActivo;

                string parametrosJson = ser.Serialize(apiCliente);
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/cliente/nuevo", parametrosJson);
                ApiClienteRespuesta apiClienteRespuesta = ser.Deserialize<ApiClienteRespuesta>(jsonRespuesta);
                if (apiClienteRespuesta.error == null)
                {
                    MessageBox.Show(this, "El cliente se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    General.CodigoCliente = apiClienteRespuesta.codigoTerceroPk;
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

            jsonRespuesta = ApiControlador.ApiPost("/general/api/windows/asesor/lista", null);
            List<ApiAsesor> apiAsesorLista = ser.Deserialize<List<ApiAsesor>>(jsonRespuesta);
            CboAsesor.ValueMember = "codigoAsesorPk";
            CboAsesor.DisplayMember = "nombre";
            CboAsesor.DataSource = apiAsesorLista;

            List<TipoPersona> listaTipoPersona = new List<TipoPersona>();
            listaTipoPersona.Add(new TipoPersona() { codigoTipoPersonaPk = "J", nombre = "JURIDICA" });
            listaTipoPersona.Add(new TipoPersona() { codigoTipoPersonaPk = "N", nombre = "NATURAL" });
            CboTipoPersona.DataSource = listaTipoPersona;
            CboTipoPersona.ValueMember = "codigoTipoPersonaPk";
            CboTipoPersona.DisplayMember = "nombre";
            CboTipoPersona.SelectedIndex = 0;

            List<Regimen> listaRegimen = new List<Regimen>();
            listaRegimen.Add(new Regimen() { codigoRegimenPk = "O", nombre = "ORDINARIO COMUN" });
            listaRegimen.Add(new Regimen() { codigoRegimenPk = "S", nombre = "SIMPLE" });
            CboRegimen.DataSource = listaRegimen;
            CboRegimen.ValueMember = "codigoRegimenPk";
            CboRegimen.DisplayMember = "nombre";
            CboRegimen.SelectedIndex = 0;

        }

        private void TxtNumeroIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
