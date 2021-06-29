namespace cromo
{
    partial class FrmManejo
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
            this.TxtManejo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtManejoMinimoUnidad = new System.Windows.Forms.TextBox();
            this.TxtManejoMinioDespacho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(150, 82);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 5;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // TxtManejo
            // 
            this.TxtManejo.Location = new System.Drawing.Point(110, 6);
            this.TxtManejo.Name = "TxtManejo";
            this.TxtManejo.Size = new System.Drawing.Size(115, 20);
            this.TxtManejo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manejo:";
            // 
            // TxtManejoMinimoUnidad
            // 
            this.TxtManejoMinimoUnidad.Location = new System.Drawing.Point(110, 32);
            this.TxtManejoMinimoUnidad.Name = "TxtManejoMinimoUnidad";
            this.TxtManejoMinimoUnidad.Size = new System.Drawing.Size(115, 20);
            this.TxtManejoMinimoUnidad.TabIndex = 6;
            // 
            // TxtManejoMinioDespacho
            // 
            this.TxtManejoMinioDespacho.Location = new System.Drawing.Point(111, 56);
            this.TxtManejoMinioDespacho.Name = "TxtManejoMinioDespacho";
            this.TxtManejoMinioDespacho.Size = new System.Drawing.Size(115, 20);
            this.TxtManejoMinioDespacho.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Minimo unidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Minimo despacho:";
            // 
            // FrmManejo
            // 
            this.AcceptButton = this.BtnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 117);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtManejoMinioDespacho);
            this.Controls.Add(this.TxtManejoMinimoUnidad);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtManejo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmManejo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manejo";
            this.Load += new System.EventHandler(this.FrmManejo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtManejo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtManejoMinimoUnidad;
        private System.Windows.Forms.TextBox TxtManejoMinioDespacho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}