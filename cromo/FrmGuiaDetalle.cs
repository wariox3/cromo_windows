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
	public partial class FrmGuiaDetalle : Form
	{
		double precioPeso = 0;
		double precioUnidad = 0;
		int tope;
		double precioTope = 0;
		double precioAdicional = 0;
		int pesoMinimoLista = 0;
		int pesoMinimoCondicion = 0;
		int codigoProducto = 0;
		string producto = "";
		public FrmGuiaDetalle()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnGuardar_Click(object sender, EventArgs e)
		{
			int registros = LvGuiaDetalles.Items.Count;
			
			GuiaDetalle[] detalles = new GuiaDetalle[registros];
			for (int i = 0; i < LvGuiaDetalles.Items.Count; i++)
			{
				GuiaDetalle guiaDetalle = new GuiaDetalle();
				guiaDetalle.codigoProducto = Convert.ToInt32(LvGuiaDetalles.Items[i].SubItems[0].Text);
				guiaDetalle.producto = LvGuiaDetalles.Items[i].SubItems[1].Text;
				guiaDetalle.unidades = Convert.ToInt32(LvGuiaDetalles.Items[i].SubItems[2].Text);
				guiaDetalle.pesoReal = Convert.ToInt32(LvGuiaDetalles.Items[i].SubItems[3].Text);
				guiaDetalle.pesoVolumen = Convert.ToInt32(LvGuiaDetalles.Items[i].SubItems[4].Text);
				guiaDetalle.pesoFacturar = Convert.ToInt32(LvGuiaDetalles.Items[i].SubItems[5].Text);
				guiaDetalle.vrFlete = Convert.ToDouble(LvGuiaDetalles.Items[i].SubItems[6].Text);
				detalles[i] = guiaDetalle;
			}	
			General.guiaDetallePublica = detalles;
			General.VrFlete = Convert.ToDouble(TxtFleteTotal.Text);
			General.Peso = Convert.ToInt32(TxtRealTotal.Text);
			General.Volumen = Convert.ToInt32(TxtVolumenTotal.Text);
			General.PesoFacturar = Convert.ToInt32(TxtFacturarTotal.Text);
			General.Unidades = Convert.ToInt32(TxtUnidadesTotal.Text);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void FrmGuiaDetalle_Load(object sender, EventArgs e)
		{
			DgListaPrecioDetalles.DataSource = LlenarDatos().Tables[0];
			TxtCodigoPrecio.Text = General.CodigoPrecio.ToString();
			string cmd = string.Format("SELECT codigo_precio_general_fk FROM tte_configuracion WHERE codigo_configuracion_pk = 1");
			DataSet ds = Utilidades.Ejecutar(cmd);
			DataTable dt = ds.Tables[0];
			if (dt.Rows.Count > 0)
			{
				TxtCodigoPrecioGeneral.Text = dt.Rows[0]["codigo_precio_general_fk"].ToString();
			}
			cmd = string.Format("SELECT codigo_condicion_pk, precio_peso, precio_unidad, precio_adicional, " +
				"peso_minimo " +
				"FROM tte_condicion WHERE codigo_condicion_pk = " + General.CodigoCondicion);
			ds = Utilidades.Ejecutar(cmd);
			dt = ds.Tables[0];
			if (dt.Rows.Count > 0)
			{
				bool precioPeso = Convert.ToBoolean(dt.Rows[0]["precio_peso"]);
				bool precioUnidad = Convert.ToBoolean(dt.Rows[0]["precio_unidad"]);
				bool precioAdicional = Convert.ToBoolean(dt.Rows[0]["precio_adicional"]);
				if (precioPeso)
				{
					RbPeso.Checked = true;
				} else
				{
					RbPeso.Enabled = false;
				}
				if (precioUnidad)
				{
					if(precioPeso == false)
					{
						RbUnidad.Checked = true;
					}
				} else
				{
					RbUnidad.Enabled = false;
				}
				if (precioAdicional)
				{
					if(precioPeso == false && precioUnidad == false)
					{
						RbAdicional.Checked = true;
					}
				} else
				{
					RbAdicional.Enabled = false;
				}
				TxtPesoMinimo.Text = dt.Rows[0]["peso_minimo"].ToString();
				pesoMinimoCondicion = Convert.ToInt32(TxtPesoMinimo.Text);
			}

		}
		public DataSet LlenarDatos()
		{
			string sql = "SELECT codigo_producto_fk, tte_producto.nombre, vr_peso, vr_unidad, peso_tope, vr_peso_tope, vr_peso_tope_adicional, minimo " +
				"FROM tte_precio_detalle " +
				"LEFT JOIN tte_producto ON tte_precio_detalle.codigo_producto_fk = tte_producto.codigo_producto_pk " +
				"WHERE codigo_precio_fk = " + General.CodigoPrecio +
				" AND codigo_ciudad_origen_fk = " + General.CodigoCiudad + " AND codigo_ciudad_destino_fk = " + General.CodigoCiudadDestino;			
			DataSet ds;
			string strSql = string.Format(sql);
			ds = Utilidades.Ejecutar(strSql);
			return ds;
		}

		private void DgListaPrecioDetalles_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{TAB}");							
			}
			if(e.KeyCode == Keys.F6)
			{
				BtnGuardar.Focus();
			}
		}

		private void DgListaPrecioDetalles_Validated(object sender, EventArgs e)
		{			
			pesoMinimoLista = Convert.ToInt32(DgListaPrecioDetalles.CurrentRow.Cells[7].Value.ToString());
			precioAdicional = Convert.ToDouble(DgListaPrecioDetalles.CurrentRow.Cells[6].Value.ToString());
			precioTope = Convert.ToInt32(DgListaPrecioDetalles.CurrentRow.Cells[5].Value.ToString());
			tope = Convert.ToInt32(DgListaPrecioDetalles.CurrentRow.Cells[4].Value.ToString());
			precioUnidad = Convert.ToDouble(DgListaPrecioDetalles.CurrentRow.Cells[3].Value.ToString());
			precioPeso = Convert.ToDouble(DgListaPrecioDetalles.CurrentRow.Cells[2].Value.ToString());
			producto = DgListaPrecioDetalles.CurrentRow.Cells[1].Value.ToString();
			codigoProducto = Convert.ToInt32(DgListaPrecioDetalles.CurrentRow.Cells[0].Value.ToString());			
		}

		private void RbPeso_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		private void RbUnidad_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		private void RbAdicional_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}
		private void TabularEnter(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.SelectNextControl((Control)sender, true, true, true, true);
			}
		}

		private void TxtUnidades_Validated(object sender, EventArgs e)
		{
			int pesoMinimo = (pesoMinimoCondicion > pesoMinimoLista) ? pesoMinimoCondicion : pesoMinimoLista;
			if (Convert.ToInt32(TxtFacturar.Text) <= 0)
			{
				if (pesoMinimo > 0)
				{
					TxtFacturar.Text = (pesoMinimo * Convert.ToInt32(TxtUnidades.Text)).ToString();
					if (Convert.ToInt32(TxtReal.Text) <= 0)
					{
						TxtReal.Text = (pesoMinimo * Convert.ToInt32(TxtUnidades.Text)).ToString();
					}
				}
			}
		}

		private void TxtVolumen_Validated(object sender, EventArgs e)
		{
			if (Convert.ToInt32(TxtVolumen.Text) <= 0)
			{
				TxtVolumen.Text = TxtReal.Text;
			}
			LiquidarPesoFacturar();
		}

		private void LiquidarPesoFacturar()
		{
			if (Convert.ToInt32(TxtReal.Text) > Convert.ToInt32(TxtFacturar.Text))
			{
				TxtFacturar.Text = TxtReal.Text;
			}
			if (Convert.ToInt32(TxtVolumen.Text) > Convert.ToInt32(TxtFacturar.Text))
			{
				TxtFacturar.Text = TxtVolumen.Text;
			}
		}

		private void TxtReal_Validated(object sender, EventArgs e)
		{
			LiquidarPesoFacturar();
		}

		private void BtnAgregar_Click(object sender, EventArgs e)
		{
			double vrFlete = 0;
			int pesoReal = Convert.ToInt32(TxtReal.Text);
			int pesoVolumen = Convert.ToInt32(TxtVolumen.Text);
			int pesoFacturar = Convert.ToInt32(TxtFacturar.Text);
			int unidades = Convert.ToInt32(TxtUnidades.Text);
			if (RbPeso.Checked)
			{
				vrFlete = pesoFacturar * precioPeso;
			} else if (RbUnidad.Checked)
			{
				vrFlete = unidades * precioUnidad;
			} else if (RbAdicional.Checked)
			{
				vrFlete = precioTope * unidades;
				if (pesoFacturar > (tope * unidades))
				{
					int diferencia = pesoFacturar - (tope * unidades);
					vrFlete += diferencia * precioAdicional;
				}				
			}			
			if(vrFlete > 0)
			{
				ListViewItem lista = new ListViewItem(codigoProducto.ToString());
				lista.SubItems.Add(producto);
				lista.SubItems.Add(TxtUnidades.Text);
				lista.SubItems.Add(TxtReal.Text);
				lista.SubItems.Add(TxtVolumen.Text);
				lista.SubItems.Add(TxtFacturar.Text);
				lista.SubItems.Add(vrFlete.ToString());
				LvGuiaDetalles.Items.Add(lista);
				TxtUnidades.Text = "0";
				TxtReal.Text = "0";
				TxtVolumen.Text = "0";
				TxtFacturar.Text = "0";
				int registros = Convert.ToInt32(TxtRegistros.Text);
				int unidadesTotales = Convert.ToInt32(TxtUnidadesTotal.Text);
				int pesoRealTotales = Convert.ToInt32(TxtRealTotal.Text);
				int pesoVolumenTotales = Convert.ToInt32(TxtVolumenTotal.Text);
				int pesoFacturarTotales = Convert.ToInt32(TxtFacturarTotal.Text);
				double fleteTotales = Convert.ToDouble(TxtFleteTotal.Text);

				TxtUnidadesTotal.Text = (unidadesTotales + unidades).ToString();
				TxtRealTotal.Text = (pesoRealTotales + pesoReal).ToString();
				TxtVolumenTotal.Text = (pesoVolumenTotales + pesoVolumen).ToString();
				TxtFacturarTotal.Text = (pesoFacturarTotales + pesoFacturar).ToString();
				TxtFleteTotal.Text = (fleteTotales + vrFlete).ToString();
				TxtRegistros.Text = (registros + 1).ToString();

				DgListaPrecioDetalles.Focus();
			} else
			{
				MessageBox.Show("El flete no puede ser cero");
			}
		}

		private void BtnEliminar_Click(object sender, EventArgs e)
		{
			foreach(ListViewItem lista in LvGuiaDetalles.SelectedItems)
			{
				lista.Remove();
			}
		}
	}
}
