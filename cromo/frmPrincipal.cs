using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cromo
{
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGuia frmGuia = new FrmGuia();
            frmGuia.MdiParent = this;
            frmGuia.Show();
        }

        private void mnuArchivoConfigurcion_Click(object sender, EventArgs e)
        {
		    FrmConfiguracion frmConfiguracion = new FrmConfiguracion();
		    frmConfiguracion.ShowDialog();
        }

		private void FrmPrincipal_Load(object sender, EventArgs e)
		{
			FrmIngreso FrmIngrero = new FrmIngreso();
            this.Text = this.Text + " " + Application.ProductVersion;
            FrmIngrero.ShowDialog();            
            if (FrmIngrero.DialogResult != DialogResult.OK)
			{
				Close();
			}
		}

        private void mnuImpresionMasiva_Click(object sender, EventArgs e)
        {
            FrmImpresionMasiva frmImpresionMasiva = new FrmImpresionMasiva();
            frmImpresionMasiva.ShowDialog();
            
        }

        private void MenuCrearCliente_Click(object sender, EventArgs e)
        {
            FrmClienteNuevo frmClienteNuevo = new FrmClienteNuevo();
            frmClienteNuevo.ShowDialog();
        }

        private void MenuCrearDestinatario_Click(object sender, EventArgs e)
        {
            FrmDestinatarioNuevo frmDestinatarioNuevo = new FrmDestinatarioNuevo();
            frmDestinatarioNuevo.ShowDialog();
        }

        private void MenuEnviarRndc_Click(object sender, EventArgs e)
        {
            FrmEnviarRndc frmEnviarRndc = new FrmEnviarRndc();
            frmEnviarRndc.ShowDialog();
        }

        private void MenuCumplirRndc_Click(object sender, EventArgs e)
        {
            FrmCumplirRndc frmCumplirRndc = new FrmCumplirRndc();
            frmCumplirRndc.ShowDialog();
        }
    }
}
