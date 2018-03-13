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
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=bdcromo; Uid=principal; pwd=70143086;");

            conectar.Open();
            return conectar;
        }
    }
}
