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
                if (!int.TryParse(CboCiudad.SelectedValue?.ToString(), out int codigoCiudad))
                {
                    MessageBox.Show(this, "Debe seleccionar una ciudad valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CboCiudad.Focus();
                    return;
                }

                var tercero = new Dictionary<string, object>
                {
                    { "codigo_identificacion_fk", CboIdentificacion.SelectedValue.ToString() },
                    { "numero_identificacion", TxtNumeroIdentificacion.Text.Trim() },
                    { "codigo_ciudad_fk", codigoCiudad },
                    { "codigo_asesor_fk", int.TryParse(CboAsesor.SelectedValue?.ToString(), out int asesor) ? (int?)asesor : null },
                    { "nombre_corto", Valor(TxtNombreCorto) },
                    { "nombre_extendido", Valor(TxtNombreExtendido) },
                    { "codigo_tipo_persona_fk", CboTipoPersona.SelectedValue?.ToString() },
                    { "codigo_regimen_fk", CboRegimen.SelectedValue?.ToString() },
                    { "codigo_postal", Valor(TxtCodigoPostal) },
                    { "nombre1", Valor(TxtNombre1) },
                    { "nombre2", Valor(TxtNombre2) },
                    { "apellido1", Valor(TxtApellido1) },
                    { "apellido2", Valor(TxtApellido2) },
                    { "direccion", Valor(TxtDireccion) },
                    { "telefono", Valor(TxtTelefono) },
                    { "correo", Valor(TxtCorreo) },
                    { "codigo_condicion_fk", General.CodigoCondicionGeneral != 0 ? (int?)General.CodigoCondicionGeneral : null },
                    { "codigo_operacion_fk", string.IsNullOrWhiteSpace(cromo.Properties.Settings.Default.centroOperacion) ? null : cromo.Properties.Settings.Default.centroOperacion.Trim() },
                    { "cliente", true },
                    { "guia_pago_credito", false },
                    { "guia_pago_contado", false },
                    { "guia_pago_destino", false },
                    { "guia_pago_cortesia", false },
                    { "guia_pago_recogida", false }
                };

                try
                {
                    var respuesta = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(
                        Fluor.Post("/gen/tercero/nuevo", new JavaScriptSerializer().Serialize(tercero)));
                    MessageBox.Show(this, "El cliente se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    General.CodigoCliente = Fluor.Texto(respuesta, "codigo_tercero_pk");
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio un error al guardar el cliente: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string Valor(TextBox caja)
        {
            return string.IsNullOrWhiteSpace(caja.Text) ? null : caja.Text.Trim();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {        
            Close();
        }

        private void FrmClienteNuevo_Load(object sender, EventArgs e)
        {
            CboIdentificacion.ValueMember = "codigoIdentificacionPk";
            CboIdentificacion.DisplayMember = "nombre";
            CboIdentificacion.DataSource = CatalogoManager.Identificaciones;

            CboCiudad.ValueMember = "codigoCiudadPk";
            CboCiudad.DisplayMember = "nombre";
            CboCiudad.DataSource = CatalogoManager.CiudadesGenerales;

            CboAsesor.ValueMember = "codigoAsesorPk";
            CboAsesor.DisplayMember = "nombre";
            CboAsesor.DataSource = CatalogoManager.Asesores;

            CboTipoPersona.ValueMember = "codigoTipoPersonaPk";
            CboTipoPersona.DisplayMember = "nombre";
            CboTipoPersona.DataSource = CatalogoManager.TiposPersona;

            CboRegimen.ValueMember = "codigoRegimenPk";
            CboRegimen.DisplayMember = "nombre";
            CboRegimen.DataSource = CatalogoManager.Regimenes;

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
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
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
