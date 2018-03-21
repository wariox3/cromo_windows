using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace cromo
{
    class guiaRepositorio
    {
        public static int Agregar(guia pGuia)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO guia (codigo_operacion_ingreso_fk, " +
                "codigo_operacion_cargo_fk, codigo_cliente_fk, codigo_ciudad_origen_fk, codigo_ciudad_destino_fk, " +
                "documento_cliente, remitente)" +
                " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                pGuia.codigoOperacionIngresoFk, pGuia.codigoOperacionCargoFk, pGuia.codigoClienteFk, pGuia.codigoCiudadOrigenFk, 
                pGuia.codigoCiudadDestinoFk, pGuia.documentoCliente, pGuia.remitente), BdCromo.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
