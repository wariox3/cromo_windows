namespace cromo
{
    partial class FrmCumplirRndc
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
            this.DgDespachos = new System.Windows.Forms.DataGridView();
            this.BtnCumplir = new System.Windows.Forms.Button();
            this.BtnDescartar = new System.Windows.Forms.Button();
            this.clmCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmConductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgDespachos)).BeginInit();
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
            this.clmFechaEntrega,
            this.clmOrigen,
            this.clmDestino,
            this.clmConductor});
            this.DgDespachos.Location = new System.Drawing.Point(12, 12);
            this.DgDespachos.MultiSelect = false;
            this.DgDespachos.Name = "DgDespachos";
            this.DgDespachos.ReadOnly = true;
            this.DgDespachos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgDespachos.Size = new System.Drawing.Size(911, 422);
            this.DgDespachos.StandardTab = true;
            this.DgDespachos.TabIndex = 3;
            this.DgDespachos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgDespachos_CellContentClick);
            // 
            // BtnCumplir
            // 
            this.BtnCumplir.Location = new System.Drawing.Point(775, 441);
            this.BtnCumplir.Name = "BtnCumplir";
            this.BtnCumplir.Size = new System.Drawing.Size(147, 23);
            this.BtnCumplir.TabIndex = 4;
            this.BtnCumplir.Text = "Cumplir";
            this.BtnCumplir.UseVisualStyleBackColor = true;
            this.BtnCumplir.Click += new System.EventHandler(this.BtnCumplir_Click);
            // 
            // BtnDescartar
            // 
            this.BtnDescartar.Location = new System.Drawing.Point(12, 442);
            this.BtnDescartar.Name = "BtnDescartar";
            this.BtnDescartar.Size = new System.Drawing.Size(147, 23);
            this.BtnDescartar.TabIndex = 5;
            this.BtnDescartar.Text = "Descartar";
            this.BtnDescartar.UseVisualStyleBackColor = true;
            this.BtnDescartar.Click += new System.EventHandler(this.BtnDescartar_Click);
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
            // clmFechaEntrega
            // 
            this.clmFechaEntrega.DataPropertyName = "fechaEntrega";
            this.clmFechaEntrega.HeaderText = "Entrega";
            this.clmFechaEntrega.Name = "clmFechaEntrega";
            this.clmFechaEntrega.ReadOnly = true;
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
            // FrmCumplirRndc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 477);
            this.Controls.Add(this.BtnDescartar);
            this.Controls.Add(this.BtnCumplir);
            this.Controls.Add(this.DgDespachos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCumplirRndc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cumplir RNDC";
            this.Load += new System.EventHandler(this.FrmCumplirRndc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgDespachos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DgDespachos;
        private System.Windows.Forms.Button BtnCumplir;
        private System.Windows.Forms.Button BtnDescartar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConductor;
    }
}