namespace cromo
{
	partial class FrmDevolverGuia
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cboGuiaTipo = new System.Windows.Forms.ComboBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tipo:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Numero:";
			// 
			// cboGuiaTipo
			// 
			this.cboGuiaTipo.FormattingEnabled = true;
			this.cboGuiaTipo.Location = new System.Drawing.Point(69, 16);
			this.cboGuiaTipo.Name = "cboGuiaTipo";
			this.cboGuiaTipo.Size = new System.Drawing.Size(261, 21);
			this.cboGuiaTipo.TabIndex = 0;
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(70, 43);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(259, 20);
			this.txtNumero.TabIndex = 1;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(245, 77);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(83, 23);
			this.btnAceptar.TabIndex = 2;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// FrmDevolverGuia
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 113);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.txtNumero);
			this.Controls.Add(this.cboGuiaTipo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FrmDevolverGuia";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscar guia..";
			this.Load += new System.EventHandler(this.FrmDevolverGuia_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboGuiaTipo;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Button btnAceptar;
	}
}