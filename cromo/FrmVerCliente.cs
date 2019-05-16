using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace cromo
{
    public partial class FrmVerCliente : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmVerCliente()
        {
            InitializeComponent();
        }

        private void FrmVerCliente_Load(object sender, EventArgs e)
        {
            DgCondicionFlete.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            string parametrosJson = "{\"codigoCliente\":\"" + General.CodigoCliente + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/condicionflete/cliente", parametrosJson);
            List<ApiCondicionFlete> apiCondicionesFlete = ser.Deserialize<List<ApiCondicionFlete>>(jsonRespuesta);
            DgCondicionFlete.DataSource = apiCondicionesFlete;
        }
    }
}
