﻿using System;
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
			string sql = "SELECT codigo_cliente_fk, codigo_operacion_ingreso_fk " +
					"FROM tte_guia WHERE codigo_guia_pk = " + General.codigoGuia;
			DataSet ds = Utilidades.Ejecutar(sql);
			DataTable dt = ds.Tables[0];

			double total = Convert.ToDouble(txtFlete.Text) + Convert.ToDouble(txtManejo.Text);
			MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tte_recibo (codigo_guia_fk, " +
				"vr_flete, vr_manejo, vr_total, fecha, codigo_cliente_fk, codigo_operacion_fk)" +
				" VALUES ({0}, {1}, {2}, {3}, now(), {4}, '{5}')",
				General.codigoGuia, Convert.ToDouble(txtFlete.Text), Convert.ToDouble(txtManejo.Text), total, dt.Rows[0]["codigo_cliente_fk"],
				dt.Rows[0]["codigo_operacion_ingreso_fk"]
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
				string sql = "SELECT tte_recibo.codigo_recibo_pk, " +
							"tte_recibo.codigo_operacion_fk, " +
							"tte_recibo.codigo_cliente_fk, " +
							"tte_recibo.codigo_relacion_caja_fk, " +
							"tte_recibo.codigo_guia_fk, " +
							"tte_recibo.numero, " +
							"tte_recibo.codigo_recibo_tipo_fk, " +
							"tte_recibo.fecha, " +
							"tte_recibo.vr_flete, " +
							"tte_recibo.vr_manejo, " +
							"tte_recibo.vr_total, " +
							"tte_guia.numero as numero_guia, " +
							"tte_guia.documento_cliente, " +
							"tte_guia.codigo_guia_tipo_fk, " +
							"tte_guia.nombre_destinatario, " +
							"tte_guia.direccion_destinatario, " +
							"tte_guia.telefono_destinatario, " +
							"ciudad_destino.nombre as ciudad_destino_nombre, " +
							"tte_cliente.nombre_corto as cliente_nombre, " +
							"tte_cliente.numero_identificacion as cliente_numero_identificacion, " +
							"tte_cliente.direccion as cliente_direccion, " +
							"tte_cliente.telefono as cliente_telefono " +
							"FROM tte_recibo " +
							"LEFT JOIN tte_cliente ON tte_recibo.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
							"LEFT JOIN tte_guia ON tte_recibo.codigo_guia_fk = tte_guia.codigo_guia_pk " +
							"LEFT JOIN tte_ciudad as ciudad_destino ON tte_guia.codigo_ciudad_destino_fk = ciudad_destino.codigo_ciudad_pk " +
							"WHERE tte_recibo.codigo_recibo_pk = " + dgRecibos.Rows[dgRecibos.CurrentRow.Index].Cells[0].Value;				
				Impresion imp = new Impresion();
				imp.formato(1, sql);
			}
		}
	}
}