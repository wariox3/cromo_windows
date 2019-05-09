namespace cromo
{
	partial class FrmRecibo
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
            this.DgRecibos = new System.Windows.Forms.DataGridView();
            this.TxtManejo = new System.Windows.Forms.TextBox();
            this.TxtFlete = new System.Windows.Forms.TextBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.clmCodigoReciboPk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFlete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmManejo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgRecibos)).BeginInit();
            this.SuspendLayout();
            // 
            // DgRecibos
            // 
            this.DgRecibos.AllowUserToAddRows = false;
            this.DgRecibos.AllowUserToDeleteRows = false;
            this.DgRecibos.AllowUserToResizeColumns = false;
            this.DgRecibos.AllowUserToResizeRows = false;
            this.DgRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgRecibos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigoReciboPk,
            this.clmFlete,
            this.clmManejo,
            this.clmTotal});
            this.DgRecibos.Location = new System.Drawing.Point(25, 12);
            this.DgRecibos.Name = "DgRecibos";
            this.DgRecibos.ReadOnly = true;
            this.DgRecibos.Size = new System.Drawing.Size(467, 212);
            this.DgRecibos.TabIndex = 5;
            // 
            // TxtManejo
            // 
            this.TxtManejo.Location = new System.Drawing.Point(83, 257);
            this.TxtManejo.Name = "TxtManejo";
            this.TxtManejo.Size = new System.Drawing.Size(100, 20);
            this.TxtManejo.TabIndex = 1;
            this.TxtManejo.Text = "0";
            this.TxtManejo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtFlete
            // 
            this.TxtFlete.Location = new System.Drawing.Point(83, 233);
            this.TxtFlete.Name = "TxtFlete";
            this.TxtFlete.Size = new System.Drawing.Size(100, 20);
            this.TxtFlete.TabIndex = 0;
            this.TxtFlete.Text = "0";
            this.TxtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(200, 231);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(75, 23);
            this.BtnAgregar.TabIndex = 2;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Manejo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Flete:";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(417, 231);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 4;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Location = new System.Drawing.Point(336, 230);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(75, 23);
            this.BtnImprimir.TabIndex = 6;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // clmCodigoReciboPk
            // 
            this.clmCodigoReciboPk.DataPropertyName = "codigoReciboPk";
            this.clmCodigoReciboPk.HeaderText = "ID";
            this.clmCodigoReciboPk.Name = "clmCodigoReciboPk";
            // 
            // clmFlete
            // 
            this.clmFlete.DataPropertyName = "vrFlete";
            this.clmFlete.HeaderText = "FLETE";
            this.clmFlete.Name = "clmFlete";
            // 
            // clmManejo
            // 
            this.clmManejo.DataPropertyName = "vrManejo";
            this.clmManejo.HeaderText = "MANEJO";
            this.clmManejo.Name = "clmManejo";
            // 
            // clmTotal
            // 
            this.clmTotal.DataPropertyName = "vrTotal";
            this.clmTotal.HeaderText = "TOTAL";
            this.clmTotal.Name = "clmTotal";
            // 
            // FrmRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 288);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TxtFlete);
            this.Controls.Add(this.TxtManejo);
            this.Controls.Add(this.DgRecibos);
            this.Name = "FrmRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar recibo";
            this.Load += new System.EventHandler(this.FrmRecibo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgRecibos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView DgRecibos;
		private System.Windows.Forms.TextBox TxtManejo;
		private System.Windows.Forms.TextBox TxtFlete;
		private System.Windows.Forms.Button BtnAgregar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BtnEliminar;
		private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoReciboPk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFlete;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmManejo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
    }
}