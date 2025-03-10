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
	public partial class FrmGuiaDetalle : Form
	{
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string codigoPrecio = "";
        string codigoOrigen = "";
        string codigoDestino = "";
        string codigoCliente = "";
        string codigoZona = "";
        int pesoMinimo = 0;
        int pesoMinimoGuia = 0;
		int pesoMinimoLista = 0;

        public bool RbPesoEnabled { get; set; }
        public bool RbPesoChecked { get; set; }
        public bool RbUnidadEnabled { get; set; }
        public bool RbUnidadChecked { get; set; }
        public bool RbAdicionalEnabled { get; set; }
        public bool RbAdicionalChecked { get; set; }
        public string TxtUnidadesText { get; set; }
        public string TxtPesoText { get; set; }
        public string TxtVolumenText { get; set; }
        public string TxtPesoFacturarText { get; set; }
        public string TxtFleteText { get; set; }
        public FrmGuiaDetalle(FrmGuia frmGuia)
		{
			InitializeComponent();
        }

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnGuardar_Click(object sender, EventArgs e)
		{

            General.GuiaDetalle.Clear();
            string comentario = "";
            int contador = 0;
            foreach (ListViewItem item in LvGuiaDetalles.Items)
            {
                GuiaDetalle guiaDetalle = new GuiaDetalle
                {
                    codigoProductoFk = item.SubItems[0].Text,
                    producto = item.SubItems[1].Text,
                    unidades = Convert.ToInt32(item.SubItems[2].Text),
                    pesoReal = Convert.ToInt32(item.SubItems[3].Text),
                    pesoVolumen = Convert.ToInt32(item.SubItems[4].Text),
                    pesoFacturado = Convert.ToInt32(item.SubItems[5].Text),
                    vrFlete = Convert.ToDouble(item.SubItems[6].Text)
                };
                if(contador==0)
                {
                    comentario = item.SubItems[1].Text;
                } else
                {
                    comentario = comentario + "," + item.SubItems[1].Text;
                }
                
                contador++;
                General.GuiaDetalle.Add(guiaDetalle);
            }

            General.VrFlete = Convert.ToDouble(TxtFleteTotal.Text);
			General.Peso = Convert.ToInt32(TxtPesoTotal.Text);
			General.Volumen = Convert.ToInt32(TxtVolumenTotal.Text);
			General.PesoFacturar = Convert.ToInt32(TxtPesoFacturarTotal.Text);
			General.Unidades = Convert.ToInt32(TxtUnidadesTotal.Text);
            General.Comentario = comentario;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void FrmGuiaDetalle_Load(object sender, EventArgs e)
		{
            TxtCodigoPrecio.Text = General.CodigoPrecio.ToString();
            codigoPrecio = General.CodigoPrecio.ToString();
            codigoOrigen = General.CodigoCiudad;
            codigoDestino = General.CodigoCiudadDestino;
			codigoCliente = General.CodigoCliente;
            codigoZona = General.CodigoZona;
			pesoMinimo = General.PesoMinimo;
			pesoMinimoGuia = General.PesoMinimoGuia;
            TxtUnidades.Text = "0";
            TxtPeso.Text = "0";
            TxtVolumen.Text = "0";
            TxtPesoFacturar.Text = "0";
            TxtFlete.Text = "0";
            
            string parametrosJson = "{\"codigo\":\"" + codigoDestino + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/detalle", parametrosJson);
            ApiCiudad apiCiudad = ser.Deserialize<ApiCiudad>(jsonRespuesta);
            if (apiCiudad.error == null)
            {

                if (codigoPrecio != "" && codigoOrigen != "" && codigoDestino != "")
                {
                    LvPrecioDetalle.Items.Clear();
                    parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"zona\":\"" + codigoZona + "\"}";
                    jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalle", parametrosJson);
                    List<ApiPrecioDetalle> apiPrecioDetalleLista = ser.Deserialize<List<ApiPrecioDetalle>>(jsonRespuesta);
                    foreach (ApiPrecioDetalle apiPrecioDetalle in apiPrecioDetalleLista)
                    {
                        ListViewItem item = new ListViewItem(apiPrecioDetalle.codigoPrecioDetallePk);
                        item.SubItems.Add(apiPrecioDetalle.productoNombre);
                        item.SubItems.Add(apiPrecioDetalle.codigoCoberturaFk);
                        item.SubItems.Add(apiPrecioDetalle.vrPeso.ToString());
                        item.SubItems.Add(apiPrecioDetalle.vrUnidad.ToString());
                        item.SubItems.Add(apiPrecioDetalle.pesoTope.ToString());
                        item.SubItems.Add(apiPrecioDetalle.vrPesoTope.ToString());
                        item.SubItems.Add(apiPrecioDetalle.vrPesoTopeAdicional.ToString());
                        item.SubItems.Add(apiPrecioDetalle.minimo.ToString());
                        LvPrecioDetalle.Items.Add(item);
                        //TxtCodigoCobertura.Text = apiPrecioDetalle.codigoCoberturaFk;
                    }              
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una condicion comercial, origen y destino del servicio");
                }
            }

            CargarProducto();
            if (cromo.Properties.Settings.Default.validarProductoCliente)
            {
                CargarProductoCliente(codigoCliente);
            }
            if (cromo.Properties.Settings.Default.validarProductoLista)
            {
                CargarProductoLista(Convert.ToInt32(TxtCodigoPrecio.Text));
            }

            LlenarDatos();
            this.RbPeso.Enabled = this.RbPesoEnabled;
            this.RbPeso.Checked = this.RbPesoChecked;
            this.RbUnidad.Enabled = this.RbUnidadEnabled;
            this.RbUnidad.Checked = this.RbUnidadChecked;
            this.RbAdicional.Enabled = this.RbAdicionalEnabled;
            this.RbAdicional.Checked = this.RbAdicionalChecked;
            this.TxtUnidadesTotal.Text = this.TxtUnidadesText;
            this.TxtPesoTotal.Text = this.TxtPesoText;
            this.TxtVolumenTotal.Text = this.TxtVolumenText;
            this.TxtPesoFacturarTotal.Text = this.TxtPesoFacturarText;
            this.TxtFleteTotal.Text = this.TxtFleteText;
        }
		private void LlenarDatos()
		{
            LvGuiaDetalles.Items.Clear(); // Limpia el ListView antes de agregar datos

            foreach (var detalle in General.GuiaDetalle)
            {
                ListViewItem item = new ListViewItem(detalle.codigoProductoFk);
                item.SubItems.Add(detalle.producto);
                item.SubItems.Add(detalle.unidades.ToString());
                item.SubItems.Add(detalle.pesoReal.ToString());
                item.SubItems.Add(detalle.pesoVolumen.ToString());
                item.SubItems.Add(detalle.pesoFacturado.ToString());
                item.SubItems.Add(detalle.vrFlete.ToString("N2")); // Formato de dos decimales
                LvGuiaDetalles.Items.Add(item);
            }
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

		private void TxtUnidades_Validated(object sender, EventArgs e)
		{

            if (codigoPrecio != "" && codigoOrigen != "" && codigoDestino != "")
            {
                string parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                ApiPrecioDetalle apiPrecioDetalle = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                if (apiPrecioDetalle.error == null)
                {
                    if (Convert.ToInt32(TxtPesoFacturar.Text) <= 0)
                    {
                        if (apiPrecioDetalle.minimo > 0)
                        {
                            TxtPesoFacturar.Text = (apiPrecioDetalle.minimo * Convert.ToInt32(TxtUnidades.Text)).ToString();
                        }
                    }
                }
            }
            int pesoMinimoCalcular = 0;
            pesoMinimoCalcular = pesoMinimo;
            if (pesoMinimoLista > 0)
            {
                if (pesoMinimoLista > pesoMinimoCalcular)
                {
                    pesoMinimoCalcular = pesoMinimoLista;
                }
            }

            if (pesoMinimoCalcular > 0)
            {
                TxtPesoFacturar.Text = (pesoMinimoCalcular * Convert.ToInt32(TxtUnidades.Text)).ToString();
                if (Convert.ToInt32(TxtPeso.Text) <= 0)
                {
                    TxtPeso.Text = (pesoMinimoCalcular * Convert.ToInt32(TxtUnidades.Text)).ToString();
                }
            }
            double pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
            if (pesoMinimoGuia > pesoFacturar)
            {
                TxtPesoFacturar.Text = pesoMinimoGuia.ToString();
            }

        }

		private void TxtVolumen_Validated(object sender, EventArgs e)
		{
            LiquidarPesoFacturar();
        }

        private void LiquidarPesoFacturar()
        {
            double pesoReal = Convert.ToInt32(TxtPeso.Text);
            double pesoVolumen = Convert.ToInt32(TxtVolumen.Text);
            double pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
            if (pesoReal > pesoFacturar)
            {
                pesoFacturar = pesoReal;
            }
            if (pesoVolumen > pesoFacturar)
            {
                pesoFacturar = pesoVolumen;
            }

            TxtPesoFacturar.Text = pesoFacturar.ToString();
        }

        private void TxtReal_Validated(object sender, EventArgs e)
		{
            if (Convert.ToInt32(TxtVolumen.Text) <= 0)
            {
                TxtVolumen.Text = TxtPeso.Text;
            }
            LiquidarPesoFacturar();
        }

		private void BtnAgregar_Click(object sender, EventArgs e)
		{
			double vrFlete = Convert.ToDouble(TxtFlete.Text);
			int pesoReal = Convert.ToInt32(TxtPeso.Text);
			int pesoVolumen = Convert.ToInt32(TxtVolumen.Text);
			int pesoFacturar = Convert.ToInt32(TxtPesoFacturar.Text);
			int unidades = Convert.ToInt32(TxtUnidades.Text);            			
			if(vrFlete > 0)
			{
				ListViewItem lista = new ListViewItem(CboProducto.SelectedValue.ToString());
				lista.SubItems.Add(CboProducto.Text);
				lista.SubItems.Add(TxtUnidades.Text);
				lista.SubItems.Add(TxtPeso.Text);
				lista.SubItems.Add(TxtVolumen.Text);
				lista.SubItems.Add(TxtPesoFacturar.Text);
				lista.SubItems.Add(vrFlete.ToString());
				LvGuiaDetalles.Items.Add(lista);
				TxtUnidades.Text = "0";
				TxtPeso.Text = "0";
				TxtVolumen.Text = "0";
				TxtPesoFacturar.Text = "0";
                TxtFlete.Text = "0";
				int unidadesTotales = Convert.ToInt32(TxtUnidadesTotal.Text);
				int pesoRealTotales = Convert.ToInt32(TxtPesoTotal.Text);
				int pesoVolumenTotales = Convert.ToInt32(TxtVolumenTotal.Text);
				int pesoFacturarTotales = Convert.ToInt32(TxtPesoFacturarTotal.Text);
				double fleteTotales = Convert.ToDouble(TxtFleteTotal.Text);

				TxtUnidadesTotal.Text = (unidadesTotales + unidades).ToString();
				TxtPesoTotal.Text = (pesoRealTotales + pesoReal).ToString();
				TxtVolumenTotal.Text = (pesoVolumenTotales + pesoVolumen).ToString();
				TxtPesoFacturarTotal.Text = (pesoFacturarTotales + pesoFacturar).ToString();
				TxtFleteTotal.Text = (fleteTotales + vrFlete).ToString();
                CboProducto.Focus();				
			} else
			{
				MessageBox.Show("El flete no puede ser cero");
			}
		}

		private void BtnEliminar_Click(object sender, EventArgs e)
		{
            int unidadesTotal = int.Parse(TxtUnidadesTotal.Text);
            int pesoTotal = int.Parse(TxtPesoTotal.Text);
            int volumenTotal = int.Parse(TxtVolumenTotal.Text);
            int pesoFacturarTotal = int.Parse(TxtPesoFacturarTotal.Text);
            double fleteTotal = double.Parse(TxtFleteTotal.Text);

            foreach (ListViewItem item in LvGuiaDetalles.CheckedItems)
            {
                int unidades = int.Parse(item.SubItems[2].Text);
                int peso = int.Parse(item.SubItems[3].Text);
                int volumen = int.Parse(item.SubItems[4].Text);
                int pesoFacturar = int.Parse(item.SubItems[5].Text);
                double flete = double.Parse(item.SubItems[6].Text);

                unidadesTotal -= unidades;
                pesoTotal -= peso;
                volumenTotal -= volumen;
                pesoFacturarTotal -= pesoFacturar;
                fleteTotal -= flete;
                LvGuiaDetalles.Items.Remove(item);
            }
            TxtUnidadesTotal.Text = unidadesTotal.ToString();
            TxtPesoTotal.Text = pesoTotal.ToString();
            TxtVolumenTotal.Text = volumenTotal.ToString();
            TxtPesoFacturarTotal.Text = pesoFacturarTotal.ToString();
            TxtFleteTotal.Text = fleteTotal.ToString();
        }

        private void CargarProducto()
        {
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/producto/lista", null);
            List<ApiProducto> apiProductoLista = ser.Deserialize<List<ApiProducto>>(jsonRespuesta);
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
        }

        private void CargarProductoCliente(string codigoCliente)
        {
            string parametrosJson = "{\"codigoTercero\":\"" + codigoCliente + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/producto/cliente", parametrosJson);
            List<ApiProducto> apiProductoLista = ser.Deserialize<List<ApiProducto>>(jsonRespuesta);
            CboProducto.Text = "";
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
        }

        private void CargarProductoLista(int codigoLista)
        {
            string parametrosJson = "{\"codigoPrecio\":\"" + codigoLista.ToString() + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/producto/clientelista", parametrosJson);
            List<ApiProducto> apiProductoLista = ser.Deserialize<List<ApiProducto>>(jsonRespuesta);
            CboProducto.Text = "";
            CboProducto.ValueMember = "codigoProductoPk";
            CboProducto.DisplayMember = "nombre";
            CboProducto.DataSource = apiProductoLista;
        }

        private void CboProducto_Validated(object sender, EventArgs e)
        {
            if (codigoPrecio != "" && codigoOrigen != "" && codigoDestino != "" && CboProducto.Text != "")
            {
                string parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"zona\":\"" + codigoZona + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                ApiPrecioDetalle apiPrecioDetalle = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                if (apiPrecioDetalle.error == null)
                {
                    TxtVrPeso.Text = apiPrecioDetalle.vrPeso.ToString();
                    TxtVrUnidad.Text = apiPrecioDetalle.vrUnidad.ToString();
                    TxtTope.Text = apiPrecioDetalle.pesoTope.ToString();
                    TxtVrTope.Text = apiPrecioDetalle.vrPesoTope.ToString();
                    TxtVrAdicional.Text = apiPrecioDetalle.vrPesoTopeAdicional.ToString();
                    TxtPesoMinimoPrecio.Text = apiPrecioDetalle.minimo.ToString();
                    pesoMinimoLista = apiPrecioDetalle.minimo;
                    ChkOmitirDescuento.Checked = apiPrecioDetalle.omitirDescuento;
                    TxtCodigoCobertura.Text = apiPrecioDetalle.codigoCoberturaFk;
                }
                else
                {
                    parametrosJson = "{\"precio\":\"1\", \"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                    jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                    ApiPrecioDetalle apiPrecioDetalleGeneral = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                    if (apiPrecioDetalleGeneral.error == null)
                    {
                        TxtVrPeso.Text = apiPrecioDetalleGeneral.vrPeso.ToString();
                        TxtVrUnidad.Text = apiPrecioDetalleGeneral.vrUnidad.ToString();
                        TxtTope.Text = apiPrecioDetalleGeneral.pesoTope.ToString();
                        TxtVrTope.Text = apiPrecioDetalleGeneral.vrPesoTope.ToString();
                        TxtVrAdicional.Text = apiPrecioDetalleGeneral.vrPesoTopeAdicional.ToString();
                        TxtPesoMinimoPrecio.Text = apiPrecioDetalleGeneral.minimo.ToString();
                        pesoMinimoLista = apiPrecioDetalleGeneral.minimo;
                        ChkOmitirDescuento.Checked = apiPrecioDetalleGeneral.omitirDescuento;
                    }
                    else
                    {
                        MessageBox.Show(this, "No se encontro este precio para la lista general, no se podra liquidar la guia automaticamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una condicion comercial, origen, destino y producto para liquidar el envio");
            }
        }

        private void TxtPesoFacturar_Validated(object sender, EventArgs e)
        {
            double vrFlete = 0;
            double vrFleteMinimo = General.VrFleteMinimo;
            double vrFleteMinimoDespacho = General.VrFleteMinimoGuia;
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
                /*if (precioPeso == 0 && ChkListaGeneral.Checked == true && General.CodigoPrecioGeneral != 0)
                {
                    string parametrosJson = "{\"precio\":\"" + codigoPrecio + "\", \"origen\":\"" + codigoOrigen + "\", \"destino\":\"" + codigoDestino + "\", \"producto\":\"" + CboProducto.SelectedValue.ToString() + "\"}";
                    string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/preciodetalle/detalleproducto", parametrosJson);
                    ApiPrecioDetalle apiPrecioDetalle = ser.Deserialize<ApiPrecioDetalle>(jsonRespuesta);
                    if (apiPrecioDetalle.error == null)
                    {
                        precioPeso = apiPrecioDetalle.vrPeso;
                    }

                }*/
                vrFlete = pesoFacturar * precioPeso;
                /*if (descuentoPeso > 0 && !ChkOmitirDescuento.Checked)
                {
                    if (limitarDescuentoReexpedicion == false || !ChkReexpedicion.Checked)
                    {
                        vrFlete -= vrFlete * descuentoPeso / 100;
                    }
                }*/
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

            if (vrFleteMinimo > vrFlete / unidades)
            {
                vrFlete = vrFleteMinimo * unidades;
            }
            if (vrFleteMinimoDespacho > vrFlete)
            {
                vrFlete = vrFleteMinimoDespacho;
            }

            vrFlete = Math.Round(vrFlete / 100) * 100;           
            TxtFlete.Text = vrFlete.ToString();
        }

        private void TabularEnterV2(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true; //Interceptamos la pulsación
                SendKeys.Send("{TAB}"); //Pulsamos la tecla Tabulador por código
            }
            if (sender is TextBox)
            {
                TextBox txt = sender as TextBox;
                if (txt.Tag != null)
                {
                    if (txt.Tag.ToString() == "N")
                    {
                        if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != (char)13)
                        {
                            MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }

    }
}
