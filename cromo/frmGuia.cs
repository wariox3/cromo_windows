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
                    txtCodigoCliente.Text = frmBuscarCliente.dgClientes.Rows[frmBuscarCliente.dgClientes.CurrentRow.Index].Cells[0].Value.ToString();
                }
            }
        }

        public void Nuevo()
        {
            Desbloquear();
            Limpiar();
            txtCodigoCliente.Focus();
        }

        public void Limpiar()
        {
            txtCodigoCliente.Text = "";
        }

        public void Desbloquear()
        {
            gbCliente.Enabled = true;
            gbDestinatario.Enabled = true;
            gbTotales.Enabled = true;
        }

        public void Bloquear()
        {
            gbCliente.Enabled = false;
            gbDestinatario.Enabled = false;
            gbTotales.Enabled = false;
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
                    txtCodigoCiudadOrigen.Text = frmBuscarCiudad.dgCiudades.Rows[frmBuscarCiudad.dgCiudades.CurrentRow.Index].Cells[0].Value.ToString();
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
                    txtCodigoCiudadDestino.Text = frmBuscarCiudad.dgCiudades.Rows[frmBuscarCiudad.dgCiudades.CurrentRow.Index].Cells[0].Value.ToString();
                }
            }
        }

        private void txtCodigoCliente_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void metodoComun_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            //Validar informacion formulario
            bool validacion = false;
            if (txtCodigoCliente.Text != "")
            {
                validacion = true;
            }
            else
            {
                txtCodigoCliente.Focus();
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
                int resultado = guiaRepositorio.Agregar(pGuia);

                if (resultado > 0)
                {
                    MessageBox.Show("Exitoso el guardado");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Bloquear();
        }

        private void frmGuia_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmGuia_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {            
            if (e.KeyCode.ToString() == "F3")
            {
                Nuevo();
            }
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

        private void txtRemitente_TextChanged(object sender, EventArgs e)
        {

        }

		private void button1_Click_1(object sender, EventArgs e)
		{
			frmReporte frmReporte = new frmReporte();
			frmReporte.Show();
		}
	}
}
