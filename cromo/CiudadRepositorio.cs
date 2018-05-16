using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MiLibreria;
namespace cromo
{
    class CiudadRepositorio
    {
        public static string nombreCiudad(string codigoCiudad)
        {

            string nombre = "";
            if (codigoCiudad != "")
            {
                DataSet ds = Utilidades.Ejecutar("SELECT nombre FROM tte_ciudad where codigo_ciudad_pk = '" + codigoCiudad + "'");
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
