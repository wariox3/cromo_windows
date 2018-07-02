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

namespace cromo
{
    public partial class FrmGuia : Form
    {
		string ultimoCliente = "";
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
			TraerGuia(fg.Ultima());		
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
			TxtCodigoCiudadOrigen.Text = cromo.Properties.Settings.Default.ciudadOrigen;
			TxtOperacionIngreso.Text = cromo.Properties.Settings.Default.centroOperacion;			
			TxtOperacionCargo.Text = cromo.Properties.Settings.Default.centroOperacion;
			TxtUsuario.Text = General.UsuarioActivo;
			TxtCodigoCliente.Focus();
        }

		public void Guardar()
		{
			//Validar informacion formulario
			bool validacion = true;
			if (TxtCodigoCliente.Text == "")
			{
				TxtCodigoCliente.Focus();
				validacion = false;
			}
			if (TxtCodigoCiudadOrigen.Text == "")
			{
				TxtCodigoCiudadOrigen.Focus();
				validacion = false;
			}
			if (TxtCodigoCiudadDestino.Text == "")
			{
				TxtCodigoCiudadDestino.Focus();
				validacion = false;
			}
			if (CboTipo.SelectedIndex < 0)
			{
				CboTipo.Focus();
				validacion = false;
			}
			if (CboServicio.SelectedIndex < 0)
			{
				CboServicio.Focus();
				validacion = false;
			}
			if (CboProducto.SelectedIndex < 0)
			{
				CboProducto.Focus();
				validacion = false;
			}
			if (CboEmpaque.SelectedIndex < 0)
			{
				CboEmpaque.Focus();
				validacion = false;
			}


			if (validacion == true)
			{
				string sql = "SELECT factura, exige_numero, consecutivo FROM tte_guia_tipo WHERE codigo_guia_tipo_pk ='" + CboTipo.SelectedValue.ToString() + "'";
				DataSet ds = Utilidades.Ejecutar(sql);
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count > 0)
				{
					ChkFactura.Checked = Convert.ToBoolean(dt.Rows[0]["factura"]);
					if (Convert.ToBoolean(dt.Rows[0]["exige_numero"]))
					{
						FrmDevolverNumero frm = new FrmDevolverNumero();
						frm.ShowDialog();
						if(General.NumeroGuia != 0)
						{
							TxtNumero.Text = General.NumeroGuia.ToString();
						} else
						{
							validacion = false;
						}
					} else
					{
						TxtNumero.Text = dt.Rows[0]["consecutivo"].ToString();
						MySqlCommand cmd = new MySqlCommand("UPDATE tte_guia_tipo SET consecutivo = consecutivo+1 WHERE codigo_guia_tipo_pk = '" + CboTipo.SelectedValue.ToString() + "'",
							BdCromo.ObtenerConexion());
						cmd.ExecuteNonQuery();
					}
				}
				if(validacion == true)
				{
					//https://www.youtube.com/watch?v=IT_R46g7YTk&t=227s
					guia pGuia = new guia();
					pGuia.codigoOperacionIngresoFk = TxtOperacionIngreso.Text;
					pGuia.codigoOperacionCargoFk = TxtOperacionCargo.Text;
					pGuia.codigoClienteFk = Convert.ToInt32(TxtCodigoCliente.Text);
					pGuia.codigoCiudadOrigenFk = TxtCodigoCiudadOrigen.Text;
					pGuia.codigoCiudadDestinoFk = TxtCodigoCiudadDestino.Text;
					pGuia.documentoCliente = TxtDocumentoCliente.Text;
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
					pGuia.codigoRutaFk = TxtCodigoRuta.Text;
					pGuia.ordenRuta = Convert.ToInt32(TxtOrdenRuta.Text);
					pGuia.reexpedicion = ChkReexpedicion.Checked;
					pGuia.codigoCondicionFk = Convert.ToInt32(TxtCodigoCondicion.Text);
					pGuia.factura = ChkFactura.Checked;
					pGuia.comentario = TxtComentario.Text;
					pGuia.numero = Convert.ToInt32(TxtNumero.Text);
					pGuia.usuario = General.UsuarioActivo;
					long resultado = GuiaRepositorio.Agregar(pGuia);

					if (resultado > 0)
					{
						TxtCodigo.Text = resultado.ToString();
						MessageBox.Show("Se guardo exitosamente");
						ultimoCliente = TxtCodigoCliente.Text;
						ultimoTipo = CboTipo.SelectedValue.ToString();
						ultimoServicio = CboServicio.SelectedValue.ToString();
						ultimoProducto = CboProducto.SelectedValue.ToString();
						ultimoEmpaque = CboEmpaque.SelectedValue.ToString();
						Bloquear();
					}
					else
					{
						MessageBox.Show("Error");
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
			TxtAbono.Text = "0";

		}

        public void Desbloquear()
        {
			TsbGuardar.Enabled = true;
			TsbCancelar.Enabled = true;
			TsbNuevo.Enabled = false;
			TsbBuscar.Enabled = false;
			TsbImprimir.Enabled = false;
            gbCliente.Enabled = true;
            gbDestinatario.Enabled = true;
            gbTotales.Enabled = true;
			gbInformacion.Enabled = true;
        }

        public void Bloquear()
        {
			TsbNuevo.Enabled = true;
			TsbBuscar.Enabled = true;
			TsbGuardar.Enabled = false;
			TsbCancelar.Enabled = false;
			TsbImprimir.Enabled = true;
			gbCliente.Enabled = false;
            gbDestinatario.Enabled = false;
            gbTotales.Enabled = false;
			gbInformacion.Enabled = false;
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
				DataSet ds = Utilidades.Ejecutar("SELECT nombre_corto, codigo_condicion_fk " +
					"FROM tte_cliente " +					
					"WHERE codigo_cliente_pk = " + TxtCodigoCliente.Text);
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count > 0)
				{
					TxtCodigoCondicion.Text = dt.Rows[0]["codigo_condicion_fk"].ToString();
					txtNombreCliente.Text = Convert.ToString(dt.Rows[0]["nombre_corto"]);
				}
				if (TxtRemitente.Text == "")
				{
					TxtRemitente.Text = txtNombreCliente.Text;
				}
			}

        }

        private void TxtCodigoCiudadOrigen_Validated(object sender, EventArgs e)
        {
            txtNombreCiudadOrigen.Text = CiudadRepositorio.nombreCiudad(TxtCodigoCiudadOrigen.Text);           
        }

        private void TxtCodigoCiudadDestino_Validated(object sender, EventArgs e)
        {            
			DataSet ds = Utilidades.Ejecutar("SELECT nombre, codigo_ruta_fk, orden_ruta, reexpedicion FROM tte_ciudad where codigo_ciudad_pk = '" + TxtCodigoCiudadDestino.Text + "'");
			DataTable dt = ds.Tables[0];
			if (dt.Rows.Count > 0)
			{
				TxtNombreCiudadDestino.Text = Convert.ToString(dt.Rows[0][0]);
				TxtCodigoRuta.Text = Convert.ToString(dt.Rows[0][1]);
				TxtOrdenRuta.Text = Convert.ToString(dt.Rows[0][2]);
				ChkReexpedicion.Checked = Convert.ToBoolean(dt.Rows[0][3]);
			}
		}


		private void CargarTipo ()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_guia_tipo_pk, nombre FROM tte_guia_tipo ORDER BY orden";
			MySqlConnection bd = BdCromo.ObtenerConexion();

			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			//DataRow fila = dt.NewRow();
			//fila["nombre"] = "Seleecciona un tipo";
			//dt.Rows.InsertAt(fila, 0);
			CboTipo.ValueMember = "codigo_guia_tipo_pk";
			CboTipo.DisplayMember = "nombre";
			CboTipo.DataSource = dt;
		}

		private void CargarServicio()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_servicio_pk, nombre FROM tte_servicio ORDER BY orden";
			MySqlConnection bd = BdCromo.ObtenerConexion();
			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			CboServicio.ValueMember = "codigo_servicio_pk";
			CboServicio.DisplayMember = "nombre";
			CboServicio.DataSource = dt;
		}

		private void CargarProducto()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_producto_pk, nombre FROM tte_producto";
			MySqlConnection bd = BdCromo.ObtenerConexion();
			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			CboProducto.ValueMember = "codigo_producto_pk";
			CboProducto.DisplayMember = "nombre";
			CboProducto.DataSource = dt;
		}

		private void CargarEmpaque()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_empaque_pk, nombre FROM tte_empaque";
			MySqlConnection bd = BdCromo.ObtenerConexion();
			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			CboEmpaque.ValueMember = "codigo_empaque_pk";
			CboEmpaque.DisplayMember = "nombre";
			CboEmpaque.DataSource = dt;
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
						"estado_cumplido, estado_facturado, estado_factura_generada, estado_anulado, usuario " +
						"FROM tte_guia " +
						"LEFT JOIN tte_cliente ON tte_guia.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
						"LEFT JOIN tte_ciudad as CiudadOrigen ON tte_guia.codigo_ciudad_origen_fk = CiudadOrigen.codigo_ciudad_pk " +
						"LEFT JOIN tte_ciudad as CiudadDestino ON tte_guia.codigo_ciudad_destino_fk = CiudadDestino.codigo_ciudad_pk " +
						"LEFT JOIN tte_condicion ON tte_guia.codigo_condicion_fk = tte_condicion.codigo_condicion_pk " +
						"WHERE codigo_guia_pk = " + codigoGuia.ToString());
					DataSet ds = Utilidades.Ejecutar(cmd);
					TxtCodigo.Text = ds.Tables[0].Rows[0]["codigo_guia_pk"].ToString();
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
					CboTipo.SelectedValue = ds.Tables[0].Rows[0]["codigo_guia_tipo_fk"].ToString();
					CboServicio.SelectedValue = ds.Tables[0].Rows[0]["codigo_servicio_fk"].ToString();
					CboEmpaque.SelectedValue = ds.Tables[0].Rows[0]["codigo_empaque_fk"].ToString();
					CboProducto.SelectedValue = ds.Tables[0].Rows[0]["codigo_producto_fk"].ToString();
					TxtNumero.Text = ds.Tables[0].Rows[0]["numero"].ToString();
					ChkReexpedicion.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["reexpedicion"]);
					ChkFactura.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["factura"]);
					ChkEstadoImpreso.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_impreso"]);
					ChkEstadoEmbarcado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_embarcado"]);
					ChkEstadoDespachado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_despachado"]);
					ChkEstadoEntregado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_entregado"]);
					ChkEstadoSoporte.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_soporte"]);
					ChkEstadoCumplido.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_cumplido"]);
					ChkEstadoFacturado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_facturado"]);
					ChkEstadoFacturaGenerada.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_factura_generada"]);
					ChkEstadoAnulado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["estado_anulado"]);
					TxtUsuario.Text = ds.Tables[0].Rows[0]["usuario"].ToString();
				}
			}
			catch (Exception error)
			{
				MessageBox.Show("No se encontro la guia Error(" + error.Message + ")");
			}
		}


		private void TxtPesoFacturar_Validated(object sender, EventArgs e)
		{
			DataSet ds = Utilidades.Ejecutar("SELECT vr_peso, minimo " +
				"FROM tte_precio_detalle where codigo_precio_fk = " + codigoPrecio + " AND codigo_ciudad_origen_fk = " + TxtCodigoCiudadOrigen.Text + " AND " +
				"codigo_ciudad_destino_fk = " + TxtCodigoCiudadDestino.Text + " AND codigo_producto_fk = '" + CboProducto.SelectedValue.ToString() + "' AND " +
				"vr_peso > 0");
			DataTable dt = ds.Tables[0];
			if (dt.Rows.Count > 0)
			{
				int pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
				double vrPeso = Convert.ToDouble(dt.Rows[0]["vr_peso"]);				
				double vrFlete = pesoFacturar * (vrPeso - (vrPeso * descuentoPeso / 100));
				TxtFlete.Text = Math.Round(vrFlete).ToString();
			}
			if (TxtRemitente.Text == "")
			{
				TxtRemitente.Text = txtNombreCliente.Text;
			}
		}



		private void TxtUnidades_Validated(object sender, EventArgs e)
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
			if(pesoMinimoCondicion > 0)
			{
				TxtPesoFacturar.Text = (pesoMinimoCondicion * Convert.ToInt32(TxtUnidades.Text)).ToString();
				if(Convert.ToInt32(TxtPeso.Text) <= 0)
				{
					TxtPeso.Text = (pesoMinimoCondicion * Convert.ToInt32(TxtUnidades.Text)).ToString();
				}
			}
			
		}

		private void TxtCodigoCondicion_Validated(object sender, EventArgs e)
		{
			if (TxtCodigoCondicion.Text != "")
			{
				DataSet ds = Utilidades.Ejecutar("SELECT nombre, porcentaje_manejo, manejo_minimo_unidad, manejo_minimo_despacho, peso_minimo, descuento_peso, codigo_precio_fk " +
					"FROM tte_condicion " +					
					"WHERE codigo_condicion_pk = " + TxtCodigoCondicion.Text);
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count > 0)
				{					
					txtNombreCondicion.Text = Convert.ToString(dt.Rows[0]["nombre"]);
					pesoMinimoCondicion = Convert.ToInt32(dt.Rows[0]["peso_minimo"]);
					porcentajeManejo = Convert.ToDouble(dt.Rows[0]["porcentaje_manejo"]);
					manejoMinimoUnidad = Convert.ToDouble(dt.Rows[0]["manejo_minimo_unidad"]);
					manejoMinimoDespacho = Convert.ToDouble(dt.Rows[0]["manejo_minimo_despacho"]);
					descuentoPeso = Convert.ToDouble(dt.Rows[0]["descuento_peso"]);
					codigoPrecio = Convert.ToInt32(dt.Rows[0]["codigo_precio_fk"]);
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
				if(manejoMinimoDespacho > Convert.ToDouble(TxtDeclarado.Text)) {
					TxtManejo.Text = manejoMinimoDespacho.ToString();
				}
				if(manejoMinimoUnidad * Convert.ToInt32(TxtUnidades.Text) > Convert.ToDouble(TxtDeclarado.Text))
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

		private void TxtCodigoCliente_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
