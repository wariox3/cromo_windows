using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
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

	public class Utilidades
	{
		public static DataSet Ejecutar(string cmd)
		{
			string servirdor = cromo.Properties.Settings.Default.servidorBaseDatos;
			string usuario = cromo.Properties.Settings.Default.usuarioBaseDatos;
			string clave = cromo.Properties.Settings.Default.claveBaseDatos;
			string baseDatos = cromo.Properties.Settings.Default.baseDatos;
			MySqlConnection bd = new MySqlConnection("server=" + servirdor + "; database=" + baseDatos + "; Uid=" + usuario + "; pwd=" + clave + ";");
			bd.Open();
			DataSet ds = new DataSet();
			MySqlDataAdapter dp = new MySqlDataAdapter(cmd, bd);
			dp.Fill(ds);
			bd.Close();
			return ds;
		}
	}

}
