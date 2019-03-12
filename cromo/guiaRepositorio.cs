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
				"codigo_condicion_fk, factura, numero, comentario, usuario, relacion_cliente, empaque_referencia, vr_costo_reexpedicion, " +
				"vr_cobro_entrega, cortesia, mercancia_peligrosa, tipo_liquidacion, numero_factura, codigo_guia_pk, estado_impreso, estado_autorizado, estado_aprobado)" +
				" values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', now(), " +
				"{13}, {14}, {15}, {16}, {17}, {18}, {19}, {20},'{21}',{22},'{23}', {24}, {25}, {26}, {27}, '{28}', '{29}', '{30}', '{31}'," +
				" {32}, {33}, {34}, {35}, '{36}', {37}, {38}, {39}, {40}, {41})",
				pGuia.codigoOperacionIngresoFk, pGuia.codigoOperacionCargoFk, pGuia.codigoClienteFk, pGuia.codigoCiudadOrigenFk,
				pGuia.codigoCiudadDestinoFk, pGuia.documentoCliente, pGuia.remitente, pGuia.codigoServicioFk, pGuia.codigoGuiaTipoFk,
				pGuia.codigoEmpaqueFk, pGuia.nombreDestinatario, pGuia.direccionDestinatario, pGuia.telefonoDestinatario,
				pGuia.unidades, pGuia.pesoReal, pGuia.pesoVolumen, pGuia.pesoFacturar, pGuia.vrFlete, pGuia.vrManejo, pGuia.vrDeclara,
				pGuia.vrRecaudo, pGuia.codigoRutaFk, pGuia.ordenRuta, pGuia.codigoProductoFk, pGuia.reexpedicion, pGuia.codigoCondicionFk,
				pGuia.factura, pGuia.numero, pGuia.comentario, pGuia.usuario, pGuia.relacionCliente, pGuia.empaqueReferencia, pGuia.vrCostoReexpedicion,
				pGuia.vrCobroEntrega, pGuia.cortesia, pGuia.mercanciaPeligrosa, pGuia.tipoLiquidacion, pGuia.numeroFactura, pGuia.codigoGuiaPk, 1, 1, 1), BdCromo.ObtenerConexion());
			retorno = comando.ExecuteNonQuery();
			return comando.LastInsertedId;						
        }

		public string sqlFormato(string codigoGuia)
		{
			string sql = "SELECT " +
			"tte_guia.codigo_guia_pk, " +
			"tte_guia.numero, " +
			"tte_guia.documento_cliente, " +
			"tte_guia.fecha_ingreso, " +
			"ciudad_origen.nombre as ciudad_origen_nombre, " +
			"ciudad_destino.nombre as ciudad_destino_nombre, " +
			"tte_guia.remitente, " +
			"tte_cliente.nombre_corto as cliente_nombre, " +
			"tte_cliente.direccion as cliente_direccion, " +
			"tte_cliente.telefono as cliente_telefono, " +
			"tte_guia.nombre_destinatario, " +
			"tte_guia.direccion_destinatario, " +
			"tte_guia.telefono_destinatario, " +
			"tte_guia.comentario, " +
			"tte_guia.factura, " +
			"tte_guia.unidades, " +
			"tte_guia.vr_flete, " +
			"tte_guia.vr_manejo, " +
			"tte_guia.vr_abono, " +
			"tte_guia.vr_recaudo, " +
			"tte_guia.peso_real, " +
			"tte_guia_tipo.nombre as tipo_guia, " +
			"tte_guia.vr_cobro_entrega, " +
            "tte_guia.numero_factura, " +
            "tte_guia_tipo.mensaje_formato as mensaje_formato " +
            "FROM " +
			"tte_guia " +
			"LEFT JOIN tte_ciudad as ciudad_origen ON tte_guia.codigo_ciudad_origen_fk = ciudad_origen.codigo_ciudad_pk " +
			"LEFT JOIN tte_ciudad as ciudad_destino ON tte_guia.codigo_ciudad_destino_fk = ciudad_destino.codigo_ciudad_pk " +
			"LEFT JOIN tte_cliente ON tte_guia.codigo_cliente_fk = tte_cliente.codigo_cliente_pk " +
			"LEFT JOIN tte_guia_tipo ON tte_guia.codigo_guia_tipo_fk = tte_guia_tipo.codigo_guia_tipo_pk " +
			"WHERE codigo_guia_pk = " + codigoGuia;
			return sql;
		}
    }
}
