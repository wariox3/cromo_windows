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
    public partial class FrmGuiaOperador : Form
    {

        int codigoCliente = 0;
        string operacionIngreso = "";
        string operacionCargo = "";
        string ciudadOrigen = "";
        string ultimaCondicion = "";
        string ultimoTipo = "";       
        string ultimoProducto = "";        
        string codigoCobertura = "";
        int pesoMinimo = 0;
        int pesoMinimoGuia = 0;        
        double porcentajeManejo = 0;
        double manejoMinimoUnidad = 0;
        double manejoMinimoDespacho = 0;
        double descuentoPeso = 0;
        double precioPeso = 0;
        int codigoPrecio = 0;
        bool bloquearFlete = false;
        bool bloquearManejo = false;
        bool pagoCredito = false;
        bool pagoContado = false;
        bool pagoDestino = false;
        bool pagoCortesia = false;
        bool pagoRecogida = false;

        public FrmGuiaOperador()
        {
            InitializeComponent();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
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
            TxtCodigoCondicion.Text = ultimaCondicion;
            TxtOperacionIngreso.Text = operacionIngreso;
            TxtOperacionCargo.Text = operacionCargo;
            TxtCodigoCiudadOrigen.Text = ciudadOrigen;
            txtNombreCiudadOrigen.Text = CatalogoManager.BuscarCiudad(ciudadOrigen)?.nombre ?? "";
            ChkContenidoVerificado.Checked = false;
            TxtCodigoCondicion.Focus();
        }

        public void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtFechaIngreso.Text = "";
            TxtOperacionIngreso.Text = "";
            TxtOperacionCargo.Text = "";
            TxtCodigoCondicion.Text = "";
            txtNombreCondicion.Text = "";
            TxtNombreRemitente.Text = "";
            TxtDireccionRemitente.Text = "";
            TxtTelefonoRemitente.Text = "";
            TxtDocumentoCliente.Text = "";
            TxtCodigoCiudadOrigen.Text = "";
            txtNombreCiudadOrigen.Text = "";
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
            TxtDescuentoPeso.Text = "0";
            TxtPorcentajeManejo.Text = "0";
            TxtManejoMinimoUnidad.Text = "0";
            TxtManejoMinimoDespacho.Text = "0";
            TxtComentario.Text = "";

        }

        public void Desbloquear()
        {
            TsbGuardar.Enabled = true;
            TsbCancelar.Enabled = true;           
            TsbNuevo.Enabled = false;            
            MnuGuardar.Enabled = true;
            MnuCancelar.Enabled = true;            
            MnuNuevo.Enabled = false;            
            MnuBuscarGuia.Enabled = false;            
            gbCliente.Enabled = true;
            gbRemitente.Enabled = true;
            gbDestinatario.Enabled = true;
            gbTotales.Enabled = true;
            gbInformacion.Enabled = true;
            gbComentario.Enabled = true;
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
            TsbGuardar.Enabled = false;
            TsbCancelar.Enabled = false;    
            
            MnuNuevo.Enabled = true;
            MnuBuscarGuia.Enabled = true;
            MnuGuardar.Enabled = false;
            MnuCancelar.Enabled = false;

            gbCliente.Enabled = false;
            gbRemitente.Enabled = false;
            gbDestinatario.Enabled = false;
            gbTotales.Enabled = false;
            gbInformacion.Enabled = false;
            gbComentario.Enabled = false;            
            BtnDescuento.Enabled = false;
            BtnManejo.Enabled = false;
        }

        public void Guardar()
        {
            if (!ValidarGuardar() || !(CboTipo.SelectedItem is ApiGuiaTipo apiGuiaTipo))
                return;
            if (!ValidarFormaPago(apiGuiaTipo.codigoFormaPago))
                return;
            if (!ValidarFlete(apiGuiaTipo.validarFlete, Numero(TxtFlete)))
                return;
            if (string.IsNullOrWhiteSpace(TxtOperacionIngreso.Text))
            {
                MessageBox.Show(this, "Debe configurar una operación de ingreso para las guias en Archivo > Configuracion > Operacion", "Operacion de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double cobro = apiGuiaTipo.generaCobro ? Numero(TxtFlete) + Numero(TxtManejo) : 0;
            var guia = new Dictionary<string, object>
            {
                { "codigo_guia_tipo_fk", CboTipo.SelectedValue.ToString() },
                { "codigo_operacion_ingreso_fk", TxtOperacionIngreso.Text },
                { "codigo_operacion_cargo_fk", Texto(TxtOperacionCargo) },
                { "codigo_tercero_fk", codigoCliente },
                { "codigo_adquiriente_fk", codigoCliente },
                { "codigo_servicio_fk", "PAQ" },
                { "codigo_producto_fk", CboProducto.SelectedValue.ToString() },
                { "codigo_empaque_fk", "VARIOS" },
                { "codigo_ciudad_origen_fk", TxtCodigoCiudadOrigen.Text },
                { "codigo_ciudad_destino_fk", TxtCodigoCiudadDestino.Text },
                { "documento_cliente", Texto(TxtDocumentoCliente) },
                { "remitente", TxtNombreRemitente.Text },
                { "direccion_remitente", Texto(TxtDireccionRemitente) },
                { "telefono_remitente", Texto(TxtTelefonoRemitente) },
                { "codigo_destinatario_fk", int.TryParse(TxtCodigoDestinatario.Text, out int destinatario) ? (int?)destinatario : null },
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
                { "vr_recaudo", 0 },
                { "condicion", int.TryParse(TxtCodigoCondicion.Text.Trim(), out int condicion) ? (int?)condicion : null },
                { "precio", codigoPrecio != 0 ? (int?)codigoPrecio : null },
                { "tipo_liquidacion", "K" },
                { "liquidar", false },
                { "comentario", TxtComentario.Text },
                { "contenido_verificado", ChkContenidoVerificado.Checked },
                { "estado_ingreso", cromo.Properties.Settings.Default.guiaIngreso },
                { "estado_recogido", cromo.Properties.Settings.Default.guiaRecogida }
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
            ultimaCondicion = TxtCodigoCondicion.Text;
            ultimoTipo = CboTipo.SelectedValue.ToString();
            ultimoProducto = CboProducto.SelectedValue.ToString();
            Bloquear();
        }

        private static string Texto(TextBox caja)
        {
            return string.IsNullOrWhiteSpace(caja.Text) ? null : caja.Text.Trim();
        }

        private static double Numero(TextBox caja)
        {
            return double.TryParse(caja.Text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out double numero) ? numero : 0;
        }
        public bool ValidarGuardar()
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
                            if (CboProducto.SelectedIndex < 0)
                            {
                                CboProducto.Focus();
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
                                    return true;
                                }
                            }
                            
                        }
                    }
                }
            }
            
        }

        public bool ValidarFormaPago(string codigoFormaPago)
        {
            switch (codigoFormaPago)
            {
                case "CR":
                    if (!pagoCredito)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago credito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "CO":
                    if (!pagoContado)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago contado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "DE":
                    if (!pagoDestino)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "CT":
                    if (!pagoCortesia)
                    {
                        MessageBox.Show(this, "El cliente no maneja pago cortesia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "RE":
                    if (!pagoRecogida)
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

        private void CargarTipo()
        {
            CboTipo.ValueMember = "codigoGuiaTipoPk";
            CboTipo.DisplayMember = "nombre";
            CboTipo.DataSource = CatalogoManager.GuiaTipos;
        }

        private void CargarProducto()
        {
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = CatalogoManager.Productos;
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

        private void FrmGuiaOperador_Load(object sender, EventArgs e)
        {
            bloquearFlete = cromo.Properties.Settings.Default.bloquearFlete;
            bloquearManejo = cromo.Properties.Settings.Default.bloquearManejo;
            CargarTipo();
            CargarProducto();

            // La guía operador siempre es del cliente configurado; si no se puede cargar, no se abre
            string error = null;
            if (!int.TryParse(cromo.Properties.Settings.Default.codigoCliente?.Trim(), out codigoCliente))
            {
                error = "Debe configurar el codigo del cliente en Archivo > Configuracion > Operador";
            }
            else
            {
                try
                {
                    var cliente = Fluor.GetDetalle("/gen/tercero/detalle/" + codigoCliente);
                    ultimaCondicion = Fluor.Texto(cliente, "codigo_condicion_fk") ?? "";
                    pagoCredito = Fluor.Booleano(cliente, "guia_pago_credito");
                    pagoContado = Fluor.Booleano(cliente, "guia_pago_contado");
                    pagoDestino = Fluor.Booleano(cliente, "guia_pago_destino");
                    pagoCortesia = Fluor.Booleano(cliente, "guia_pago_cortesia");
                    pagoRecogida = Fluor.Booleano(cliente, "guia_pago_recogida");
                }
                catch (Exception ex)
                {
                    error = "No se pudo consultar el cliente " + codigoCliente + ": " + Fluor.MensajeError(ex);
                }
            }
            if (error != null)
            {
                MessageBox.Show(this, error, "Guia operador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new Action(Close));
                return;
            }

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
        private void TxtCodigoCondicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                if (codigoCliente != 0)
                {
                    General.CodigoCliente = codigoCliente.ToString();
                    FrmBuscarCondicion frm = new FrmBuscarCondicion();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        TxtCodigoCondicion.Text = General.CodigoCondicion;
                    }
                }
            }
        }

        private void TabularEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true; //Interceptamos la pulsación
                SendKeys.Send("{TAB}"); //Pulsamos la tecla Tabulador por código
            }
            if (sender is TextBox)
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

        private void TxtCodigoCondicion_Validated(object sender, EventArgs e)
        {
            if (int.TryParse(TxtCodigoCondicion.Text.Trim(), out int codigoCondicion))
            {
                try
                {
                    var condicion = Fluor.GetDetalle("/tte/condicion/detalle/" + codigoCondicion);
                    txtNombreCondicion.Text = Fluor.Texto(condicion, "nombre");
                    pesoMinimo = Fluor.Entero(condicion, "peso_minimo");
                    porcentajeManejo = Fluor.Numero(condicion, "porcentaje_manejo");
                    manejoMinimoUnidad = Fluor.Numero(condicion, "manejo_minimo_unidad");
                    manejoMinimoDespacho = Fluor.Numero(condicion, "manejo_minimo_despacho");
                    descuentoPeso = Fluor.Numero(condicion, "descuento_peso");
                    TxtDescuentoPeso.Text = descuentoPeso.ToString();
                    TxtPorcentajeManejo.Text = porcentajeManejo.ToString();
                    TxtManejoMinimoUnidad.Text = manejoMinimoUnidad.ToString();
                    TxtManejoMinimoDespacho.Text = manejoMinimoDespacho.ToString();
                    codigoPrecio = Fluor.Entero(condicion, "codigo_precio_fk");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo consultar la condicion: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ApiCiudad apiCiudad = CatalogoManager.BuscarCiudad(TxtCodigoCiudadDestino.Text);
            if (apiCiudad == null)
                return;

            TxtNombreCiudadDestino.Text = apiCiudad.nombre;
            if (codigoPrecio == 0 || TxtCodigoCiudadOrigen.Text == "" || TxtCodigoCiudadDestino.Text == "")
            {
                MessageBox.Show("Debe seleccionar una condicion comercial, origen y destino del servicio");
                return;
            }

            ApiPrecioDetalle apiPrecioDetalle = ConsultasGuia.PrecioProducto(this, codigoPrecio, TxtCodigoCiudadOrigen.Text, TxtCodigoCiudadDestino.Text, null, CboProducto.SelectedValue?.ToString());
            if (apiPrecioDetalle == null)
            {
                MessageBox.Show(this, "No existe precio para este producto con esta condicion y este destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            precioPeso = apiPrecioDetalle.vrPeso;
            codigoCobertura = apiPrecioDetalle.codigoCoberturaFk;

            var ruta = new Dictionary<string, object>
            {
                { "codigo_tercero_fk", codigoCliente },
                { "codigo_ciudad_origen_fk", TxtCodigoCiudadOrigen.Text },
                { "codigo_ciudad_destino_fk", TxtCodigoCiudadDestino.Text },
                { "codigo_cobertura_fk", string.IsNullOrWhiteSpace(codigoCobertura) ? null : codigoCobertura }
            };

            var condicionFlete = ConsultasGuia.LiquidarCondicionRuta(this, "/tte/condicion-flete/liquidar", ruta, "flete");
            if (condicionFlete != null)
            {
                descuentoPeso = Fluor.Numero(condicionFlete, "descuento_peso");
                pesoMinimo = Fluor.Entero(condicionFlete, "peso_minimo");
                pesoMinimoGuia = Fluor.Entero(condicionFlete, "peso_minimo_guia");
                TxtDescuentoPeso.Text = descuentoPeso.ToString();
            }

            var condicionManejo = ConsultasGuia.LiquidarCondicionRuta(this, "/tte/condicion-manejo/liquidar", ruta, "manejo");
            if (condicionManejo != null)
            {
                porcentajeManejo = Fluor.Numero(condicionManejo, "porcentaje");
                manejoMinimoUnidad = Fluor.Numero(condicionManejo, "minimo_unidad");
                manejoMinimoDespacho = Fluor.Numero(condicionManejo, "minimo_despacho");
                TxtPorcentajeManejo.Text = porcentajeManejo.ToString();
                TxtManejoMinimoUnidad.Text = manejoMinimoUnidad.ToString();
                TxtManejoMinimoDespacho.Text = manejoMinimoDespacho.ToString();
            }
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

        private void TxtUnidades_Validated(object sender, EventArgs e)
        {
            int peso = pesoMinimo * Convert.ToInt32(TxtUnidades.Text);
                 
            if (peso > 0)
            {              
                if (Convert.ToInt32(TxtPeso.Text) <= 0)
                {
                    TxtPeso.Text = peso.ToString();
                }
            }
            double pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
            if (peso > pesoFacturar)
            {
                TxtPesoFacturar.Text = peso.ToString();
            }
        }

        private void TxtPeso_Validated(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TxtVolumen.Text) <= 0)
            {
                TxtVolumen.Text = TxtPeso.Text;
            }
            LiquidarPesoFacturar();
        }

        private void TxtVolumen_Validated(object sender, EventArgs e)
        {
            LiquidarPesoFacturar();
        }

        private void TxtPesoFacturar_Validated(object sender, EventArgs e)
        {
            double vrFlete = 0;
            double vrManejo = 0;
            int pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
            vrFlete = pesoFacturar * precioPeso;
            if (descuentoPeso > 0)
            {
                vrFlete -= vrFlete * descuentoPeso / 100;
            }
                           
            vrFlete = Math.Round(vrFlete);
            TxtFlete.Text = vrFlete.ToString();
            vrManejo = Convert.ToDouble(TxtManejo.Text);
            TxtTotal.Text = (vrFlete + vrManejo).ToString();            
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
                TxtTotal.Text = (Convert.ToDouble(TxtFlete.Text) + Convert.ToDouble(TxtManejo.Text)).ToString();
            }
        }

        private void TsbGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void TsbCancelar_Click(object sender, EventArgs e)
        {
            Bloquear();
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
            General.ManejoMinimoUnidad = Convert.ToDouble(TxtManejoMinimoUnidad.Text);
            General.ManejoMinimoDespacho = Convert.ToDouble(TxtManejoMinimoDespacho.Text);
            FrmManejo frmManejo = new FrmManejo();
            frmManejo.ShowDialog();
            if (frmManejo.DialogResult == DialogResult.OK)
            {
                TxtPorcentajeManejo.Text = General.Manejo.ToString();
                TxtManejoMinimoUnidad.Text = General.ManejoMinimoUnidad.ToString();
                TxtManejoMinimoDespacho.Text = General.ManejoMinimoDespacho.ToString();
                porcentajeManejo = General.Manejo;
                manejoMinimoUnidad = General.ManejoMinimoUnidad;
                manejoMinimoDespacho = General.ManejoMinimoDespacho;
                TxtDeclarado.Focus();
            }
        }

        private void TxtNombreDestinatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                General.CodigoCliente = codigoCliente.ToString();
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
                        return;
                    }

                    if (destinatario != null)
                    {
                        TxtCodigoDestinatario.Text = Fluor.Texto(destinatario, "codigo_destinatario_pk");
                        TxtNombreDestinatario.Text = Fluor.Texto(destinatario, "nombre_corto");
                        TxtDireccionDestinatario.Text = Fluor.Texto(destinatario, "direccion");
                        TxtTelefonoDestinatario.Text = Fluor.Texto(destinatario, "telefono");
                        TxtCodigoCiudadDestino.Text = Fluor.Texto(destinatario, "codigo_ciudad_fk");
                    }
                    else
                    {
                        MessageBox.Show("No existe el destinatario");
                    }
                }            }
        }
    }
}
