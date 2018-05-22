using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;
using MySql.Data.MySqlClient;

namespace cromo
{
    public partial class frmGuia : Form
    {
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
			if (cboTipo.SelectedIndex <= 0)
			{
				cboTipo.Focus();
				validacion = false;
			}
			if (cboServicio.SelectedIndex <= 0)
			{
				cboServicio.Focus();
				validacion = false;
			}
			if (cboEmpaque.SelectedIndex <= 0)
			{
				cboEmpaque.Focus();
				validacion = false;
			}

			if (validacion == true)
			{
				//https://www.youtube.com/watch?v=IT_R46g7YTk&t=227s
				guia pGuia = new guia();
				pGuia.codigoOperacionIngresoFk = cromo.Properties.Settings.Default.centroOperacion;
				pGuia.codigoOperacionCargoFk = cromo.Properties.Settings.Default.centroOperacion;
				pGuia.codigoClienteFk = Convert.ToInt32(txtCodigoCliente.Text);
				pGuia.codigoCiudadOrigenFk = txtCodigoCiudadOrigen.Text;
				pGuia.codigoCiudadDestinoFk = txtCodigoCiudadDestino.Text;
				pGuia.documentoCliente = txtDocumentoCliente.Text;
				pGuia.remitente = txtRemitente.Text;
				pGuia.codigoServicioFk = cboServicio.SelectedValue.ToString();
				pGuia.codigoGuiaTipoFk = cboTipo.SelectedValue.ToString();
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

				int resultado = GuiaRepositorio.Agregar(pGuia);

				if (resultado > 0)
				{
					MessageBox.Show("Exitoso el guardado");
					Bloquear();
				}
				else
				{
					MessageBox.Show("Error");
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

		}

        public void Desbloquear()
        {
			tsbGuardar.Enabled = true;
			tsbCancelar.Enabled = true;
			tsbNuevo.Enabled = false;
			tsbBuscar.Enabled = false;
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
        }

        private void txtCodigoCliente_Validated(object sender, EventArgs e)
        {
            txtNombreCliente.Text = ClienteRepositorio.nombreCliente(txtCodigoCliente.Text);
            if(txtRemitente.Text == "")
            {
                txtRemitente.Text = txtNombreCliente.Text;
            }
        }

        private void txtCodigoCiudadOrigen_Validated(object sender, EventArgs e)
        {
            txtNombreCiudadOrigen.Text = CiudadRepositorio.nombreCiudad(txtCodigoCiudadOrigen.Text);           
        }

        private void txtCodigoCiudadDestino_Validated(object sender, EventArgs e)
        {
            txtNombreCiudadDestino.Text = CiudadRepositorio.nombreCiudad(txtCodigoCiudadDestino.Text);
        }



		private void button1_Click_1(object sender, EventArgs e)
		{
			frmReporte frmReporte = new frmReporte();
			frmReporte.Show();
		}

		private void cargar_tipo ()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_guia_tipo_pk, nombre FROM tte_guia_tipo";
			MySqlConnection bd = BdCromo.ObtenerConexion();

			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			DataRow fila = dt.NewRow();
			fila["nombre"] = "Seleecciona un tipo";
			dt.Rows.InsertAt(fila, 0);
			cboTipo.ValueMember = "codigo_guia_tipo_pk";
			cboTipo.DisplayMember = "nombre";
			cboTipo.DataSource = dt;
		}

		private void cargar_servicio()
		{
			/* https://www.youtube.com/watch?v=O2CwKIV9bn0 */
			string query = "SELECT codigo_servicio_pk, nombre FROM tte_servicio";
			MySqlConnection bd = BdCromo.ObtenerConexion();

			MySqlCommand cmd = new MySqlCommand(query, bd);
			MySqlDataAdapter da = new MySqlDataAdapter(query, bd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			DataRow fila = dt.NewRow();
			fila["nombre"] = "Seleecciona un servicio";
			dt.Rows.InsertAt(fila, 0);
			cboServicio.ValueMember = "codigo_servicio_pk";
			cboServicio.DisplayMember = "nombre";
			cboServicio.DataSource = dt;
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

			DataRow fila = dt.NewRow();
			fila["nombre"] = "Seleecciona un empaque";
			dt.Rows.InsertAt(fila, 0);
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

		private void button1_Click_2(object sender, EventArgs e)
		{			
			frmReporte frmReporte = new frmReporte();
			frmReporte.Show();
		}

		private void txtCodigoCiudadDestino_TextChanged(object sender, EventArgs e)
		{

		}

		private void tsbBuscar_Click(object sender, EventArgs e)
		{

			BuscarGuia buscar = new BuscarGuia();
			buscar.devolverGuia();
			TraerGuia(BuscarGuia.codigoGuia.ToString());
		}

		private void mnuBuscar_Click(object sender, EventArgs e)
		{
			BuscarGuia buscar = new BuscarGuia();
			buscar.devolverGuia();			
			TraerGuia(BuscarGuia.codigoGuia.ToString());
		}
		public void TraerGuia(string codigoGuia)
		{
			try
			{
				string cmd = string.Format("SELECT codigo_guia_pk, codigo_cliente_fk, tte_cliente.nombre_corto as nombreCliente, " +
					"remitente, documento_cliente, codigo_ciudad_origen_fk, nombre_destinatario, telefono_destinatario, " +
					"direccion_destinatario, codigo_ciudad_destino_fk, unidades, peso_real, peso_volumen, peso_facturado, " +
					"vr_declara, vr_flete, vr_manejo, vr_recaudo, CiudadOrigen.nombre as ciudadOrigen, CiudadDestino.nombre as ciudadDestino, " +
					"codigo_guia_tipo_fk, codigo_servicio_fk, codigo_empaque_fk, fecha_ingreso, fecha_despacho, fecha_entrega, " +
					"codigo_operacion_ingreso_fk, codigo_operacion_cargo_fk " +
					"FROM tte_guia " +
					"LEFT JOIN tte_cliente ON tte_guia.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
					"LEFT JOIN tte_ciudad as CiudadOrigen ON tte_guia.codigo_ciudad_origen_fk = CiudadOrigen.codigo_ciudad_pk " +
					"LEFT JOIN tte_ciudad as CiudadDestino ON tte_guia.codigo_ciudad_destino_fk = CiudadDestino.codigo_ciudad_pk " +
					"WHERE codigo_guia_pk = " + codigoGuia);
				DataSet ds = Utilidades.Ejecutar(cmd);
				txtCodigo.Text = ds.Tables[0].Rows[0]["codigo_guia_pk"].ToString();
				txtFechaIngreso.Text = ds.Tables[0].Rows[0]["fecha_ingreso"].ToString();
				txtFechaDespacho.Text = ds.Tables[0].Rows[0]["fecha_despacho"].ToString();
				txtFechaEntrega.Text = ds.Tables[0].Rows[0]["fecha_entrega"].ToString();
				txtOperacionIngreso.Text = ds.Tables[0].Rows[0]["codigo_operacion_ingreso_fk"].ToString();
				txtOperacionCargo.Text = ds.Tables[0].Rows[0]["codigo_operacion_cargo_fk"].ToString();
				txtCodigoCliente.Text = ds.Tables[0].Rows[0]["codigo_cliente_fk"].ToString();				
				txtNombreCliente.Text = ds.Tables[0].Rows[0]["nombreCliente"].ToString();
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
			}
			catch (Exception error)
			{
				MessageBox.Show("No se encontro la guia Error(" + error.Message + ")");
			}
		}

		private void label24_Click(object sender, EventArgs e)
		{

		}
	}
}
