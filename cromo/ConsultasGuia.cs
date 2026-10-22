using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace cromo
{
    // Consultas a Fluor que comparten la guía y la guía operador
    static class ConsultasGuia
    {
        // 404 = el cliente no tiene reglas especiales para esa ruta: se usan las de la condición
        public static Dictionary<string, object> LiquidarCondicionRuta(IWin32Window ventana, string ruta, Dictionary<string, object> parametros, string tipo)
        {
            try
            {
                return new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(
                    Fluor.Post(ruta, new JavaScriptSerializer().Serialize(parametros)));
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ventana, "No se pudo consultar la condicion de " + tipo + " del cliente: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Precios por ciudad destino y, si se indica zona, también los de la zona del destino
        public static List<ApiPrecioDetalle> ConsultarPrecios(IWin32Window ventana, int precio, string origen, string destino, string zona, string producto)
        {
            var precios = new List<ApiPrecioDetalle>();
            try
            {
                precios.AddRange(ListaPrecios(precio, origen, destino, null, producto));
                if (!string.IsNullOrWhiteSpace(zona))
                    precios.AddRange(ListaPrecios(precio, origen, null, zona, producto));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ventana, "No se pudieron consultar los precios: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return precios;
        }

        public static ApiPrecioDetalle PrecioProducto(IWin32Window ventana, int precio, string origen, string destino, string zona, string producto)
        {
            if (string.IsNullOrWhiteSpace(producto))
                return null;
            return ConsultarPrecios(ventana, precio, origen, destino, zona, producto).FirstOrDefault();
        }

        private static IEnumerable<ApiPrecioDetalle> ListaPrecios(int precio, string origen, string destino, string zona, string producto)
        {
            var filtros = new Dictionary<string, object>
            {
                { "size", 200 },
                { "codigo_precio_fk", precio },
                { "codigo_ciudad_origen_fk", origen },
                { "codigo_ciudad_destino_fk", destino },
                { "codigo_zona_fk", zona },
                { "codigo_producto_fk", producto }
            };
            return Fluor.GetLista("/tte/precio-detalle/lista", filtros).Select(p => new ApiPrecioDetalle
            {
                codigoPrecioDetallePk = Fluor.Texto(p, "codigo_precio_detalle_pk"),
                productoNombre = Fluor.Texto(p, "producto_nombre"),
                codigoCoberturaFk = Fluor.Texto(p, "codigo_cobertura_fk"),
                vrPeso = Fluor.Numero(p, "vr_peso"),
                vrUnidad = Fluor.Numero(p, "vr_unidad"),
                pesoTope = Fluor.Numero(p, "peso_tope"),
                vrPesoTope = Fluor.Numero(p, "vr_peso_tope"),
                vrPesoTopeAdicional = Fluor.Numero(p, "vr_peso_tope_adicional"),
                minimo = Fluor.Entero(p, "minimo"),
                omitirDescuento = Fluor.Booleano(p, "omitir_descuento")
            });
        }

        // Operación de cargo y ciudad origen de la operación de ingreso configurada; null si la operación no existe o falla la consulta
        public static Dictionary<string, object> DetalleOperacion(IWin32Window ventana, string operacionIngreso)
        {
            try
            {
                return Fluor.GetDetalle("/tte/operacion/detalle/" + Uri.EscapeDataString(operacionIngreso));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ventana, "No se pudo consultar la operacion de ingreso '" + operacionIngreso + "': " + Fluor.MensajeError(ex) +
                    "\n\nRevise la operacion en Archivo > Configuracion > Operacion.", "Operacion de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
