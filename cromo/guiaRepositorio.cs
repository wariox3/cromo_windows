using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace cromo
{
    class GuiaRepositorio
    {
        public static long Agregar(guia pGuia)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tte_guia (codigo_operacion_ingreso_fk, " +
                "codigo_operacion_cargo_fk, codigo_cliente_fk, codigo_ciudad_origen_fk, codigo_ciudad_destino_fk, " +
				"documento_cliente, remitente, codigo_servicio_fk, codigo_guia_tipo_fk, codigo_empaque_fk, nombre_destinatario, " +
				"direccion_destinatario, telefono_destinatario, fecha_ingreso, unidades, peso_real, peso_volumen, peso_facturado, " +
				"vr_flete, vr_manejo, vr_declara, vr_recaudo, codigo_ruta_fk, orden_ruta, codigo_producto_fk, reexpedicion, " +
				"codigo_condicion_fk, factura, numero, comentario)" +
				" values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', now(), " +
				"{13}, {14}, {15}, {16}, {17}, {18}, {19}, {20},'{21}',{22},'{23}', {24}, {25}, {26}, {27}, '{28}')",
                pGuia.codigoOperacionIngresoFk, pGuia.codigoOperacionCargoFk, pGuia.codigoClienteFk, pGuia.codigoCiudadOrigenFk, 
                pGuia.codigoCiudadDestinoFk, pGuia.documentoCliente, pGuia.remitente, pGuia.codigoServicioFk, pGuia.codigoGuiaTipoFk,
				pGuia.codigoEmpaqueFk, pGuia.nombreDestinatario, pGuia.direccionDestinatario, pGuia.telefonoDestinatario,
				pGuia.unidades, pGuia.pesoReal, pGuia.pesoVolumen, pGuia.pesoFacturar, pGuia.vrFlete, pGuia.vrManejo, pGuia.vrDeclara,
				pGuia.vrRecaudo, pGuia.codigoRutaFk, pGuia.ordenRuta, pGuia.codigoProductoFk, pGuia.reexpedicion, pGuia.codigoCondicionFk,
				pGuia.factura, pGuia.numero, pGuia.comentario
				), BdCromo.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
			
			return comando.LastInsertedId;
        }
    }
}
