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
            // Usar catálogos cargados en memoria en lugar de consultar API
            // Identificaciones
            CboIdentificacion.ValueMember = "codigoIdentificacionPk";
            CboIdentificacion.DisplayMember = "nombre";
            CboIdentificacion.DataSource = CatalogoManager.Identificaciones;

            // Ciudades
            CboCiudad.ValueMember = "codigoCiudadPk";
            CboCiudad.DisplayMember = "nombre";
            CboCiudad.DataSource = CatalogoManager.Ciudades;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarGuardar())
            {
                int? codigoTercero = null;
                if (int.TryParse(General.CodigoCliente?.Trim(), out int codigo))
                    codigoTercero = codigo;

                var destinatario = new
                {
                    codigo_identificacion_fk = CboIdentificacion.SelectedValue.ToString(),
                    numero_identificacion = TxtNumeroIdentificacion.Text.Trim(),
                    codigo_ciudad_fk = CboCiudad.SelectedValue?.ToString(),
                    codigo_tercero_fk = codigoTercero,
                    nombre_corto = Valor(TxtNombreCorto),
                    nombre1 = Valor(TxtNombre1),
                    nombre2 = Valor(TxtNombre2),
                    apellido1 = Valor(TxtApellido1),
                    apellido2 = Valor(TxtApellido2),
                    direccion = Valor(TxtDireccion),
                    telefono = Valor(TxtTelefono),
                    correo = Valor(TxtCorreo)
                };

                BtnGuardar.Enabled = false;
                try
                {
                    string jsonRespuesta = Fluor.Post("/tte/destinatario/nuevo", ser.Serialize(destinatario));
                    var respuesta = ser.Deserialize<Dictionary<string, object>>(jsonRespuesta);

                    General.CodigoDestinatario = respuesta["codigo_destinatario_pk"].ToString();
                    General.NombreDestinatario = TxtNombreCorto.Text;
                    MessageBox.Show(this, "El destinatario se guardo con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio un error al guardar el destinatario: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    BtnGuardar.Enabled = true;
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
    }
}
