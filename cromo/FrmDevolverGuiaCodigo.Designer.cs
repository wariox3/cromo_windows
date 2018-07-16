namespace cromo
{
	partial class FrmDevolverGuiaCodigo
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
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.BtnAceptar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtCodigoGuia = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancelar.Location = new System.Drawing.Point(19, 48);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
			this.BtnCancelar.TabIndex = 2;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// BtnAceptar
			// 
			this.BtnAceptar.Location = new System.Drawing.Point(138, 48);
			this.BtnAceptar.Name = "BtnAceptar";
			this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
			this.BtnAceptar.TabIndex = 1;
			this.BtnAceptar.Text = "Aceptar";
			this.BtnAceptar.UseVisualStyleBackColor = true;
			this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Codigo guia:";
			// 
			// TxtCodigoGuia
			// 
			this.TxtCodigoGuia.Location = new System.Drawing.Point(113, 13);
			this.TxtCodigoGuia.Name = "TxtCodigoGuia";
			this.TxtCodigoGuia.Size = new System.Drawing.Size(100, 20);
			this.TxtCodigoGuia.TabIndex = 0;
			this.TxtCodigoGuia.Text = "0";
			this.TxtCodigoGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TxtCodigoGuia.Enter += new System.EventHandler(this.TxtCodigoGuia_Enter);
			// 
			// FrmDevolverGuiaCodigo
			// 
			this.AcceptButton = this.BtnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancelar;
			this.ClientSize = new System.Drawing.Size(231, 83);
			this.ControlBox = false;
			this.Controls.Add(this.TxtCodigoGuia);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnAceptar);
			this.Controls.Add(this.BtnCancelar);
			this.Name = "FrmDevolverGuiaCodigo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Digite la guia";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Button BtnAceptar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxtCodigoGuia;
	}
}