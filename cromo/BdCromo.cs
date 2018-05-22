using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace cromo
{
    public class BdCromo
    {
        public static MySqlConnection ObtenerConexion()
        {
			/*https://www.youtube.com/watch?v=e8R3-EXqQIM */
			string servirdor = cromo.Properties.Settings.Default.servidorBaseDatos;
			string usuario = cromo.Properties.Settings.Default.usuarioBaseDatos;
			string clave = cromo.Properties.Settings.Default.claveBaseDatos;
			string baseDatos = cromo.Properties.Settings.Default.baseDatos;
			MySqlConnection conectar = new MySqlConnection("server="+ servirdor + "; database="+baseDatos+"; Uid="+usuario+"; pwd="+clave+";");
            conectar.Open();
            return conectar;
        }
    }
}
