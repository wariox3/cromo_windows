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
            int numeroDesde = Convert.ToInt32(TxtCodigoDesde.Text);
            int numeroHasta = Convert.ToInt32(TxtCodigoHasta.Text);
            if(numeroDesde <= numeroHasta)
            {
                if (numeroHasta - numeroDesde < ImpresionGuia.MaximoGuias)
                {
                    ImpresionGuia.Imprimir(this, numeroDesde, numeroHasta);
                } else
                {
                    MessageBox.Show("Se pueden imprimir maximo " + ImpresionGuia.MaximoGuias + " guias a la vez");
                }
            } else
            {
                MessageBox.Show("El numero desde debe ser menor o igual al numero hasta");
            }
        }
    }
}
