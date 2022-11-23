namespace cromo
{
    partial class FrmConexion
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
            this.btnProbar = new System.Windows.Forms.Button();
            this.btnProbar2 = new System.Windows.Forms.Button();
            this.btnProbar3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProbar
            // 
            this.btnProbar.Location = new System.Drawing.Point(57, 110);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(75, 23);
            this.btnProbar.TabIndex = 0;
            this.btnProbar.Text = "Probar";
            this.btnProbar.UseVisualStyleBackColor = true;
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
            // 
            // btnProbar2
            // 
            this.btnProbar2.Location = new System.Drawing.Point(156, 110);
            this.btnProbar2.Name = "btnProbar2";
            this.btnProbar2.Size = new System.Drawing.Size(75, 23);
            this.btnProbar2.TabIndex = 1;
            this.btnProbar2.Text = "Probar 2";
            this.btnProbar2.UseVisualStyleBackColor = true;
            this.btnProbar2.Click += new System.EventHandler(this.btnProbar2_Click);
            // 
            // btnProbar3
            // 
            this.btnProbar3.Location = new System.Drawing.Point(247, 110);
            this.btnProbar3.Name = "btnProbar3";
            this.btnProbar3.Size = new System.Drawing.Size(75, 23);
            this.btnProbar3.TabIndex = 2;
            this.btnProbar3.Text = "Probar 3";
            this.btnProbar3.UseVisualStyleBackColor = true;
            this.btnProbar3.Click += new System.EventHandler(this.btnProbar3_Click);
            // 
            // FrmConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 160);
            this.Controls.Add(this.btnProbar3);
            this.Controls.Add(this.btnProbar2);
            this.Controls.Add(this.btnProbar);
            this.Name = "FrmConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prueba de conexion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProbar;
        private System.Windows.Forms.Button btnProbar2;
        private System.Windows.Forms.Button btnProbar3;
    }
}