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
    public partial class frmGuia : Form
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

        public frmGuia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string prueba = "hola mundo";
            prueba = cromo.Properties.Settings.Default.centroOperacion;
            //BdCromo.ObtenerConexion();
            MessageBox.Show(prueba);
            //DataSet ds = Utilidades.Ejecutar("SELECT guia.codigo_guia_pk FROM guia");
            
        }

        private void Guia_Load(object sender, EventArgs e)
        {
			cargar_tipo();
			cargar_servicio();
			cargar_empaque();
			cargar_producto();
			FuncionesGuia fg = new FuncionesGuia();
			TraerGuia(fg.Ultima());		
		}

        private void button2_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frmBuscarCliente = new frmBuscarCliente();            
            frmBuscarCliente.ShowDialog();
            if (frmBuscarCliente.DialogResult == DialogResult.OK)
            {
                txtCodigoCliente.Text = frmBuscarCliente.dgClientes.Rows[frmBuscarCliente.dgClientes.CurrentRow.Index].Cells[0].Value.ToString();
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                frmBuscarCliente frmBuscarCliente = new frmBuscarCliente();
                frmBuscarCliente.ShowDialog();
                if (frmBuscarCliente.DialogResult == DialogResult.OK)
                {					
					txtCodigoCliente.Text = General.codigoCliente;
				}
            }
        }

        public void Nuevo()
        {			
			Desbloquear();
            Limpiar();
			if(ultimoTipo != "")
			{
				cboTipo.SelectedValue = ultimoTipo;
			} else
			{
				cboTipo.SelectedIndex = 0;
			}

			txtFechaIngreso.Text = DateTime.Now.ToString("G");
			txtCodigoCliente.Text = ultimoCliente;
			txtCodigoCiudadOrigen.Text = cromo.Properties.Settings.Default.ciudadOrigen;
			txtOperacionIngreso.Text = cromo.Properties.Settings.Default.centroOperacion;			
			txtOperacionCargo.Text = cromo.Properties.Settings.Default.centroOperacion;
			txtCodigoCliente.Focus();
        }

		public void Guardar()
		{
			//Validar informacion formulario
			bool validacion = true;
			if (txtCodigoCliente.Text == "")
			{
				txtCodigoCliente.Focus();
				validacion = false;
			}
			if (txtCodigoCiudadOrigen.Text == "")
			{
				txtCodigoCiudadOrigen.Focus();
				validacion = false;
			}
			if (txtCodigoCiudadDestino.Text == "")
			{
				txtCodigoCiudadDestino.Focus();
				validacion = false;
			}
			if (cboTipo.SelectedIndex < 0)
			{
				cboTipo.Focus();
				validacion = false;
			}
			if (cboServicio.SelectedIndex < 0)
			{
				cboServicio.Focus();
				validacion = false;
			}
			if (cboProducto.SelectedIndex < 0)
			{
				cboProducto.Focus();
				validacion = false;
			}
			if (cboEmpaque.SelectedIndex < 0)
			{
				cboEmpaque.Focus();
				validacion = false;
			}


			if (validacion == true)
			{
				string sql = "SELECT factura, exige_numero, consecutivo FROM tte_guia_tipo WHERE codigo_guia_tipo_pk ='" + cboTipo.SelectedValue.ToString() + "'";
				DataSet ds = Utilidades.Ejecutar(sql);
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count > 0)
				{
					chkFactura.Checked = Convert.ToBoolean(dt.Rows[0]["factura"]);
					if (Convert.ToBoolean(dt.Rows[0]["exige_numero"]))
					{
						frmDevolverNumero frm = new frmDevolverNumero();
						frm.ShowDialog();
						if(General.numeroGuia != 0)
						{
							txtNumero.Text = General.numeroGuia.ToString();
						} else
						{
							validacion = false;
						}
					} else
					{
						txtNumero.Text = dt.Rows[0]["consecutivo"].ToString();
						MySqlCommand cmd = new MySqlCommand("UPDATE tte_guia_tipo SET consecutivo = consecutivo+1 WHERE codigo_guia_tipo_pk = '" + cboTipo.SelectedValue.ToString() + "'",
							BdCromo.ObtenerConexion());
						cmd.ExecuteNonQuery();
					}
				}
				if(validacion == true)
				{
					//https://www.youtube.com/watch?v=IT_R46g7YTk&t=227s
					guia pGuia = new guia();
					pGuia.codigoOperacionIngresoFk = txtOperacionIngreso.Text;
					pGuia.codigoOperacionCargoFk = txtOperacionCargo.Text;
					pGuia.codigoClienteFk = Convert.ToInt32(txtCodigoCliente.Text);
					pGuia.codigoCiudadOrigenFk = txtCodigoCiudadOrigen.Text;
					pGuia.codigoCiudadDestinoFk = txtCodigoCiudadDestino.Text;
					pGuia.documentoCliente = txtDocumentoCliente.Text;
					pGuia.remitente = txtRemitente.Text;
					pGuia.codigoServicioFk = cboServicio.SelectedValue.ToString();
					pGuia.codigoGuiaTipoFk = cboTipo.SelectedValue.ToString();
					pGuia.codigoProductoFk = cboProducto.SelectedValue.ToString();
					pGuia.codigoEmpaqueFk = cboEmpaque.SelectedValue.ToString();
					pGuia.nombreDestinatario = txtNombreDestinatario.Text;
					pGuia.direccionDestinatario = txtDireccionDestinatario.Text;
					pGuia.telefonoDestinatario = txtTelefonoDestinatario.Text;
					pGuia.unidades = Convert.ToInt32(txtUnidades.Text);
					pGuia.pesoReal = Convert.ToInt32(txtPeso.Text);
					pGuia.pesoVolumen = Convert.ToInt32(txtVolumen.Text);
					pGuia.pesoFacturar = Convert.ToInt32(txtPesoFacturar.Text);
					pGuia.vrFlete = Convert.ToDouble(txtFlete.Text);
					pGuia.vrManejo = Convert.ToDouble(txtManejo.Text);
					pGuia.vrDeclara = Convert.ToDouble(txtDeclarado.Text);
					pGuia.vrRecaudo = Convert.ToDouble(txtRecaudo.Text);
					pGuia.codigoRutaFk = txtCodigoRuta.Text;
					pGuia.ordenRuta = Convert.ToInt32(txtOrdenRuta.Text);
					pGuia.reexpedicion = chkReexpedicion.Checked;
					pGuia.codigoCondicionFk = Convert.ToInt32(txtCodigoCondicion.Text);
					pGuia.factura = chkFactura.Checked;
					pGuia.comentario = txtComentario.Text;
					long resultado = GuiaRepositorio.Agregar(pGuia);

					if (resultado > 0)
					{
						txtCodigo.Text = resultado.ToString();
						MessageBox.Show("Se guardo exitosamente");
						ultimoCliente = txtCodigoCliente.Text;
						ultimoTipo = cboTipo.SelectedValue.ToString();
						ultimoServicio = cboServicio.SelectedValue.ToString();
						ultimoProducto = cboProducto.SelectedValue.ToString();
						ultimoEmpaque = cboEmpaque.SelectedValue.ToString();
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
			txtCodigo.Text = "";
			txtFechaIngreso.Text = "";
			txtFechaDespacho.Text = "";
			txtFechaEntrega.Text = "";
			txtOperacionIngreso.Text = "";
			txtOperacionCargo.Text = "";
			txtCodigoCliente.Text = "";
			txtNombreCliente.Text = "";
			txtCodigoCondicion.Text = "";
			txtNombreCondicion.Text = "";
			txtRemitente.Text = "";
			txtDocumentoCliente.Text = "";
			txtCodigoCiudadOrigen.Text = "";
			txtNombreCiudadOrigen.Text = "";
			txtNombreDestinatario.Text = "";
			txtTelefonoDestinatario.Text = "";
			txtDireccionDestinatario.Text = "";
			txtCodigoCiudadDestino.Text = "";
			txtNombreCiudadDestino.Text = "";
			txtUnidades.Text = "0";
			txtPeso.Text = "0";
			txtVolumen.Text = "0";
			txtPesoFacturar.Text = "0";
			txtDeclarado.Text = "0";
			txtFlete.Text = "0";
			txtManejo.Text = "0";
			txtRecaudo.Text = "0";
			txtNumero.Text = "";
			txtAbono.Text = "0";

		}

        public void Desbloquear()
        {
			tsbGuardar.Enabled = true;
			tsbCancelar.Enabled = true;
			tsbNuevo.Enabled = false;
			tsbBuscar.Enabled = false;
			tsbImprimir.Enabled = false;
            gbCliente.Enabled = true;
            gbDestinatario.Enabled = true;
            gbTotales.Enabled = true;
			gbInformacion.Enabled = true;
        }

        public void Bloquear()
        {
			tsbNuevo.Enabled = true;
			tsbBuscar.Enabled = true;
			tsbGuardar.Enabled = false;
			tsbCancelar.Enabled = false;
			tsbImprimir.Enabled = true;
			gbCliente.Enabled = false;
            gbDestinatario.Enabled = false;
            gbTotales.Enabled = false;
			gbInformacion.Enabled = false;
        }

		private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumero(e);
        }

        private void txtCodigoCiudadOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                frmBuscarCiudad frmBuscarCiudad = new frmBuscarCiudad();
                frmBuscarCiudad.ShowDialog();
                if (frmBuscarCiudad.DialogResult == DialogResult.OK)
                {
					txtCodigoCiudadOrigen.Text = General.codigoCiudad;
                }
            }
        }

        private void txtCodigoCiudadDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                frmBuscarCiudad frmBuscarCiudad = new frmBuscarCiudad();
                frmBuscarCiudad.ShowDialog();
                if (frmBuscarCiudad.DialogResult == DialogResult.OK)
                {
					txtCodigoCiudadDestino.Text = General.codigoCiudad;
                }
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
			Guardar();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Bloquear();
			FuncionesGuia fg = new FuncionesGuia();
			TraerGuia(fg.Ultima());
		}

        private void txtCodigoCliente_Validated(object sender, EventArgs e)
        {
			if(txtCodigoCliente.Text != "")
			{
				DataSet ds = Utilidades.Ejecutar("SELECT nombre_corto, codigo_condicion_fk " +
					"FROM tte_cliente " +					
					"WHERE codigo_cliente_pk = " + txtCodigoCliente.Text);
				DataTable dt = ds.Tables[0];
				if (dt.Rows.Count > 0)
				{
					txtCodigoCondicion.Text = dt.Rows[0]["codigo_condicion_fk"].ToString();
					txtNombreCliente.Text = Convert.ToString(dt.Rows[0]["nombre_corto"]);
				}
				if (txtRemitente.Text == "")
				{
					txtRemitente.Text = txtNombreCliente.Text;
				}
			}

        }

        private void txtCodigoCiudadOrigen_Validated(object sender, EventArgs e)
        {
            txtNombreCiudadOrigen.Text = CiudadRepositorio.nombreCiudad(txtCodigoCiudadOrigen.Text);           
        }

        private void txtCodigoCiudadDestino_Validated(object sender, EventArgs e)
        {            
			DataSet ds = Utilidades.Ejecutar("SELECT nombre, codigo_ruta_fk, orden_ruta, reexpedicion FROM tte_ciudad where codigo_ciudad_pk = '" + txtCodigoCiudadDestino.Text + "'");
			DataTable dt = ds.Tables[0];
			if (dt.Rows.Count > 0)
			{
				txtNombreCiudadDestino.Text = Convert.ToString(dt.Rows[0][0]);
				txtCodigoRuta.Text = Convert.ToString(dt.Rows[0][1]);
				txtOrdenRuta.Text = Convert.ToString(dt.Rows[0][2]);
				chkReexpedicion.Checked = Convert.ToBoolean(dt.Rows[0][3]);
			}
		}



		private void button1_Click_1(object sender, EventArgs e)
		{
			frmReporte frmReporte = new frmReporte();
			frmReporte.Show();
		}

		private void cargar_tipo ()
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
			cboTipo.ValueMember = "codigo_guia_tipo_pk";
			cboTipo.DisplayMember = "nombre";
			cboTipo.DataSource = dt;
		}

		private void cargar_servicio()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_servicio_pk, nombre FROM tte_servicio ORDER BY orden";
			MySqlConnection bd = BdCromo.ObtenerConexion();
			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			cboServicio.ValueMember = "codigo_servicio_pk";
			cboServicio.DisplayMember = "nombre";
			cboServicio.DataSource = dt;
		}

		private void cargar_producto()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_producto_pk, nombre FROM tte_producto";
			MySqlConnection bd = BdCromo.ObtenerConexion();
			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			cboProducto.ValueMember = "codigo_producto_pk";
			cboProducto.DisplayMember = "nombre";
			cboProducto.DataSource = dt;
		}

		private void cargar_empaque()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_empaque_pk, nombre FROM tte_empaque";
			MySqlConnection bd = BdCromo.ObtenerConexion();
			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			cboEmpaque.ValueMember = "codigo_empaque_pk";
			cboEmpaque.DisplayMember = "nombre";
			cboEmpaque.DataSource = dt;
		}


		private void mnuNuevo_Click(object sender, EventArgs e)
		{
			Nuevo();
		}

		private void mnuGuardar_Click(object sender, EventArgs e)
		{
			Guardar();
		}

		private void mnuCancelar_Click(object sender, EventArgs e)
		{
			Bloquear();
		}

		private void tsbBuscar_Click(object sender, EventArgs e)
		{

			FuncionesGuia buscar = new FuncionesGuia();
			buscar.devolverGuia();
			TraerGuia(FuncionesGuia.codigoGuia);
		}

		private void mnuBuscar_Click(object sender, EventArgs e)
		{
			FuncionesGuia buscar = new FuncionesGuia();
			buscar.devolverGuia();			
			TraerGuia(FuncionesGuia.codigoGuia);
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
						"tte_guia.reexpedicion, factura, vr_abono " +
						"FROM tte_guia " +
						"LEFT JOIN tte_cliente ON tte_guia.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
						"LEFT JOIN tte_ciudad as CiudadOrigen ON tte_guia.codigo_ciudad_origen_fk = CiudadOrigen.codigo_ciudad_pk " +
						"LEFT JOIN tte_ciudad as CiudadDestino ON tte_guia.codigo_ciudad_destino_fk = CiudadDestino.codigo_ciudad_pk " +
						"LEFT JOIN tte_condicion ON tte_guia.codigo_condicion_fk = tte_condicion.codigo_condicion_pk " +
						"WHERE codigo_guia_pk = " + codigoGuia.ToString());
					DataSet ds = Utilidades.Ejecutar(cmd);
					txtCodigo.Text = ds.Tables[0].Rows[0]["codigo_guia_pk"].ToString();
					txtFechaIngreso.Text = ds.Tables[0].Rows[0]["fecha_ingreso"].ToString();
					txtFechaDespacho.Text = ds.Tables[0].Rows[0]["fecha_despacho"].ToString();
					txtFechaEntrega.Text = ds.Tables[0].Rows[0]["fecha_entrega"].ToString();
					txtOperacionIngreso.Text = ds.Tables[0].Rows[0]["codigo_operacion_ingreso_fk"].ToString();
					txtOperacionCargo.Text = ds.Tables[0].Rows[0]["codigo_operacion_cargo_fk"].ToString();
					txtAbono.Text = ds.Tables[0].Rows[0]["vr_abono"].ToString();
					txtCodigoCliente.Text = ds.Tables[0].Rows[0]["codigo_cliente_fk"].ToString();
					txtNombreCliente.Text = ds.Tables[0].Rows[0]["nombreCliente"].ToString();
					txtCodigoCondicion.Text = ds.Tables[0].Rows[0]["codigo_condicion_fk"].ToString();
					txtNombreCondicion.Text = ds.Tables[0].Rows[0]["nombreCondicion"].ToString();
					txtRemitente.Text = ds.Tables[0].Rows[0]["remitente"].ToString();
					txtDocumentoCliente.Text = ds.Tables[0].Rows[0]["documento_cliente"].ToString();
					txtCodigoCiudadOrigen.Text = ds.Tables[0].Rows[0]["codigo_ciudad_origen_fk"].ToString();
					txtNombreCiudadOrigen.Text = ds.Tables[0].Rows[0]["ciudadOrigen"].ToString();
					txtNombreDestinatario.Text = ds.Tables[0].Rows[0]["nombre_destinatario"].ToString();
					txtTelefonoDestinatario.Text = ds.Tables[0].Rows[0]["telefono_destinatario"].ToString();
					txtDireccionDestinatario.Text = ds.Tables[0].Rows[0]["direccion_destinatario"].ToString();
					txtCodigoCiudadDestino.Text = ds.Tables[0].Rows[0]["codigo_ciudad_destino_fk"].ToString();
					txtNombreCiudadDestino.Text = ds.Tables[0].Rows[0]["ciudadDestino"].ToString();
					txtUnidades.Text = ds.Tables[0].Rows[0]["unidades"].ToString();
					txtPeso.Text = ds.Tables[0].Rows[0]["peso_real"].ToString();
					txtVolumen.Text = ds.Tables[0].Rows[0]["peso_volumen"].ToString();
					txtPesoFacturar.Text = ds.Tables[0].Rows[0]["peso_facturado"].ToString();
					txtDeclarado.Text = ds.Tables[0].Rows[0]["vr_declara"].ToString();
					txtFlete.Text = ds.Tables[0].Rows[0]["vr_flete"].ToString();
					txtManejo.Text = ds.Tables[0].Rows[0]["vr_manejo"].ToString();
					txtRecaudo.Text = ds.Tables[0].Rows[0]["vr_recaudo"].ToString();
					cboTipo.SelectedValue = ds.Tables[0].Rows[0]["codigo_guia_tipo_fk"].ToString();
					cboServicio.SelectedValue = ds.Tables[0].Rows[0]["codigo_servicio_fk"].ToString();
					cboEmpaque.SelectedValue = ds.Tables[0].Rows[0]["codigo_empaque_fk"].ToString();
					cboProducto.SelectedValue = ds.Tables[0].Rows[0]["codigo_producto_fk"].ToString();
					txtNumero.Text = ds.Tables[0].Rows[0]["numero"].ToString();
					chkReexpedicion.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["reexpedicion"]);
					chkFactura.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["factura"]);
				}
			}
			catch (Exception error)
			{
				MessageBox.Show("No se encontro la guia Error(" + error.Message + ")");
			}
		}

		private void label24_Click(object sender, EventArgs e)
		{

		}

		private void txtPesoFacturar_Validated(object sender, EventArgs e)
		{
			DataSet ds = Utilidades.Ejecutar("SELECT vr_peso, minimo " +
				"FROM tte_precio_detalle where codigo_precio_fk = " + codigoPrecio + " AND codigo_ciudad_origen_fk = " + txtCodigoCiudadOrigen.Text + " AND " +
				"codigo_ciudad_destino_fk = " + txtCodigoCiudadDestino.Text + " AND codigo_producto_fk = '" + cboProducto.SelectedValue.ToString() + "' AND " +
				"vr_peso > 0");
			DataTable dt = ds.Tables[0];
			if (dt.Rows.Count > 0)
			{
				int pesoFacturar = Convert.ToInt32(txtPesoFacturar.Text);
				double vrPeso = Convert.ToDouble(dt.Rows[0]["vr_peso"]);				
				double vrFlete = pesoFacturar * (vrPeso - (vrPeso * descuentoPeso / 100));
				txtFlete.Text = Math.Round(vrFlete).ToString();
			}
			if (txtRemitente.Text == "")
			{
				txtRemitente.Text = txtNombreCliente.Text;
			}
		}



		private void txtUnidades_Validated(object sender, EventArgs e)
		{
			DataSet ds = Utilidades.Ejecutar("SELECT minimo " +
				"FROM tte_precio_detalle where codigo_precio_fk = " + codigoPrecio + " AND codigo_ciudad_origen_fk = " + txtCodigoCiudadOrigen.Text + " AND " +
				"codigo_ciudad_destino_fk = " + txtCodigoCiudadDestino.Text + " AND codigo_producto_fk = '" + cboProducto.SelectedValue.ToString() + "' AND " +
				"vr_peso > 0");
			DataTable dt = ds.Tables[0];
			if (dt.Rows.Count > 0)
			{
				if (Convert.ToInt32(txtPesoFacturar.Text) <= 0)
				{
					if (Convert.ToInt32(dt.Rows[0]["minimo"]) > 0)
					{
						txtPesoFacturar.Text = (Convert.ToInt32(dt.Rows[0]["minimo"]) * Convert.ToInt32(txtUnidades.Text)).ToString();
					}
				}
			}
			if(pesoMinimoCondicion > 0)
			{
				txtPesoFacturar.Text = (pesoMinimoCondicion * Convert.ToInt32(txtUnidades.Text)).ToString();
				if(Convert.ToInt32(txtPeso.Text) <= 0)
				{
					txtPeso.Text = (pesoMinimoCondicion * Convert.ToInt32(txtUnidades.Text)).ToString();
				}
			}
			
		}

		private void txtCodigoCondicion_Validated(object sender, EventArgs e)
		{
			if (txtCodigoCondicion.Text != "")
			{
				DataSet ds = Utilidades.Ejecutar("SELECT nombre, porcentaje_manejo, manejo_minimo_unidad, manejo_minimo_despacho, peso_minimo, descuento_peso, codigo_precio_fk " +
					"FROM tte_condicion " +					
					"WHERE codigo_condicion_pk = " + txtCodigoCondicion.Text);
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

		private void txtVolumen_Validated(object sender, EventArgs e)
		{
			liquidarPesoFacturar();
		}
		private void txtPeso_Validated(object sender, EventArgs e)
		{
			if(Convert.ToInt32(txtVolumen.Text) <= 0)
			{
				txtVolumen.Text = txtPeso.Text;
			}
			liquidarPesoFacturar();
		}
		private void liquidarPesoFacturar()
		{
			if(Convert.ToInt32(txtPeso.Text) > Convert.ToInt32(txtPesoFacturar.Text))
			{
				txtPesoFacturar.Text = txtPeso.Text;
			}
			if(Convert.ToInt32(txtVolumen.Text) > Convert.ToInt32(txtPesoFacturar.Text))
			{
				txtPesoFacturar.Text = txtVolumen.Text;
			}
		}

		private void txtDeclarado_Validated(object sender, EventArgs e)
		{
			if(Convert.ToDouble(txtManejo.Text) == 0 && Convert.ToDouble(txtDeclarado.Text) > 0)
			{
				txtManejo.Text = (Convert.ToDouble(txtDeclarado.Text) * porcentajeManejo / 100).ToString();
				if(manejoMinimoDespacho > Convert.ToDouble(txtDeclarado.Text)) {
					txtManejo.Text = manejoMinimoDespacho.ToString();
				}
				if(manejoMinimoUnidad * Convert.ToInt32(txtUnidades.Text) > Convert.ToDouble(txtDeclarado.Text))
				{
					txtManejo.Text = (manejoMinimoUnidad * Convert.ToInt32(txtUnidades.Text)).ToString();
				}
			}
		}

		private void mnuImprimir_Click(object sender, EventArgs e)
		{
			Impresion imp = new Impresion();
			imp.formatoGuia(txtCodigo.Text);
		}



		private void txtCodigoCiudadDestino_TextChanged(object sender, EventArgs e)
		{

		}

		private void tsbRecibo_Click(object sender, EventArgs e)
		{
			General.codigoGuia = Convert.ToInt32(txtCodigo.Text);
			frmRecibo frmRecibo = new frmRecibo();
			frmRecibo.ShowDialog();
		}

		private void tsbImprimir_Click(object sender, EventArgs e)
		{
			Impresion imp = new Impresion();
			imp.formatoGuia(txtCodigo.Text);
		}

		private void tsbVistaPrevia_Click(object sender, EventArgs e)
		{
			GuiaRepositorio repositorio = new GuiaRepositorio();			
			Impresion imp = new Impresion();
			imp.formato(2, repositorio.sqlFormato(txtCodigo.Text));
		}
	}
}
