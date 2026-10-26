using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Diagnostics;

namespace cromo
{

    public partial class FrmGuia : Form
    {
        string ultimoCliente = "";
        string ultimaCondicion = "";
        string ultimoTipo = "";
        string ultimoServicio = "";
        string ultimoProducto = "";
        string ultimoEmpaque = "";
        string pago = "";
        string operacionIngreso = "";
        string operacionCargo = "";
        string ciudadOrigen = "";

        int pesoMinimo = 0;
        int pesoMinimoGuia = 0;
        int pesoMinimoLista = 0;
        double porcentajeManejo = 0;
        double manejoMinimoUnidad = 0;
        double manejoMinimoDespacho = 0;
        double descuentoPeso = 0;
        int codigoPrecio = 0;
        bool bloquearFlete = false;
        bool bloquearManejo = false;
        bool limitarDescuentoReexpedicion = false;
        bool estadoIngreso = true;
        bool estadoRecogido = true;

        public FrmGuia()
        {
            InitializeComponent();
        }

        private void Guia_Load(object sender, EventArgs e)
        {
            bloquearFlete = cromo.Properties.Settings.Default.bloquearFlete;
            bloquearManejo = cromo.Properties.Settings.Default.bloquearManejo;
            estadoIngreso = cromo.Properties.Settings.Default.guiaIngreso;
            estadoRecogido = cromo.Properties.Settings.Default.guiaRecogida;
            CargarTipo();
            CargarServicio();
            CargarEmpaque();
            CargarProducto();
            CargarIdentificacionDestinatario();
            CargarOperacion();
        }

        // Se lee una sola vez al abrir la guía: si cambia la configuración hay que cerrar y volver a abrir el formulario
        private void CargarOperacion()
        {
            operacionIngreso = cromo.Properties.Settings.Default.centroOperacion?.Trim() ?? "";
            var operacion = ConsultasGuia.DetalleOperacion(this, operacionIngreso);
            if (operacion == null)
            {
                BeginInvoke(new Action(Close));
                return;
            }
            operacionCargo = Fluor.Texto(operacion, "codigo_operacion_cargo_fk") ?? "";
            ciudadOrigen = Fluor.Texto(operacion, "codigo_ciudad_fk") ?? "";
        }
        void TxtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                FrmBuscarCliente frmBuscarCliente = new FrmBuscarCliente();
                frmBuscarCliente.ShowDialog();
                if (frmBuscarCliente.DialogResult == DialogResult.OK)
                {
                    TxtCodigoCliente.Text = General.CodigoCliente;
                }
            }
        }

        public void Nuevo()
        {
            Desbloquear();
            Limpiar();
            if (ultimoTipo != "")
            {
                CboTipo.SelectedValue = ultimoTipo;
            }
            else
            {
                CboTipo.SelectedIndex = 0;
            }

            TxtFechaIngreso.Text = DateTime.Now.ToString("G");
            TxtCodigoCliente.Text = ultimoCliente;
            TxtCodigoCondicion.Text = ultimaCondicion;
            TxtCodigoAdquiriente.Text = ultimoCliente;
            TxtOperacionIngreso.Text = operacionIngreso;
            TxtOperacionCargo.Text = operacionCargo;
            TxtCodigoCiudadOrigen.Text = ciudadOrigen;
            txtNombreCiudadOrigen.Text = CatalogoManager.BuscarCiudad(ciudadOrigen)?.nombre ?? "";
            TxtUsuario.Text = General.UsuarioActivo;
            RbPeso.Enabled = true;
            RbUnidad.Enabled = true;
            RbAdicional.Enabled = true;
            TxtCodigoCliente.Focus();
        }

        public void Guardar()
        {
            if (!ValidarGuardar() || !(CboTipo.SelectedItem is ApiGuiaTipo apiGuiaTipo))
                return;
            if (!ValidarFormaPago(apiGuiaTipo.codigoFormaPago))
                return;
            if (!ValidarFlete(apiGuiaTipo.validarFlete, Convert.ToDouble(TxtFlete.Text)))
                return;

            if (string.IsNullOrWhiteSpace(TxtOperacionIngreso.Text))
            {
                MessageBox.Show(this, "Debe configurar una operación de ingreso para las guias en Archivo > Configuracion > Operacion", "Operacion de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int codigoCliente;
            if (!int.TryParse(TxtCodigoCliente.Text.Trim(), out codigoCliente))
            {
                MessageBox.Show(this, "El codigo del cliente no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCodigoCliente.Focus();
                return;
            }

            double cobro = Numero(TxtRecaudo);
            if (apiGuiaTipo.generaCobro)
            {
                cobro += Numero(TxtFlete) + Numero(TxtManejo);
            }

            var guia = new Dictionary<string, object>
            {
                { "codigo_guia_tipo_fk", CboTipo.SelectedValue.ToString() },
                { "codigo_operacion_ingreso_fk", TxtOperacionIngreso.Text },
                { "codigo_operacion_cargo_fk", Texto(TxtOperacionCargo) },
                { "codigo_tercero_fk", codigoCliente },
                { "codigo_adquiriente_fk", Entero(TxtCodigoAdquiriente) ?? codigoCliente },
                { "codigo_tercero_operacion_fk", CboTerceroOperacion.Items.Count > 0 ? EnteroONulo(CboTerceroOperacion.SelectedValue) : null },
                { "codigo_servicio_fk", CboServicio.SelectedValue.ToString() },
                { "codigo_producto_fk", CboProducto.SelectedValue.ToString() },
                { "codigo_empaque_fk", CboEmpaque.SelectedValue.ToString() },
                { "empaque_referencia", Texto(TxtReferenciaEmpaque) },
                { "codigo_ciudad_origen_fk", TxtCodigoCiudadOrigen.Text },
                { "codigo_ciudad_destino_fk", TxtCodigoCiudadDestino.Text },
                { "codigo_ruta_fk", Texto(TxtCodigoRuta) },
                { "orden_ruta", Entero(TxtOrdenRuta) },
                { "zona", Texto(TxtCodigoZona) },
                { "codigo_asesor_fk", Entero(TxtCodigoAsesor) },
                { "documento_cliente", Texto(TxtDocumentoCliente) },
                { "relacion_cliente", Texto(TxtRelacion) },
                { "remitente", TxtNombreRemitente.Text },
                { "direccion_remitente", Texto(TxtDireccionRemitente) },
                { "telefono_remitente", Texto(TxtTelefonoRemitente) },
                { "codigo_destinatario_fk", Entero(TxtCodigoDestinatario) },
                { "codigo_identificacion_destinatario_fk", CboIdentificacionDestinatario.SelectedValue?.ToString() },
                { "numero_identificacion_destinatario", Texto(TxtNumeroIdentificacionDestinatario) },
                { "nombre_destinatario", TxtNombreDestinatario.Text },
                { "direccion_destinatario", TxtDireccionDestinatario.Text },
                { "telefono_destinatario", TxtTelefonoDestinatario.Text },
                { "unidades", Numero(TxtUnidades) },
                { "peso_real", Numero(TxtPeso) },
                { "peso_volumen", Numero(TxtVolumen) },
                { "peso_facturado", Numero(TxtPesoFacturar) },
                { "vr_declara", Numero(TxtDeclarado) },
                { "vr_flete", Numero(TxtFlete) },
                { "vr_manejo", Numero(TxtManejo) },
                { "vr_otros", Numero(TxtOtros) },
                { "vr_recaudo", Numero(TxtRecaudo) },
                { "condicion", Entero(TxtCodigoCondicion) },
                { "precio", codigoPrecio != 0 ? (int?)codigoPrecio : null },
                { "tipo_liquidacion", this.TipoLiquidacion() },
                { "liquidar", false },
                { "comentario", TxtComentario.Text },
                { "mercancia_peligrosa", ChkMercanciaPeligrosa.Checked },
                { "contenido_verificado", ChkContenidoVerificado.Checked },
                { "devolver_documento_cliente", ChkDevolverDocumento.Checked },
                { "estado_ingreso", estadoIngreso },
                { "estado_recogido", estadoRecogido }
            };

            guia["usuario"] = Fluor.UsuarioGuia;
            Dictionary<string, object> respuesta;
            try
            {
                respuesta = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(
                    Fluor.Post("/tte/guia/nuevo", new JavaScriptSerializer().Serialize(guia)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrio un error al guardar la guia: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(this, "La guia se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            double cobroFluor = Fluor.Numero(respuesta, "vr_cobro_entrega");
            if (Math.Abs(cobroFluor - cobro) > 0.5)
            {
                MessageBox.Show(this, "Atencion: el cobro contra entrega calculado por Fluor (" + cobroFluor.ToString("N0") +
                    ") es distinto al calculado por la guia (" + cobro.ToString("N0") + "). Revise la guia.", "Cobro contra entrega", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            TxtCodigo.Text = Fluor.Texto(respuesta, "codigo_guia_pk");
            ultimoCliente = TxtCodigoCliente.Text;
            ultimaCondicion = TxtCodigoCondicion.Text;
            ultimoTipo = CboTipo.SelectedValue.ToString();
            ultimoServicio = CboServicio.SelectedValue.ToString();
            ultimoProducto = CboProducto.SelectedValue.ToString();
            ultimoEmpaque = CboEmpaque.SelectedValue.ToString();
            ChkLiquidado.Checked = false;
            RbPeso.Checked = false;
            RbUnidad.Checked = false;
            RbAdicional.Checked = false;
            Bloquear();
        }

        private static string Texto(TextBox caja)
        {
            return string.IsNullOrWhiteSpace(caja.Text) ? null : caja.Text.Trim();
        }

        private static int? Entero(TextBox caja)
        {
            return EnteroONulo(caja.Text);
        }

        private static int? EnteroONulo(object valor)
        {
            return int.TryParse(valor?.ToString().Trim(), out int numero) ? (int?)numero : null;
        }

        private static double Numero(TextBox caja)
        {
            return double.TryParse(caja.Text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out double numero) ? numero : 0;
        }

        public bool ValidarGuardar()
        {
            if (TxtCodigoCliente.Text == "")
            {
                TxtCodigoCliente.Focus();
                return false;
            }
            else
            {
                if(TxtNombreRemitente.Text == "")
                {
                    TxtNombreRemitente.Focus();
                    return false;
                } else
                {
                    if(TxtDireccionRemitente.Text == "")
                    {
                        TxtDireccionRemitente.Focus();
                        return false;
                    } else
                    {
                        if (TxtTelefonoRemitente.Text == "")
                        {
                            TxtTelefonoRemitente.Focus();
                            return false;
                        } else
                        {
                            if (TxtCodigoCondicion.Text == "")
                            {
                                TxtCodigoCondicion.Focus();
                                return false;
                            }
                            else
                            {
                                if (TxtCodigoCiudadOrigen.Text == "")
                                {
                                    TxtCodigoCiudadOrigen.Focus();
                                    return false;
                                }
                                else
                                {
                                    if (TxtCodigoCiudadDestino.Text == "")
                                    {
                                        TxtCodigoCiudadDestino.Focus();
                                        return false;
                                    }
                                    else
                                    {
                                        if (CboTipo.SelectedIndex < 0)
                                        {
                                            CboTipo.Focus();
                                            return false;
                                        }
                                        else
                                        {
                                            if (CboServicio.SelectedIndex < 0)
                                            {
                                                CboServicio.Focus();
                                                return false;
                                            }
                                            else
                                            {
                                                if (CboProducto.SelectedIndex < 0)
                                                {
                                                    CboProducto.Focus();
                                                    return false;
                                                }
                                                else
                                                {
                                                    if (CboEmpaque.SelectedIndex < 0)
                                                    {
                                                        CboEmpaque.Focus();
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        double pesoMinimoValidar = 0;
                                                        double unidades = Convert.ToInt32(TxtUnidades.Text);
                                                        double pesoFacturarValidar = Convert.ToInt32(TxtPesoFacturar.Text);
                                                        pesoMinimoValidar = pesoMinimo * unidades;
                                                        if (pesoFacturarValidar < pesoMinimoValidar)
                                                        {
                                                            MessageBox.Show(this, "El peso minimo a facturar es " + pesoMinimoValidar.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            TxtPesoFacturar.Focus();
                                                            return false;
                                                        }
                                                        else
                                                        {
                                                            double pesoVolumen = Convert.ToInt32(TxtVolumen.Text);
                                                            if(pesoFacturarValidar < pesoVolumen)
                                                            {
                                                                MessageBox.Show(this, "El peso volumen es " + pesoVolumen.ToString() + " y no puede ser menor al peso a facturar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                TxtPesoFacturar.Focus();
                                                                return false;
                                                            } else
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
                }
            }
        }

        public string TipoLiquidacion()
        {
            string tipoLiquidacion = "K";
            if (RbUnidad.Checked)
            {
                tipoLiquidacion = "U";
            }
            if (RbAdicional.Checked)
            {
                tipoLiquidacion = "A";
            }
            return tipoLiquidacion;
        }

        public bool ValidarFlete(bool validar, double flete)
        {
            if (validar)
            {
                if (flete > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, "Este tipo de guia no puede tener flete en cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool ValidarFormaPago(string codigoFormaPago)
        {
            switch (codigoFormaPago)
            {
                case "CR":
                    if (!ChkPagoCredito.Checked)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago credito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "CO":
                    if (!ChkPagoContado.Checked)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago contado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "DE":
                    if (!ChkPagoDestino.Checked)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "CT":
                    if (!ChkPagoCortesia.Checked)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago cortesia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "RE":
                    if (!ChkPagoRecogida.Checked)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago recogida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return true;
            }

        }

        public void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtFechaIngreso.Text = "";
            TxtFechaDespacho.Text = "";
            TxtFechaEntrega.Text = "";
            TxtOperacionIngreso.Text = "";
            TxtOperacionCargo.Text = "";
            TxtCodigoCliente.Text = "";
            txtNombreCliente.Text = "";
            TxtCodigoAdquiriente.Text = "";
            txtNombreAdquiriente.Text = "";
            TxtCodigoCondicion.Text = "";
            txtNombreCondicion.Text = "";
            TxtCodigoAsesor.Text = "";
            TxtNombreRemitente.Text = "";
            TxtDireccionRemitente.Text = "";
            TxtTelefonoRemitente.Text = "";
            TxtDocumentoCliente.Text = "";
            TxtRelacion.Text = "";
            TxtCodigoCiudadOrigen.Text = "";
            txtNombreCiudadOrigen.Text = "";
            TxtNumeroIdentificacionDestinatario.Text = "";
            TxtNombreDestinatario.Text = "";
            TxtTelefonoDestinatario.Text = "";
            TxtDireccionDestinatario.Text = "";
            TxtCodigoCiudadDestino.Text = "";
            TxtNombreCiudadDestino.Text = "";
            TxtUnidades.Text = "0";
            TxtPeso.Text = "0";
            TxtVolumen.Text = "0";
            TxtPesoFacturar.Text = "0";
            TxtDeclarado.Text = "0";
            TxtFlete.Text = "0";
            TxtManejo.Text = "0";
            TxtTotal.Text = "0";
            TxtRecaudo.Text = "0";
            TxtAbono.Text = "0";
            TxtComentario.Text = "";
            TxtReferenciaEmpaque.Text = "";
            TxtOtros.Text = "0";
            TxtCodigoDespacho.Text = "";
            ChkFactura.Checked = false;
            ChkReexpedicion.Checked = false;
            ChkEstadoImpreso.Checked = false;
            ChkEstadoEmbarcado.Checked = false;
            ChkEstadoEntregado.Checked = false;
            ChkEstadoCumplido.Checked = false;
            ChkEstadoDespachado.Checked = false;
            ChkEstadoSoporte.Checked = false;
            ChkEstadoAnulado.Checked = false;
            ChkEstadoFacturado.Checked = false;
            ChkEstadoFacturaGenerada.Checked = false;
            TxtPesoMinimo.Text = "0";
            TxtPesoMinimoDespacho.Text = "0";
            TxtDescuentoPeso.Text = "0";
            TxtPorcentajeManejo.Text = "0";
            TxtManejoMinimoUnidad.Text = "0";
            TxtManejoMinimoDespacho.Text = "0";
            ChkListaGeneral.Checked = false;
            TxtCodigoPrecio.Text = "";
            TxtVrPeso.Text = "0";
            TxtVrTope.Text = "0";
            TxtVrAdicional.Text = "0";
            TxtVrUnidad.Text = "0";
            TxtTope.Text = "0";
            TxtPesoMinimoPrecio.Text = "0";
            TxtComentarioCondicion.Text = "";
            LvPrecioDetalle.Items.Clear();
            ChkLiquidado.Checked = false;
            RbPeso.Checked = false;
            RbUnidad.Checked = false;
            RbAdicional.Checked = false;
            TxtUsuario.Text = "";
            ChkMercanciaPeligrosa.Checked = false;
            ChkContenidoVerificado.Checked = false;
            ChkDevolverDocumento.Checked = false;
        }

        public void Desbloquear()
        {
            TsbGuardar.Enabled = true;
            TsbCancelar.Enabled = true;
            TsbNuevo.Enabled = false;
            TsbBuscar.Enabled = false;
            TsbImprimir.Enabled = false;

            MnuGuardar.Enabled = true;
            MnuCancelar.Enabled = true;
            MnuNuevo.Enabled = false;
            MnuBuscar.Enabled = false;
            MnuBuscarGuia.Enabled = false;
            MnuImprimir.Enabled = false;

            gbCliente.Enabled = true;
            gbRemitente.Enabled = true;
            gbDestinatario.Enabled = true;
            gbTotales.Enabled = true;
            gbInformacion.Enabled = true;
            gbComentario.Enabled = true;
            GbPrecioDetalle.Visible = true;
            GbCondiciones.Visible = true;
            GbCondicionEspecial.Visible = true;
            GbCondicionEspecialManejo.Visible = true;

            BtnDescuento.Enabled = true;
            BtnManejo.Enabled = true;

            if (bloquearFlete)
            {
                TxtFlete.Enabled = false;
            }

            if (bloquearManejo)
            {
                TxtManejo.Enabled = false;
            }
        }

        public void Bloquear()
        {
            TsbNuevo.Enabled = true;
            TsbBuscar.Enabled = true;
            TsbGuardar.Enabled = false;
            TsbCancelar.Enabled = false;
            TsbImprimir.Enabled = true;

            MnuNuevo.Enabled = true;
            MnuBuscar.Enabled = true;
            MnuBuscarGuia.Enabled = true;
            MnuGuardar.Enabled = false;
            MnuCancelar.Enabled = false;
            MnuImprimir.Enabled = true;

            gbCliente.Enabled = false;
            gbRemitente.Enabled = false;
            gbDestinatario.Enabled = false;
            gbTotales.Enabled = false;
            gbInformacion.Enabled = false;
            gbComentario.Enabled = false;
            GbPrecioDetalle.Visible = false;
            GbCondicionEspecial.Visible = false;
            GbCondicionEspecialManejo.Visible = false;
            LvPrecioDetalle.Items.Clear();

            BtnDescuento.Enabled = false;
            BtnManejo.Enabled = false;
        }

        private void TxtCodigoCiudadOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                FrmBuscarCiudad frmBuscarCiudad = new FrmBuscarCiudad();
                frmBuscarCiudad.ShowDialog();
                if (frmBuscarCiudad.DialogResult == DialogResult.OK)
                {
                    TxtCodigoCiudadOrigen.Text = General.CodigoCiudad;
                }
            }
        }

        private void TxtCodigoCiudadDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                FrmBuscarCiudad frmBuscarCiudad = new FrmBuscarCiudad();
                frmBuscarCiudad.ShowDialog();
                if (frmBuscarCiudad.DialogResult == DialogResult.OK)
                {
                    TxtCodigoCiudadDestino.Text = General.CodigoCiudad;
                }
            }
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void TsbGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void TsbCancelar_Click(object sender, EventArgs e)
        {
            Bloquear();
        }

        private void TxtCodigoCliente_Validated(object sender, EventArgs e)
        {
            if (int.TryParse(TxtCodigoCliente.Text.Trim(), out int codigoCliente))
            {
                ApiCliente apiCliente;
                try
                {
                    var tercero = Fluor.GetDetalle("/gen/tercero/detalle/" + codigoCliente);
                    apiCliente = new ApiCliente
                    {
                        codigoTerceroPk = Fluor.Texto(tercero, "codigo_tercero_pk"),
                        nombreCorto = Fluor.Texto(tercero, "nombre_corto"),
                        direccion = Fluor.Texto(tercero, "direccion"),
                        telefono = Fluor.Texto(tercero, "telefono"),
                        estadoInactivo = Fluor.Booleano(tercero, "estado_inactivo"),
                        codigoCondicionFk = Fluor.Texto(tercero, "codigo_condicion_fk"),
                        guiaPagoCredito = Fluor.Booleano(tercero, "guia_pago_credito"),
                        guiaPagoContado = Fluor.Booleano(tercero, "guia_pago_contado"),
                        guiaPagoDestino = Fluor.Booleano(tercero, "guia_pago_destino"),
                        guiaPagoCortesia = Fluor.Booleano(tercero, "guia_pago_cortesia"),
                        guiaPagoRecogida = Fluor.Booleano(tercero, "guia_pago_recogida"),
                        operaciones = Fluor.GetLista("/tte/tercero-operacion/buscar",
                                new Dictionary<string, object> { { "codigo_tercero_fk", codigoCliente } })
                            .Select(o => new ApiTerceroOperacion
                            {
                                codigoTerceroOperacionPk = Fluor.Texto(o, "codigo_tercero_operacion_pk"),
                                codigo = Fluor.Texto(o, "codigo"),
                                nombre = Fluor.Texto(o, "nombre")
                            })
                            .ToList()
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo consultar el cliente: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (apiCliente.estadoInactivo)
                {
                    TxtCodigoCliente.Text = "";
                    txtNombreCliente.Text = "";
                    MessageBox.Show(this, "El cliente esta inactivo debe seleccionar otro ", "Cliente inactivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (ultimoCliente != TxtCodigoCliente.Text)
                    {
                        TxtCodigoCondicion.Text = apiCliente.codigoCondicionFk;
                        TxtCodigoAdquiriente.Text = TxtCodigoCliente.Text;
                    }
                    txtNombreCliente.Text = apiCliente.nombreCorto;
                    ChkPagoCredito.Checked = apiCliente.guiaPagoCredito;
                    ChkPagoContado.Checked = apiCliente.guiaPagoContado;
                    ChkPagoDestino.Checked = apiCliente.guiaPagoDestino;
                    ChkPagoCortesia.Checked = apiCliente.guiaPagoCortesia;
                    ChkPagoRecogida.Checked = apiCliente.guiaPagoRecogida;
                    TxtNombreRemitente.Text = txtNombreCliente.Text;
                    TxtTelefonoRemitente.Text = apiCliente.telefono;
                    TxtDireccionRemitente.Text = apiCliente.direccion;                       
                    if (cromo.Properties.Settings.Default.validarProductoCliente) {
                        CargarProductoCliente(Convert.ToInt32(TxtCodigoCliente.Text));
                    }
                    CboTerceroOperacion.Text = "";
                    CboTerceroOperacion.ValueMember = "codigoTerceroOperacionPk";
                    CboTerceroOperacion.DisplayMember = "nombre";
                    CboTerceroOperacion.DataSource = apiCliente.operaciones;
                }                    
            }

        }

        private void TxtCodigoCiudadOrigen_Validated(object sender, EventArgs e)
        {
            ApiCiudad apiCiudad = CatalogoManager.BuscarCiudad(TxtCodigoCiudadOrigen.Text);
            if (apiCiudad != null)
            {
                txtNombreCiudadOrigen.Text = apiCiudad.nombre;
            }
        }

        private void TxtCodigoCiudadDestino_Validated(object sender, EventArgs e)
        {
            string codigoOrigen = TxtCodigoCiudadOrigen.Text;
            string codigoDestino = TxtCodigoCiudadDestino.Text;
            TxtUnidades.Text = "0";
            TxtPeso.Text = "0";
            TxtVolumen.Text = "0";
            TxtPesoFacturar.Text = "0";            
            TxtFlete.Text = "0";
            TxtManejo.Text = "0";
            if (ChkInvertirCiudad.Checked)
            {
                codigoOrigen = TxtCodigoCiudadDestino.Text;
                codigoDestino = TxtCodigoCiudadOrigen.Text;
            }
            ApiCiudad apiCiudad = CatalogoManager.BuscarCiudad(codigoDestino);
            if (apiCiudad != null)
            {
                TxtNombreCiudadDestino.Text = apiCiudad.nombre;
                TxtCodigoRuta.Text = apiCiudad.codigoRutaFk;
                TxtOrdenRuta.Text = apiCiudad.ordenRuta.ToString();
                TxtCodigoZona.Text = apiCiudad.codigoZonaFk;
                ChkReexpedicion.Checked = apiCiudad.reexpedicion;

                if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "")
                {
                    LvPrecioDetalle.Items.Clear();
                    List<ApiPrecioDetalle> apiPrecioDetalleLista = ConsultasGuia.ConsultarPrecios(this, codigoPrecio, TxtCodigoCiudadOrigen.Text, TxtCodigoCiudadDestino.Text, TxtCodigoZona.Text, null);
                    foreach (ApiPrecioDetalle apiPrecioDetalle in apiPrecioDetalleLista)
                    {
                        ListViewItem item = new ListViewItem(apiPrecioDetalle.codigoPrecioDetallePk);
                        item.SubItems.Add(apiPrecioDetalle.productoNombre);
                        item.SubItems.Add(apiPrecioDetalle.codigoCoberturaFk);
                        item.SubItems.Add(apiPrecioDetalle.vrPeso.ToString());
                        item.SubItems.Add(apiPrecioDetalle.vrUnidad.ToString());
                        item.SubItems.Add(apiPrecioDetalle.pesoTope.ToString());
                        item.SubItems.Add(apiPrecioDetalle.vrPesoTope.ToString());
                        item.SubItems.Add(apiPrecioDetalle.vrPesoTopeAdicional.ToString());
                        item.SubItems.Add(apiPrecioDetalle.minimo.ToString());
                        LvPrecioDetalle.Items.Add(item);
                        TxtCodigoCobertura.Text = apiPrecioDetalle.codigoCoberturaFk;
                    }

                    TxtFleteDescuentoPeso.Text = "0";
                    TxtFleteDescuentoUnidad.Text = "0";
                    TxtFletePesoMinimo.Text = "0";
                    TxtFletePesoMinimoGuia.Text = "0";
                    TxtFleteFleteMinimo.Text = "0";
                    TxtFleteFleteMinimoGuia.Text = "0";

                    if (int.TryParse(TxtCodigoCliente.Text.Trim(), out int codigoCliente))
                    {
                        var ruta = new Dictionary<string, object>
                        {
                            { "codigo_tercero_fk", codigoCliente },
                            { "codigo_ciudad_origen_fk", codigoOrigen },
                            { "codigo_ciudad_destino_fk", codigoDestino },
                            { "codigo_zona_fk", string.IsNullOrWhiteSpace(TxtCodigoZona.Text) ? null : TxtCodigoZona.Text },
                            { "codigo_cobertura_fk", string.IsNullOrWhiteSpace(TxtCodigoCobertura.Text) ? null : TxtCodigoCobertura.Text },
                            { "codigo_pago_fk", string.IsNullOrWhiteSpace(pago) ? null : pago }
                        };

                        var condicionFlete = ConsultasGuia.LiquidarCondicionRuta(this, "/tte/condicion-flete/liquidar", ruta, "flete");
                        if (condicionFlete != null)
                        {
                            TxtFleteDescuentoPeso.Text = Fluor.Numero(condicionFlete, "descuento_peso").ToString();
                            TxtFleteDescuentoUnidad.Text = Fluor.Numero(condicionFlete, "descuento_unidad").ToString();
                            TxtFletePesoMinimo.Text = Fluor.Entero(condicionFlete, "peso_minimo").ToString();
                            TxtFletePesoMinimoGuia.Text = Fluor.Entero(condicionFlete, "peso_minimo_guia").ToString();
                            TxtFleteFleteMinimo.Text = Fluor.Numero(condicionFlete, "flete_minimo").ToString();
                            TxtFleteFleteMinimoGuia.Text = Fluor.Numero(condicionFlete, "flete_minimo_guia").ToString();
                            pesoMinimo = Fluor.Entero(condicionFlete, "peso_minimo");
                            pesoMinimoGuia = Fluor.Entero(condicionFlete, "peso_minimo_guia");
                            descuentoPeso = Fluor.Numero(condicionFlete, "descuento_peso");
                        }

                        var condicionManejo = ConsultasGuia.LiquidarCondicionRuta(this, "/tte/condicion-manejo/liquidar", ruta, "manejo");
                        if (condicionManejo != null)
                        {
                            TxtPorcentajeManejoEspecial.Text = Fluor.Numero(condicionManejo, "porcentaje").ToString();
                            TxtManejoMinimoUnidadEspecial.Text = Fluor.Numero(condicionManejo, "minimo_unidad").ToString();
                            TxtManejoMinimoDespachoEspecial.Text = Fluor.Numero(condicionManejo, "minimo_despacho").ToString();
                            porcentajeManejo = Fluor.Numero(condicionManejo, "porcentaje");
                            manejoMinimoUnidad = Fluor.Numero(condicionManejo, "minimo_unidad");
                            manejoMinimoDespacho = Fluor.Numero(condicionManejo, "minimo_despacho");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una condicion comercial, origen y destino del servicio");
                }
            }
        }


        private void CargarTipo()
        {
            CboTipo.ValueMember = "codigoGuiaTipoPk";
            CboTipo.DisplayMember = "nombre";
            CboTipo.DataSource = CatalogoManager.GuiaTipos;
        }

        private void CargarServicio()
        {
            CboServicio.ValueMember = "codigoServicioPk";
            CboServicio.DisplayMember = "nombre";
            CboServicio.DataSource = CatalogoManager.Servicios;
        }

        private void CargarProducto()
        {
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = CatalogoManager.Productos;
        }

        private void CargarProductoCliente(int codigoCliente)
        {
            List<ApiProducto> apiProductoLista;
            try
            {
                apiProductoLista = Fluor.GetLista("/tte/tercero-producto/buscar",
                        new Dictionary<string, object> { { "codigo_tercero_fk", codigoCliente }, { "size", 500 } })
                    .Select(p => new ApiProducto { codigoProductoPk = Fluor.Texto(p, "codigo_producto_fk"), nombre = Fluor.Texto(p, "producto_nombre") })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudieron consultar los productos del cliente: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CboProducto.Text = "";
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
        }

        private void CargarProductoLista(int codigoLista)
        {
            List<ApiProducto> apiProductoLista;
            try
            {
                apiProductoLista = Fluor.GetLista("/tte/precio-detalle/producto-cliente",
                        new Dictionary<string, object> { { "codigo_precio_fk", codigoLista } })
                    .Select(p => new ApiProducto { codigoProductoPk = Fluor.Texto(p, "codigo_producto_pk"), nombre = Fluor.Texto(p, "nombre") })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudieron consultar los productos de la lista de precios: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CboProducto.Text = "";
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
        }

        private void CargarEmpaque()
        {
            CboEmpaque.ValueMember = "codigoEmpaquePk";
            CboEmpaque.DisplayMember = "nombre";
            CboEmpaque.DataSource = CatalogoManager.Empaques;
        }

        private void CargarIdentificacionDestinatario()
        {
            CboIdentificacionDestinatario.ValueMember = "codigoIdentificacionPk";
            CboIdentificacionDestinatario.DisplayMember = "nombre";
            CboIdentificacionDestinatario.DataSource = CatalogoManager.Identificaciones;
        }

        private void MnuNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void MnuGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void MnuCancelar_Click(object sender, EventArgs e)
        {
            Bloquear();
        }

        private void TsbBuscar_Click(object sender, EventArgs e)
        {

            //TraerGuia(FuncionesGuia.CodigoGuia);
        }

        private void MnuBuscar_Click(object sender, EventArgs e)
        {

            //TraerGuia(FuncionesGuia.CodigoGuia);
        }

        private void TxtPesoFacturar_Validated(object sender, EventArgs e)
        {
            if (ChkLiquidado.Checked == false)
            {
                double vrFlete = 0;
                double vrManejo = 0;
                double vrFleteMinimo = Convert.ToDouble(TxtFleteFleteMinimo.Text);
                double vrFleteMinimoDespacho = Convert.ToDouble(TxtFleteFleteMinimoGuia.Text);
                double precioPeso = Convert.ToDouble(TxtVrPeso.Text);
                double precioTope = Convert.ToDouble(TxtVrTope.Text);
                double precioUnidad = Convert.ToDouble(TxtVrUnidad.Text);
                double precioAdicional = Convert.ToDouble(TxtVrAdicional.Text);
                int tope = Convert.ToInt32(TxtTope.Text);
                int pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
                int unidades = Convert.ToInt32(TxtUnidades.Text);
                
                if (RbPeso.Checked)
                {
                    precioPeso = Convert.ToDouble(TxtVrPeso.Text);
                    if (precioPeso == 0 && ChkListaGeneral.Checked == true && General.CodigoPrecioGeneral != 0)
                    {
                        string codigoOrigen = TxtCodigoCiudadOrigen.Text;
                        string codigoDestino = TxtCodigoCiudadDestino.Text;
                        if(ChkInvertirCiudad.Checked)
                        {
                            codigoOrigen = TxtCodigoCiudadDestino.Text;
                            codigoDestino = TxtCodigoCiudadOrigen.Text;
                        }
                        ApiPrecioDetalle apiPrecioDetalle = ConsultasGuia.PrecioProducto(this, General.CodigoPrecioGeneral, codigoOrigen, codigoDestino, null, CboProducto.SelectedValue?.ToString());
                        if (apiPrecioDetalle != null)
                        {
                            precioPeso = apiPrecioDetalle.vrPeso;
                        }

                    }
                    vrFlete = pesoFacturar * precioPeso;
                    if (descuentoPeso > 0 && !ChkOmitirDescuento.Checked)
                    {
                        if(limitarDescuentoReexpedicion == false || !ChkReexpedicion.Checked)
                        {
                            vrFlete -= vrFlete * descuentoPeso / 100;
                        }                                          
                    }
                }
                else if (RbUnidad.Checked)
                {
                    vrFlete = unidades * precioUnidad;
                }
                else if (RbAdicional.Checked)
                {
                    vrFlete = precioTope * unidades;
                    if (pesoFacturar > (tope * unidades))
                    {
                        int diferencia = pesoFacturar - (tope * unidades);
                        vrFlete += diferencia * precioAdicional;
                    }
                }

                if(vrFleteMinimo > vrFlete / unidades)
                {
                    vrFlete = vrFleteMinimo * unidades;
                }
                if(vrFleteMinimoDespacho > vrFlete)
                {
                    vrFlete = vrFleteMinimoDespacho;
                }
                vrFlete = Math.Round(vrFlete);
                vrManejo = Convert.ToDouble(TxtManejo.Text);
                if (pago == "DES" || pago == "CON")
                {                    
                    vrFlete = Math.Round(vrFlete / 100) * 100;
                    vrManejo = Math.Round(vrManejo / 100) * 100;
                }
                TxtFlete.Text = vrFlete.ToString();
                TxtManejo.Text = vrManejo.ToString();
                TxtTotal.Text = (vrFlete + vrManejo).ToString();                
            }
        }

        private void TxtUnidades_Validated(object sender, EventArgs e)
        {
            if (ChkLiquidado.Checked == false)
            {
                if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "")
                {
                    ApiPrecioDetalle apiPrecioDetalle = ConsultasGuia.PrecioProducto(this, codigoPrecio, TxtCodigoCiudadOrigen.Text, TxtCodigoCiudadDestino.Text, null, CboProducto.SelectedValue?.ToString());
                    if (apiPrecioDetalle != null)
                    {
                        if (Convert.ToInt32(TxtPesoFacturar.Text) <= 0)
                        {
                            if (apiPrecioDetalle.minimo > 0)
                            {
                                TxtPesoFacturar.Text = (apiPrecioDetalle.minimo * Convert.ToInt32(TxtUnidades.Text)).ToString();
                            }
                        }
                    }
                }
                int pesoMinimoCalcular = 0;
                pesoMinimoCalcular = pesoMinimo;
                if(pesoMinimoLista > 0)
                {
                    if(pesoMinimoLista > pesoMinimoCalcular)
                    {
                        pesoMinimoCalcular = pesoMinimoLista;
                    }
                }

                if (pesoMinimoCalcular > 0)
                {
                    TxtPesoFacturar.Text = (pesoMinimoCalcular * Convert.ToInt32(TxtUnidades.Text)).ToString();
                    if (Convert.ToInt32(TxtPeso.Text) <= 0)
                    {
                        TxtPeso.Text = (pesoMinimoCalcular * Convert.ToInt32(TxtUnidades.Text)).ToString();
                    }
                }
                double pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
                if (pesoMinimoGuia > pesoFacturar)
                {
                    TxtPesoFacturar.Text = pesoMinimoGuia.ToString();
                }
            }
            else
            {
                TxtDeclarado.Focus();
            }
        }

        private void TxtCodigoCondicion_Validated(object sender, EventArgs e)
        {
            CargarCondicion();
        }

        private void LimpiarCondicion()
        {
            txtNombreCondicion.Text = "";
            pesoMinimo = 0;
            pesoMinimoGuia = 0;
            porcentajeManejo = 0;
            manejoMinimoUnidad = 0;
            manejoMinimoDespacho = 0;
            descuentoPeso = 0;
            codigoPrecio = 0;
            limitarDescuentoReexpedicion = false;
            TxtCodigoPrecio.Text = "";
            ChkListaGeneral.Checked = false;
            TxtPesoMinimo.Text = "0";
            TxtPesoMinimoDespacho.Text = "0";
            TxtPorcentajeManejo.Text = "0";
            TxtDescuentoPeso.Text = "0";
            TxtManejoMinimoUnidad.Text = "0";
            TxtManejoMinimoDespacho.Text = "0";
            TxtComentarioCondicion.Text = "";
            RbPeso.Checked = false;
            RbUnidad.Checked = false;
            RbAdicional.Checked = false;
            RbPeso.Enabled = true;
            RbUnidad.Enabled = true;
            RbAdicional.Enabled = true;
        }

        private void CargarCondicion()
        {
            if (!int.TryParse(TxtCodigoCondicion.Text.Trim(), out _))
            {
                LimpiarCondicion();
                return;
            }
            if (int.TryParse(TxtCodigoCondicion.Text.Trim(), out int codigoCondicion))
            {
                ApiCondicion apiCondicion;
                try
                {
                    var condicion = Fluor.GetDetalle("/tte/condicion/detalle/" + codigoCondicion);
                    apiCondicion = new ApiCondicion
                    {
                        codigoCondicionFk = Fluor.Texto(condicion, "codigo_condicion_pk"),
                        nombre = Fluor.Texto(condicion, "nombre"),
                        codigoPrecioFk = Fluor.Entero(condicion, "codigo_precio_fk"),
                        precioGeneral = Fluor.Booleano(condicion, "precio_general"),
                        precioPeso = Fluor.Booleano(condicion, "precio_peso"),
                        precioUnidad = Fluor.Booleano(condicion, "precio_unidad"),
                        precioAdicional = Fluor.Booleano(condicion, "precio_adicional"),
                        pesoMinimo = Fluor.Entero(condicion, "peso_minimo"),
                        pesoMinimoGuia = Fluor.Entero(condicion, "peso_minimo_guia"),
                        porcentajeManejo = Fluor.Numero(condicion, "porcentaje_manejo"),
                        manejoMinimoUnidad = Fluor.Numero(condicion, "manejo_minimo_unidad"),
                        manejoMinimoDespacho = Fluor.Numero(condicion, "manejo_minimo_despacho"),
                        descuentoPeso = Fluor.Numero(condicion, "descuento_peso"),
                        limitarDescuentoReexpedicion = Fluor.Booleano(condicion, "limitar_descuento_reexpedicion"),
                        comentario = Fluor.Texto(condicion, "comentario")
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo consultar la condicion: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtNombreCondicion.Text = apiCondicion.nombre;
                pesoMinimo = apiCondicion.pesoMinimo;
                pesoMinimoGuia = apiCondicion.pesoMinimoGuia;
                porcentajeManejo = apiCondicion.porcentajeManejo;
                manejoMinimoUnidad = apiCondicion.manejoMinimoUnidad;
                manejoMinimoDespacho = apiCondicion.manejoMinimoDespacho;
                descuentoPeso = apiCondicion.descuentoPeso;
                codigoPrecio = apiCondicion.codigoPrecioFk;
                limitarDescuentoReexpedicion = apiCondicion.limitarDescuentoReexpedicion;
                TxtCodigoPrecio.Text = apiCondicion.codigoPrecioFk.ToString();
                ChkListaGeneral.Checked = apiCondicion.precioGeneral;
                TxtPesoMinimo.Text = pesoMinimo.ToString();
                TxtPesoMinimoDespacho.Text = pesoMinimoGuia.ToString();
                TxtPorcentajeManejo.Text = porcentajeManejo.ToString();
                TxtDescuentoPeso.Text = descuentoPeso.ToString();
                TxtManejoMinimoUnidad.Text = manejoMinimoUnidad.ToString();
                TxtManejoMinimoDespacho.Text = manejoMinimoDespacho.ToString();
                TxtComentarioCondicion.Text = apiCondicion.comentario;
                if (cromo.Properties.Settings.Default.validarProductoLista)
                {
                    CargarProductoLista(Convert.ToInt32(TxtCodigoPrecio.Text));
                }

                bool precioPeso = apiCondicion.precioPeso;
                bool precioUnidad = apiCondicion.precioUnidad;
                bool precioAdicional = apiCondicion.precioAdicional;
                
                if (precioPeso)
                {
                    RbPeso.Checked = true;
                }
                else
                {
                    RbPeso.Enabled = false;
                }
                if (precioUnidad)
                {
                    if (precioPeso == false)
                    {
                        RbUnidad.Checked = true;
                    }
                }
                else
                {
                    RbUnidad.Enabled = false;
                }
                if (precioAdicional)
                {
                    if (precioPeso == false && precioUnidad == false)
                    {
                        RbAdicional.Checked = true;
                    }
                }
                else
                {
                    RbAdicional.Enabled = false;
                }
            }
        }

        private void TxtVolumen_Validated(object sender, EventArgs e)
        {
            LiquidarPesoFacturar();
        }

        private void TxtPeso_Validated(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TxtVolumen.Text) <= 0)
            {
                TxtVolumen.Text = TxtPeso.Text;
            }
            LiquidarPesoFacturar();
        }

        private void LiquidarPesoFacturar()
        {
            double pesoReal = Convert.ToInt32(TxtPeso.Text);
            double pesoVolumen = Convert.ToInt32(TxtVolumen.Text);
            double pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
            if (pesoReal > pesoFacturar)
            {
                pesoFacturar = pesoReal;
            }
            if (pesoVolumen > pesoFacturar)
            {
                pesoFacturar = pesoVolumen;
            }

            TxtPesoFacturar.Text = pesoFacturar.ToString();
        }

        private void TxtDeclarado_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtDeclarado.Text) > 0)
            {
                TxtManejo.Text = (Convert.ToDouble(TxtDeclarado.Text) * porcentajeManejo / 100).ToString();
                if (manejoMinimoDespacho > Convert.ToDouble(TxtManejo.Text))
                {
                    TxtManejo.Text = manejoMinimoDespacho.ToString();
                }
                if (manejoMinimoUnidad * Convert.ToInt32(TxtUnidades.Text) > Convert.ToDouble(TxtManejo.Text))
                {
                    TxtManejo.Text = (manejoMinimoUnidad * Convert.ToInt32(TxtUnidades.Text)).ToString();
                }
                double vrManejo = Math.Round(Convert.ToDouble(TxtManejo.Text));
                double vrFlete = Convert.ToDouble(TxtFlete.Text);
                double vrOtros = Convert.ToDouble(TxtOtros.Text);
                if (pago == "DES" || pago == "CON")
                {                   
                    vrManejo = Math.Round(vrManejo / 100) * 100;
                }
                TxtManejo.Text = vrManejo.ToString();
                TxtTotal.Text = (vrFlete + vrManejo + vrOtros).ToString();
            }
        }

        private void MnuImprimir_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtCodigo.Text, out int codigoGuia))
            {
                ImpresionGuia.Imprimir(this, codigoGuia, codigoGuia);
            }
        }

        private void TsbImprimir_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtCodigo.Text, out int codigoGuia))
            {
                ImpresionGuia.Imprimir(this, codigoGuia, codigoGuia);
            }
        }

        private void TsbVistaPrevia_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtCodigo.Text, out int codigoGuia))
            {
                ImpresionGuia.Previsualizar(this, codigoGuia, codigoGuia);
            }
        }


        private void TabularEnterV2(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true; //Interceptamos la pulsación
                SendKeys.Send("{TAB}"); //Pulsamos la tecla Tabulador por código
            }
            if(sender is TextBox)
            {
                TextBox txt = sender as TextBox;
                if (txt.Tag != null)
                {
                    if (txt.Tag.ToString() == "N")
                    {
                        if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != (char)13)
                        {
                            MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }

        private void TxtCodigoCondicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                if (TxtCodigoCliente.Text != "")
                {
                    General.CodigoCliente = TxtCodigoCliente.Text;
                    FrmBuscarCondicion frm = new FrmBuscarCondicion();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        TxtCodigoCondicion.Text = General.CodigoCondicion;
                    }
                }
            }
        }

        private void CboProducto_Validated(object sender, EventArgs e)
        {
            if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "" && CboProducto.Text != "")
            {
                string codigoOrigen = TxtCodigoCiudadOrigen.Text;
                string codigoDestino = TxtCodigoCiudadDestino.Text;
                if (ChkInvertirCiudad.Checked)
                {
                    codigoOrigen = TxtCodigoCiudadDestino.Text;
                    codigoDestino = TxtCodigoCiudadOrigen.Text;
                }
                ApiPrecioDetalle apiPrecioDetalle = ConsultasGuia.PrecioProducto(this, codigoPrecio, codigoOrigen, codigoDestino, TxtCodigoZona.Text, CboProducto.SelectedValue?.ToString());
                if (apiPrecioDetalle != null)
                {
                    TxtVrPeso.Text = apiPrecioDetalle.vrPeso.ToString();
                    TxtVrUnidad.Text = apiPrecioDetalle.vrUnidad.ToString();
                    TxtTope.Text = apiPrecioDetalle.pesoTope.ToString();
                    TxtVrTope.Text = apiPrecioDetalle.vrPesoTope.ToString();
                    TxtVrAdicional.Text = apiPrecioDetalle.vrPesoTopeAdicional.ToString();
                    TxtPesoMinimoPrecio.Text = apiPrecioDetalle.minimo.ToString();
                    pesoMinimoLista = apiPrecioDetalle.minimo;
                    ChkOmitirDescuento.Checked = apiPrecioDetalle.omitirDescuento;
                    TxtCodigoCobertura.Text = apiPrecioDetalle.codigoCoberturaFk;
                }
                else
                {
                    if (ChkListaGeneral.Checked && General.CodigoPrecioGeneral == 0)
                    {
                        MessageBox.Show(this, "No hay lista de precios general configurada en Fluor, no se podra liquidar la guia automaticamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ChkListaGeneral.Checked)
                    {
                        ApiPrecioDetalle apiPrecioDetalleGeneral = ConsultasGuia.PrecioProducto(this, General.CodigoPrecioGeneral, TxtCodigoCiudadOrigen.Text, TxtCodigoCiudadDestino.Text, null, CboProducto.SelectedValue?.ToString());
                        if (apiPrecioDetalleGeneral != null)
                        {
                            TxtVrPeso.Text = apiPrecioDetalleGeneral.vrPeso.ToString();
                            TxtVrUnidad.Text = apiPrecioDetalleGeneral.vrUnidad.ToString();
                            TxtTope.Text = apiPrecioDetalleGeneral.pesoTope.ToString();
                            TxtVrTope.Text = apiPrecioDetalleGeneral.vrPesoTope.ToString();
                            TxtVrAdicional.Text = apiPrecioDetalleGeneral.vrPesoTopeAdicional.ToString();
                            TxtPesoMinimoPrecio.Text = apiPrecioDetalleGeneral.minimo.ToString();
                            pesoMinimoLista = apiPrecioDetalleGeneral.minimo;
                            ChkOmitirDescuento.Checked = apiPrecioDetalleGeneral.omitirDescuento;
                        }
                        else
                        {
                            MessageBox.Show(this, "No se encontro este precio para la lista general, no se podra liquidar la guia automaticamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                            
                        }
                    } else
                    {
                        MessageBox.Show(this, "No existe precio para este producto con esta condicion y este destino y la condicion no permite lista precios general", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una condicion comercial, origen, destino y producto para liquidar el envio");
            }
        }

        private void TsbBuscarGuia_Click(object sender, EventArgs e)
        {
            FrmDevolverGuiaCodigo frm = new FrmDevolverGuiaCodigo();
            frm.ShowDialog();
            if (General.CodigoGuia != 0)
            {
                try
                {
                    TraerGuia(Fluor.DetalleGuia(General.CodigoGuia));
                }
                catch (System.Net.WebException ex) when ((ex.Response as System.Net.HttpWebResponse)?.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show(this, "No existe la guia " + General.CodigoGuia, "Buscar guia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo consultar la guia: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MnuBuscarGuia_Click(object sender, EventArgs e)
        {
            /*FuncionesGuia buscar = new FuncionesGuia();
			buscar.DevolverCodigoGuia();
			if (General.CodigoGuia != 0)
			{
				//TraerGuia(General.CodigoGuia);
			}*/
        }

        private void TxtNombreDestinatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                General.CodigoCliente = TxtCodigoCliente.Text;
                FrmBuscarDestinatario frmBuscarDestinatario = new FrmBuscarDestinatario();
                frmBuscarDestinatario.ShowDialog();
                if (frmBuscarDestinatario.DialogResult == DialogResult.OK)
                {
                    Dictionary<string, object> destinatario = null;
                    try
                    {
                        destinatario = Fluor.GetLista("/tte/destinatario/lista",
                            new Dictionary<string, object> { { "codigo_destinatario_pk", General.CodigoDestinatario } }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "No se pudo consultar el destinatario: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (destinatario != null)
                    {
                        TxtCodigoDestinatario.Text = Fluor.Texto(destinatario, "codigo_destinatario_pk");
                        TxtNombreDestinatario.Text = Fluor.Texto(destinatario, "nombre_corto");
                        TxtDireccionDestinatario.Text = Fluor.Texto(destinatario, "direccion");
                        TxtTelefonoDestinatario.Text = Fluor.Texto(destinatario, "telefono");
                        TxtCodigoCiudadDestino.Text = Fluor.Texto(destinatario, "codigo_ciudad_fk");
                        TxtNumeroIdentificacionDestinatario.Text = Fluor.Texto(destinatario, "numero_identificacion");
                        CboIdentificacionDestinatario.SelectedValue = Fluor.Texto(destinatario, "codigo_identificacion_fk") ?? "";
                    }
                    else
                    {
                        MessageBox.Show("No existe el destinatario");
                    }

                }
            }
        }

        private void TraerGuia(ApiGuia apiGuia)
        {
            TxtCodigo.Text = apiGuia.codigoGuiaPk;
            TxtCodigoDespacho.Text = apiGuia.codigoDespachoFk;
            TxtFechaIngreso.Text = apiGuia.fechaIngreso.ToString();
            TxtFechaDespacho.Text = apiGuia.fechaDespacho.ToString();
            TxtFechaEntrega.Text = apiGuia.fechaEntrega.ToString();
            TxtOperacionIngreso.Text = apiGuia.codigoOperacionIngresoFk;
            TxtOperacionCargo.Text = apiGuia.codigoOperacionCargoFk;
            TxtCodigoAsesor.Text = apiGuia.codigoAsesorFk;
            TxtAbono.Text = apiGuia.vrAbono;
            TxtCodigoCliente.Text = apiGuia.codigoTerceroFk;
            txtNombreCliente.Text = apiGuia.clienteNombreCorto;
            TxtCodigoAdquiriente.Text = apiGuia.codigoAdquirienteFk;
            txtNombreAdquiriente.Text = apiGuia.adquirienteNombreCorto;
            TxtCodigoCondicion.Text = apiGuia.codigoCondicionFk;
            txtNombreCondicion.Text = apiGuia.condicionNombre;
            TxtNombreRemitente.Text = apiGuia.nombreRemitente;
            TxtTelefonoRemitente.Text = apiGuia.telefonoRemitente;
            TxtDireccionRemitente.Text = apiGuia.direccionRemitente;
            TxtDocumentoCliente.Text = apiGuia.documentoCliente;
            TxtRelacion.Text = apiGuia.relacionCliente;
            TxtCodigoCiudadOrigen.Text = apiGuia.codigoCiudadOrigenFk;
            txtNombreCiudadOrigen.Text = apiGuia.ciudadOrigenNombre;
            TxtNombreDestinatario.Text = apiGuia.nombreDestinatario;
            TxtTelefonoDestinatario.Text = apiGuia.telefonoDestinatario;
            TxtDireccionDestinatario.Text = apiGuia.direccionDestinatario;
            TxtCodigoCiudadDestino.Text = apiGuia.codigoCiudadDestinoFk;
            TxtNombreCiudadDestino.Text = apiGuia.ciudadDestinoNombre;
            TxtUnidades.Text = apiGuia.unidades;
            TxtPeso.Text = apiGuia.pesoReal;
            TxtVolumen.Text = apiGuia.pesoVolumen;
            TxtPesoFacturar.Text = apiGuia.pesoFacturado;
            TxtDeclarado.Text = apiGuia.vrDeclara;
            TxtFlete.Text = apiGuia.vrFlete;
            TxtManejo.Text = apiGuia.vrManejo;
            TxtTotal.Text = (Convert.ToDouble(apiGuia.vrFlete) + Convert.ToDouble(apiGuia.vrManejo) + Convert.ToDouble(apiGuia.vrOtros)).ToString();
            TxtRecaudo.Text = apiGuia.vrRecaudo;
            TxtOtros.Text = apiGuia.vrOtros;
            TxtReferenciaEmpaque.Text = apiGuia.empaqueReferencia;
            TxtComentario.Text = apiGuia.comentario;
            TxtUsuario.Text = apiGuia.usuario;
            TxtCodigoZona.Text = apiGuia.codigoZonaFk;
            TxtCodigoDestinatario.Text = apiGuia.codigoDestinatarioFk;
            CboTipo.SelectedValue = apiGuia.codigoGuiaTipoFk;
            CboServicio.SelectedValue = apiGuia.codigoServicioFk;
            CboEmpaque.SelectedValue = apiGuia.codigoEmpaqueFk;
            CboProducto.SelectedValue = apiGuia.codigoProductoFk;
            ChkReexpedicion.Checked = apiGuia.reexpedicion;
            ChkFactura.Checked = apiGuia.factura;
            ChkCortesia.Checked = apiGuia.cortesia;
            ChkEstadoImpreso.Checked = apiGuia.estadoImpreso;
            ChkEstadoEmbarcado.Checked = apiGuia.estadoEmbarcado;
            ChkEstadoDespachado.Checked = apiGuia.estadoDespachado;
            ChkEstadoEntregado.Checked = apiGuia.estadoEntregado;
            ChkEstadoSoporte.Checked = apiGuia.estadoSoporte;
            ChkEstadoCumplido.Checked = apiGuia.estadoCumplido;
            ChkEstadoFacturado.Checked = apiGuia.estadoFacturado;
            ChkEstadoFacturaGenerada.Checked = apiGuia.estadoFacturaGenerada;
            ChkEstadoAnulado.Checked = apiGuia.estadoAnulado;
        }

        private void BtnCrearCliente_Click(object sender, EventArgs e)
        {
            FrmClienteNuevo frmClienteNuevo = new FrmClienteNuevo();
            frmClienteNuevo.ShowDialog();
            if (frmClienteNuevo.DialogResult == DialogResult.OK)
            {
                TxtCodigoCliente.Text = General.CodigoCliente;
                TxtCodigoCliente.Focus();
            }
        }

        private void TxtCodigoAsesor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                FrmBuscarAsesor frmBuscarAsesor = new FrmBuscarAsesor();
                frmBuscarAsesor.ShowDialog();
                if (frmBuscarAsesor.DialogResult == DialogResult.OK)
                {
                    TxtCodigoAsesor.Text = General.CodigoAsesor;
                }
            }
        }


        private void BtnDescuento_Click(object sender, EventArgs e)
        {
            General.Descuento = Convert.ToDouble(TxtDescuentoPeso.Text);
            FrmDescuento frmDescuento = new FrmDescuento();
            frmDescuento.ShowDialog();
            if (frmDescuento.DialogResult == DialogResult.OK)
            {
                TxtDescuentoPeso.Text = General.Descuento.ToString();
                descuentoPeso = General.Descuento;
                TxtPesoFacturar.Focus();
            }
        }

        private void BtnManejo_Click(object sender, EventArgs e)
        {
            General.Manejo = Convert.ToDouble(TxtPorcentajeManejo.Text);
            FrmManejo frmManejo = new FrmManejo();
            frmManejo.ShowDialog();
            if (frmManejo.DialogResult == DialogResult.OK)
            {
                TxtPorcentajeManejo.Text = General.Manejo.ToString();
                porcentajeManejo = General.Manejo;
                TxtDeclarado.Focus();
            }
        }

        private void CboTipo_Validated(object sender, EventArgs e)
        {
            if (CboTipo.SelectedItem is ApiGuiaTipo guiaTipo)
            {
                pago = guiaTipo.codigoPagoFk;
            }
        }

        private void TxtFlete_Validated(object sender, EventArgs e)
        {
            double flete = Convert.ToDouble(TxtFlete.Text);
            double manejo = Convert.ToDouble(TxtManejo.Text);
            double otros = Convert.ToDouble(TxtOtros.Text);
            TxtTotal.Text = (flete + manejo + otros).ToString();
        }

        private void TxtManejo_Validated(object sender, EventArgs e)
        {
            double flete = Convert.ToDouble(TxtFlete.Text);
            double manejo = Convert.ToDouble(TxtManejo.Text);
            double otros = Convert.ToDouble(TxtOtros.Text);
            TxtTotal.Text = (flete + manejo + otros).ToString();
        }

        private void TxtCodigoAdquiriente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                FrmBuscarCliente frmBuscarCliente = new FrmBuscarCliente();
                frmBuscarCliente.ShowDialog();
                if (frmBuscarCliente.DialogResult == DialogResult.OK)
                {
                    TxtCodigoAdquiriente.Text = General.CodigoCliente;
                }
            }
        }

        private void TxtCodigoAdquiriente_Validated(object sender, EventArgs e)
        {
            if (int.TryParse(TxtCodigoAdquiriente.Text.Trim(), out int codigoAdquiriente))
            {
                try
                {
                    var tercero = Fluor.GetDetalle("/gen/tercero/detalle/" + codigoAdquiriente);
                    txtNombreAdquiriente.Text = Fluor.Texto(tercero, "nombre_corto");
                }
                catch (Exception ex)
                {
                    txtNombreAdquiriente.Text = "";
                    MessageBox.Show(this, "No se pudo consultar el adquiriente: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtRecaudo_Validated(object sender, EventArgs e)
        {
            double flete = Convert.ToDouble(TxtFlete.Text);
            double manejo = Convert.ToDouble(TxtManejo.Text);
            double otros = Convert.ToDouble(TxtOtros.Text);
            TxtTotal.Text = (flete + manejo + otros).ToString();
        }

        private void TxtOtros_Validated(object sender, EventArgs e)
        {
            double flete = Convert.ToDouble(TxtFlete.Text);
            double manejo = Convert.ToDouble(TxtManejo.Text);
            double otros = Convert.ToDouble(TxtOtros.Text);
            TxtTotal.Text = (flete + manejo + otros).ToString();
        }
    }

}
