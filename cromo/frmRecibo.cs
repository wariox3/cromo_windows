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
	public partial class FrmRecibo : Form
	{
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmRecibo()
		{
			InitializeComponent();
		}

		private void FrmRecibo_Load(object sender, EventArgs e)
		{
            DgRecibos.AutoGenerateColumns = false;
            LlenarDatosApi();
		}
		public void LlenarDatosApi()
		{
            string parametrosJson = "{\"codigoGuia\":\"" + General.CodigoGuia + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/recibo/detalle", parametrosJson);
            List<ApiRecibo> apiRecibo = ser.Deserialize<List<ApiRecibo>>(jsonRespuesta);
            DgRecibos.DataSource = apiRecibo;
        }

		private void BtnAgregar_Click(object sender, EventArgs e)
		{
            string parametrosJson = "{\"codigoGuiaPk\":\"" + General.CodigoGuia + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guia/detalle", parametrosJson);
            ApiGuia apiGuia = ser.Deserialize<ApiGuia>(jsonRespuesta);
            if (apiGuia.error == null)
            {
                if (TxtFlete.Text == "") {
                    TxtFlete.Text = "0";
                }
                if (TxtManejo.Text == "") {
                    TxtManejo.Text = "0";
                }
                double total = Convert.ToDouble(TxtFlete.Text) + Convert.ToDouble(TxtManejo.Text);
                ApiRecibo apiRecibo = new ApiRecibo();
                apiRecibo.codigoGuiaFk = General.CodigoGuia.ToString();
                apiRecibo.codigoClienteFk = apiGuia.codigoTerceroFk;
                apiRecibo.codigoOperacionFk = apiGuia.codigoOperacionIngresoFk;
                apiRecibo.vrFlete = Convert.ToDouble(TxtFlete.Text);
                apiRecibo.vrManejo = Convert.ToDouble(TxtManejo.Text);
                apiRecibo.vrTotal = total;
                parametrosJson = ser.Serialize(apiRecibo);
                jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/recibo/nuevo", parametrosJson);
                ApiRecibo apiReciboRespuesta = ser.Deserialize<ApiRecibo>(jsonRespuesta);
                if (apiReciboRespuesta.error != null)
                {
                    MessageBox.Show(this, "Ocurrio un error al guardar el recibo: " + apiReciboRespuesta.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LlenarDatosApi();
                TxtFlete.Text = "0";
                TxtManejo.Text = "0";
                TxtFlete.Focus();
            }
        }

		private void Eliminar_Click(object sender, EventArgs e)
		{			
			if (DgRecibos.CurrentRow  != null )
			{
				/*int codigoRecibo = Convert.ToInt32(DgRecibos.Rows[DgRecibos.CurrentRow.Index].Cells[0].Value);
				double total = Convert.ToInt32(DgRecibos.Rows[DgRecibos.CurrentRow.Index].Cells[3].Value);
				MySqlCommand comando = new MySqlCommand("DELETE FROM tte_recibo WHERE codigo_recibo_pk = " + codigoRecibo, BdCromo.ObtenerConexion());
				comando.ExecuteNonQuery();

				MySqlCommand cmdGuia = new MySqlCommand("UPDATE tte_guia SET vr_abono = vr_abono - " + total + ", vr_cobro_entrega = (vr_recaudo + vr_flete + vr_manejo) - vr_abono WHERE codigo_guia_pk = " + General.CodigoGuia,
					BdCromo.ObtenerConexion());
				cmdGuia.ExecuteNonQuery();
				DgRecibos.DataSource = LlenarDatos().Tables[0];*/
			}
		}

		private void BtnImprimir_Click(object sender, EventArgs e)
		{
            ImprimirFormato formato = new ImprimirFormato();
            formato.codigoFormato = "";
            formato.codigoDesde = General.CodigoGuia.ToString();
            formato.codigoHasta = General.CodigoGuia.ToString();
            formato.tipo = "Recibo";
            General.Formato = formato;
            FrmVisor frm = new FrmVisor();
            frm.ShowDialog();
        }    
	}
}
