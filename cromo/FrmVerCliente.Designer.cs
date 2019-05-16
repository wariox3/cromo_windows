namespace cromo
{
    partial class FrmVerCliente
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
            this.DgCondicionFlete = new System.Windows.Forms.DataGridView();
            this.ClmCodigoCondicionFletePk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCiudadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCiudadDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDescuentoPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDescuentoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPesoMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPesoMinimoGuia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgCondicionFlete)).BeginInit();
            this.SuspendLayout();
            // 
            // DgCondicionFlete
            // 
            this.DgCondicionFlete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgCondicionFlete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmCodigoCondicionFletePk,
            this.ClmCiudadOrigen,
            this.ClmCiudadDestino,
            this.Zona,
            this.ClmDescuentoPeso,
            this.ClmDescuentoUnidad,
            this.ClmPesoMinimo,
            this.ClmPesoMinimoGuia});
            this.DgCondicionFlete.Location = new System.Drawing.Point(12, 60);
            this.DgCondicionFlete.Name = "DgCondicionFlete";
            this.DgCondicionFlete.Size = new System.Drawing.Size(776, 192);
            this.DgCondicionFlete.TabIndex = 0;
            // 
            // ClmCodigoCondicionFletePk
            // 
            this.ClmCodigoCondicionFletePk.DataPropertyName = "codigoCondicionFletePk";
            this.ClmCodigoCondicionFletePk.HeaderText = "ID";
            this.ClmCodigoCondicionFletePk.Name = "ClmCodigoCondicionFletePk";
            this.ClmCodigoCondicionFletePk.Width = 30;
            // 
            // ClmCiudadOrigen
            // 
            this.ClmCiudadOrigen.DataPropertyName = "ciudadOrigenNombre";
            this.ClmCiudadOrigen.HeaderText = "Origen";
            this.ClmCiudadOrigen.Name = "ClmCiudadOrigen";
            // 
            // ClmCiudadDestino
            // 
            this.ClmCiudadDestino.DataPropertyName = "ciudadDestinoNombre";
            this.ClmCiudadDestino.HeaderText = "Destino";
            this.ClmCiudadDestino.Name = "ClmCiudadDestino";
            // 
            // Zona
            // 
            this.Zona.DataPropertyName = "zonaNombre";
            this.Zona.HeaderText = "Zona";
            this.Zona.Name = "Zona";
            // 
            // ClmDescuentoPeso
            // 
            this.ClmDescuentoPeso.DataPropertyName = "descuentoPeso";
            this.ClmDescuentoPeso.HeaderText = "Des peso";
            this.ClmDescuentoPeso.Name = "ClmDescuentoPeso";
            this.ClmDescuentoPeso.Width = 30;
            // 
            // ClmDescuentoUnidad
            // 
            this.ClmDescuentoUnidad.DataPropertyName = "descuentoUnidad";
            this.ClmDescuentoUnidad.HeaderText = "Des unidad";
            this.ClmDescuentoUnidad.Name = "ClmDescuentoUnidad";
            this.ClmDescuentoUnidad.Width = 30;
            // 
            // ClmPesoMinimo
            // 
            this.ClmPesoMinimo.DataPropertyName = "pesoMinimo";
            this.ClmPesoMinimo.HeaderText = "P_Min";
            this.ClmPesoMinimo.Name = "ClmPesoMinimo";
            this.ClmPesoMinimo.Width = 30;
            // 
            // ClmPesoMinimoGuia
            // 
            this.ClmPesoMinimoGuia.DataPropertyName = "pesoMinimoGuia";
            this.ClmPesoMinimoGuia.HeaderText = "P_Min_Guia";
            this.ClmPesoMinimoGuia.Name = "ClmPesoMinimoGuia";
            this.ClmPesoMinimoGuia.Width = 30;
            // 
            // FrmVerCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 260);
            this.Controls.Add(this.DgCondicionFlete);
            this.Name = "FrmVerCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver cliente";
            this.Load += new System.EventHandler(this.FrmVerCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgCondicionFlete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgCondicionFlete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoCondicionFletePk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCiudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCiudadDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zona;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDescuentoPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDescuentoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPesoMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPesoMinimoGuia;
    }
}