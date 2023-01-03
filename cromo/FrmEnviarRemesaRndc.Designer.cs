namespace cromo
{
    partial class FrmEnviarRemesaRndc
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
            this.DgGuias = new System.Windows.Forms.DataGridView();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.clmCodigoGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTerceroNombreCorto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCodigoCiudadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCodigoCiudadDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCodigoDespachoFk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgGuias)).BeginInit();
            this.SuspendLayout();
            // 
            // DgGuias
            // 
            this.DgGuias.AllowUserToAddRows = false;
            this.DgGuias.AllowUserToDeleteRows = false;
            this.DgGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgGuias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigoGuia,
            this.clmFechaIngreso,
            this.ClmTerceroNombreCorto,
            this.ClmCodigoCiudadOrigen,
            this.clmOrigen,
            this.ClmCodigoCiudadDestino,
            this.clmDestino,
            this.ClmCodigoProducto,
            this.clmProductoNombre,
            this.ClmCodigoDespachoFk});
            this.DgGuias.Location = new System.Drawing.Point(12, 12);
            this.DgGuias.MultiSelect = false;
            this.DgGuias.Name = "DgGuias";
            this.DgGuias.ReadOnly = true;
            this.DgGuias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgGuias.Size = new System.Drawing.Size(911, 422);
            this.DgGuias.StandardTab = true;
            this.DgGuias.TabIndex = 3;
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Location = new System.Drawing.Point(809, 440);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(114, 23);
            this.BtnEnviar.TabIndex = 4;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // clmCodigoGuia
            // 
            this.clmCodigoGuia.DataPropertyName = "codigoGuiaPk";
            this.clmCodigoGuia.HeaderText = "Guia";
            this.clmCodigoGuia.Name = "clmCodigoGuia";
            this.clmCodigoGuia.ReadOnly = true;
            this.clmCodigoGuia.Width = 50;
            // 
            // clmFechaIngreso
            // 
            this.clmFechaIngreso.DataPropertyName = "fechaIngreso";
            this.clmFechaIngreso.HeaderText = "Fecha";
            this.clmFechaIngreso.Name = "clmFechaIngreso";
            this.clmFechaIngreso.ReadOnly = true;
            this.clmFechaIngreso.Width = 80;
            // 
            // ClmTerceroNombreCorto
            // 
            this.ClmTerceroNombreCorto.DataPropertyName = "terceroNombreCorto";
            this.ClmTerceroNombreCorto.HeaderText = "Cliente";
            this.ClmTerceroNombreCorto.Name = "ClmTerceroNombreCorto";
            this.ClmTerceroNombreCorto.ReadOnly = true;
            this.ClmTerceroNombreCorto.Width = 180;
            // 
            // ClmCodigoCiudadOrigen
            // 
            this.ClmCodigoCiudadOrigen.DataPropertyName = "codigoCiudadOrigen";
            this.ClmCodigoCiudadOrigen.HeaderText = "Cod";
            this.ClmCodigoCiudadOrigen.Name = "ClmCodigoCiudadOrigen";
            this.ClmCodigoCiudadOrigen.ReadOnly = true;
            this.ClmCodigoCiudadOrigen.Width = 50;
            // 
            // clmOrigen
            // 
            this.clmOrigen.DataPropertyName = "ciudadOrigen";
            this.clmOrigen.HeaderText = "Origen";
            this.clmOrigen.Name = "clmOrigen";
            this.clmOrigen.ReadOnly = true;
            // 
            // ClmCodigoCiudadDestino
            // 
            this.ClmCodigoCiudadDestino.DataPropertyName = "codigoCiudadDestino";
            this.ClmCodigoCiudadDestino.HeaderText = "Cod";
            this.ClmCodigoCiudadDestino.Name = "ClmCodigoCiudadDestino";
            this.ClmCodigoCiudadDestino.ReadOnly = true;
            this.ClmCodigoCiudadDestino.Width = 50;
            // 
            // clmDestino
            // 
            this.clmDestino.DataPropertyName = "ciudadDestino";
            this.clmDestino.HeaderText = "Destino";
            this.clmDestino.Name = "clmDestino";
            this.clmDestino.ReadOnly = true;
            // 
            // ClmCodigoProducto
            // 
            this.ClmCodigoProducto.DataPropertyName = "productoCodigoTransporte";
            this.ClmCodigoProducto.HeaderText = "Cod";
            this.ClmCodigoProducto.Name = "ClmCodigoProducto";
            this.ClmCodigoProducto.ReadOnly = true;
            this.ClmCodigoProducto.Width = 50;
            // 
            // clmProductoNombre
            // 
            this.clmProductoNombre.DataPropertyName = "productoNombre";
            this.clmProductoNombre.HeaderText = "Producto";
            this.clmProductoNombre.Name = "clmProductoNombre";
            this.clmProductoNombre.ReadOnly = true;
            this.clmProductoNombre.Width = 150;
            // 
            // ClmCodigoDespachoFk
            // 
            this.ClmCodigoDespachoFk.DataPropertyName = "codigoDespachoFk";
            this.ClmCodigoDespachoFk.HeaderText = "Des";
            this.ClmCodigoDespachoFk.Name = "ClmCodigoDespachoFk";
            this.ClmCodigoDespachoFk.ReadOnly = true;
            this.ClmCodigoDespachoFk.Width = 50;
            // 
            // FrmEnviarRemesaRndc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 473);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.DgGuias);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnviarRemesaRndc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar remesas RNDC";
            this.Load += new System.EventHandler(this.FrmEnviarRemesaRndc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgGuias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DgGuias;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoGuia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTerceroNombreCorto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoCiudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoCiudadDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoDespachoFk;
    }
}