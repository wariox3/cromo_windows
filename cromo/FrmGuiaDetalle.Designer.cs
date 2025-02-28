namespace cromo
{
	partial class FrmGuiaDetalle
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.LvGuiaDetalles = new System.Windows.Forms.ListView();
            this.ClmCodigoProducto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmNombreProducto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmUnidades = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmPesoReal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmVolumen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmFacturar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmVrFlete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtUnidades = new System.Windows.Forms.TextBox();
            this.TxtVolumen = new System.Windows.Forms.TextBox();
            this.TxtPeso = new System.Windows.Forms.TextBox();
            this.TxtPesoFacturar = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.GbListas = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCodigoPrecioGeneral = new System.Windows.Forms.TextBox();
            this.TxtNombrePrecioGeneral = new System.Windows.Forms.TextBox();
            this.TxtNombrePrecio = new System.Windows.Forms.TextBox();
            this.TxtCodigoPrecio = new System.Windows.Forms.TextBox();
            this.RbAdicional = new System.Windows.Forms.RadioButton();
            this.RbPeso = new System.Windows.Forms.RadioButton();
            this.RbUnidad = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TxtPesoMinimo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.TxtUnidadesTotal = new System.Windows.Forms.TextBox();
            this.TxtFleteTotal = new System.Windows.Forms.TextBox();
            this.TxtPesoFacturarTotal = new System.Windows.Forms.TextBox();
            this.TxtVolumenTotal = new System.Windows.Forms.TextBox();
            this.TxtPesoTotal = new System.Windows.Forms.TextBox();
            this.LvPrecioDetalle = new System.Windows.Forms.ListView();
            this.ClmCodigoPrecioDetallePk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CmlProducto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmCodigoCoberturaFk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmVrPeso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmVrUnidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmVrPesoTope = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmPesoTope = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmVrAdicional = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmMinimo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtFlete = new System.Windows.Forms.TextBox();
            this.CboProducto = new System.Windows.Forms.ComboBox();
            this.GbPrecioDetalle = new System.Windows.Forms.GroupBox();
            this.TxtCodigoCobertura = new System.Windows.Forms.TextBox();
            this.ChkOmitirDescuento = new System.Windows.Forms.CheckBox();
            this.TxtVrAdicional = new System.Windows.Forms.TextBox();
            this.TxtPesoMinimoPrecio = new System.Windows.Forms.TextBox();
            this.TxtTope = new System.Windows.Forms.TextBox();
            this.TxtVrUnidad = new System.Windows.Forms.TextBox();
            this.TxtVrPeso = new System.Windows.Forms.TextBox();
            this.TxtVrTope = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.GbListas.SuspendLayout();
            this.GbPrecioDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(957, 261);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(79, 23);
            this.BtnGuardar.TabIndex = 9;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // LvGuiaDetalles
            // 
            this.LvGuiaDetalles.CheckBoxes = true;
            this.LvGuiaDetalles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmCodigoProducto,
            this.ClmNombreProducto,
            this.ClmUnidades,
            this.ClmPesoReal,
            this.ClmVolumen,
            this.ClmFacturar,
            this.ClmVrFlete});
            this.LvGuiaDetalles.HideSelection = false;
            this.LvGuiaDetalles.Location = new System.Drawing.Point(16, 122);
            this.LvGuiaDetalles.MultiSelect = false;
            this.LvGuiaDetalles.Name = "LvGuiaDetalles";
            this.LvGuiaDetalles.Size = new System.Drawing.Size(685, 112);
            this.LvGuiaDetalles.TabIndex = 50;
            this.LvGuiaDetalles.UseCompatibleStateImageBehavior = false;
            this.LvGuiaDetalles.View = System.Windows.Forms.View.Details;
            // 
            // ClmCodigoProducto
            // 
            this.ClmCodigoProducto.Text = "Cod";
            // 
            // ClmNombreProducto
            // 
            this.ClmNombreProducto.Text = "Producto";
            this.ClmNombreProducto.Width = 300;
            // 
            // ClmUnidades
            // 
            this.ClmUnidades.Text = "Uni";
            // 
            // ClmPesoReal
            // 
            this.ClmPesoReal.Text = "Peso";
            // 
            // ClmVolumen
            // 
            this.ClmVolumen.Text = "Vol";
            // 
            // ClmFacturar
            // 
            this.ClmFacturar.Text = "Fac";
            // 
            // ClmVrFlete
            // 
            this.ClmVrFlete.Text = "Flete";
            this.ClmVrFlete.Width = 76;
            // 
            // TxtUnidades
            // 
            this.TxtUnidades.Location = new System.Drawing.Point(936, 147);
            this.TxtUnidades.Name = "TxtUnidades";
            this.TxtUnidades.Size = new System.Drawing.Size(100, 20);
            this.TxtUnidades.TabIndex = 1;
            this.TxtUnidades.Text = "0";
            this.TxtUnidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtUnidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabularEnterV2);
            this.TxtUnidades.Validated += new System.EventHandler(this.TxtUnidades_Validated);
            // 
            // TxtVolumen
            // 
            this.TxtVolumen.Location = new System.Drawing.Point(936, 191);
            this.TxtVolumen.Name = "TxtVolumen";
            this.TxtVolumen.Size = new System.Drawing.Size(100, 20);
            this.TxtVolumen.TabIndex = 3;
            this.TxtVolumen.Text = "0";
            this.TxtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtVolumen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabularEnterV2);
            this.TxtVolumen.Validated += new System.EventHandler(this.TxtVolumen_Validated);
            // 
            // TxtPeso
            // 
            this.TxtPeso.Location = new System.Drawing.Point(936, 169);
            this.TxtPeso.Name = "TxtPeso";
            this.TxtPeso.Size = new System.Drawing.Size(100, 20);
            this.TxtPeso.TabIndex = 2;
            this.TxtPeso.Text = "0";
            this.TxtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabularEnterV2);
            this.TxtPeso.Validated += new System.EventHandler(this.TxtReal_Validated);
            // 
            // TxtPesoFacturar
            // 
            this.TxtPesoFacturar.Location = new System.Drawing.Point(936, 213);
            this.TxtPesoFacturar.Name = "TxtPesoFacturar";
            this.TxtPesoFacturar.Size = new System.Drawing.Size(100, 20);
            this.TxtPesoFacturar.TabIndex = 4;
            this.TxtPesoFacturar.Text = "0";
            this.TxtPesoFacturar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPesoFacturar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabularEnterV2);
            this.TxtPesoFacturar.Validated += new System.EventHandler(this.TxtPesoFacturar_Validated);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(16, 240);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 50;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // GbListas
            // 
            this.GbListas.Controls.Add(this.label2);
            this.GbListas.Controls.Add(this.label1);
            this.GbListas.Controls.Add(this.TxtCodigoPrecioGeneral);
            this.GbListas.Controls.Add(this.TxtNombrePrecioGeneral);
            this.GbListas.Controls.Add(this.TxtNombrePrecio);
            this.GbListas.Controls.Add(this.TxtCodigoPrecio);
            this.GbListas.Location = new System.Drawing.Point(7, 4);
            this.GbListas.Name = "GbListas";
            this.GbListas.Size = new System.Drawing.Size(239, 60);
            this.GbListas.TabIndex = 50;
            this.GbListas.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gral:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TxtCodigoPrecioGeneral
            // 
            this.TxtCodigoPrecioGeneral.Location = new System.Drawing.Point(36, 32);
            this.TxtCodigoPrecioGeneral.Name = "TxtCodigoPrecioGeneral";
            this.TxtCodigoPrecioGeneral.Size = new System.Drawing.Size(35, 20);
            this.TxtCodigoPrecioGeneral.TabIndex = 50;
            // 
            // TxtNombrePrecioGeneral
            // 
            this.TxtNombrePrecioGeneral.Location = new System.Drawing.Point(77, 32);
            this.TxtNombrePrecioGeneral.Name = "TxtNombrePrecioGeneral";
            this.TxtNombrePrecioGeneral.Size = new System.Drawing.Size(152, 20);
            this.TxtNombrePrecioGeneral.TabIndex = 50;
            // 
            // TxtNombrePrecio
            // 
            this.TxtNombrePrecio.Location = new System.Drawing.Point(77, 10);
            this.TxtNombrePrecio.Name = "TxtNombrePrecio";
            this.TxtNombrePrecio.Size = new System.Drawing.Size(152, 20);
            this.TxtNombrePrecio.TabIndex = 1;
            // 
            // TxtCodigoPrecio
            // 
            this.TxtCodigoPrecio.Location = new System.Drawing.Point(36, 10);
            this.TxtCodigoPrecio.Name = "TxtCodigoPrecio";
            this.TxtCodigoPrecio.Size = new System.Drawing.Size(35, 20);
            this.TxtCodigoPrecio.TabIndex = 50;
            // 
            // RbAdicional
            // 
            this.RbAdicional.AutoSize = true;
            this.RbAdicional.Location = new System.Drawing.Point(707, 197);
            this.RbAdicional.Name = "RbAdicional";
            this.RbAdicional.Size = new System.Drawing.Size(68, 17);
            this.RbAdicional.TabIndex = 50;
            this.RbAdicional.TabStop = true;
            this.RbAdicional.Text = "Adicional";
            this.RbAdicional.UseVisualStyleBackColor = true;
            this.RbAdicional.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RbAdicional_KeyUp);
            // 
            // RbPeso
            // 
            this.RbPeso.AutoSize = true;
            this.RbPeso.Location = new System.Drawing.Point(707, 151);
            this.RbPeso.Name = "RbPeso";
            this.RbPeso.Size = new System.Drawing.Size(49, 17);
            this.RbPeso.TabIndex = 50;
            this.RbPeso.TabStop = true;
            this.RbPeso.Text = "Peso";
            this.RbPeso.UseVisualStyleBackColor = true;
            this.RbPeso.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RbPeso_KeyUp);
            // 
            // RbUnidad
            // 
            this.RbUnidad.AutoSize = true;
            this.RbUnidad.Location = new System.Drawing.Point(707, 174);
            this.RbUnidad.Name = "RbUnidad";
            this.RbUnidad.Size = new System.Drawing.Size(59, 17);
            this.RbUnidad.TabIndex = 50;
            this.RbUnidad.TabStop = true;
            this.RbUnidad.Text = "Unidad";
            this.RbUnidad.UseVisualStyleBackColor = true;
            this.RbUnidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RbUnidad_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(875, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Unidades:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(896, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Peso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(879, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Volumen:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(881, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Facturar:";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(875, 261);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(76, 23);
            this.BtnAgregar.TabIndex = 6;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TxtPesoMinimo
            // 
            this.TxtPesoMinimo.Enabled = false;
            this.TxtPesoMinimo.Location = new System.Drawing.Point(211, 94);
            this.TxtPesoMinimo.Name = "TxtPesoMinimo";
            this.TxtPesoMinimo.Size = new System.Drawing.Size(35, 20);
            this.TxtPesoMinimo.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Minimo:";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(97, 240);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 53;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TxtUnidadesTotal
            // 
            this.TxtUnidadesTotal.Location = new System.Drawing.Point(381, 238);
            this.TxtUnidadesTotal.Name = "TxtUnidadesTotal";
            this.TxtUnidadesTotal.Size = new System.Drawing.Size(43, 20);
            this.TxtUnidadesTotal.TabIndex = 54;
            this.TxtUnidadesTotal.Text = "0";
            this.TxtUnidadesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtFleteTotal
            // 
            this.TxtFleteTotal.Location = new System.Drawing.Point(624, 238);
            this.TxtFleteTotal.Name = "TxtFleteTotal";
            this.TxtFleteTotal.Size = new System.Drawing.Size(77, 20);
            this.TxtFleteTotal.TabIndex = 55;
            this.TxtFleteTotal.Text = "0";
            this.TxtFleteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtPesoFacturarTotal
            // 
            this.TxtPesoFacturarTotal.Location = new System.Drawing.Point(559, 238);
            this.TxtPesoFacturarTotal.Name = "TxtPesoFacturarTotal";
            this.TxtPesoFacturarTotal.Size = new System.Drawing.Size(59, 20);
            this.TxtPesoFacturarTotal.TabIndex = 56;
            this.TxtPesoFacturarTotal.Text = "0";
            this.TxtPesoFacturarTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtVolumenTotal
            // 
            this.TxtVolumenTotal.Location = new System.Drawing.Point(498, 238);
            this.TxtVolumenTotal.Name = "TxtVolumenTotal";
            this.TxtVolumenTotal.Size = new System.Drawing.Size(55, 20);
            this.TxtVolumenTotal.TabIndex = 57;
            this.TxtVolumenTotal.Text = "0";
            this.TxtVolumenTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtPesoTotal
            // 
            this.TxtPesoTotal.Location = new System.Drawing.Point(430, 238);
            this.TxtPesoTotal.Name = "TxtPesoTotal";
            this.TxtPesoTotal.Size = new System.Drawing.Size(62, 20);
            this.TxtPesoTotal.TabIndex = 58;
            this.TxtPesoTotal.Text = "0";
            this.TxtPesoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LvPrecioDetalle
            // 
            this.LvPrecioDetalle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmCodigoPrecioDetallePk,
            this.CmlProducto,
            this.ClmCodigoCoberturaFk,
            this.ClmVrPeso,
            this.ClmVrUnidad,
            this.ClmVrPesoTope,
            this.ClmPesoTope,
            this.ClmVrAdicional,
            this.ClmMinimo});
            this.LvPrecioDetalle.HideSelection = false;
            this.LvPrecioDetalle.Location = new System.Drawing.Point(252, 12);
            this.LvPrecioDetalle.Name = "LvPrecioDetalle";
            this.LvPrecioDetalle.Size = new System.Drawing.Size(539, 104);
            this.LvPrecioDetalle.TabIndex = 60;
            this.LvPrecioDetalle.UseCompatibleStateImageBehavior = false;
            this.LvPrecioDetalle.View = System.Windows.Forms.View.Details;
            // 
            // ClmCodigoPrecioDetallePk
            // 
            this.ClmCodigoPrecioDetallePk.Text = "ID";
            this.ClmCodigoPrecioDetallePk.Width = 40;
            // 
            // CmlProducto
            // 
            this.CmlProducto.Text = "Producto";
            this.CmlProducto.Width = 160;
            // 
            // ClmCodigoCoberturaFk
            // 
            this.ClmCodigoCoberturaFk.Text = "Cob";
            this.ClmCodigoCoberturaFk.Width = 40;
            // 
            // ClmVrPeso
            // 
            this.ClmVrPeso.Text = "Peso";
            this.ClmVrPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ClmVrPeso.Width = 40;
            // 
            // ClmVrUnidad
            // 
            this.ClmVrUnidad.Text = "Und";
            this.ClmVrUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ClmVrUnidad.Width = 40;
            // 
            // ClmVrPesoTope
            // 
            this.ClmVrPesoTope.Text = "VrTope";
            this.ClmVrPesoTope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ClmPesoTope
            // 
            this.ClmPesoTope.Text = "Tope";
            this.ClmPesoTope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ClmPesoTope.Width = 40;
            // 
            // ClmVrAdicional
            // 
            this.ClmVrAdicional.Text = "VrAd";
            this.ClmVrAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ClmMinimo
            // 
            this.ClmMinimo.Text = "Min";
            this.ClmMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ClmMinimo.Width = 40;
            // 
            // TxtFlete
            // 
            this.TxtFlete.Location = new System.Drawing.Point(936, 235);
            this.TxtFlete.Name = "TxtFlete";
            this.TxtFlete.Size = new System.Drawing.Size(100, 20);
            this.TxtFlete.TabIndex = 5;
            this.TxtFlete.Text = "0";
            this.TxtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFlete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabularEnterV2);
            // 
            // CboProducto
            // 
            this.CboProducto.FormattingEnabled = true;
            this.CboProducto.Location = new System.Drawing.Point(835, 122);
            this.CboProducto.Name = "CboProducto";
            this.CboProducto.Size = new System.Drawing.Size(201, 21);
            this.CboProducto.TabIndex = 0;
            this.CboProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabularEnterV2);
            this.CboProducto.Validated += new System.EventHandler(this.CboProducto_Validated);
            // 
            // GbPrecioDetalle
            // 
            this.GbPrecioDetalle.Controls.Add(this.TxtCodigoCobertura);
            this.GbPrecioDetalle.Controls.Add(this.ChkOmitirDescuento);
            this.GbPrecioDetalle.Controls.Add(this.TxtVrAdicional);
            this.GbPrecioDetalle.Controls.Add(this.TxtPesoMinimoPrecio);
            this.GbPrecioDetalle.Controls.Add(this.TxtTope);
            this.GbPrecioDetalle.Controls.Add(this.TxtVrUnidad);
            this.GbPrecioDetalle.Controls.Add(this.TxtVrPeso);
            this.GbPrecioDetalle.Controls.Add(this.TxtVrTope);
            this.GbPrecioDetalle.Controls.Add(this.label43);
            this.GbPrecioDetalle.Controls.Add(this.label42);
            this.GbPrecioDetalle.Controls.Add(this.label41);
            this.GbPrecioDetalle.Controls.Add(this.label40);
            this.GbPrecioDetalle.Controls.Add(this.label39);
            this.GbPrecioDetalle.Controls.Add(this.label38);
            this.GbPrecioDetalle.Enabled = false;
            this.GbPrecioDetalle.Location = new System.Drawing.Point(797, 14);
            this.GbPrecioDetalle.Name = "GbPrecioDetalle";
            this.GbPrecioDetalle.Size = new System.Drawing.Size(239, 102);
            this.GbPrecioDetalle.TabIndex = 61;
            this.GbPrecioDetalle.TabStop = false;
            this.GbPrecioDetalle.Text = "Lista";
            // 
            // TxtCodigoCobertura
            // 
            this.TxtCodigoCobertura.Location = new System.Drawing.Point(159, 76);
            this.TxtCodigoCobertura.Name = "TxtCodigoCobertura";
            this.TxtCodigoCobertura.Size = new System.Drawing.Size(69, 20);
            this.TxtCodigoCobertura.TabIndex = 50;
            this.TxtCodigoCobertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChkOmitirDescuento
            // 
            this.ChkOmitirDescuento.AutoSize = true;
            this.ChkOmitirDescuento.Location = new System.Drawing.Point(51, 80);
            this.ChkOmitirDescuento.Name = "ChkOmitirDescuento";
            this.ChkOmitirDescuento.Size = new System.Drawing.Size(105, 17);
            this.ChkOmitirDescuento.TabIndex = 49;
            this.ChkOmitirDescuento.Text = "Omitir descuento";
            this.ChkOmitirDescuento.UseVisualStyleBackColor = true;
            // 
            // TxtVrAdicional
            // 
            this.TxtVrAdicional.Location = new System.Drawing.Point(51, 54);
            this.TxtVrAdicional.Name = "TxtVrAdicional";
            this.TxtVrAdicional.Size = new System.Drawing.Size(69, 20);
            this.TxtVrAdicional.TabIndex = 11;
            this.TxtVrAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtPesoMinimoPrecio
            // 
            this.TxtPesoMinimoPrecio.Location = new System.Drawing.Point(159, 54);
            this.TxtPesoMinimoPrecio.Name = "TxtPesoMinimoPrecio";
            this.TxtPesoMinimoPrecio.Size = new System.Drawing.Size(69, 20);
            this.TxtPesoMinimoPrecio.TabIndex = 10;
            this.TxtPesoMinimoPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtTope
            // 
            this.TxtTope.Location = new System.Drawing.Point(159, 33);
            this.TxtTope.Name = "TxtTope";
            this.TxtTope.Size = new System.Drawing.Size(69, 20);
            this.TxtTope.TabIndex = 9;
            this.TxtTope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtVrUnidad
            // 
            this.TxtVrUnidad.Location = new System.Drawing.Point(159, 12);
            this.TxtVrUnidad.Name = "TxtVrUnidad";
            this.TxtVrUnidad.Size = new System.Drawing.Size(69, 20);
            this.TxtVrUnidad.TabIndex = 8;
            this.TxtVrUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtVrPeso
            // 
            this.TxtVrPeso.Location = new System.Drawing.Point(51, 12);
            this.TxtVrPeso.Name = "TxtVrPeso";
            this.TxtVrPeso.Size = new System.Drawing.Size(69, 20);
            this.TxtVrPeso.TabIndex = 7;
            this.TxtVrPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtVrTope
            // 
            this.TxtVrTope.Location = new System.Drawing.Point(51, 33);
            this.TxtVrTope.Name = "TxtVrTope";
            this.TxtVrTope.Size = new System.Drawing.Size(69, 20);
            this.TxtVrTope.TabIndex = 6;
            this.TxtVrTope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(128, 58);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(27, 13);
            this.label43.TabIndex = 5;
            this.label43.Text = "Min:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(18, 12);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(34, 13);
            this.label42.TabIndex = 4;
            this.label42.Text = "Peso:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(125, 12);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(30, 13);
            this.label41.TabIndex = 3;
            this.label41.Text = "Und:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(120, 35);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(35, 13);
            this.label40.TabIndex = 2;
            this.label40.Text = "Tope:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(7, 33);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(45, 13);
            this.label39.TabIndex = 1;
            this.label39.Text = "VrTope:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(13, 57);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(35, 13);
            this.label38.TabIndex = 0;
            this.label38.Text = "VrAdi:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(896, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Flete:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(780, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Producto:";
            // 
            // FrmGuiaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(1055, 294);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GbPrecioDetalle);
            this.Controls.Add(this.CboProducto);
            this.Controls.Add(this.TxtFlete);
            this.Controls.Add(this.LvPrecioDetalle);
            this.Controls.Add(this.TxtPesoTotal);
            this.Controls.Add(this.TxtVolumenTotal);
            this.Controls.Add(this.TxtPesoFacturarTotal);
            this.Controls.Add(this.TxtFleteTotal);
            this.Controls.Add(this.TxtUnidadesTotal);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtPesoMinimo);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RbUnidad);
            this.Controls.Add(this.RbPeso);
            this.Controls.Add(this.RbAdicional);
            this.Controls.Add(this.GbListas);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtPesoFacturar);
            this.Controls.Add(this.TxtPeso);
            this.Controls.Add(this.TxtVolumen);
            this.Controls.Add(this.TxtUnidades);
            this.Controls.Add(this.LvGuiaDetalles);
            this.Controls.Add(this.BtnGuardar);
            this.Name = "FrmGuiaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle guia";
            this.Load += new System.EventHandler(this.FrmGuiaDetalle_Load);
            this.GbListas.ResumeLayout(false);
            this.GbListas.PerformLayout();
            this.GbPrecioDetalle.ResumeLayout(false);
            this.GbPrecioDetalle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnGuardar;
		private System.Windows.Forms.ListView LvGuiaDetalles;
		private System.Windows.Forms.TextBox TxtUnidades;
		private System.Windows.Forms.TextBox TxtVolumen;
		private System.Windows.Forms.TextBox TxtPeso;
		private System.Windows.Forms.TextBox TxtPesoFacturar;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.GroupBox GbListas;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxtCodigoPrecioGeneral;
		private System.Windows.Forms.TextBox TxtNombrePrecioGeneral;
		private System.Windows.Forms.TextBox TxtNombrePrecio;
		private System.Windows.Forms.TextBox TxtCodigoPrecio;
		private System.Windows.Forms.RadioButton RbAdicional;
		private System.Windows.Forms.RadioButton RbPeso;
		private System.Windows.Forms.RadioButton RbUnidad;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button BtnAgregar;
		private System.Windows.Forms.TextBox TxtPesoMinimo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ColumnHeader ClmCodigoProducto;
		private System.Windows.Forms.ColumnHeader ClmNombreProducto;
		private System.Windows.Forms.ColumnHeader ClmPesoReal;
		private System.Windows.Forms.ColumnHeader ClmVrFlete;
		private System.Windows.Forms.ColumnHeader ClmVolumen;
		private System.Windows.Forms.ColumnHeader ClmFacturar;
		private System.Windows.Forms.Button BtnEliminar;
		private System.Windows.Forms.ColumnHeader ClmUnidades;
		private System.Windows.Forms.TextBox TxtUnidadesTotal;
		private System.Windows.Forms.TextBox TxtFleteTotal;
		private System.Windows.Forms.TextBox TxtPesoFacturarTotal;
		private System.Windows.Forms.TextBox TxtVolumenTotal;
		private System.Windows.Forms.TextBox TxtPesoTotal;
        private System.Windows.Forms.ListView LvPrecioDetalle;
        private System.Windows.Forms.ColumnHeader ClmCodigoPrecioDetallePk;
        private System.Windows.Forms.ColumnHeader CmlProducto;
        private System.Windows.Forms.ColumnHeader ClmCodigoCoberturaFk;
        private System.Windows.Forms.ColumnHeader ClmVrPeso;
        private System.Windows.Forms.ColumnHeader ClmVrUnidad;
        private System.Windows.Forms.ColumnHeader ClmVrPesoTope;
        private System.Windows.Forms.ColumnHeader ClmPesoTope;
        private System.Windows.Forms.ColumnHeader ClmVrAdicional;
        private System.Windows.Forms.ColumnHeader ClmMinimo;
        private System.Windows.Forms.TextBox TxtFlete;
        private System.Windows.Forms.ComboBox CboProducto;
        private System.Windows.Forms.GroupBox GbPrecioDetalle;
        private System.Windows.Forms.TextBox TxtCodigoCobertura;
        private System.Windows.Forms.CheckBox ChkOmitirDescuento;
        private System.Windows.Forms.TextBox TxtVrAdicional;
        private System.Windows.Forms.TextBox TxtPesoMinimoPrecio;
        private System.Windows.Forms.TextBox TxtTope;
        private System.Windows.Forms.TextBox TxtVrUnidad;
        private System.Windows.Forms.TextBox TxtVrPeso;
        private System.Windows.Forms.TextBox TxtVrTope;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}