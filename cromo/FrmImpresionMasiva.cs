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
    public partial class FrmImpresionMasiva : Form
    {
        public FrmImpresionMasiva()
        {
            InitializeComponent();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidarRango(out int desde, out int hasta))
                ImpresionGuia.Imprimir(this, desde, hasta);
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (ValidarRango(out int desde, out int hasta))
                ImpresionGuia.Previsualizar(this, desde, hasta);
        }

        // Desde y hasta deben ser números y desde <= hasta. El máximo de guías lo valida Fluor y su mensaje se muestra al imprimir
        private bool ValidarRango(out int desde, out int hasta)
        {
            hasta = 0;
            if (!int.TryParse(TxtCodigoDesde.Text.Trim(), out desde))
            {
                MessageBox.Show(this, "Digite un numero desde valido", "Impresion masiva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCodigoDesde.Focus();
                return false;
            }
            if (!int.TryParse(TxtCodigoHasta.Text.Trim(), out hasta))
            {
                MessageBox.Show(this, "Digite un numero hasta valido", "Impresion masiva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCodigoHasta.Focus();
                return false;
            }
            if (desde > hasta)
            {
                MessageBox.Show(this, "El numero desde debe ser menor o igual al numero hasta", "Impresion masiva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCodigoDesde.Focus();
                return false;
            }
            return true;
        }
    }
}
