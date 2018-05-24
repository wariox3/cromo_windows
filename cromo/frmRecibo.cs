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
	public partial class frmRecibo : Form
	{
		public frmRecibo()
		{
			InitializeComponent();
		}

		private void frmRecibo_Load(object sender, EventArgs e)
		{
			dgRecibos.DataSource = LlenarDatos().Tables[0];
		}
		public DataSet LlenarDatos()
		{
			string sql = "SELECT codigo_recibo_pk, vr_flete, vr_manejo, vr_total " +
					"FROM tte_recibo WHERE codigo_guia_fk = " + General.codigoGuia;
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			return ds;
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			double total = Convert.ToDouble(txtFlete.Text) + Convert.ToDouble(txtManejo.Text);
			MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tte_recibo (codigo_guia_fk, " +
				"vr_flete, vr_manejo, vr_total)" +
				" VALUES ({0}, {1}, {2}, {3})",
				General.codigoGuia, Convert.ToDouble(txtFlete.Text), Convert.ToDouble(txtManejo.Text), total
				), BdCromo.ObtenerConexion());
			comando.ExecuteNonQuery();
			MySqlCommand cmdGuia = new MySqlCommand("UPDATE tte_guia SET vr_abono = vr_abono + "+ total + " WHERE codigo_guia_pk = " + General.codigoGuia, 
				BdCromo.ObtenerConexion());
			cmdGuia.ExecuteNonQuery();
			dgRecibos.DataSource = LlenarDatos().Tables[0];
			txtFlete.Text = "";
			txtManejo.Text = "";
			txtFlete.Focus();
		}

		private void Eliminar_Click(object sender, EventArgs e)
		{			
			if (dgRecibos.CurrentRow  != null )
			{
				int codigoRecibo = Convert.ToInt32(dgRecibos.Rows[dgRecibos.CurrentRow.Index].Cells[0].Value);
				double total = Convert.ToInt32(dgRecibos.Rows[dgRecibos.CurrentRow.Index].Cells[3].Value);
				MySqlCommand comando = new MySqlCommand("DELETE FROM tte_recibo WHERE codigo_recibo_pk = " + codigoRecibo, BdCromo.ObtenerConexion());
				comando.ExecuteNonQuery();

				MySqlCommand cmdGuia = new MySqlCommand("UPDATE tte_guia SET vr_abono = vr_abono - " + total + " WHERE codigo_guia_pk = " + General.codigoGuia,
					BdCromo.ObtenerConexion());
				cmdGuia.ExecuteNonQuery();
				dgRecibos.DataSource = LlenarDatos().Tables[0];
			}
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			if (dgRecibos.CurrentRow != null)
			{
				int codigoRecibo = Convert.ToInt32(dgRecibos.Rows[dgRecibos.CurrentRow.Index].Cells[0].Value);
				Impresion imp = new Impresion();
				imp.formato(1, "SELECT tte_recibo.codigo_recibo_pk, tte_recibo.codigo_operacion_fk, tte_recibo.codigo_cliente_fk, " +
					"tte_recibo.codigo_relacion_caja_fk, tte_recibo.codigo_guia_fk, tte_recibo.numero, tte_recibo.codigo_recibo_tipo_fk, " +
					"tte_recibo.fecha, tte_recibo.vr_flete, tte_recibo.vr_manejo, tte_recibo.vr_total " +
				    "FROM tte_recibo " +
				    "LEFT JOIN tte_cliente ON tte_recibo.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
				    "WHERE tte_recibo.codigo_recibo_pk = " + codigoRecibo);
			}
		}
	}
}
