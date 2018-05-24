namespace cromo
{
	partial class frmRecibo
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
			this.dgRecibos = new System.Windows.Forms.DataGridView();
			this.clmCodigoReciboPk = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmFlete = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmManejo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtManejo = new System.Windows.Forms.TextBox();
			this.txtFlete = new System.Windows.Forms.TextBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Eliminar = new System.Windows.Forms.Button();
			this.btnImprimir = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgRecibos)).BeginInit();
			this.SuspendLayout();
			// 
			// dgRecibos
			// 
			this.dgRecibos.AllowUserToAddRows = false;
			this.dgRecibos.AllowUserToDeleteRows = false;
			this.dgRecibos.AllowUserToResizeColumns = false;
			this.dgRecibos.AllowUserToResizeRows = false;
			this.dgRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgRecibos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigoReciboPk,
            this.clmFlete,
            this.clmManejo,
            this.clmTotal});
			this.dgRecibos.Location = new System.Drawing.Point(25, 12);
			this.dgRecibos.Name = "dgRecibos";
			this.dgRecibos.Size = new System.Drawing.Size(467, 212);
			this.dgRecibos.TabIndex = 5;
			// 
			// clmCodigoReciboPk
			// 
			this.clmCodigoReciboPk.DataPropertyName = "codigo_recibo_pk";
			this.clmCodigoReciboPk.HeaderText = "ID";
			this.clmCodigoReciboPk.Name = "clmCodigoReciboPk";
			// 
			// clmFlete
			// 
			this.clmFlete.DataPropertyName = "vr_flete";
			this.clmFlete.HeaderText = "FLETE";
			this.clmFlete.Name = "clmFlete";
			// 
			// clmManejo
			// 
			this.clmManejo.DataPropertyName = "vr_manejo";
			this.clmManejo.HeaderText = "MANEJO";
			this.clmManejo.Name = "clmManejo";
			// 
			// clmTotal
			// 
			this.clmTotal.DataPropertyName = "vr_total";
			this.clmTotal.HeaderText = "TOTAL";
			this.clmTotal.Name = "clmTotal";
			// 
			// txtManejo
			// 
			this.txtManejo.Location = new System.Drawing.Point(83, 257);
			this.txtManejo.Name = "txtManejo";
			this.txtManejo.Size = new System.Drawing.Size(100, 20);
			this.txtManejo.TabIndex = 1;
			// 
			// txtFlete
			// 
			this.txtFlete.Location = new System.Drawing.Point(83, 233);
			this.txtFlete.Name = "txtFlete";
			this.txtFlete.Size = new System.Drawing.Size(100, 20);
			this.txtFlete.TabIndex = 0;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(200, 231);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(75, 23);
			this.btnAgregar.TabIndex = 2;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
			// Eliminar
			// 
			this.Eliminar.Location = new System.Drawing.Point(417, 231);
			this.Eliminar.Name = "Eliminar";
			this.Eliminar.Size = new System.Drawing.Size(75, 23);
			this.Eliminar.TabIndex = 4;
			this.Eliminar.Text = "Eliminar";
			this.Eliminar.UseVisualStyleBackColor = true;
			this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
			// 
			// btnImprimir
			// 
			this.btnImprimir.Location = new System.Drawing.Point(336, 230);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(75, 23);
			this.btnImprimir.TabIndex = 6;
			this.btnImprimir.Text = "Imprimir";
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// frmRecibo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 288);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.Eliminar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.txtFlete);
			this.Controls.Add(this.txtManejo);
			this.Controls.Add(this.dgRecibos);
			this.Name = "frmRecibo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generar recibo";
			this.Load += new System.EventHandler(this.frmRecibo_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgRecibos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgRecibos;
		private System.Windows.Forms.TextBox txtManejo;
		private System.Windows.Forms.TextBox txtFlete;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Eliminar;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoReciboPk;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmFlete;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmManejo;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
		private System.Windows.Forms.Button btnImprimir;
	}
}