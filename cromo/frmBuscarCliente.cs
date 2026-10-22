using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace cromo
{
    public partial class FrmBuscarCliente : Form
    {

        public FrmBuscarCliente()
        {
            InitializeComponent();
        }

        public void LlenarDatosApi()
        {
            var filtros = new Dictionary<string, object>
            {
                { "nombre_corto", TxtNombre.Text },
                { "numero_identificacion", TxtNit.Text }
            };

            try
            {
                DgClientes.DataSource = Fluor.GetLista("/gen/tercero/buscar", filtros)
                    .Select(t => new ApiCliente
                    {
                        codigoTerceroPk = Fluor.Texto(t, "codigo_tercero_pk"),
                        numeroIdentificacion = Fluor.Texto(t, "numero_identificacion"),
                        nombreCorto = Fluor.Texto(t, "nombre_corto"),
                        condicionNombre = Fluor.Texto(t, "condicion_nombre"),
                        estadoInactivo = Booleano(t, "estado_inactivo")
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudieron consultar los clientes: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool Booleano(IDictionary<string, object> registro, string campo)
        {
            return registro.TryGetValue(campo, out object valor) && valor is bool b && b;
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            DgClientes.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
			General.CodigoCliente = DgClientes.Rows[DgClientes.CurrentRow.Index].Cells[0].Value.ToString(); 
			DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void DgClientes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				General.CodigoCliente = DgClientes.Rows[DgClientes.CurrentRow.Index].Cells[0].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void BtnFiltrar_Click(object sender, EventArgs e)
		{
            LlenarDatosApi();
		}

		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Down)
			{
				DgClientes.Focus();
			}
		}

		private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
                LlenarDatosApi();
			}
		}

	}
}
