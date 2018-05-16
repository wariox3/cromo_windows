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

			MySqlConnection conectar = new MySqlConnection("server=localhost; database=bdcromo; Uid=principal; pwd=70143086;");
            conectar.Open();
            return conectar;
        }
    }
}
