namespace cromo
{
	partial class FrmDevolverNumero
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
			this.BtnAceptar = new System.Windows.Forms.Button();
			this.TxtNumero = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BtnAceptar
			// 
			this.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BtnAceptar.Location = new System.Drawing.Point(189, 47);
			this.BtnAceptar.Name = "BtnAceptar";
			this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
			this.BtnAceptar.TabIndex = 1;
			this.BtnAceptar.Text = "Aceptar";
			this.BtnAceptar.UseVisualStyleBackColor = true;
			this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// TxtNumero
			// 
			this.TxtNumero.Location = new System.Drawing.Point(87, 12);
			this.TxtNumero.Name = "TxtNumero";
			this.TxtNumero.Size = new System.Drawing.Size(177, 20);
			this.TxtNumero.TabIndex = 0;
			this.TxtNumero.Enter += new System.EventHandler(this.TxtNumero_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Numero:";
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancelar.Location = new System.Drawing.Point(87, 47);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
			this.BtnCancelar.TabIndex = 2;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// FrmDevolverNumero
			// 
			this.AcceptButton = this.BtnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancelar;
			this.ClientSize = new System.Drawing.Size(274, 86);
			this.ControlBox = false;
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TxtNumero);
			this.Controls.Add(this.BtnAceptar);
			this.Name = "FrmDevolverNumero";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ingresar numero guia";
			this.Load += new System.EventHandler(this.FrmDevolverNumero_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnAceptar;
		private System.Windows.Forms.TextBox TxtNumero;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnCancelar;
	}
}