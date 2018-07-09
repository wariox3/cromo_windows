namespace cromo
{
	partial class FrmDevolverDocumento
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
			this.TxtDocumento = new System.Windows.Forms.TextBox();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.BtnAceptar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Documento:";
			// 
			// TxtDocumento
			// 
			this.TxtDocumento.Location = new System.Drawing.Point(95, 9);
			this.TxtDocumento.Name = "TxtDocumento";
			this.TxtDocumento.Size = new System.Drawing.Size(188, 20);
			this.TxtDocumento.TabIndex = 1;
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancelar.Location = new System.Drawing.Point(95, 35);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
			this.BtnCancelar.TabIndex = 2;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// BtnAceptar
			// 
			this.BtnAceptar.Location = new System.Drawing.Point(208, 35);
			this.BtnAceptar.Name = "BtnAceptar";
			this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
			this.BtnAceptar.TabIndex = 3;
			this.BtnAceptar.Text = "Aceptar";
			this.BtnAceptar.UseVisualStyleBackColor = true;
			this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// FrmDevolverDocumento
			// 
			this.AcceptButton = this.BtnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancelar;
			this.ClientSize = new System.Drawing.Size(295, 75);
			this.ControlBox = false;
			this.Controls.Add(this.BtnAceptar);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.TxtDocumento);
			this.Controls.Add(this.label1);
			this.Name = "FrmDevolverDocumento";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Devolver documento";
			this.Load += new System.EventHandler(this.FrmDevolverDocumento_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxtDocumento;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Button BtnAceptar;
	}
}