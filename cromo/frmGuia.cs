﻿using System;
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
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string ultimoCliente = "";
        string ultimaCondicion = "";
        string ultimoTipo = "";
        string ultimoServicio = "";
        string ultimoProducto = "";
        string ultimoEmpaque = "";
        string pago = "";

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

        public FrmGuia()
        {
            InitializeComponent();
        }

        private void Guia_Load(object sender, EventArgs e)
        {
            bloquearFlete = cromo.Properties.Settings.Default.bloquearFlete;
            bloquearManejo = cromo.Properties.Settings.Default.bloquearManejo;
            CargarTipo();
            CargarServicio();
            CargarEmpaque();
            CargarProducto();
            CargarIdentificacionDestinatario();
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
            TxtCodigoCiudadOrigen.Text = General.CodigoCiudadOrigenParametro;
            TxtOperacionIngreso.Text = General.CodigoOperacionIngreso;
            TxtOperacionCargo.Text = General.CodigoOperacionCargo;
            TxtUsuario.Text = General.UsuarioActivo;
            RbPeso.Enabled = true;
            RbUnidad.Enabled = true;
            RbAdicional.Enabled = true;
            TxtCodigoCliente.Focus();
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
                            if (ValidarNumero(apiGuiaTipo.exigeNumero))
                            {
                                int numero = General.NumeroGuia;
                                string tipoLiquidacion = this.TipoLiquidacion();
                                double cobro = Convert.ToDouble(TxtRecaudo.Text);
                                if (apiGuiaTipo.generaCobro)
                                {
                                    cobro = cobro + Convert.ToDouble(TxtFlete.Text) + Convert.ToDouble(TxtManejo.Text);
                                }

                                ApiGuia apiGuia = new ApiGuia();
                                apiGuia.numeroUnicoGuia = General.NumeroUnicoGuia;
                                apiGuia.codigoGuiaTipoFk = CboTipo.SelectedValue.ToString();
                                apiGuia.numero = numero;
                                apiGuia.codigoOperacionIngresoFk = TxtOperacionIngreso.Text;
                                apiGuia.codigoOperacionCargoFk = TxtOperacionCargo.Text;
                                apiGuia.codigoTerceroFk = TxtCodigoCliente.Text;
                                apiGuia.codigoCondicionFk = TxtCodigoCondicion.Text;
                                apiGuia.codigoCiudadOrigenFk = TxtCodigoCiudadOrigen.Text;
                                apiGuia.codigoCiudadDestinoFk = TxtCodigoCiudadDestino.Text;
                                apiGuia.codigoRutaFk = TxtCodigoRuta.Text;
                                apiGuia.codigoAsesorFk = TxtCodigoAsesor.Text;
                                apiGuia.codigoServicioFk = CboServicio.SelectedValue.ToString();
                                apiGuia.codigoProductoFk = CboProducto.SelectedValue.ToString();
                                apiGuia.codigoEmpaqueFk = CboEmpaque.SelectedValue.ToString();
                                apiGuia.documentoCliente = TxtDocumentoCliente.Text;
                                apiGuia.relacionCliente = TxtRelacion.Text;
                                apiGuia.remitente = TxtNombreRemitente.Text;
                                apiGuia.nombreRemitente = TxtNombreRemitente.Text;
                                apiGuia.telefonoRemitente = TxtTelefonoRemitente.Text;
                                apiGuia.direccionRemitente = TxtDireccionRemitente.Text;
                                apiGuia.codigoIdentificacionDestinatarioFk = CboIdentificacionDestinatario.SelectedValue.ToString();
                                apiGuia.numeroIdentificacionDestinatario = TxtNumeroIdentificacionDestinatario.Text;
                                apiGuia.nombreDestinatario = TxtNombreDestinatario.Text;
                                apiGuia.direccionDestinatario = TxtDireccionDestinatario.Text;
                                apiGuia.telefonoDestinatario = TxtTelefonoDestinatario.Text;
                                apiGuia.pesoReal = TxtPeso.Text;
                                apiGuia.pesoVolumen = TxtVolumen.Text;
                                apiGuia.pesoFacturado = TxtPesoFacturar.Text;
                                apiGuia.unidades = TxtUnidades.Text;
                                apiGuia.vrRecaudo = TxtRecaudo.Text;
                                apiGuia.vrDeclara = TxtDeclarado.Text;
                                apiGuia.vrFlete = TxtFlete.Text;
                                apiGuia.vrManejo = TxtManejo.Text;
                                apiGuia.vrCostoReexpedicion = TxtCostoReexpedicion.Text;
                                apiGuia.vrCobroEntrega = cobro.ToString();
                                apiGuia.usuario = General.UsuarioActivo;
                                apiGuia.empaqueReferencia = TxtReferenciaEmpaque.Text;
                                apiGuia.tipoLiquidacion = tipoLiquidacion;
                                apiGuia.comentario = TxtComentario.Text;
                                apiGuia.mercanciaPeligrosa = ChkMercanciaPeligrosa.Checked;
                                apiGuia.contenidoVerificado = ChkContenidoVerificado.Checked;
                                apiGuia.ordenRuta = TxtOrdenRuta.Text;
                                apiGuia.codigoZonaFk = TxtCodigoZona.Text;
                                apiGuia.codigoDestinatarioFk = TxtCodigoDestinatario.Text;
                                if (CboTerceroOperacion.Items.Count > 0) {
                                    apiGuia.codigoTerceroOperacionFk = CboTerceroOperacion.SelectedValue.ToString();
                                }
                               
                                
                                parametrosJson = ser.Serialize(apiGuia);
                                jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/nuevo", parametrosJson);
                                ApiGuiaRespuesta apiGuiaRespuesta = ser.Deserialize<ApiGuiaRespuesta>(jsonRespuesta);
                                if (apiGuiaRespuesta.error == null)
                                {
                                    MessageBox.Show(this, "La guia se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TxtNumero.Text = apiGuiaRespuesta.numero;
                                    TxtNumeroFactura.Text = apiGuiaRespuesta.numeroFactura;
                                    TxtCodigo.Text = apiGuiaRespuesta.codigoGuiaPk;
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
                                else
                                {
                                    MessageBox.Show(this, "Ocurrio un error al guardar la guia: " + apiGuiaRespuesta.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }

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

        public bool ValidarNumero(bool exigeNumero)
        {
            if (exigeNumero)
            {
                FrmDevolverNumero frm = new FrmDevolverNumero();
                frm.ShowDialog();
                if (General.NumeroGuia != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, "Este tipo de guia exige numero y debe digitarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                General.NumeroGuia = 0;
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
            TxtNumero.Text = "";
            TxtNumeroFactura.Text = "";
            TxtAbono.Text = "0";
            TxtComentario.Text = "";
            TxtReferenciaEmpaque.Text = "";
            TxtCostoReexpedicion.Text = "0";
            TxtCodigoDespacho.Text = "";
            ChkFactura.Checked = false;
            ChkReexpedicion.Checked = false;
            ChkEstadoImpreso.Checked = false;
            ChkEstadoEmbarcado.Checked = false;
            ChkEstadoEntregado.Checked = false;
            ChkEstadoCumplido.Checked = false;
            ChkEstadoFacturaGenerada.Checked = false;
            ChkEstadoDespachado.Checked = false;
            ChkEstadoSoporte.Checked = false;
            ChkEstadoAnulado.Checked = false;
            ChkEstadoFacturado.Checked = false;
            TxtPesoMinimo.Text = "0";
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
            LvPrecioDetalle.Items.Clear();
            ChkLiquidado.Checked = false;
            RbPeso.Checked = false;
            RbUnidad.Checked = false;
            RbAdicional.Checked = false;
            TxtUsuario.Text = "";
            ChkMercanciaPeligrosa.Checked = false;
            ChkContenidoVerificado.Checked = false;            
        }

        public void Desbloquear()
        {
            TsbGuardar.Enabled = true;
            TsbCancelar.Enabled = true;
            TsbPrecargar.Enabled = true;
            TsbNuevo.Enabled = false;
            TsbBuscar.Enabled = false;
            TsbImprimir.Enabled = false;

            MnuGuardar.Enabled = true;
            MnuCancelar.Enabled = true;
            MnuPrecargar.Enabled = true;
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
            TsbPrecargar.Enabled = false;
            TsbImprimir.Enabled = true;

            MnuNuevo.Enabled = true;
            MnuBuscar.Enabled = true;
            MnuBuscarGuia.Enabled = true;
            MnuGuardar.Enabled = false;
            MnuCancelar.Enabled = false;
            MnuPrecargar.Enabled = false;
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
            if (TxtCodigoCliente.Text != "")
            {
                string parametrosJson = "{\"codigo\":\"" + TxtCodigoCliente.Text + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/cliente/detalle", parametrosJson);
                ApiCliente apiCliente = ser.Deserialize<ApiCliente>(jsonRespuesta);
                if (apiCliente.error == null)
                {
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
            TxtUnidades.Text = "0";
            TxtPeso.Text = "0";
            TxtVolumen.Text = "0";
            TxtPesoFacturar.Text = "0";
            TxtDeclarado.Text = "0";            
            TxtFlete.Text = "0";
            TxtManejo.Text = "0";
            if (ChkInvertirCiudad.Checked)
            {
                codigoOrigen = TxtCodigoCiudadDestino.Text;
                codigoDestino = TxtCodigoCiudadOrigen.Text;
            }
            string parametrosJson = "{\"codigo\":\"" + codigoDestino + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/detalle", parametrosJson);
            ApiCiudad apiCiudad = ser.Deserialize<ApiCiudad>(jsonRespuesta);
            if (apiCiudad.error == null)
            {
                TxtNombreCiudadDestino.Text = apiCiudad.nombre;
                TxtCodigoRuta.Text = apiCiudad.codigoRutaFk;
                TxtOrdenRuta.Text = apiCiudad.ordenRuta.ToString();
                TxtCodigoZona.Text = apiCiudad.codigoZonaFk;
                ChkReexpedicion.Checked = apiCiudad.reexpedicion;

                if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "")
                {
                    LvPrecioDetalle.Items.Clear();
                    parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + TxtCodigoCiudadOrigen.Text + "\", \"destino\":\"" + TxtCodigoCiudadDestino.Text + "\"}";
                    jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalle", parametrosJson);
                    List<ApiPrecioDetalle> apiPrecioDetalleLista = ser.Deserialize<List<ApiPrecioDetalle>>(jsonRespuesta);
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

                    if (TxtCodigoCliente.Text != "")
                    {                        
                        parametrosJson = "{\"codigoCliente\":\"" + TxtCodigoCliente.Text + "\",\"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"codigoZona\":\"" + TxtCodigoZona.Text + "\", \"codigoCobertura\":\"" + TxtCodigoCobertura.Text + "\", \"guiaTipo\":\"" + CboTipo.SelectedValue.ToString() + "\"}";
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/condicionflete/liquidar", parametrosJson);
                        ApiCondicionFlete apiCondicionFlete = ser.Deserialize<ApiCondicionFlete>(jsonRespuesta);
                        if (apiCondicionFlete.error == null)
                        {
                            TxtFleteDescuentoPeso.Text = apiCondicionFlete.descuentoPeso.ToString();
                            TxtFleteDescuentoUnidad.Text = apiCondicionFlete.descuentoUnidad.ToString();
                            TxtFletePesoMinimo.Text = apiCondicionFlete.pesoMinimo.ToString();
                            TxtFletePesoMinimoGuia.Text = apiCondicionFlete.pesoMinimoGuia.ToString();
                            TxtFleteFleteMinimo.Text = apiCondicionFlete.fleteMinimo.ToString();
                            TxtFleteFleteMinimoGuia.Text = apiCondicionFlete.fleteMinimoGuia.ToString();
                            pesoMinimo = apiCondicionFlete.pesoMinimo;
                            pesoMinimoGuia = apiCondicionFlete.pesoMinimoGuia;
                            descuentoPeso = apiCondicionFlete.descuentoPeso;
                        } else
                        {
                            TxtFleteDescuentoPeso.Text = "0";
                            TxtFleteDescuentoUnidad.Text = "0";
                            TxtFletePesoMinimo.Text = "0";
                            TxtFletePesoMinimoGuia.Text = "0";
                            TxtFleteFleteMinimo.Text = "0";
                            TxtFleteFleteMinimoGuia.Text = "0";
                        }
                        parametrosJson = "{\"codigoCliente\":\"" + TxtCodigoCliente.Text + "\",\"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"codigoZona\":\"" + TxtCodigoZona.Text + "\", \"codigoCobertura\":\"" + TxtCodigoCobertura.Text + "\", \"guiaTipo\":\"" + CboTipo.SelectedValue.ToString() + "\"}";
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/condicionmanejo/liquidar", parametrosJson);
                        ApiCondicionManejo apiCondicionManejo = ser.Deserialize<ApiCondicionManejo>(jsonRespuesta);
                        if (apiCondicionManejo.error == null)
                        {
                            TxtPorcentajeManejoEspecial.Text = apiCondicionManejo.porcentaje.ToString();
                            TxtManejoMinimoUnidadEspecial.Text = apiCondicionManejo.minimoUnidad.ToString();
                            TxtManejoMinimoDespachoEspecial.Text = apiCondicionManejo.minimoDespacho.ToString();
                            porcentajeManejo = apiCondicionManejo.porcentaje;
                            manejoMinimoUnidad = apiCondicionManejo.minimoUnidad;
                            manejoMinimoDespacho = apiCondicionManejo.minimoDespacho;
                        }
                    }
                    else
                    {
                        TxtFleteDescuentoPeso.Text = "0";
                        TxtFleteDescuentoUnidad.Text = "0";
                        TxtFletePesoMinimo.Text = "0";
                        TxtFletePesoMinimoGuia.Text = "0";
                        TxtFleteFleteMinimo.Text = "0";
                        TxtFleteFleteMinimoGuia.Text = "0";
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
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guiatipo/lista", null);
            List<ApiGuiaTipo> apiGuiaTipoLista = ser.Deserialize<List<ApiGuiaTipo>>(jsonRespuesta);
            CboTipo.ValueMember = "codigoGuiaTipoPk";
            CboTipo.DisplayMember = "nombre";
            CboTipo.DataSource = apiGuiaTipoLista;
        }

        private void CargarServicio()
        {

            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/servicio/lista", null);
            List<ApiServicio> apiServicioLista = ser.Deserialize<List<ApiServicio>>(jsonRespuesta);
            CboServicio.ValueMember = "codigoServicioPk";
            CboServicio.DisplayMember = "nombre";
            CboServicio.DataSource = apiServicioLista;
        }

        private void CargarProducto()
        {           
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/producto/lista", null);
            List<ApiProducto> apiProductoLista = ser.Deserialize<List<ApiProducto>>(jsonRespuesta);
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
        }

        private void CargarProductoCliente(int codigoCliente)
        {
            string parametrosJson = "{\"codigoTercero\":\"" + codigoCliente.ToString() + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/producto/cliente", parametrosJson);
            List<ApiProducto> apiProductoLista = ser.Deserialize<List<ApiProducto>>(jsonRespuesta);
            CboProducto.Text = "";
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
        }

        private void CargarEmpaque()
        {
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/empaque/lista", null);
            List<ApiEmpaque> apiEmpaqueLista = ser.Deserialize<List<ApiEmpaque>>(jsonRespuesta);
            CboEmpaque.ValueMember = "codigoEmpaquePk";
            CboEmpaque.DisplayMember = "nombre";
            CboEmpaque.DataSource = apiEmpaqueLista;
        }

        private void CargarIdentificacionDestinatario()
        {
            string jsonRespuesta = ApiControlador.ApiPost("/general/api/windows/identificacion/lista", null);
            List<ApiIdentificacion> apiIdentificacion = ser.Deserialize<List<ApiIdentificacion>>(jsonRespuesta);
            CboIdentificacionDestinatario.ValueMember = "codigoIdentificacionPk";
            CboIdentificacionDestinatario.DisplayMember = "nombre";
            CboIdentificacionDestinatario.DataSource = apiIdentificacion;
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
                        string parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                        string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                        ApiPrecioDetalle apiPrecioDetalle = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                        if (apiPrecioDetalle.error == null)
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
                    string parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + TxtCodigoCiudadOrigen.Text + "\", \"destino\":\"" + TxtCodigoCiudadDestino.Text + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                    string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                    ApiPrecioDetalle apiPrecioDetalle = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                    if (apiPrecioDetalle.error == null)
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
                    codigoPrecio = apiCondicion.codigoPrecioFk;
                    limitarDescuentoReexpedicion = apiCondicion.limitarDescuentoReexpedicion;
                    TxtCodigoPrecio.Text = apiCondicion.codigoPrecioFk.ToString();
                    ChkListaGeneral.Checked = apiCondicion.precioGeneral;
                    TxtPesoMinimo.Text = pesoMinimo.ToString();
                    TxtPorcentajeManejo.Text = porcentajeManejo.ToString();
                    TxtDescuentoPeso.Text = descuentoPeso.ToString();
                    TxtManejoMinimoUnidad.Text = manejoMinimoUnidad.ToString();
                    TxtManejoMinimoDespacho.Text = manejoMinimoDespacho.ToString();

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
                if (pago == "DES" || pago == "CON")
                {                   
                    vrManejo = Math.Round(vrManejo / 100) * 100;
                }
                TxtManejo.Text = vrManejo.ToString();
                TxtTotal.Text = (vrFlete + vrManejo).ToString();
            }
        }

        private void MnuImprimir_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != "")
            {
                ImprimirFormato formato = new ImprimirFormato();
                formato.codigoFormato = "2";
                formato.codigoDesde = TxtCodigo.Text;
                formato.codigoHasta = TxtCodigo.Text;
                formato.tipo = "Guia";
                General.Formato = formato;
                FrmVisor frm = new FrmVisor();
                frm.ShowDialog();
            }
        }

        private void TsbRecibo_Click(object sender, EventArgs e)
        {
            General.CodigoGuia = Convert.ToInt32(TxtCodigo.Text);
            FrmRecibo frmRecibo = new FrmRecibo();
            frmRecibo.ShowDialog();
        }

        private void TsbImprimir_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != "")
            {
                ImprimirFormato formato = new ImprimirFormato();
                formato.codigoFormato = General.CodigoFormatoGuia;
                formato.codigoDesde = TxtCodigo.Text;
                formato.codigoHasta = TxtCodigo.Text;
                formato.tipo = "Guia";
                General.Formato = formato;
                FrmVisor frm = new FrmVisor();
                frm.ShowDialog();
            }
        }

        private void TsbVistaPrevia_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != "")
            {
                ImprimirFormato formato = new ImprimirFormato();
                formato.codigoFormato = General.CodigoFormatoGuia;
                formato.codigoDesde = TxtCodigo.Text;
                formato.codigoHasta = TxtCodigo.Text;
                formato.tipo = "Guia";
                General.Formato = formato;
                FrmVisor frm = new FrmVisor();
                frm.ShowDialog();
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

        private void TsbPrecargar_Click(object sender, EventArgs e)
        {
            Precargar();
        }

        private void MnuPrecargar_Click(object sender, EventArgs e)
        {
            Precargar();
        }

        private void Precargar()
        {
            FrmDevolverDocumento frm = new FrmDevolverDocumento();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                TraerPrecarga(General.DocumentoCliente);

            }

        }

        public void TraerPrecarga(string documentoCliente)
        {
            try
            {
                if (documentoCliente != "")
                {
                    string parametrosJson = "{\"documentoCliente\":\"" + documentoCliente + "\"}";
                    string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guiacarga/detalle", parametrosJson);
                    ApiGuiaCarga apiGuiaCarga = ser.Deserialize<ApiGuiaCarga>(jsonRespuesta);
                    if (apiGuiaCarga.error == null)
                    {
                        TxtNombreRemitente.Text = apiGuiaCarga.remitente;
                        TxtDocumentoCliente.Text = apiGuiaCarga.documentoCliente;
                        TxtNumero.Text = apiGuiaCarga.numero;
                        TxtRelacion.Text = apiGuiaCarga.relacionCliente;
                        TxtNombreDestinatario.Text = apiGuiaCarga.nombreDestinatario;
                        TxtDireccionDestinatario.Text = apiGuiaCarga.direccionDestinatario;
                        TxtTelefonoDestinatario.Text = apiGuiaCarga.telefonoDestinatario;
                        TxtComentario.Text = apiGuiaCarga.comentario;
                        TxtDeclarado.Text = apiGuiaCarga.vrDeclarado.ToString();
                    }
                    else
                    {
                        MessageBox.Show(this, "Error del servicio ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo cargar la informacion inicial (" + error.Message + ")");
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

        private void TxtUnidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {

                ChkLiquidado.Checked = true;
                if (codigoPrecio != 0 && TxtCodigoCiudadDestino.Text != "" && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCondicion.Text != "")
                {
                    General.CodigoPrecio = codigoPrecio;
                    General.CodigoCiudad = TxtCodigoCiudadOrigen.Text;
                    General.CodigoCiudadDestino = TxtCodigoCiudadDestino.Text;
                    General.CodigoCondicion = TxtCodigoCondicion.Text;
                    FrmGuiaDetalle frm = new FrmGuiaDetalle();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        TxtUnidades.Text = General.Unidades.ToString();
                        TxtFlete.Text = General.VrFlete.ToString();
                        TxtPeso.Text = General.Peso.ToString();
                        TxtVolumen.Text = General.Volumen.ToString();
                        TxtPesoFacturar.Text = General.PesoFacturar.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Verifique si tiene seleccionada una condicion comercial, ciudad de origen y ciudad de destino");
                }
            }
        }

        private void GuardarDetalle(string codigoGuia)
        {
            /*if (General.guiaDetallePublica.Length > 0)
			{
				string sql = "";
				for (int i = 0; i < General.guiaDetallePublica.Length; i++)
				{
					sql = "INSERT INTO tte_guia_detalle (" +
						"codigo_guia_fk, codigo_producto_fk, unidades, peso_real, peso_volumen, peso_facturado, vr_flete) VALUES (" +
						codigoGuia + "," + General.guiaDetallePublica[i].codigoProducto.ToString() + "" +
						"," + General.guiaDetallePublica[i].unidades + "" +
						"," + General.guiaDetallePublica[i].pesoReal + "" +
						"," + General.guiaDetallePublica[i].pesoVolumen + "" +
						"," + General.guiaDetallePublica[i].pesoFacturar + "" +
						"," + General.guiaDetallePublica[i].vrFlete + ") ";
					MySqlCommand cmd = new MySqlCommand(sql,
					BdCromo.ObtenerConexion());
					cmd.ExecuteNonQuery();
				}
				General.guiaDetallePublica = new GuiaDetalle[0];
			}*/
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
                string parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"zona\":\"" + TxtCodigoZona.Text + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                ApiPrecioDetalle apiPrecioDetalle = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                if (apiPrecioDetalle.error == null)
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
                    if(ChkListaGeneral.Checked)
                    {
                        parametrosJson = "{\"precio\":\"1\", \"origen\":\"" + TxtCodigoCiudadOrigen.Text + "\", \"destino\":\"" + TxtCodigoCiudadDestino.Text + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                        jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                        ApiPrecioDetalle apiPrecioDetalleGeneral = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                        if (apiPrecioDetalleGeneral.error == null)
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
                string parametrosJson = "{\"codigoGuiaPk\":\"" + General.CodigoGuia + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/detalle", parametrosJson);
                ApiGuia apiGuia = ser.Deserialize<ApiGuia>(jsonRespuesta);
                if (apiGuia.error == null)
                {
                    TraerGuia(apiGuia);
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
                    string parametrosJson = "{\"codigo\":\"" + General.CodigoDestinatario + "\"}";
                    string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/destinatario/detalle", parametrosJson);
                    ApiDestinatario apiDestinatario = ser.Deserialize<ApiDestinatario>(jsonRespuesta);
                    if (apiDestinatario.error == null)
                    {
                        TxtCodigoDestinatario.Text = apiDestinatario.codigoDestinatarioPk;
                        TxtNombreDestinatario.Text = apiDestinatario.nombreCorto;
                        TxtDireccionDestinatario.Text = apiDestinatario.direccion;
                        TxtTelefonoDestinatario.Text = apiDestinatario.telefono;
                        TxtCodigoCiudadDestino.Text = apiDestinatario.codigoCiudadFk;
                        TxtNumeroIdentificacionDestinatario.Text = apiDestinatario.numeroIdentificacion;
                        CboIdentificacionDestinatario.SelectedValue = apiDestinatario.codigoIdentificacionFk;
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
            TxtNumero.Text = apiGuia.numero.ToString();
            TxtNumeroFactura.Text = apiGuia.numeroFactura;
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
            TxtTotal.Text = (Convert.ToDouble(apiGuia.vrFlete) + Convert.ToDouble(apiGuia.vrManejo)).ToString();
            TxtRecaudo.Text = apiGuia.vrRecaudo;
            TxtCostoReexpedicion.Text = apiGuia.vrCostoReexpedicion;
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

        private void TxtNombreRemitente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                FrmBuscarRemitente frmBuscarRemitente = new FrmBuscarRemitente();
                frmBuscarRemitente.ShowDialog();
                if (frmBuscarRemitente.DialogResult == DialogResult.OK)
                {
                    string parametrosJson = "{\"codigo\":\"" + General.CodigoRemitente + "\"}";
                    string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/remitente/detalle", parametrosJson);
                    ApiRemitente apiRemitente = ser.Deserialize<ApiRemitente>(jsonRespuesta);
                    if (apiRemitente.error == null)
                    {
                        TxtCodigoRemitente.Text = apiRemitente.codigoRemitentePk;
                        TxtNombreRemitente.Text = apiRemitente.nombreCorto;
                        TxtDireccionRemitente.Text = apiRemitente.direccion;
                        TxtTelefonoRemitente.Text = apiRemitente.telefono;
                        TxtCodigoCiudadOrigen.Text = apiRemitente.codigoCiudadFk;
                        TxtCodigoAsesor.Text = apiRemitente.codigoAsesorFk;
                    }
                    else
                    {
                        MessageBox.Show("No existe el remitente");
                    }

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
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string parametrosJson = "{\"guiaTipo\":\"" + CboTipo.SelectedValue.ToString() + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guiatipo/detalle", parametrosJson);
            ApiGuiaTipo apiGuiaTipo = ser.Deserialize<ApiGuiaTipo>(jsonRespuesta);
            if (apiGuiaTipo.error == null)
            {
                pago = apiGuiaTipo.codigoPagoFk;
            }
        }

        private void TxtFlete_Validated(object sender, EventArgs e)
        {
            double flete = Convert.ToDouble(TxtFlete.Text);
            double manejo = Convert.ToDouble(TxtManejo.Text);
            TxtTotal.Text = (flete + manejo).ToString();
        }

        private void TxtManejo_Validated(object sender, EventArgs e)
        {
            double flete = Convert.ToDouble(TxtFlete.Text);
            double manejo = Convert.ToDouble(TxtManejo.Text);
            TxtTotal.Text = (flete + manejo).ToString();
        }
    }

}
