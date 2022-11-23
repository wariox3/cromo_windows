﻿namespace cromo
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivoConfigurcion = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuia = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGuiaOperador = new System.Windows.Forms.ToolStripMenuItem();
            this.utilidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImpresionMasiva = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCrearCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCrearDestinatario = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEnviarRndc = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCumplirRndc = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.conexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.utilidadesToolStripMenuItem,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1111, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivoConfigurcion});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(60, 20);
            this.fileMenu.Text = "&Archivo";
            // 
            // mnuArchivoConfigurcion
            // 
            this.mnuArchivoConfigurcion.Name = "mnuArchivoConfigurcion";
            this.mnuArchivoConfigurcion.Size = new System.Drawing.Size(180, 22);
            this.mnuArchivoConfigurcion.Text = "Configuracion";
            this.mnuArchivoConfigurcion.Click += new System.EventHandler(this.mnuArchivoConfigurcion_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuia,
            this.MnuGuiaOperador});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(84, 20);
            this.editMenu.Text = "&Movimiento";
            // 
            // mnuGuia
            // 
            this.mnuGuia.ImageTransparentColor = System.Drawing.Color.Black;
            this.mnuGuia.Name = "mnuGuia";
            this.mnuGuia.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuGuia.Size = new System.Drawing.Size(180, 22);
            this.mnuGuia.Text = "&Guia";
            this.mnuGuia.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // MnuGuiaOperador
            // 
            this.MnuGuiaOperador.Name = "MnuGuiaOperador";
            this.MnuGuiaOperador.Size = new System.Drawing.Size(180, 22);
            this.MnuGuiaOperador.Text = "Guia operador";
            this.MnuGuiaOperador.Click += new System.EventHandler(this.MnuGuiaOperador_Click);
            // 
            // utilidadesToolStripMenuItem
            // 
            this.utilidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImpresionMasiva,
            this.MenuCrearCliente,
            this.MenuCrearDestinatario,
            this.MenuEnviarRndc,
            this.MenuCumplirRndc});
            this.utilidadesToolStripMenuItem.Name = "utilidadesToolStripMenuItem";
            this.utilidadesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.utilidadesToolStripMenuItem.Text = "Utilidades";
            // 
            // mnuImpresionMasiva
            // 
            this.mnuImpresionMasiva.Name = "mnuImpresionMasiva";
            this.mnuImpresionMasiva.Size = new System.Drawing.Size(180, 22);
            this.mnuImpresionMasiva.Text = "Impresion masiva";
            this.mnuImpresionMasiva.Click += new System.EventHandler(this.mnuImpresionMasiva_Click);
            // 
            // MenuCrearCliente
            // 
            this.MenuCrearCliente.Name = "MenuCrearCliente";
            this.MenuCrearCliente.Size = new System.Drawing.Size(180, 22);
            this.MenuCrearCliente.Text = "Crear cliente";
            this.MenuCrearCliente.Click += new System.EventHandler(this.MenuCrearCliente_Click);
            // 
            // MenuCrearDestinatario
            // 
            this.MenuCrearDestinatario.Name = "MenuCrearDestinatario";
            this.MenuCrearDestinatario.Size = new System.Drawing.Size(180, 22);
            this.MenuCrearDestinatario.Text = "Crear destinatario";
            this.MenuCrearDestinatario.Click += new System.EventHandler(this.MenuCrearDestinatario_Click);
            // 
            // MenuEnviarRndc
            // 
            this.MenuEnviarRndc.Name = "MenuEnviarRndc";
            this.MenuEnviarRndc.Size = new System.Drawing.Size(180, 22);
            this.MenuEnviarRndc.Text = "Enviar rndc";
            this.MenuEnviarRndc.Click += new System.EventHandler(this.MenuEnviarRndc_Click);
            // 
            // MenuCumplirRndc
            // 
            this.MenuCumplirRndc.Name = "MenuCumplirRndc";
            this.MenuCumplirRndc.Size = new System.Drawing.Size(180, 22);
            this.MenuCumplirRndc.Text = "Cumplir rndc";
            this.MenuCumplirRndc.Click += new System.EventHandler(this.MenuCumplirRndc_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem,
            this.conexionToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(53, 20);
            this.helpMenu.Text = "Ay&uda";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.contentsToolStripMenuItem.Text = "&Contenido";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.indexToolStripMenuItem.Text = "&Índice";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.searchToolStripMenuItem.Text = "&Buscar";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&Acerca de... ...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 657);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1111, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // conexionToolStripMenuItem
            // 
            this.conexionToolStripMenuItem.Name = "conexionToolStripMenuItem";
            this.conexionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.conexionToolStripMenuItem.Text = "Conexion";
            this.conexionToolStripMenuItem.Click += new System.EventHandler(this.conexionToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 679);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cromo escritorio";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuGuia;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivoConfigurcion;
        private System.Windows.Forms.ToolStripMenuItem utilidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuImpresionMasiva;
        private System.Windows.Forms.ToolStripMenuItem MenuCrearCliente;
        private System.Windows.Forms.ToolStripMenuItem MenuCrearDestinatario;
        private System.Windows.Forms.ToolStripMenuItem MenuEnviarRndc;
        private System.Windows.Forms.ToolStripMenuItem MenuCumplirRndc;
        private System.Windows.Forms.ToolStripMenuItem MnuGuiaOperador;
        private System.Windows.Forms.ToolStripMenuItem conexionToolStripMenuItem;
    }
}



