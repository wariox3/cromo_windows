namespace cromo
{
	partial class FrmBuscarGuia
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
			this.clmCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.DgGuias)).BeginInit();
			this.SuspendLayout();
			// 
			// DgGuias
			// 
			this.DgGuias.AllowUserToAddRows = false;
			this.DgGuias.AllowUserToDeleteRows = false;
			this.DgGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgGuias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigo,
            this.clmNumero});
			this.DgGuias.Location = new System.Drawing.Point(8, 37);
			this.DgGuias.Name = "DgGuias";
			this.DgGuias.ReadOnly = true;
			this.DgGuias.Size = new System.Drawing.Size(783, 305);
			this.DgGuias.TabIndex = 0;
			// 
			// clmCodigo
			// 
			this.clmCodigo.DataPropertyName = "codigo_guia_pk";
			this.clmCodigo.HeaderText = "ID";
			this.clmCodigo.Name = "clmCodigo";
			this.clmCodigo.ReadOnly = true;
			// 
			// clmNumero
			// 
			this.clmNumero.DataPropertyName = "numero";
			this.clmNumero.HeaderText = "Numero";
			this.clmNumero.Name = "clmNumero";
			this.clmNumero.ReadOnly = true;
			// 
			// FrmBuscarGuia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.DgGuias);
			this.Name = "FrmBuscarGuia";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscar guia";
			this.Load += new System.EventHandler(this.FrmBuscarGuia_Load);
			((System.ComponentModel.ISupportInitialize)(this.DgGuias)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DgGuias;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmNumero;
	}
}