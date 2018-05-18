namespace cromo
{
	partial class frmBuscarGuia
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
			this.dgGuias = new System.Windows.Forms.DataGridView();
			this.clmCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgGuias)).BeginInit();
			this.SuspendLayout();
			// 
			// dgGuias
			// 
			this.dgGuias.AllowUserToAddRows = false;
			this.dgGuias.AllowUserToDeleteRows = false;
			this.dgGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgGuias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigo,
            this.clmNumero});
			this.dgGuias.Location = new System.Drawing.Point(8, 37);
			this.dgGuias.Name = "dgGuias";
			this.dgGuias.ReadOnly = true;
			this.dgGuias.Size = new System.Drawing.Size(783, 305);
			this.dgGuias.TabIndex = 0;
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
			// frmBuscarGuia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dgGuias);
			this.Name = "frmBuscarGuia";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscar guia";
			this.Load += new System.EventHandler(this.frmBuscarGuia_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgGuias)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgGuias;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmNumero;
	}
}