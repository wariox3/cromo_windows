using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using MiLibreria;

namespace cromo
{
    class ClienteRepositorio
    {
        public static string nombreCliente(string codigoCliente)
        {

            string nombre = "";
            if (codigoCliente != "")
            {
                DataSet ds = Utilidades.Ejecutar("SELECT nombre_corto FROM tte_cliente where codigo_cliente_pk = " + codigoCliente);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {                   
                    nombre = Convert.ToString(dt.Rows[0][0]);
                }
            }

            return nombre;
        }
    }
}
