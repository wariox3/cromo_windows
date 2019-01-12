namespace cromo
{
	partial class FrmValidarAdministrador
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
			this.TxtClave = new System.Windows.Forms.TextBox();
			this.BtnValidar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtClave
			// 
			this.TxtClave.Location = new System.Drawing.Point(80, 12);
			this.TxtClave.Name = "TxtClave";
			this.TxtClave.PasswordChar = '*';
			this.TxtClave.Size = new System.Drawing.Size(211, 20);
			this.TxtClave.TabIndex = 0;
			// 
			// BtnValidar
			// 
			this.BtnValidar.Location = new System.Drawing.Point(196, 47);
			this.BtnValidar.Name = "BtnValidar";
			this.BtnValidar.Size = new System.Drawing.Size(95, 20);
			this.BtnValidar.TabIndex = 1;
			this.BtnValidar.Text = "Validar";
			this.BtnValidar.UseVisualStyleBackColor = true;
			this.BtnValidar.Click += new System.EventHandler(this.BtnValidar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Clave:";
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(80, 47);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(95, 20);
			this.BtnCancelar.TabIndex = 3;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// FrmValidarAdministrador
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(301, 76);
			this.ControlBox = false;
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnValidar);
			this.Controls.Add(this.TxtClave);
			this.Name = "FrmValidarAdministrador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Validar administrador";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TxtClave;
		private System.Windows.Forms.Button BtnValidar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnCancelar;
	}
}