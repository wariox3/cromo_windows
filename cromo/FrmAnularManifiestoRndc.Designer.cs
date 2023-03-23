namespace cromo
{
    partial class FrmAnularManifiestoRndc
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
            this.components = new System.ComponentModel.Container();
            this.DgDespachos = new System.Windows.Forms.DataGridView();
            this.clmCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmConductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apiUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnAnular = new System.Windows.Forms.Button();
            this.apiReciboImprimirBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCodigoDespacho = new System.Windows.Forms.TextBox();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgDespachos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apiUsuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apiReciboImprimirBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DgDespachos
            // 
            this.DgDespachos.AllowUserToAddRows = false;
            this.DgDespachos.AllowUserToDeleteRows = false;
            this.DgDespachos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgDespachos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigoCliente,
            this.clmTipo,
            this.clmOperacion,
            this.clmNumero,
            this.clmFecha,
            this.clmOrigen,
            this.clmDestino,
            this.clmConductor});
            this.DgDespachos.Location = new System.Drawing.Point(16, 36);
            this.DgDespachos.MultiSelect = false;
            this.DgDespachos.Name = "DgDespachos";
            this.DgDespachos.ReadOnly = true;
            this.DgDespachos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgDespachos.Size = new System.Drawing.Size(853, 407);
            this.DgDespachos.StandardTab = true;
            this.DgDespachos.TabIndex = 3;
            this.DgDespachos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgDespachos_CellContentClick);
            // 
            // clmCodigoCliente
            // 
            this.clmCodigoCliente.DataPropertyName = "codigoDespachoPk";
            this.clmCodigoCliente.HeaderText = "ID";
            this.clmCodigoCliente.Name = "clmCodigoCliente";
            this.clmCodigoCliente.ReadOnly = true;
            this.clmCodigoCliente.Width = 50;
            // 
            // clmTipo
            // 
            this.clmTipo.DataPropertyName = "despachoTipo";
            this.clmTipo.HeaderText = "Tipo";
            this.clmTipo.Name = "clmTipo";
            this.clmTipo.ReadOnly = true;
            // 
            // clmOperacion
            // 
            this.clmOperacion.DataPropertyName = "codigoOperacionFk";
            this.clmOperacion.HeaderText = "OP";
            this.clmOperacion.Name = "clmOperacion";
            this.clmOperacion.ReadOnly = true;
            this.clmOperacion.Width = 50;
            // 
            // clmNumero
            // 
            this.clmNumero.DataPropertyName = "numero";
            this.clmNumero.HeaderText = "Numero";
            this.clmNumero.Name = "clmNumero";
            this.clmNumero.ReadOnly = true;
            this.clmNumero.Width = 60;
            // 
            // clmFecha
            // 
            this.clmFecha.DataPropertyName = "fechaSalida";
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.ReadOnly = true;
            // 
            // clmOrigen
            // 
            this.clmOrigen.DataPropertyName = "ciudadOrigen";
            this.clmOrigen.HeaderText = "Origen";
            this.clmOrigen.Name = "clmOrigen";
            this.clmOrigen.ReadOnly = true;
            // 
            // clmDestino
            // 
            this.clmDestino.DataPropertyName = "ciudadDestino";
            this.clmDestino.HeaderText = "Destino";
            this.clmDestino.Name = "clmDestino";
            this.clmDestino.ReadOnly = true;
            // 
            // clmConductor
            // 
            this.clmConductor.DataPropertyName = "conductorNombre";
            this.clmConductor.HeaderText = "Conductor";
            this.clmConductor.Name = "clmConductor";
            this.clmConductor.ReadOnly = true;
            this.clmConductor.Width = 200;
            // 
            // apiUsuarioBindingSource
            // 
            this.apiUsuarioBindingSource.DataSource = typeof(cromo.ApiUsuario);
            // 
            // BtnAnular
            // 
            this.BtnAnular.Location = new System.Drawing.Point(755, 449);
            this.BtnAnular.Name = "BtnAnular";
            this.BtnAnular.Size = new System.Drawing.Size(114, 23);
            this.BtnAnular.TabIndex = 4;
            this.BtnAnular.Text = "Anular";
            this.BtnAnular.UseVisualStyleBackColor = true;
            this.BtnAnular.Click += new System.EventHandler(this.BtnAnular_Click);
            // 
            // apiReciboImprimirBindingSource
            // 
            this.apiReciboImprimirBindingSource.DataSource = typeof(cromo.ApiReciboImprimir);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Codigo despacho:";
            // 
            // TxtCodigoDespacho
            // 
            this.TxtCodigoDespacho.Location = new System.Drawing.Point(112, 10);
            this.TxtCodigoDespacho.Name = "TxtCodigoDespacho";
            this.TxtCodigoDespacho.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigoDespacho.TabIndex = 6;
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Location = new System.Drawing.Point(218, 8);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(91, 23);
            this.BtnFiltrar.TabIndex = 7;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // FrmAnularManifiestoRndc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 486);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.TxtCodigoDespacho);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAnular);
            this.Controls.Add(this.DgDespachos);
            this.Name = "FrmAnularManifiestoRndc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAnularManifiestoRndc";
            this.Load += new System.EventHandler(this.FrmAnularManifiestoRndc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgDespachos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apiUsuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apiReciboImprimirBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DgDespachos;
        private System.Windows.Forms.Button BtnAnular;
        private System.Windows.Forms.BindingSource apiReciboImprimirBindingSource;
        private System.Windows.Forms.BindingSource apiUsuarioBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConductor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCodigoDespacho;
        private System.Windows.Forms.Button BtnFiltrar;
    }
}