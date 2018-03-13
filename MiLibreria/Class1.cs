using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace MiLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            MySqlConnection bd = new MySqlConnection("server=localhost; database=bdcromo; Uid=principal; pwd=70143086;");
            bd.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd, bd);
            dp.Fill(ds);
            bd.Close();
            return ds;
        }
    }
}
