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

        JavaScriptSerializer ser = new JavaScriptSerializer();

        string codigoCliente = "";       
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
            TxtCodigoCiudadOrigen.Text = General.CodigoCiudadOrigenParametro;
            TxtOperacionIngreso.Text = General.CodigoOperacionIngreso;
            TxtOperacionCargo.Text = General.CodigoOperacionCargo;
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
            if (ValidarGuardar())
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string parametrosJson = "{\"guiaTipo\":\"" + CboTipo.SelectedValue.ToString() + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guiatipo/detalle", parametrosJson);
                ApiGuiaTipo apiGuiaTipo = ser.Deserialize<ApiGuiaTipo>(jsonRespuesta);
                if (apiGuiaTipo.error == null)
                {
                    if (ValidarFormaPago(apiGuiaTipo.codigoFormaPago))
                    {
                        if (ValidarFlete(apiGuiaTipo.validarFlete, Convert.ToDouble(TxtFlete.Text)))
                        {                                                        
                            double cobro = 0;
                            if (apiGuiaTipo.generaCobro)
                            {
                                cobro = cobro + Convert.ToDouble(TxtFlete.Text) + Convert.ToDouble(TxtManejo.Text);
                            }

                            ApiGuia apiGuia = new ApiGuia();                           
                            apiGuia.codigoGuiaTipoFk = CboTipo.SelectedValue.ToString();                            
                            apiGuia.codigoOperacionIngresoFk = TxtOperacionIngreso.Text;
                            apiGuia.codigoOperacionCargoFk = TxtOperacionCargo.Text;
                            apiGuia.codigoTerceroFk = codigoCliente;
                            apiGuia.codigoCondicionFk = TxtCodigoCondicion.Text;
                            apiGuia.codigoCiudadOrigenFk = TxtCodigoCiudadOrigen.Text;
                            apiGuia.codigoCiudadDestinoFk = TxtCodigoCiudadDestino.Text;
                            //apiGuia.codigoRutaFk = TxtCodigoRuta.Text;
                            //apiGuia.codigoAsesorFk = TxtCodigoAsesor.Text;
                            apiGuia.codigoServicioFk = "PAQ";
                            apiGuia.codigoProductoFk = CboProducto.SelectedValue.ToString();
                            apiGuia.codigoEmpaqueFk = "VARIOS";
                            apiGuia.documentoCliente = TxtDocumentoCliente.Text;
                            //apiGuia.relacionCliente = TxtRelacion.Text;
                            apiGuia.remitente = TxtNombreRemitente.Text;
                            apiGuia.nombreRemitente = TxtNombreRemitente.Text;
                            apiGuia.telefonoRemitente = TxtTelefonoRemitente.Text;
                            apiGuia.direccionRemitente = TxtDireccionRemitente.Text;
                            apiGuia.nombreDestinatario = TxtNombreDestinatario.Text;
                            apiGuia.direccionDestinatario = TxtDireccionDestinatario.Text;
                            apiGuia.telefonoDestinatario = TxtTelefonoDestinatario.Text;
                            apiGuia.pesoReal = TxtPeso.Text;
                            apiGuia.pesoVolumen = TxtVolumen.Text;
                            apiGuia.pesoFacturado = TxtPesoFacturar.Text;
                            apiGuia.unidades = TxtUnidades.Text;
                            apiGuia.vrRecaudo = "0";
                            apiGuia.vrDeclara = TxtDeclarado.Text;
                            apiGuia.vrFlete = TxtFlete.Text;
                            apiGuia.vrManejo = TxtManejo.Text;
                            apiGuia.vrCostoReexpedicion = "0";
                            apiGuia.vrCobroEntrega = cobro.ToString();
                            apiGuia.usuario = General.UsuarioActivo;
                            //apiGuia.empaqueReferencia = TxtReferenciaEmpaque.Text;
                            apiGuia.tipoLiquidacion = "K";
                            apiGuia.comentario = TxtComentario.Text;
                            //apiGuia.mercanciaPeligrosa = ChkMercanciaPeligrosa.Checked;
                            //apiGuia.ordenRuta = TxtOrdenRuta.Text;
                            //apiGuia.codigoZonaFk = TxtCodigoZona.Text;
                            apiGuia.codigoDestinatarioFk = TxtCodigoDestinatario.Text;
                            parametrosJson = ser.Serialize(apiGuia);
                            jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/nuevo", parametrosJson);
                            ApiGuiaRespuesta apiGuiaRespuesta = ser.Deserialize<ApiGuiaRespuesta>(jsonRespuesta);
                            if (apiGuiaRespuesta.error == null)
                            {
                                MessageBox.Show(this, "La guia se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TxtCodigo.Text = apiGuiaRespuesta.codigoGuiaPk;                               
                                ultimaCondicion = TxtCodigoCondicion.Text;
                                ultimoTipo = CboTipo.SelectedValue.ToString();                               
                                ultimoProducto = CboProducto.SelectedValue.ToString();                                                                
                                Bloquear();
                            }
                            else
                            {
                                MessageBox.Show(this, "Ocurrio un error al guardar la guia: " + apiGuiaRespuesta.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }                            
                        }
                    }
                }
            }

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
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guiatipo/lista", null);
            List<ApiGuiaTipo> apiGuiaTipoLista = ser.Deserialize<List<ApiGuiaTipo>>(jsonRespuesta);
            CboTipo.ValueMember = "codigoGuiaTipoPk";
            CboTipo.DisplayMember = "nombre";
            CboTipo.DataSource = apiGuiaTipoLista;
        }

        private void CargarProducto()
        {
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/producto/lista", null);
            List<ApiProducto> apiProductoLista = ser.Deserialize<List<ApiProducto>>(jsonRespuesta);
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
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
            codigoCliente = cromo.Properties.Settings.Default.codigoCliente;
            CargarTipo();
            CargarProducto();
            if (codigoCliente != "")
            {
                string parametrosJson = "{\"codigo\":\"" + codigoCliente + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/cliente/detalle", parametrosJson);
                ApiCliente apiCliente = ser.Deserialize<ApiCliente>(jsonRespuesta);
                if (apiCliente.error == null)
                {
                    ultimaCondicion = apiCliente.codigoCondicionFk;
                    pagoCredito = apiCliente.guiaPagoCredito;
                    pagoContado = apiCliente.guiaPagoContado;
                    pagoDestino = apiCliente.guiaPagoDestino;
                    pagoCortesia = apiCliente.guiaPagoCortesia;
                    pagoRecogida = apiCliente.guiaPagoRecogida;                                     
                }
            }
        }

        private void TxtCodigoCondicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                if (codigoCliente != "")
                {
                    General.CodigoCliente = codigoCliente;
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
            if (TxtCodigoCondicion.Text != "")
            {
                string parametrosJson = "{\"codigo\":\"" + TxtCodigoCondicion.Text + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/condicion/detalle", parametrosJson);
                ApiCondicion apiCondicion = ser.Deserialize<ApiCondicion>(jsonRespuesta);
                if (apiCondicion.error == null)
                {
                    txtNombreCondicion.Text = apiCondicion.nombre;
                    pesoMinimo = apiCondicion.pesoMinimo;
                    porcentajeManejo = apiCondicion.porcentajeManejo;
                    manejoMinimoUnidad = apiCondicion.manejoMinimoUnidad;
                    manejoMinimoDespacho = apiCondicion.manejoMinimoDespacho;
                    descuentoPeso = apiCondicion.descuentoPeso;
                    TxtDescuentoPeso.Text = apiCondicion.descuentoPeso.ToString();
                    TxtPorcentajeManejo.Text = apiCondicion.porcentajeManejo.ToString();
                    TxtManejoMinimoUnidad.Text = apiCondicion.manejoMinimoUnidad.ToString();
                    TxtManejoMinimoDespacho.Text = apiCondicion.manejoMinimoDespacho.ToString();
                    codigoPrecio = apiCondicion.codigoPrecioFk;
                }
            }
        }

        private void TxtCodigoCiudadOrigen_Validated(object sender, EventArgs e)
        {
            string parametrosJson = "{\"codigo\":\"" + TxtCodigoCiudadOrigen.Text + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/detalle", parametrosJson);
            ApiCiudad apiCiudad = ser.Deserialize<ApiCiudad>(jsonRespuesta);
            if (apiCiudad.error == null)
            {
                txtNombreCiudadOrigen.Text = apiCiudad.nombre;
            }
        }

        private void TxtCodigoCiudadDestino_Validated(object sender, EventArgs e)
        {
            string codigoOrigen = TxtCodigoCiudadOrigen.Text;
            string codigoDestino = TxtCodigoCiudadDestino.Text;
            string parametrosJson = "{\"codigo\":\"" + codigoDestino + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/detalle", parametrosJson);
            ApiCiudad apiCiudad = ser.Deserialize<ApiCiudad>(jsonRespuesta);
            if (apiCiudad.error == null)
            {
                TxtNombreCiudadDestino.Text = apiCiudad.nombre;
                if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "")
                {

                    parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + TxtCodigoCiudadOrigen.Text + "\", \"destino\":\"" + TxtCodigoCiudadDestino.Text + "\", \"zona\":\"" + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                    jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                    ApiPrecioDetalle apiPrecioDetalle = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                    if (apiPrecioDetalle.error == null)
                    {
                        precioPeso = apiPrecioDetalle.vrPeso;
                        codigoCobertura = apiPrecioDetalle.codigoCoberturaFk;

                        parametrosJson = "{\"codigoCliente\":\"" + codigoCliente + "\",\"origen\":\"" + TxtCodigoCiudadOrigen.Text + "\", \"destino\":\"" + TxtCodigoCiudadDestino.Text + "\", \"codigoZona\":\"" + "\", \"codigoCobertura\":\"" + codigoCobertura + "\"}";
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/condicionflete/liquidar", parametrosJson);
                        ApiCondicionFlete apiCondicionFlete = ser.Deserialize<ApiCondicionFlete>(jsonRespuesta);
                        if (apiCondicionFlete.error == null)
                        {
                            descuentoPeso = apiCondicionFlete.descuentoPeso;
                            pesoMinimo = apiCondicionFlete.pesoMinimo;
                            pesoMinimoGuia = apiCondicionFlete.pesoMinimoGuia;
                            TxtDescuentoPeso.Text = apiCondicionFlete.descuentoPeso.ToString();
                        }

                        parametrosJson = "{\"codigoCliente\":\"" + codigoCliente + "\",\"origen\":\"" + TxtCodigoCiudadOrigen.Text + "\", \"destino\":\"" + TxtCodigoCiudadDestino.Text + "\", \"codigoZona\":\"" + "\", \"codigoCobertura\":\"" + codigoCobertura + "\"}";
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/condicionmanejo/liquidar", parametrosJson);
                        ApiCondicionManejo apiCondicionManejo = ser.Deserialize<ApiCondicionManejo>(jsonRespuesta);
                        if (apiCondicionManejo.error == null)
                        {
                            porcentajeManejo = apiCondicionManejo.porcentaje;
                            manejoMinimoUnidad = apiCondicionManejo.minimoUnidad;
                            manejoMinimoDespacho = apiCondicionManejo.minimoDespacho;
                            TxtPorcentajeManejo.Text = apiCondicionManejo.porcentaje.ToString();
                            TxtManejoMinimoUnidad.Text = apiCondicionManejo.minimoUnidad.ToString();
                            TxtManejoMinimoDespacho.Text = apiCondicionManejo.minimoDespacho.ToString();
                               
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No existe precio para este producto con esta condicion y este destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una condicion comercial, origen y destino del servicio");
                }
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
    }
}
