namespace cromo
{
	partial class FrmImprimirGuia
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
			this.btnImprimir = new System.Windows.Forms.Button();
			this.btnCambiarEstado = new System.Windows.Forms.Button();
			this.dgGuias = new System.Windows.Forms.DataGridView();
			this.clmSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgGuias)).BeginInit();
			this.SuspendLayout();
			// 
			// btnImprimir
			// 
			this.btnImprimir.Location = new System.Drawing.Point(633, 402);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(154, 25);
			this.btnImprimir.TabIndex = 1;
			this.btnImprimir.Text = "Imprimir";
			this.btnImprimir.UseVisualStyleBackColor = true;
			// 
			// btnCambiarEstado
			// 
			this.btnCambiarEstado.Location = new System.Drawing.Point(473, 402);
			this.btnCambiarEstado.Name = "btnCambiarEstado";
			this.btnCambiarEstado.Size = new System.Drawing.Size(154, 25);
			this.btnCambiarEstado.TabIndex = 2;
			this.btnCambiarEstado.Text = "Estado impreso";
			this.btnCambiarEstado.UseVisualStyleBackColor = true;
			this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
			// 
			// dgGuias
			// 
			this.dgGuias.AllowUserToAddRows = false;
			this.dgGuias.AllowUserToDeleteRows = false;
			this.dgGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgGuias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSeleccionar});
			this.dgGuias.Location = new System.Drawing.Point(12, 12);
			this.dgGuias.Name = "dgGuias";
			this.dgGuias.ReadOnly = true;
			this.dgGuias.Size = new System.Drawing.Size(776, 384);
			this.dgGuias.TabIndex = 0;
			// 
			// clmSeleccionar
			// 
			this.clmSeleccionar.HeaderText = "";
			this.clmSeleccionar.Name = "clmSeleccionar";
			this.clmSeleccionar.ReadOnly = true;
			this.clmSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.clmSeleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// frmImprimirGuia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 435);
			this.Controls.Add(this.btnCambiarEstado);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.dgGuias);
			this.Name = "frmImprimirGuia";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Imprimir guias";
			this.Load += new System.EventHandler(this.frmImprimirGuia_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgGuias)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnImprimir;
		private System.Windows.Forms.Button btnCambiarEstado;
		private System.Windows.Forms.DataGridView dgGuias;
		private System.Windows.Forms.DataGridViewCheckBoxColumn clmSeleccionar;
	}
}