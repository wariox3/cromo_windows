using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Web.Script.Serialization;

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

		int pesoMinimoCondicion = 0;
		double porcentajeManejo = 0;
		double manejoMinimoUnidad = 0;
		double manejoMinimoDespacho = 0;
		double descuentoPeso = 0;
		int codigoPrecio = 0;
		
        public FrmGuia()
        {
            InitializeComponent();
        }

        private void Guia_Load(object sender, EventArgs e)
        {
			CargarTipo();
			CargarServicio();
			CargarEmpaque();
			CargarProducto();
			FuncionesGuia fg = new FuncionesGuia();			
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
			if(ultimoTipo != "")
			{
				CboTipo.SelectedValue = ultimoTipo;
			} else
			{
				CboTipo.SelectedIndex = 0;
			}

			TxtFechaIngreso.Text = DateTime.Now.ToString("G");
			TxtCodigoCliente.Text = ultimoCliente;
			TxtCodigoCondicion.Text = ultimaCondicion;
			TxtCodigoCiudadOrigen.Text = cromo.Properties.Settings.Default.ciudadOrigen;
			TxtOperacionIngreso.Text = cromo.Properties.Settings.Default.centroOperacion;			
			TxtOperacionCargo.Text = cromo.Properties.Settings.Default.centroOperacion;
			TxtUsuario.Text = General.UsuarioActivo;
			RbPeso.Enabled = true;
			RbUnidad.Enabled = true;
			RbAdicional.Enabled = true;
			TxtCodigoCliente.Focus();
        }

        public void Guardar()
        {
            if(ValidarGuardar())
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string parametrosJson = "{\"guiaTipo\":\"" + CboTipo.SelectedValue.ToString() + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guiatipo/detalle", parametrosJson);
                ApiGuiaTipo apiGuiaTipo = ser.Deserialize<ApiGuiaTipo>(jsonRespuesta);
                if (apiGuiaTipo.error == null)
                {
                    if(ValidarFormaPago(apiGuiaTipo.codigoFormaPago))
                    {
                        if (ValidarFlete(apiGuiaTipo.validarFlete, Convert.ToDouble(TxtFlete.Text)))
                        {
                            if (ValidarNumero(apiGuiaTipo.exigeNumero))
                            {
                                int numero = General.NumeroGuia;
                                string tipoLiquidacion = this.TipoLiquidacion();
                                if (apiGuiaTipo.cortesia)
                                {
                                    TxtFlete.Text = "0";
                                    TxtManejo.Text = "0";
                                }
                                double cobro = Convert.ToDouble(TxtRecaudo.Text);
                                if (apiGuiaTipo.generaCobro)
                                {
                                    cobro = cobro + Convert.ToDouble(TxtFlete.Text) + Convert.ToDouble(TxtManejo.Text);
                                }

                                ApiGuia apiGuia = new ApiGuia();
                                apiGuia.numeroUnicoGuia = General.NumeroUnicoGuia;
                                apiGuia.codigoGuiaTipo = CboTipo.SelectedValue.ToString();
                                apiGuia.numero = numero;
                                apiGuia.codigoOperacionIngreso = TxtOperacionIngreso.Text;
                                apiGuia.codigoCliente = TxtCodigoCliente.Text;
                                apiGuia.codigoCondicion = TxtCodigoCondicion.Text;
                                apiGuia.codigoCiudadOrigen = TxtCodigoCiudadOrigen.Text;
                                apiGuia.codigoCiudadDestino = TxtCodigoCiudadDestino.Text;
                                apiGuia.codigoRuta = TxtCodigoRuta.Text;                                
                                apiGuia.codigoServicio = CboServicio.SelectedValue.ToString();
                                apiGuia.codigoProducto = CboProducto.SelectedValue.ToString();
                                apiGuia.codigoEmpaque = CboEmpaque.SelectedValue.ToString();
                                apiGuia.documentoCliente = TxtDocumentoCliente.Text;
                                apiGuia.relacionCliente = TxtRelacion.Text;
                                apiGuia.remitente = TxtRemitente.Text;
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
                                apiGuia.factura = ChkFactura.Checked;
                                apiGuia.reexpedicion = ChkReexpedicion.Checked;
                                apiGuia.cortesia = ChkCortesia.Checked;
                                apiGuia.mercanciaPeligrosa = ChkMercanciaPeligrosa.Checked;
                                apiGuia.ordenRuta = TxtOrdenRuta.Text;

                                parametrosJson = ser.Serialize(apiGuia);
                                jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/nuevo", parametrosJson);

                                ApiRespuesta apiRespuesta = ser.Deserialize<ApiRespuesta>(jsonRespuesta);
                                if(apiRespuesta.error == null)
                                {
                                    MessageBox.Show(this, "La guia se guardo con exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                } else
                                {
                                    MessageBox.Show(this, "Ocurrio un error al guardar la guia: " + apiRespuesta.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public string TipoLiquidacion ()
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
                } else
                {
                    MessageBox.Show(this, "Este tipo de guia no puede tener flete en cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            } else
            {
                return true;
            }            
        }

        public bool ValidarNumero(bool exigeNumero)
        {
            if(exigeNumero)
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
            } else
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
                    } else
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

        public void Guardar1()
		{
			//Validar informacion formulario
			bool validacion = true;
			if (TxtCodigoCliente.Text == "" )
			{
				TxtCodigoCliente.Focus();
				validacion = false;
			} else
			{
				if (TxtCodigoCondicion.Text == "")
				{
					TxtCodigoCondicion.Focus();
					validacion = false;
				}
				else
				{
					if (TxtCodigoCiudadOrigen.Text == "")
					{
						TxtCodigoCiudadOrigen.Focus();
						validacion = false;
					}
					else
					{
						if (TxtCodigoCiudadDestino.Text == "")
						{
							TxtCodigoCiudadDestino.Focus();
							validacion = false;
						}
						else
						{
							if (CboTipo.SelectedIndex < 0)
							{
								CboTipo.Focus();
								validacion = false;
							}
							else
							{
								if (CboServicio.SelectedIndex < 0)
								{
									CboServicio.Focus();
									validacion = false;
								}
								else
								{
									if (CboProducto.SelectedIndex < 0)
									{
										CboProducto.Focus();
										validacion = false;
									}
									else
									{
										if (CboEmpaque.SelectedIndex < 0)
										{
											CboEmpaque.Focus();
											validacion = false;
										}
									}
								}
							}
						}
					}
				}
			}
			string tipoLiquidacion = "K";		
			if(RbUnidad.Checked)
			{
				tipoLiquidacion = "U";
			}
			if(RbAdicional.Checked)
			{
				tipoLiquidacion = "A";
			}
			if (validacion == true)
			{
				string sql = "SELECT factura, exige_numero, consecutivo, consecutivo_factura, validar_flete, validar_rango, genera_cobro, cortesia, codigo_forma_pago FROM tte_guia_tipo WHERE codigo_guia_tipo_pk ='" + CboTipo.SelectedValue.ToString() + "'";
				DataSet ds = Utilidades.Ejecutar(sql);
				DataTable dtGuiaTipo = ds.Tables[0];
				if (dtGuiaTipo.Rows.Count > 0)
				{
					if(Convert.ToBoolean(dtGuiaTipo.Rows[0]["validar_flete"]) == true && Convert.ToDouble(TxtFlete.Text) <= 0)
					{
						MessageBox.Show("Este tipo de guia no puede tener flete en cero");
					} else
					{
						ChkFactura.Checked = Convert.ToBoolean(dtGuiaTipo.Rows[0]["factura"]);
						ChkCortesia.Checked = Convert.ToBoolean(dtGuiaTipo.Rows[0]["cortesia"]);
						if(Convert.ToBoolean(dtGuiaTipo.Rows[0]["cortesia"]))
						{
							TxtFlete.Text = "0";
							TxtManejo.Text = "0";
						}
						if (Convert.ToBoolean(dtGuiaTipo.Rows[0]["exige_numero"]))
						{
							FrmDevolverNumero frm = new FrmDevolverNumero();
							frm.ShowDialog();
							if (General.NumeroGuia != 0)
							{
								sql = "SELECT numero FROM tte_guia WHERE codigo_guia_tipo_fk ='" + CboTipo.SelectedValue.ToString() + "' AND numero = " + General.NumeroGuia;
								ds = Utilidades.Ejecutar(sql);
								DataTable dtGuia = ds.Tables[0];
								if (dtGuia.Rows.Count > 0)
								{
									MessageBox.Show("El numero de guia " + General.NumeroGuia + " ya existe para el tipo: " + CboTipo.SelectedValue.ToString());
									validacion = false;
								} else
								{
									//Validar si tiene rango asignado
									if (Convert.ToBoolean(dtGuiaTipo.Rows[0]["validar_rango"]))
									{
										sql = "SELECT desde, hasta FROM tte_guia_cliente WHERE codigo_guia_tipo_fk ='" + CboTipo.SelectedValue.ToString() + "' AND codigo_cliente_fk=" + TxtCodigoCliente.Text + " AND estado_activo = 1";
										ds = Utilidades.Ejecutar(sql);
										DataTable dtGuiaCliente = ds.Tables[0];
										if (dtGuiaCliente.Rows.Count > 0)
										{
											if(General.NumeroGuia < Convert.ToInt32(dtGuiaCliente.Rows[0]["desde"]) || General.NumeroGuia > Convert.ToInt32(dtGuiaCliente.Rows[0]["hasta"]))
											{
												MessageBox.Show("El numero digitado esta fuera del rango asignado para el cliente desde: " + dtGuiaCliente.Rows[0]["desde"] + " hasta:" + dtGuiaCliente.Rows[0]["hasta"]);
												validacion = false;
											}											
										}
										else
										{
											MessageBox.Show("El tipo de guia exige rango y el cliente no tiene uno asignado");
											validacion = false;
										}
									}
									TxtNumero.Text = General.NumeroGuia.ToString();
								}								
							}
							else
							{
								validacion = false;
							}
						} else
						{
							TxtNumero.Text = dtGuiaTipo.Rows[0]["consecutivo"].ToString();
						}

						if (validacion == true)
						{
							if (General.NumeroUnicoGuia)
							{
								sql = "SELECT codigo_guia_pk FROM tte_guia WHERE codigo_guia_pk = " + TxtNumero.Text;
								ds = Utilidades.Ejecutar(sql);
								DataTable dtGuia = ds.Tables[0];
								if (dtGuia.Rows.Count > 0)
								{
									MessageBox.Show("El numero de guia " + TxtNumero.Text + " ya existe");
									validacion = false;
								}
							}
						}

						//Validar formas de pago (cre,con,des)
						if (validacion == true)
						{
							switch (dtGuiaTipo.Rows[0]["codigo_forma_pago"])
							{
								case "CR":
									if (!ChkPagoCredito.Checked)
									{
										MessageBox.Show("El cliente no maneja pago credito");
										validacion = false;
									}
									break;
								case "CO":
									if (!ChkPagoContado.Checked)
									{
										MessageBox.Show("El cliente no maneja pago contado");
										validacion = false;
									}
									break;
								case "DE":
									if (!ChkPagoDestino.Checked)
									{
										MessageBox.Show("El cliente no maneja pago destino");
										validacion = false;
									}
									break;
								case "CT":
									if (!ChkPagoCortesia.Checked)
									{
										MessageBox.Show("El cliente no maneja pago cortesia");
										validacion = false;
									}
									break;
								case "RE":
									if (!ChkPagoRecogida.Checked)
									{
										MessageBox.Show("El cliente no maneja pago recogida");
										validacion = false;
									}
									break;
							}
						}

						if (validacion == true)
						{
							//Si es una factura se le asigna el consecutivo
							if (Convert.ToBoolean(dtGuiaTipo.Rows[0]["factura"]))
							{
								TxtNumeroFactura.Text = dtGuiaTipo.Rows[0]["consecutivo_factura"].ToString();
							}

							double cobro = Convert.ToDouble(TxtRecaudo.Text);
							if(Convert.ToBoolean(dtGuiaTipo.Rows[0]["genera_cobro"]))
							{
								double vrGuia = Convert.ToDouble(TxtFlete.Text) + Convert.ToDouble(TxtManejo.Text);								
								cobro = cobro + vrGuia;
							}
							//https://www.youtube.com/watch?v=IT_R46g7YTk&t=227s
							guia pGuia = new guia();
							if(General.NumeroUnicoGuia)
							{
								pGuia.codigoGuiaPk = Convert.ToInt32(TxtNumero.Text);
							} else
							{
								string sqlConsecutivo = "SELECT guia FROM tte_consecutivo WHERE codigo_consecutivo_pk =1";
								DataSet dsConsecutivo = Utilidades.Ejecutar(sqlConsecutivo);
								DataTable dtConsecutivo = dsConsecutivo.Tables[0];
								
								pGuia.codigoGuiaPk = Convert.ToInt32(dtConsecutivo.Rows[0]["guia"].ToString());
								TxtCodigo.Text = dtConsecutivo.Rows[0]["guia"].ToString();
							}
							pGuia.codigoOperacionIngresoFk = TxtOperacionIngreso.Text;
							pGuia.codigoOperacionCargoFk = TxtOperacionCargo.Text;
							pGuia.codigoClienteFk = Convert.ToInt32(TxtCodigoCliente.Text);
							pGuia.codigoCiudadOrigenFk = TxtCodigoCiudadOrigen.Text;
							pGuia.codigoCiudadDestinoFk = TxtCodigoCiudadDestino.Text;
							pGuia.documentoCliente = TxtDocumentoCliente.Text;
							pGuia.relacionCliente = TxtRelacion.Text;
							pGuia.remitente = TxtRemitente.Text;
							pGuia.codigoServicioFk = CboServicio.SelectedValue.ToString();
							pGuia.codigoGuiaTipoFk = CboTipo.SelectedValue.ToString();
							pGuia.codigoProductoFk = CboProducto.SelectedValue.ToString();
							pGuia.codigoEmpaqueFk = CboEmpaque.SelectedValue.ToString();
							pGuia.nombreDestinatario = TxtNombreDestinatario.Text;
							pGuia.direccionDestinatario = TxtDireccionDestinatario.Text;
							pGuia.telefonoDestinatario = TxtTelefonoDestinatario.Text;
							pGuia.unidades = Convert.ToInt32(TxtUnidades.Text);
							pGuia.pesoReal = Convert.ToInt32(TxtPeso.Text);
							pGuia.pesoVolumen = Convert.ToInt32(TxtVolumen.Text);
							pGuia.pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
							pGuia.vrFlete = Convert.ToDouble(TxtFlete.Text);
							pGuia.vrManejo = Convert.ToDouble(TxtManejo.Text);
							pGuia.vrDeclara = Convert.ToDouble(TxtDeclarado.Text);
							pGuia.vrRecaudo = Convert.ToDouble(TxtRecaudo.Text);
							pGuia.vrCostoReexpedicion = Convert.ToDouble(TxtCostoReexpedicion.Text);
							pGuia.vrCobroEntrega = cobro;
							pGuia.codigoRutaFk = TxtCodigoRuta.Text;
							pGuia.ordenRuta = Convert.ToInt32(TxtOrdenRuta.Text);
							pGuia.reexpedicion = ChkReexpedicion.Checked;
							pGuia.codigoCondicionFk = Convert.ToInt32(TxtCodigoCondicion.Text);
							pGuia.factura = ChkFactura.Checked;
							pGuia.cortesia = ChkCortesia.Checked;
							pGuia.comentario = TxtComentario.Text;
							pGuia.numero = Convert.ToInt32(TxtNumero.Text);
							if(TxtNumeroFactura.Text != "")
							{
								pGuia.numeroFactura = Convert.ToInt32(TxtNumeroFactura.Text);
							}							
							pGuia.usuario = General.UsuarioActivo;
							pGuia.empaqueReferencia = TxtReferenciaEmpaque.Text;
							pGuia.mercanciaPeligrosa = ChkMercanciaPeligrosa.Checked;
							pGuia.tipoLiquidacion = tipoLiquidacion;
							GuiaRepositorio.Agregar(pGuia);

							if (Convert.ToBoolean(dtGuiaTipo.Rows[0]["factura"]))
							{								
								MySqlCommand cmd = new MySqlCommand("UPDATE tte_guia_tipo SET consecutivo_factura = consecutivo_factura+1 WHERE codigo_guia_tipo_pk = '" + CboTipo.SelectedValue.ToString() + "'",
									BdCromo.ObtenerConexion());
								cmd.ExecuteNonQuery();
							}
							if (!General.NumeroUnicoGuia)
							{
								MySqlCommand cmd = new MySqlCommand("UPDATE tte_consecutivo SET guia = guia+1 WHERE codigo_consecutivo_pk = 1",
								BdCromo.ObtenerConexion());
								cmd.ExecuteNonQuery();
							}
							if (!Convert.ToBoolean(dtGuiaTipo.Rows[0]["exige_numero"]))
							{								
								MySqlCommand cmd = new MySqlCommand("UPDATE tte_guia_tipo SET consecutivo = consecutivo+1 WHERE codigo_guia_tipo_pk = '" + CboTipo.SelectedValue.ToString() + "'",
									BdCromo.ObtenerConexion());
								cmd.ExecuteNonQuery();
							}

							MessageBox.Show("Se guardo exitosamente");
							GuardarDetalle(TxtCodigo.Text);
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

					}
				}
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
			TxtRemitente.Text = "";
			TxtDocumentoCliente.Text = "";
			TxtRelacion.Text = "";
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
			TxtVrPeso.Text = "0";
			TxtVrTope.Text = "0";
			TxtVrAdicional.Text = "0";
			TxtVrUnidad.Text = "0";
			TxtTope.Text = "0";
			TxtPesoMinimoPrecio.Text = "0";
			LblPrecioDetalle.Text = "";
			ChkLiquidado.Checked = false;
			RbPeso.Checked = false;
			RbUnidad.Checked = false;
			RbAdicional.Checked = false;
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
            gbDestinatario.Enabled = true;
            gbTotales.Enabled = true;
			gbInformacion.Enabled = true;
			gbComentario.Enabled = true;
			GbPrecioDetalle.Visible = true;
			GbCondiciones.Visible = true;
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
            gbDestinatario.Enabled = false;
            gbTotales.Enabled = false;
			gbInformacion.Enabled = false;
			gbComentario.Enabled = false;
			GbPrecioDetalle.Visible = false;
			GbCondiciones.Visible = false;
			LblPrecioDetalle.Text = "";
		}

		private void TxtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumero(e);
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
			FuncionesGuia fg = new FuncionesGuia();
			TraerGuia(fg.Ultima());
		}

        private void TxtCodigoCliente_Validated(object sender, EventArgs e)
        {
			if(TxtCodigoCliente.Text != "")
			{
                string parametrosJson = "{\"codigo\":\"" + TxtCodigoCliente.Text + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/cliente/detalle", parametrosJson);
                ApiCliente apiCliente = ser.Deserialize<ApiCliente>(jsonRespuesta);
                if(apiCliente.error == null)
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
                    }
                }
				
				if (TxtRemitente.Text == "")
				{
					TxtRemitente.Text = txtNombreCliente.Text;
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
            string parametrosJson = "{\"codigo\":\"" + TxtCodigoCiudadDestino.Text + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/detalle", parametrosJson);
            ApiCiudad apiCiudad = ser.Deserialize<ApiCiudad>(jsonRespuesta);
            if (apiCiudad.error == null)
            {
                TxtNombreCiudadDestino.Text = apiCiudad.nombre;
                TxtCodigoRuta.Text = apiCiudad.codigoRutaFk;
                TxtOrdenRuta.Text = apiCiudad.ordenRuta.ToString();
                ChkReexpedicion.Checked = apiCiudad.reexpedicion;

                if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "")
                {
                    parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + TxtCodigoCiudadOrigen.Text + "\", \"destino\":\"" + TxtCodigoCiudadDestino.Text + "\"}";
                    jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalle", parametrosJson);                    
                    List<ApiPrecioDetalle> apiPrecioDetalleLista = ser.Deserialize<List<ApiPrecioDetalle>>(jsonRespuesta);
                    string texto = "";
                    foreach (ApiPrecioDetalle apiPrecioDetalle in apiPrecioDetalleLista)
                    {
                        texto = texto + "Producto: " + apiPrecioDetalle.productoNombre + " Pes:" + apiPrecioDetalle.vrPeso + 
                            " Und:" + apiPrecioDetalle.vrUnidad + " Tope:" + apiPrecioDetalle.pesoTope + " VrTope:" + apiPrecioDetalle.vrPesoTope + 
                            " VrAdc:" + apiPrecioDetalle.vrPesoTopeAdicional + " Min:" + apiPrecioDetalle.minimo + "\r\n";
                    }
                    LblPrecioDetalle.Text = texto;                                            
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una condicion comercial, origen y destino del servicio");
                }
            }
		}


		private void CargarTipo ()
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

		private void CargarEmpaque()
		{            
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/empaque/lista", null);
            List<ApiEmpaque> apiEmpaqueLista = ser.Deserialize<List<ApiEmpaque>>(jsonRespuesta);
            CboEmpaque.ValueMember = "codigoEmpaquePk";
            CboEmpaque.DisplayMember = "nombre";
            CboEmpaque.DataSource = apiEmpaqueLista;
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
			FuncionesGuia fg = new FuncionesGuia();
			TraerGuia(fg.Ultima());
		}

		private void TsbBuscar_Click(object sender, EventArgs e)
		{
			FuncionesGuia buscar = new FuncionesGuia();
			buscar.DevolverGuia();
			TraerGuia(FuncionesGuia.CodigoGuia);
		}

		private void MnuBuscar_Click(object sender, EventArgs e)
		{
			FuncionesGuia buscar = new FuncionesGuia();
			buscar.DevolverGuia();			
			TraerGuia(FuncionesGuia.CodigoGuia);
		}

        public void TraerGuia(int codigoGuia)
		{
			try
			{
				if(codigoGuia != 0)
				{
					string cmd = string.Format("SELECT codigo_guia_pk, numero, codigo_cliente_fk, tte_cliente.nombre_corto as nombreCliente, " +
						"remitente, documento_cliente, codigo_ciudad_origen_fk, nombre_destinatario, telefono_destinatario, " +
						"direccion_destinatario, codigo_ciudad_destino_fk, unidades, peso_real, peso_volumen, peso_facturado, " +
						"vr_declara, vr_flete, vr_manejo, vr_recaudo, CiudadOrigen.nombre as ciudadOrigen, CiudadDestino.nombre as ciudadDestino, " +
						"codigo_guia_tipo_fk, codigo_servicio_fk, codigo_empaque_fk, fecha_ingreso, fecha_despacho, fecha_entrega, " +
						"codigo_operacion_ingreso_fk, codigo_operacion_cargo_fk, codigo_producto_fk, tte_guia.codigo_condicion_fk, tte_condicion.nombre as nombreCondicion, " +
						"tte_guia.reexpedicion, factura, vr_abono, estado_impreso, estado_embarcado, estado_despachado, estado_entregado, estado_soporte, " +
						"estado_cumplido, estado_facturado, estado_factura_generada, estado_anulado, usuario, relacion_cliente, empaque_referencia, " +
						"tte_guia.comentario, codigo_despacho_fk, vr_costo_reexpedicion, cortesia, numero_factura " +
						"FROM tte_guia " +
						"LEFT JOIN tte_cliente ON tte_guia.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
						"LEFT JOIN tte_ciudad as CiudadOrigen ON tte_guia.codigo_ciudad_origen_fk = CiudadOrigen.codigo_ciudad_pk " +
						"LEFT JOIN tte_ciudad as CiudadDestino ON tte_guia.codigo_ciudad_destino_fk = CiudadDestino.codigo_ciudad_pk " +
						"LEFT JOIN tte_condicion ON tte_guia.codigo_condicion_fk = tte_condicion.codigo_condicion_pk " +
						"WHERE codigo_guia_pk = " + codigoGuia.ToString());
					DataSet ds = Utilidades.Ejecutar(cmd);
					TxtCodigo.Text = ds.Tables[0].Rows[0]["codigo_guia_pk"].ToString();
					TxtNumero.Text = ds.Tables[0].Rows[0]["numero"].ToString();
					TxtNumeroFactura.Text = ds.Tables[0].Rows[0]["numero_factura"].ToString();
					TxtCodigoDespacho.Text = ds.Tables[0].Rows[0]["codigo_despacho_fk"].ToString();
					TxtFechaIngreso.Text = ds.Tables[0].Rows[0]["fecha_ingreso"].ToString();
					TxtFechaDespacho.Text = ds.Tables[0].Rows[0]["fecha_despacho"].ToString();
					TxtFechaEntrega.Text = ds.Tables[0].Rows[0]["fecha_entrega"].ToString();
					TxtOperacionIngreso.Text = ds.Tables[0].Rows[0]["codigo_operacion_ingreso_fk"].ToString();
					TxtOperacionCargo.Text = ds.Tables[0].Rows[0]["codigo_operacion_cargo_fk"].ToString();
					TxtAbono.Text = ds.Tables[0].Rows[0]["vr_abono"].ToString();
					TxtCodigoCliente.Text = ds.Tables[0].Rows[0]["codigo_cliente_fk"].ToString();
					txtNombreCliente.Text = ds.Tables[0].Rows[0]["nombreCliente"].ToString();
					TxtCodigoCondicion.Text = ds.Tables[0].Rows[0]["codigo_condicion_fk"].ToString();
					txtNombreCondicion.Text = ds.Tables[0].Rows[0]["nombreCondicion"].ToString();
					TxtRemitente.Text = ds.Tables[0].Rows[0]["remitente"].ToString();
					TxtDocumentoCliente.Text = ds.Tables[0].Rows[0]["documento_cliente"].ToString();
					TxtRelacion.Text = ds.Tables[0].Rows[0]["relacion_cliente"].ToString();
					TxtCodigoCiudadOrigen.Text = ds.Tables[0].Rows[0]["codigo_ciudad_origen_fk"].ToString();
					txtNombreCiudadOrigen.Text = ds.Tables[0].Rows[0]["ciudadOrigen"].ToString();
					TxtNombreDestinatario.Text = ds.Tables[0].Rows[0]["nombre_destinatario"].ToString();
					TxtTelefonoDestinatario.Text = ds.Tables[0].Rows[0]["telefono_destinatario"].ToString();
					TxtDireccionDestinatario.Text = ds.Tables[0].Rows[0]["direccion_destinatario"].ToString();
					TxtCodigoCiudadDestino.Text = ds.Tables[0].Rows[0]["codigo_ciudad_destino_fk"].ToString();
					TxtNombreCiudadDestino.Text = ds.Tables[0].Rows[0]["ciudadDestino"].ToString();
					TxtUnidades.Text = ds.Tables[0].Rows[0]["unidades"].ToString();
					TxtPeso.Text = ds.Tables[0].Rows[0]["peso_real"].ToString();
					TxtVolumen.Text = ds.Tables[0].Rows[0]["peso_volumen"].ToString();
					TxtPesoFacturar.Text = ds.Tables[0].Rows[0]["peso_facturado"].ToString();
					TxtDeclarado.Text = ds.Tables[0].Rows[0]["vr_declara"].ToString();
					TxtFlete.Text = ds.Tables[0].Rows[0]["vr_flete"].ToString();
					TxtManejo.Text = ds.Tables[0].Rows[0]["vr_manejo"].ToString();
					TxtRecaudo.Text = ds.Tables[0].Rows[0]["vr_recaudo"].ToString();
					TxtCostoReexpedicion.Text = ds.Tables[0].Rows[0]["vr_costo_reexpedicion"].ToString();
					TxtReferenciaEmpaque.Text = ds.Tables[0].Rows[0]["empaque_referencia"].ToString();
					TxtComentario.Text = ds.Tables[0].Rows[0]["comentario"].ToString();
					TxtUsuario.Text = ds.Tables[0].Rows[0]["usuario"].ToString();
					CboTipo.SelectedValue = ds.Tables[0].Rows[0]["codigo_guia_tipo_fk"].ToString();
					CboServicio.SelectedValue = ds.Tables[0].Rows[0]["codigo_servicio_fk"].ToString();
					CboEmpaque.SelectedValue = ds.Tables[0].Rows[0]["codigo_empaque_fk"].ToString();
					CboProducto.SelectedValue = ds.Tables[0].Rows[0]["codigo_producto_fk"].ToString();					
					ChkReexpedicion.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["reexpedicion"]);
					ChkFactura.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["factura"]);
					ChkCortesia.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["cortesia"]);
					ChkEstadoImpreso.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_impreso"]);
					ChkEstadoEmbarcado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_embarcado"]);
					ChkEstadoDespachado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_despachado"]);
					ChkEstadoEntregado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_entregado"]);
					ChkEstadoSoporte.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_soporte"]);
					ChkEstadoCumplido.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_cumplido"]);
					ChkEstadoFacturado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_facturado"]);
					ChkEstadoFacturaGenerada.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_factura_generada"]);
					ChkEstadoAnulado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_anulado"]);
					
				}
			}
			catch (Exception error)
			{
				MessageBox.Show("No se encontro la guia Error(" + error.Message + ")");
			}
		}

		private void TxtPesoFacturar_Validated(object sender, EventArgs e)
		{
			if(ChkLiquidado.Checked == false)
			{
				if(Convert.ToDouble(TxtFlete.Text) <= 0)
				{					
					double vrFlete = 0;
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
							DataSet ds = Utilidades.Ejecutar("SELECT vr_peso " +
								"FROM tte_precio_detalle where codigo_precio_fk = " + General.CodigoPrecioGeneral + " AND codigo_ciudad_origen_fk = " + TxtCodigoCiudadOrigen.Text + " AND " +
								"codigo_ciudad_destino_fk = " + TxtCodigoCiudadDestino.Text + " AND codigo_producto_fk = '" + CboProducto.SelectedValue.ToString() + "'");
							DataTable dt = ds.Tables[0];
							if (dt.Rows.Count > 0)
							{
								precioPeso = Convert.ToDouble(dt.Rows[0]["vr_peso"]);								
							}
						}                        
						vrFlete = pesoFacturar * precioPeso;
                        if(descuentoPeso > 0)
                        {
                            vrFlete -=  vrFlete * descuentoPeso / 100;
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
					TxtFlete.Text = vrFlete.ToString();
				}
			}
		}

		private void TxtUnidades_Validated(object sender, EventArgs e)
		{
			if(ChkLiquidado.Checked == false)
			{
				if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "")
				{
					DataSet ds = Utilidades.Ejecutar("SELECT minimo " +
						"FROM tte_precio_detalle where codigo_precio_fk = " + codigoPrecio + " AND codigo_ciudad_origen_fk = " + TxtCodigoCiudadOrigen.Text + " AND " +
						"codigo_ciudad_destino_fk = " + TxtCodigoCiudadDestino.Text + " AND codigo_producto_fk = '" + CboProducto.SelectedValue.ToString() + "' AND " +
						"vr_peso > 0");
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count > 0)
					{
						if (Convert.ToInt32(TxtPesoFacturar.Text) <= 0)
						{
							if (Convert.ToInt32(dt.Rows[0]["minimo"]) > 0)
							{
								TxtPesoFacturar.Text = (Convert.ToInt32(dt.Rows[0]["minimo"]) * Convert.ToInt32(TxtUnidades.Text)).ToString();
							}
						}
					}
				}

				if (pesoMinimoCondicion > 0)
				{
					TxtPesoFacturar.Text = (pesoMinimoCondicion * Convert.ToInt32(TxtUnidades.Text)).ToString();
					if (Convert.ToInt32(TxtPeso.Text) <= 0)
					{
						TxtPeso.Text = (pesoMinimoCondicion * Convert.ToInt32(TxtUnidades.Text)).ToString();
					}
				}
			} else
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
                    pesoMinimoCondicion = apiCondicion.pesoMinimo;
                    porcentajeManejo = apiCondicion.porcentajeManejo;
                    manejoMinimoUnidad = apiCondicion.manejoMinimoUnidad;
                    manejoMinimoDespacho = apiCondicion.manejoMinimoDespacho;
                    descuentoPeso = apiCondicion.descuentoPeso;
                    codigoPrecio = apiCondicion.codigoPrecioFk;
                    ChkListaGeneral.Checked = apiCondicion.precioGeneral;
                    TxtPesoMinimo.Text = pesoMinimoCondicion.ToString();
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
			if(Convert.ToInt32(TxtVolumen.Text) <= 0)
			{
				TxtVolumen.Text = TxtPeso.Text;
			}
			LiquidarPesoFacturar();
		}

		private void LiquidarPesoFacturar()
		{
			if(Convert.ToInt32(TxtPeso.Text) > Convert.ToInt32(TxtPesoFacturar.Text))
			{
				TxtPesoFacturar.Text = TxtPeso.Text;
			}
			if(Convert.ToInt32(TxtVolumen.Text) > Convert.ToInt32(TxtPesoFacturar.Text))
			{
				TxtPesoFacturar.Text = TxtVolumen.Text;
			}
		}

		private void TxtDeclarado_Validated(object sender, EventArgs e)
		{
			if(Convert.ToDouble(TxtManejo.Text) == 0 && Convert.ToDouble(TxtDeclarado.Text) > 0)
			{
				TxtManejo.Text = (Convert.ToDouble(TxtDeclarado.Text) * porcentajeManejo / 100).ToString();
				if(manejoMinimoDespacho > Convert.ToDouble(TxtManejo.Text)) {
					TxtManejo.Text = manejoMinimoDespacho.ToString();
				}
				if(manejoMinimoUnidad * Convert.ToInt32(TxtUnidades.Text) > Convert.ToDouble(TxtManejo.Text))
				{
					TxtManejo.Text = (manejoMinimoUnidad * Convert.ToInt32(TxtUnidades.Text)).ToString();
				}
			}
		}

		private void MnuImprimir_Click(object sender, EventArgs e)
		{
			Impresion imp = new Impresion();
			imp.FormatoGuia(TxtCodigo.Text);
		}

		private void TsbRecibo_Click(object sender, EventArgs e)
		{
			General.CodigoGuia = Convert.ToInt32(TxtCodigo.Text);
			FrmRecibo frmRecibo = new FrmRecibo();
			frmRecibo.ShowDialog();
		}

		private void TsbImprimir_Click(object sender, EventArgs e)
		{
			Impresion imp = new Impresion();
			imp.FormatoGuia(TxtCodigo.Text);
		}

		private void TsbVistaPrevia_Click(object sender, EventArgs e)
		{
			GuiaRepositorio repositorio = new GuiaRepositorio();			
			Impresion imp = new Impresion();			
			imp.Formato(2, repositorio.sqlFormato(TxtCodigo.Text));
		}

		private void TabularEnter(object sender, KeyEventArgs e)
		{			
			if (e.KeyCode == Keys.Enter)
			{
				this.SelectNextControl((Control)sender, true, true, true, true);
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
					string cmd = string.Format("SELECT codigo_guia_carga_pk, documento_cliente, remitente, numero, relacion_cliente, nombre_destinatario," +
						" direccion_destinatario, telefono_destinatario, comentario, vr_declarado " +
						"FROM tte_guia_carga " +
						"WHERE documento_cliente = '" + documentoCliente + "'");
					DataSet ds = Utilidades.Ejecutar(cmd);
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count > 0)
					{
						TxtRemitente.Text = dt.Rows[0]["remitente"].ToString();
						TxtDocumentoCliente.Text = dt.Rows[0]["documento_cliente"].ToString();
						TxtNumero.Text = dt.Rows[0]["numero"].ToString();
						TxtRelacion.Text = dt.Rows[0]["relacion_cliente"].ToString();
						TxtNombreDestinatario.Text = dt.Rows[0]["nombre_destinatario"].ToString();
						TxtDireccionDestinatario.Text = dt.Rows[0]["direccion_destinatario"].ToString();
						TxtTelefonoDestinatario.Text = dt.Rows[0]["telefono_destinatario"].ToString();
						TxtComentario.Text = dt.Rows[0]["comentario"].ToString();
						TxtDeclarado.Text = dt.Rows[0]["vr_declarado"].ToString();
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
				if(TxtCodigoCliente.Text != "")
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
				if(codigoPrecio != 0 && TxtCodigoCiudadDestino.Text != "" && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCondicion.Text != "")
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
				} else
				{
					MessageBox.Show("Verifique si tiene seleccionada una condicion comercial, ciudad de origen y ciudad de destino");
				}				
			}
		}

		private void GuardarDetalle (string codigoGuia)
		{
			if (General.guiaDetallePublica.Length > 0)
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
			}
		}

		private void CboProducto_Validated(object sender, EventArgs e)
		{
			if (codigoPrecio != 0 && TxtCodigoCiudadOrigen.Text != "" && TxtCodigoCiudadDestino.Text != "")
			{
				DataSet ds = Utilidades.Ejecutar("SELECT vr_peso, vr_unidad, peso_tope, vr_peso_tope, vr_peso_tope_adicional, minimo " +
					"FROM tte_precio_detalle where codigo_precio_fk = " + codigoPrecio + " AND codigo_ciudad_origen_fk = " + TxtCodigoCiudadOrigen.Text + " AND " +
					"codigo_ciudad_destino_fk = " + TxtCodigoCiudadDestino.Text + " AND codigo_producto_fk = '" + CboProducto.SelectedValue.ToString() + "'");
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count > 0)
				{
					TxtVrPeso.Text = dt.Rows[0]["vr_peso"].ToString();
					TxtVrUnidad.Text = dt.Rows[0]["vr_unidad"].ToString();
					TxtTope.Text = dt.Rows[0]["peso_tope"].ToString();
					TxtVrTope.Text = dt.Rows[0]["vr_peso_tope"].ToString();
					TxtVrAdicional.Text = dt.Rows[0]["vr_peso_tope_adicional"].ToString();
					TxtPesoMinimoPrecio.Text = dt.Rows[0]["minimo"].ToString();					
				} else 
				{
					MessageBox.Show("No existe precio para este producto con esta condicion y este destino");
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar una condicion comercial, origen y destino del servicio");
			}
		}

		private void TsbBuscarGuia_Click(object sender, EventArgs e)
		{
			FuncionesGuia buscar = new FuncionesGuia();
			buscar.DevolverCodigoGuia();
			if(General.CodigoGuia != 0)
			{
				TraerGuia(General.CodigoGuia);
			}
		}

		private void MnuBuscarGuia_Click(object sender, EventArgs e)
		{
			FuncionesGuia buscar = new FuncionesGuia();
			buscar.DevolverCodigoGuia();
			if (General.CodigoGuia != 0)
			{
				TraerGuia(General.CodigoGuia);
			}
		}

		private void TxtNombreDestinatario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.ToString() == "F2")
			{
				FrmBuscarDestinatario frmBuscarDestinatario= new FrmBuscarDestinatario();
				frmBuscarDestinatario.ShowDialog();
				if (frmBuscarDestinatario.DialogResult == DialogResult.OK)
				{
					DataSet ds = Utilidades.Ejecutar("SELECT nombre_corto, direccion, telefono, codigo_ciudad_fk " +
						"FROM tte_destinatario WHERE codigo_destinatario_pk = " + General.CodigoDestinatario + " AND estado_inactivo = 0");
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count > 0)
					{
						TxtNombreDestinatario.Text = dt.Rows[0]["nombre_corto"].ToString();
						TxtDireccionDestinatario.Text = dt.Rows[0]["direccion"].ToString();
						TxtTelefonoDestinatario.Text = dt.Rows[0]["telefono"].ToString();
						TxtCodigoCiudadDestino.Text = dt.Rows[0]["codigo_ciudad_fk"].ToString();
					}
					else
					{
						MessageBox.Show("No existe el destinatario");
					}
					
				}
			}
		}

		private void TxtCodigoCiudadDestino_TextChanged(object sender, EventArgs e)
		{

		}

    }

}
