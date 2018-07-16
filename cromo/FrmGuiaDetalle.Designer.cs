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
			this.TxtReal = new System.Windows.Forms.TextBox();
			this.TxtFacturar = new System.Windows.Forms.TextBox();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.GbListas = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtCodigoPrecioGeneral = new System.Windows.Forms.TextBox();
			this.TxtNombrePrecioGeneral = new System.Windows.Forms.TextBox();
			this.TxtNombrePrecio = new System.Windows.Forms.TextBox();
			this.TxtCodigoPrecio = new System.Windows.Forms.TextBox();
			this.DgListaPrecioDetalles = new System.Windows.Forms.DataGridView();
			this.ClmCodigoProductoPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClmProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClmPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClmUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClmPesoTope = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClmVrPesoTope = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClmVrTopeAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClmMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.TxtFacturarTotal = new System.Windows.Forms.TextBox();
			this.TxtVolumenTotal = new System.Windows.Forms.TextBox();
			this.TxtRealTotal = new System.Windows.Forms.TextBox();
			this.TxtRegistros = new System.Windows.Forms.TextBox();
			this.GbListas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgListaPrecioDetalles)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnGuardar
			// 
			this.BtnGuardar.Location = new System.Drawing.Point(757, 285);
			this.BtnGuardar.Name = "BtnGuardar";
			this.BtnGuardar.Size = new System.Drawing.Size(100, 23);
			this.BtnGuardar.TabIndex = 9;
			this.BtnGuardar.Text = "Guardar (F6)";
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
			this.LvGuiaDetalles.Location = new System.Drawing.Point(7, 167);
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
			this.TxtUnidades.Location = new System.Drawing.Point(759, 167);
			this.TxtUnidades.Name = "TxtUnidades";
			this.TxtUnidades.Size = new System.Drawing.Size(100, 20);
			this.TxtUnidades.TabIndex = 4;
			this.TxtUnidades.Text = "0";
			this.TxtUnidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtUnidades.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TabularEnter);
			this.TxtUnidades.Validated += new System.EventHandler(this.TxtUnidades_Validated);
			// 
			// TxtVolumen
			// 
			this.TxtVolumen.Location = new System.Drawing.Point(759, 211);
			this.TxtVolumen.Name = "TxtVolumen";
			this.TxtVolumen.Size = new System.Drawing.Size(100, 20);
			this.TxtVolumen.TabIndex = 6;
			this.TxtVolumen.Text = "0";
			this.TxtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtVolumen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TabularEnter);
			this.TxtVolumen.Validated += new System.EventHandler(this.TxtVolumen_Validated);
			// 
			// TxtReal
			// 
			this.TxtReal.Location = new System.Drawing.Point(759, 189);
			this.TxtReal.Name = "TxtReal";
			this.TxtReal.Size = new System.Drawing.Size(100, 20);
			this.TxtReal.TabIndex = 5;
			this.TxtReal.Text = "0";
			this.TxtReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtReal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TabularEnter);
			this.TxtReal.Validated += new System.EventHandler(this.TxtReal_Validated);
			// 
			// TxtFacturar
			// 
			this.TxtFacturar.Location = new System.Drawing.Point(759, 233);
			this.TxtFacturar.Name = "TxtFacturar";
			this.TxtFacturar.Size = new System.Drawing.Size(100, 20);
			this.TxtFacturar.TabIndex = 7;
			this.TxtFacturar.Text = "0";
			this.TxtFacturar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtFacturar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TabularEnter);
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancelar.Location = new System.Drawing.Point(7, 285);
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
			// DgListaPrecioDetalles
			// 
			this.DgListaPrecioDetalles.AllowUserToAddRows = false;
			this.DgListaPrecioDetalles.AllowUserToDeleteRows = false;
			this.DgListaPrecioDetalles.AllowUserToResizeColumns = false;
			this.DgListaPrecioDetalles.AllowUserToResizeRows = false;
			this.DgListaPrecioDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgListaPrecioDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmCodigoProductoPrecio,
            this.ClmProducto,
            this.ClmPeso,
            this.ClmUnidad,
            this.ClmPesoTope,
            this.ClmVrPesoTope,
            this.ClmVrTopeAdicional,
            this.ClmMinimo});
			this.DgListaPrecioDetalles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.DgListaPrecioDetalles.Location = new System.Drawing.Point(252, 12);
			this.DgListaPrecioDetalles.MultiSelect = false;
			this.DgListaPrecioDetalles.Name = "DgListaPrecioDetalles";
			this.DgListaPrecioDetalles.ReadOnly = true;
			this.DgListaPrecioDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgListaPrecioDetalles.Size = new System.Drawing.Size(607, 124);
			this.DgListaPrecioDetalles.StandardTab = true;
			this.DgListaPrecioDetalles.TabIndex = 0;
			this.DgListaPrecioDetalles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgListaPrecioDetalles_KeyDown);
			this.DgListaPrecioDetalles.Validated += new System.EventHandler(this.DgListaPrecioDetalles_Validated);
			// 
			// ClmCodigoProductoPrecio
			// 
			this.ClmCodigoProductoPrecio.DataPropertyName = "codigo_producto_fk";
			this.ClmCodigoProductoPrecio.HeaderText = "Cod";
			this.ClmCodigoProductoPrecio.Name = "ClmCodigoProductoPrecio";
			this.ClmCodigoProductoPrecio.ReadOnly = true;
			this.ClmCodigoProductoPrecio.Width = 50;
			// 
			// ClmProducto
			// 
			this.ClmProducto.DataPropertyName = "nombre";
			this.ClmProducto.HeaderText = "Producto";
			this.ClmProducto.Name = "ClmProducto";
			this.ClmProducto.ReadOnly = true;
			this.ClmProducto.Width = 190;
			// 
			// ClmPeso
			// 
			this.ClmPeso.DataPropertyName = "vr_peso";
			this.ClmPeso.HeaderText = "Pes";
			this.ClmPeso.Name = "ClmPeso";
			this.ClmPeso.ReadOnly = true;
			this.ClmPeso.Width = 50;
			// 
			// ClmUnidad
			// 
			this.ClmUnidad.DataPropertyName = "vr_unidad";
			this.ClmUnidad.HeaderText = "Uni";
			this.ClmUnidad.Name = "ClmUnidad";
			this.ClmUnidad.ReadOnly = true;
			this.ClmUnidad.Width = 50;
			// 
			// ClmPesoTope
			// 
			this.ClmPesoTope.DataPropertyName = "peso_tope";
			this.ClmPesoTope.HeaderText = "Top";
			this.ClmPesoTope.Name = "ClmPesoTope";
			this.ClmPesoTope.ReadOnly = true;
			this.ClmPesoTope.Width = 40;
			// 
			// ClmVrPesoTope
			// 
			this.ClmVrPesoTope.DataPropertyName = "vr_peso_tope";
			this.ClmVrPesoTope.HeaderText = "Vr Top";
			this.ClmVrPesoTope.Name = "ClmVrPesoTope";
			this.ClmVrPesoTope.ReadOnly = true;
			this.ClmVrPesoTope.Width = 70;
			// 
			// ClmVrTopeAdicional
			// 
			this.ClmVrTopeAdicional.DataPropertyName = "vr_peso_tope_adicional";
			this.ClmVrTopeAdicional.HeaderText = "Vr Ad";
			this.ClmVrTopeAdicional.Name = "ClmVrTopeAdicional";
			this.ClmVrTopeAdicional.ReadOnly = true;
			this.ClmVrTopeAdicional.Width = 60;
			// 
			// ClmMinimo
			// 
			this.ClmMinimo.DataPropertyName = "minimo";
			this.ClmMinimo.HeaderText = "Min";
			this.ClmMinimo.Name = "ClmMinimo";
			this.ClmMinimo.ReadOnly = true;
			this.ClmMinimo.Width = 40;
			// 
			// RbAdicional
			// 
			this.RbAdicional.AutoSize = true;
			this.RbAdicional.Location = new System.Drawing.Point(372, 142);
			this.RbAdicional.Name = "RbAdicional";
			this.RbAdicional.Size = new System.Drawing.Size(68, 17);
			this.RbAdicional.TabIndex = 3;
			this.RbAdicional.TabStop = true;
			this.RbAdicional.Text = "Adicional";
			this.RbAdicional.UseVisualStyleBackColor = true;
			this.RbAdicional.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RbAdicional_KeyUp);
			// 
			// RbPeso
			// 
			this.RbPeso.AutoSize = true;
			this.RbPeso.Location = new System.Drawing.Point(252, 142);
			this.RbPeso.Name = "RbPeso";
			this.RbPeso.Size = new System.Drawing.Size(49, 17);
			this.RbPeso.TabIndex = 1;
			this.RbPeso.TabStop = true;
			this.RbPeso.Text = "Peso";
			this.RbPeso.UseVisualStyleBackColor = true;
			this.RbPeso.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RbPeso_KeyUp);
			// 
			// RbUnidad
			// 
			this.RbUnidad.AutoSize = true;
			this.RbUnidad.Location = new System.Drawing.Point(307, 142);
			this.RbUnidad.Name = "RbUnidad";
			this.RbUnidad.Size = new System.Drawing.Size(59, 17);
			this.RbUnidad.TabIndex = 2;
			this.RbUnidad.TabStop = true;
			this.RbUnidad.Text = "Unidad";
			this.RbUnidad.UseVisualStyleBackColor = true;
			this.RbUnidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RbUnidad_KeyUp);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(698, 171);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Unidades:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(719, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Peso:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(702, 214);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Volumen:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(704, 233);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Facturar:";
			// 
			// BtnAgregar
			// 
			this.BtnAgregar.Location = new System.Drawing.Point(757, 256);
			this.BtnAgregar.Name = "BtnAgregar";
			this.BtnAgregar.Size = new System.Drawing.Size(100, 23);
			this.BtnAgregar.TabIndex = 8;
			this.BtnAgregar.Text = "Agregar";
			this.BtnAgregar.UseVisualStyleBackColor = true;
			this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
			// 
			// TxtPesoMinimo
			// 
			this.TxtPesoMinimo.Enabled = false;
			this.TxtPesoMinimo.Location = new System.Drawing.Point(211, 68);
			this.TxtPesoMinimo.Name = "TxtPesoMinimo";
			this.TxtPesoMinimo.Size = new System.Drawing.Size(35, 20);
			this.TxtPesoMinimo.TabIndex = 51;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(162, 71);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 13);
			this.label7.TabIndex = 52;
			this.label7.Text = "Minimo:";
			// 
			// BtnEliminar
			// 
			this.BtnEliminar.Location = new System.Drawing.Point(88, 285);
			this.BtnEliminar.Name = "BtnEliminar";
			this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
			this.BtnEliminar.TabIndex = 53;
			this.BtnEliminar.Text = "Eliminar";
			this.BtnEliminar.UseVisualStyleBackColor = true;
			this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
			// 
			// TxtUnidadesTotal
			// 
			this.TxtUnidadesTotal.Location = new System.Drawing.Point(372, 283);
			this.TxtUnidadesTotal.Name = "TxtUnidadesTotal";
			this.TxtUnidadesTotal.Size = new System.Drawing.Size(43, 20);
			this.TxtUnidadesTotal.TabIndex = 54;
			this.TxtUnidadesTotal.Text = "0";
			this.TxtUnidadesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtFleteTotal
			// 
			this.TxtFleteTotal.Location = new System.Drawing.Point(615, 283);
			this.TxtFleteTotal.Name = "TxtFleteTotal";
			this.TxtFleteTotal.Size = new System.Drawing.Size(77, 20);
			this.TxtFleteTotal.TabIndex = 55;
			this.TxtFleteTotal.Text = "0";
			this.TxtFleteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtFacturarTotal
			// 
			this.TxtFacturarTotal.Location = new System.Drawing.Point(550, 283);
			this.TxtFacturarTotal.Name = "TxtFacturarTotal";
			this.TxtFacturarTotal.Size = new System.Drawing.Size(59, 20);
			this.TxtFacturarTotal.TabIndex = 56;
			this.TxtFacturarTotal.Text = "0";
			this.TxtFacturarTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtVolumenTotal
			// 
			this.TxtVolumenTotal.Location = new System.Drawing.Point(489, 283);
			this.TxtVolumenTotal.Name = "TxtVolumenTotal";
			this.TxtVolumenTotal.Size = new System.Drawing.Size(55, 20);
			this.TxtVolumenTotal.TabIndex = 57;
			this.TxtVolumenTotal.Text = "0";
			this.TxtVolumenTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtRealTotal
			// 
			this.TxtRealTotal.Location = new System.Drawing.Point(421, 283);
			this.TxtRealTotal.Name = "TxtRealTotal";
			this.TxtRealTotal.Size = new System.Drawing.Size(62, 20);
			this.TxtRealTotal.TabIndex = 58;
			this.TxtRealTotal.Text = "0";
			this.TxtRealTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtRegistros
			// 
			this.TxtRegistros.Location = new System.Drawing.Point(328, 283);
			this.TxtRegistros.Name = "TxtRegistros";
			this.TxtRegistros.Size = new System.Drawing.Size(38, 20);
			this.TxtRegistros.TabIndex = 59;
			this.TxtRegistros.Text = "0";
			this.TxtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// FrmGuiaDetalle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancelar;
			this.ClientSize = new System.Drawing.Size(869, 315);
			this.ControlBox = false;
			this.Controls.Add(this.TxtRegistros);
			this.Controls.Add(this.TxtRealTotal);
			this.Controls.Add(this.TxtVolumenTotal);
			this.Controls.Add(this.TxtFacturarTotal);
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
			this.Controls.Add(this.DgListaPrecioDetalles);
			this.Controls.Add(this.GbListas);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.TxtFacturar);
			this.Controls.Add(this.TxtReal);
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
			((System.ComponentModel.ISupportInitialize)(this.DgListaPrecioDetalles)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnGuardar;
		private System.Windows.Forms.ListView LvGuiaDetalles;
		private System.Windows.Forms.TextBox TxtUnidades;
		private System.Windows.Forms.TextBox TxtVolumen;
		private System.Windows.Forms.TextBox TxtReal;
		private System.Windows.Forms.TextBox TxtFacturar;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.GroupBox GbListas;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxtCodigoPrecioGeneral;
		private System.Windows.Forms.TextBox TxtNombrePrecioGeneral;
		private System.Windows.Forms.TextBox TxtNombrePrecio;
		private System.Windows.Forms.TextBox TxtCodigoPrecio;
		private System.Windows.Forms.DataGridView DgListaPrecioDetalles;
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
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoProductoPrecio;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmProducto;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmPeso;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmUnidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmPesoTope;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmVrPesoTope;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmVrTopeAdicional;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClmMinimo;
		private System.Windows.Forms.Button BtnEliminar;
		private System.Windows.Forms.ColumnHeader ClmUnidades;
		private System.Windows.Forms.TextBox TxtUnidadesTotal;
		private System.Windows.Forms.TextBox TxtFleteTotal;
		private System.Windows.Forms.TextBox TxtFacturarTotal;
		private System.Windows.Forms.TextBox TxtVolumenTotal;
		private System.Windows.Forms.TextBox TxtRealTotal;
		private System.Windows.Forms.TextBox TxtRegistros;
	}
}