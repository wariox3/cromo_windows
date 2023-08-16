using cromo.WsRndc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace cromo
{
    public partial class FrmEnviarRndc : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();

        public FrmEnviarRndc()
        {
            InitializeComponent();
        }

        private void FrmEnviarRndc_Load(object sender, EventArgs e)
        {
            DgDespachos.AutoGenerateColumns = false;
            LlenarDatosApi();
        }

        public void LlenarDatosApi()
        {
            
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcpendiente", null);
            List<ApiDespacho> apiDespachoLista = ser.Deserialize<List<ApiDespacho>>(jsonRespuesta);
            DgDespachos.DataSource = apiDespachoLista;

        }

        private void DgDespachos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            string codigo = DgDespachos.Rows[DgDespachos.CurrentRow.Index].Cells[0].Value.ToString();                
            bool validacion = true;
            RespuestaRndc retorno = new RespuestaRndc();
            BPMServicesClient client = new BPMServicesClient();
            //Buscamos los terceros de ese despacho para transmitirlos
            string parametrosJson = "{\"codigoDespacho\":\"" + codigo + "\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/despacho/rndc", parametrosJson);
            ApiElementosRndc apiElementosRndc = ser.Deserialize<ApiElementosRndc>(jsonRespuesta);
            List<ApiTerceroRndc> apiTerceroLista = ser.Deserialize<List<ApiTerceroRndc>>(jsonRespuesta);
            foreach (ApiTerceroRndc apiTercero in apiElementosRndc.terceros)
            {
                string xmlTercero = "";
                if (apiTercero.conductor == "0")
                {
                    xmlTercero = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                            <root>
                                <acceso>
                                    <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                    <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                                </acceso>
                                <solicitud>
                                    <tipo>1</tipo>
                                    <procesoid>11</procesoid>
                                </solicitud>
                                <variables>
                                    <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                    <CODTIPOIDTERCERO>" + apiTercero.identificacionTipo + @"</CODTIPOIDTERCERO>
                                    <NUMIDTERCERO>" + apiTercero.identificacion + @"</NUMIDTERCERO>
                                    <NOMIDTERCERO>" + apiTercero.nombre1 + @"</NOMIDTERCERO>
                                    <PRIMERAPELLIDOIDTERCERO>" + apiTercero.apellido1 + @"</PRIMERAPELLIDOIDTERCERO>    
                                    <SEGUNDOAPELLIDOIDTERCERO> " + apiTercero.apellido2 + @"</SEGUNDOAPELLIDOIDTERCERO>
                                    <CODSEDETERCERO>" + apiTercero.codigoSede + @"</CODSEDETERCERO>
                                    <NOMSEDETERCERO>" + apiTercero.nombreSede + @"</NOMSEDETERCERO>
                                    <NUMTELEFONOCONTACTO>" + apiTercero.telefono + @"</NUMTELEFONOCONTACTO>
                                    <NOMENCLATURADIRECCION>" + apiTercero.direccion + @"</NOMENCLATURADIRECCION>
                                    <CODMUNICIPIORNDC>" + apiTercero.codigoCiudad + @"</CODMUNICIPIORNDC>
                                 </variables>
                              </root>";
                }

                if (apiTercero.conductor == "1")
                {
                    xmlTercero = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                            <root>
                                <acceso>
                                    <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                    <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                                </acceso>
                                <solicitud>
                                    <tipo>1</tipo>
                                    <procesoid>11</procesoid>
                                </solicitud>
                                <variables>
                                    <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                    <CODTIPOIDTERCERO>" + apiTercero.identificacionTipo + @"</CODTIPOIDTERCERO>
                                    <NUMIDTERCERO>" + apiTercero.identificacion + @"</NUMIDTERCERO>
                                    <NOMIDTERCERO>" + apiTercero.nombre1 + @"</NOMIDTERCERO>
                                    <PRIMERAPELLIDOIDTERCERO>" + apiTercero.apellido1 + @"</PRIMERAPELLIDOIDTERCERO>    
                                    <SEGUNDOAPELLIDOIDTERCERO> " + apiTercero.apellido2 + @"</SEGUNDOAPELLIDOIDTERCERO>
                                    <CODSEDETERCERO>" + apiTercero.codigoSede + @"</CODSEDETERCERO>
                                    <NOMSEDETERCERO>" + apiTercero.nombreSede + @"</NOMSEDETERCERO>
                                    <NUMTELEFONOCONTACTO>" + apiTercero.telefono + @"</NUMTELEFONOCONTACTO>
                                    <NOMENCLATURADIRECCION>" + apiTercero.direccion + @"</NOMENCLATURADIRECCION>
                                    <CODMUNICIPIORNDC>" + apiTercero.codigoCiudad + @"</CODMUNICIPIORNDC>
                                    <CODCATEGORIALICENCIACONDUCCION>" + apiTercero.categoriaLicencia + @"</CODCATEGORIALICENCIACONDUCCION>
                                    <NUMLICENCIACONDUCCION>" + apiTercero.numeroLicencia + @"</NUMLICENCIACONDUCCION>
                                    <FECHAVENCIMIENTOLICENCIA>" + apiTercero.fechaVenceLicencia + @"</FECHAVENCIMIENTOLICENCIA>
                                 </variables>
                              </root>";
                }
             
                AtenderMensajeRNDCRequest solicitudTercero = new AtenderMensajeRNDCRequest(xmlTercero);               
                var respuestaTercero = client.AtenderMensajeRNDC(solicitudTercero);
                var textXmlTercero = respuestaTercero.@return;
                XmlSerializer serializerTercero = new XmlSerializer(typeof(RespuestaRndc));
                using (TextReader reader = new StringReader(textXmlTercero))
                {
                    //de esta manera se deserializa
                    retorno = (RespuestaRndc)serializerTercero.Deserialize(reader);
                    if(retorno.ErrorMSG != null) {
                        string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                        if(mensajeError != "DUPLICADO" && mensajeError != "Access vi") {
                            MessageBox.Show(this, "Tercero " + apiTercero.identificacion + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            validacion = false;
                        }
                    }
                }                       
            }

            
            if(validacion == true) {
                string xmlVehiculo = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                        <root>
                            <acceso>
                                <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                            </acceso>
                            <solicitud>
                                <tipo>1</tipo>
                                <procesoid>12</procesoid>
                            </solicitud>
                            <variables>
                                <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                <NUMPLACA>" + apiElementosRndc.vehiculo.codigoVehiculoPk + @"</NUMPLACA>
                                <CODCONFIGURACIONUNIDADCARGA>" + apiElementosRndc.vehiculo.configuracion + @"</CODCONFIGURACIONUNIDADCARGA>
                                <NUMEJES>" + apiElementosRndc.vehiculo.numeroEjes + @"</NUMEJES>
                                <CODMARCAVEHICULOCARGA>" + apiElementosRndc.vehiculo.codigoMarca + @"</CODMARCAVEHICULOCARGA>
                                <CODLINEAVEHICULOCARGA>" + apiElementosRndc.vehiculo.codigoLinea + @"</CODLINEAVEHICULOCARGA>
                                <ANOFABRICACIONVEHICULOCARGA>" + apiElementosRndc.vehiculo.modelo + @"</ANOFABRICACIONVEHICULOCARGA>
                                <CODTIPOCOMBUSTIBLE>" + apiElementosRndc.vehiculo.tipoCombustible + @"</CODTIPOCOMBUSTIBLE>
                                <PESOVEHICULOVACIO>" + apiElementosRndc.vehiculo.pesoVacio + @"</PESOVEHICULOVACIO>
                                <CODCOLORVEHICULOCARGA>" + apiElementosRndc.vehiculo.codigoColor + @"</CODCOLORVEHICULOCARGA>
                                <CODTIPOCARROCERIA>" + apiElementosRndc.vehiculo.tipoCarroceria + @"</CODTIPOCARROCERIA>
                                <CODTIPOIDPROPIETARIO>" + apiElementosRndc.vehiculo.tipoIdentificacionPropietario + @"</CODTIPOIDPROPIETARIO>
                                <NUMIDPROPIETARIO>" + apiElementosRndc.vehiculo.numeroIdentificacionPropietario + @"</NUMIDPROPIETARIO>
                                <CODTIPOIDTENEDOR>" + apiElementosRndc.vehiculo.tipoIdentificacionPoseedor + @"</CODTIPOIDTENEDOR>
                                <NUMIDTENEDOR>" + apiElementosRndc.vehiculo.numeroIdentificacionPoseedor + @"</NUMIDTENEDOR>
                                <NUMSEGUROSOAT>" + apiElementosRndc.vehiculo.numeroPoliza + @"</NUMSEGUROSOAT>
                                <FECHAVENCIMIENTOSOAT>" + apiElementosRndc.vehiculo.fechaVencePoliza + @"</FECHAVENCIMIENTOSOAT>
                                <NUMNITASEGURADORASOAT>" + apiElementosRndc.vehiculo.numeroIdentificacionAseguradora + @"</NUMNITASEGURADORASOAT>
                                <CAPACIDADUNIDADCARGA>" + apiElementosRndc.vehiculo.capacidad + @"</CAPACIDADUNIDADCARGA>
                                <UNIDADMEDIDACAPACIDAD>1</UNIDADMEDIDACAPACIDAD>
                            </variables>
                        </root>";

                AtenderMensajeRNDCRequest solicitudVehiculo = new AtenderMensajeRNDCRequest(xmlVehiculo);
                var respuestaVehiculo = client.AtenderMensajeRNDC(solicitudVehiculo);
                var textXmlVehiculo = respuestaVehiculo.@return;
                XmlSerializer serializerVehiculo = new XmlSerializer(typeof(RespuestaRndc));
                using (TextReader reader = new StringReader(textXmlVehiculo))
                {
                    //de esta manera se deserializa
                    retorno = (RespuestaRndc)serializerVehiculo.Deserialize(reader);
                    if (retorno.ErrorMSG != null)
                    {
                        string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                        if (mensajeError != "DUPLICADO")
                        {
                            MessageBox.Show(this, "Vehiculo " + apiElementosRndc.vehiculo.codigoVehiculoPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            validacion = false;
                        }
                    }
                }


                if (validacion == true) {
                    if(apiElementosRndc.remolque != null)
                    {
                        string xmlRemolque = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                        <root>
                            <acceso>
                                <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                            </acceso>
                            <solicitud>
                                <tipo>1</tipo>
                                <procesoid>12</procesoid>
                            </solicitud>
                            <variables>
                                <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                <NUMPLACA>" + apiElementosRndc.remolque.codigoVehiculoPk + @"</NUMPLACA>
                                <CODCONFIGURACIONUNIDADCARGA>" + apiElementosRndc.remolque.configuracion + @"</CODCONFIGURACIONUNIDADCARGA>                                
                                <CODMARCAVEHICULOCARGA>" + apiElementosRndc.remolque.codigoMarca + @"</CODMARCAVEHICULOCARGA>                                
                                <ANOFABRICACIONVEHICULOCARGA>" + apiElementosRndc.remolque.modelo + @"</ANOFABRICACIONVEHICULOCARGA>                                
                                <PESOVEHICULOVACIO>" + apiElementosRndc.remolque.pesoVacio + @"</PESOVEHICULOVACIO>
                                <CAPACIDADUNIDADCARGA>" + apiElementosRndc.remolque.capacidad + @"</CAPACIDADUNIDADCARGA>
                                <CODCOLORVEHICULOCARGA>" + apiElementosRndc.remolque.codigoColor + @"</CODCOLORVEHICULOCARGA>
                                <CODTIPOCARROCERIA>" + apiElementosRndc.remolque.tipoCarroceria + @"</CODTIPOCARROCERIA>
                                <CODTIPOIDPROPIETARIO>" + apiElementosRndc.remolque.tipoIdentificacionPropietario + @"</CODTIPOIDPROPIETARIO>
                                <NUMIDPROPIETARIO>" + apiElementosRndc.remolque.numeroIdentificacionPropietario + @"</NUMIDPROPIETARIO>
                                <CODTIPOIDTENEDOR>" + apiElementosRndc.remolque.tipoIdentificacionPoseedor + @"</CODTIPOIDTENEDOR>
                                <NUMIDTENEDOR>" + apiElementosRndc.remolque.numeroIdentificacionPoseedor + @"</NUMIDTENEDOR>                                                                                              
                            </variables>
                        </root>";

                        AtenderMensajeRNDCRequest solicitudRemolque = new AtenderMensajeRNDCRequest(xmlRemolque);
                        var respuestaRemolque = client.AtenderMensajeRNDC(solicitudRemolque);
                        var textXmlRemolque = respuestaRemolque.@return;
                        XmlSerializer serializerRemolque = new XmlSerializer(typeof(RespuestaRndc));
                        using (TextReader reader = new StringReader(textXmlRemolque))
                        {
                            //de esta manera se deserializa
                            retorno = (RespuestaRndc)serializerRemolque.Deserialize(reader);
                            if (retorno.ErrorMSG != null)
                            {
                                string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                                if (mensajeError != "DUPLICADO")
                                {
                                    MessageBox.Show(this, "Remolque " + apiElementosRndc.remolque.codigoVehiculoPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    validacion = false;
                                }
                            }
                        }
                    }
                }

                if (validacion == true) {
                    if(apiElementosRndc.configuracion.remesasRndc == false)
                    {
                        //Transmitir guia
                        string xmlGuia = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                        <root>
                            <acceso>
                                <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                            </acceso>
                            <solicitud>
                                <tipo>1</tipo>
                                <procesoid>3</procesoid>
                            </solicitud>
                            <variables>
                                <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                <CONSECUTIVOREMESA>" + apiElementosRndc.despacho.numero + @"</CONSECUTIVOREMESA>
                                <CODOPERACIONTRANSPORTE>P</CODOPERACIONTRANSPORTE>
                                <CODTIPOEMPAQUE>0</CODTIPOEMPAQUE>
                                <CODNATURALEZACARGA>1</CODNATURALEZACARGA>                                                  
                                <DESCRIPCIONCORTAPRODUCTO>PAQUETES VARIOS</DESCRIPCIONCORTAPRODUCTO>
                                <MERCANCIAREMESA>009880</MERCANCIAREMESA>
                                <CANTIDADCARGADA>" + apiElementosRndc.despacho.pesoReal + @"</CANTIDADCARGADA>
                                <UNIDADMEDIDACAPACIDAD>1</UNIDADMEDIDACAPACIDAD>
                                <CODTIPOIDREMITENTE>N</CODTIPOIDREMITENTE>
                                <NUMIDREMITENTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMIDREMITENTE>
                                <CODSEDEREMITENTE>1</CODSEDEREMITENTE>
                                <CODTIPOIDDESTINATARIO>C</CODTIPOIDDESTINATARIO>
                                <NUMIDDESTINATARIO>333333333</NUMIDDESTINATARIO>
                                <CODSEDEDESTINATARIO>" + apiElementosRndc.despacho.codigoCiudadDestinoFk + @"</CODSEDEDESTINATARIO>
                                <CODTIPOIDPROPIETARIO>N</CODTIPOIDPROPIETARIO>
                                <NUMIDPROPIETARIO>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMIDPROPIETARIO>
                                <CODSEDEPROPIETARIO>1</CODSEDEPROPIETARIO>
                                <DUENOPOLIZA>E</DUENOPOLIZA>
                                <NUMPOLIZATRANSPORTE>" + apiElementosRndc.configuracion.numeroPoliza + @"</NUMPOLIZATRANSPORTE>
                                <FECHAVENCIMIENTOPOLIZACARGA>" + apiElementosRndc.configuracion.fechaVencePoliza + @"</FECHAVENCIMIENTOPOLIZACARGA>
                                <COMPANIASEGURO>" + apiElementosRndc.configuracion.numeroIdentificacionAseguradora + @"</COMPANIASEGURO>
                                <HORASPACTOCARGA>24</HORASPACTOCARGA>
                                <MINUTOSPACTOCARGA>00</MINUTOSPACTOCARGA>
                                <FECHACITAPACTADACARGUE>" + apiElementosRndc.despacho.fechaSalida + @"</FECHACITAPACTADACARGUE>
                                <HORACITAPACTADACARGUE>22:00</HORACITAPACTADACARGUE>
                                <HORASPACTODESCARGUE>72</HORASPACTODESCARGUE>
                                <MINUTOSPACTODESCARGUE>00</MINUTOSPACTODESCARGUE>
                                <FECHACITAPACTADADESCARGUE>" + apiElementosRndc.despacho.fechaSalida + @"</FECHACITAPACTADADESCARGUE>
                                <HORACITAPACTADADESCARGUEREMESA>08:00</HORACITAPACTADADESCARGUEREMESA>
                            </variables>
                        </root>";

                        AtenderMensajeRNDCRequest solicitudGuia = new AtenderMensajeRNDCRequest(xmlGuia);
                        var respuestaGuia = client.AtenderMensajeRNDC(solicitudGuia);
                        var textXmlGuia = respuestaGuia.@return;
                        XmlSerializer serializerGuia = new XmlSerializer(typeof(RespuestaRndc));
                        using (TextReader reader = new StringReader(textXmlGuia))
                        {
                            //de esta manera se deserializa
                            retorno = (RespuestaRndc)serializerGuia.Deserialize(reader);
                            if (retorno.ErrorMSG != null)
                            {
                                string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                                if (mensajeError != "DUPLICADO")
                                {
                                    MessageBox.Show(this, "Guia " + apiElementosRndc.despacho.codigoDespachoPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    validacion = false;
                                }
                            }
                        }
                    }
                    

                    if(validacion == true) {
                        //Transmitir manifiesto
                        string remesas = "<REMESASMAN procesoid='43'><REMESA><CONSECUTIVOREMESA>" + apiElementosRndc.despacho.numero + @"</CONSECUTIVOREMESA></REMESA></REMESASMAN>";
                        if (apiElementosRndc.configuracion.remesasRndc == true)
                        {
                            remesas = "<REMESASMAN procesoid='43'>";
                            List<ApiGuiaRndc> apiGuiaLista = ser.Deserialize<List<ApiGuiaRndc>>(jsonRespuesta);
                            foreach (ApiGuiaRndc apiGuia in apiElementosRndc.guias)
                            {
                                remesas = remesas + "<REMESA><CONSECUTIVOREMESA>" + apiGuia.codigoGuiaPk + @"</CONSECUTIVOREMESA></REMESA>";                            
                            }
                            remesas = remesas + "</REMESASMAN>";
                        }
                        string xmlManifiesto = @"<?xml version='1.0' encoding='ISO-8859-1' ?>
                            <root>
                                <acceso>
                                        <username>" + apiElementosRndc.configuracion.usuarioRndc + @"</username>
                                        <password>" + apiElementosRndc.configuracion.claveRndc + @"</password>
                                </acceso>
                                <solicitud>
                                    <tipo>1</tipo>
                                    <procesoid>4</procesoid>
                                </solicitud>
                                <variables>
                                    <NUMNITEMPRESATRANSPORTE>" + apiElementosRndc.configuracion.empresaRndc + @"</NUMNITEMPRESATRANSPORTE>
                                    <NUMMANIFIESTOCARGA>" + apiElementosRndc.despacho.numero + @"</NUMMANIFIESTOCARGA>
                                    <CODOPERACIONTRANSPORTE>P</CODOPERACIONTRANSPORTE>
                                    <FECHAEXPEDICIONMANIFIESTO>" + apiElementosRndc.despacho.fechaSalida + @"</FECHAEXPEDICIONMANIFIESTO>
                                    <CODMUNICIPIOORIGENMANIFIESTO>" + apiElementosRndc.despacho.codigoCiudadOrigen + @"</CODMUNICIPIOORIGENMANIFIESTO>
                                    <CODMUNICIPIODESTINOMANIFIESTO>" + apiElementosRndc.despacho.codigoCiudadDestino + @"</CODMUNICIPIODESTINOMANIFIESTO>
                                    <CODIDTITULARMANIFIESTO>" + apiElementosRndc.despacho.poseedorTipoIdentificacion + @"</CODIDTITULARMANIFIESTO>
                                    <NUMIDTITULARMANIFIESTO>" + apiElementosRndc.despacho.poseedorNumeroIdentificacion + @"</NUMIDTITULARMANIFIESTO>
                                    <NUMPLACA>" + apiElementosRndc.despacho.codigoVehiculoFk + @"</NUMPLACA>
                                    <NUMPLACAREMOLQUE>" + apiElementosRndc.despacho.codigoVehiculoRemolqueFk + @"</NUMPLACAREMOLQUE>
                                    <CODIDCONDUCTOR>" + apiElementosRndc.despacho.conductorTipoIdentificacion + @"</CODIDCONDUCTOR>
                                    <NUMIDCONDUCTOR>" + apiElementosRndc.despacho.conductorNumeroIdentificacion + @"</NUMIDCONDUCTOR>
                                    <VALORFLETEPACTADOVIAJE>" + apiElementosRndc.despacho.vrFletePago + @"</VALORFLETEPACTADOVIAJE>
                                    <RETENCIONFUENTEMANIFIESTO>" + apiElementosRndc.despacho.vrRetencionFuente + @"</RETENCIONFUENTEMANIFIESTO>
                                    <RETENCIONICAMANIFIESTOCARGA>" + apiElementosRndc.despacho.porcentajeIndustriaComercio + @"</RETENCIONICAMANIFIESTOCARGA>
                                    <VALORANTICIPOMANIFIESTO>" + apiElementosRndc.despacho.vrAnticipo + @"</VALORANTICIPOMANIFIESTO>
                                    <FECHAPAGOSALDOMANIFIESTO>" + apiElementosRndc.despacho.fechaSalida + @"</FECHAPAGOSALDOMANIFIESTO>                                                
                                    <CODRESPONSABLEPAGOCARGUE>E</CODRESPONSABLEPAGOCARGUE>
                                    <CODRESPONSABLEPAGODESCARGUE>E</CODRESPONSABLEPAGODESCARGUE>
                                    <OBSERVACIONES>NADA</OBSERVACIONES>
                                    <CODMUNICIPIOPAGOSALDO>05001000</CODMUNICIPIOPAGOSALDO>
                                    " + remesas + @"
                                </variables>
                            </root>";                        

                        AtenderMensajeRNDCRequest solicitudManifiesto = new AtenderMensajeRNDCRequest(xmlManifiesto);
                        var respuestaManifiesto = client.AtenderMensajeRNDC(solicitudManifiesto);
                        var textXmlManifiesto = respuestaManifiesto.@return;
                        XmlSerializer serializerManifiesto = new XmlSerializer(typeof(RespuestaRndc));
                        using (TextReader reader = new StringReader(textXmlManifiesto))
                        {
                            //de esta manera se deserializa
                            retorno = (RespuestaRndc)serializerManifiesto.Deserialize(reader);
                            if (retorno.ErrorMSG != null)
                            {
                                string mensajeError = retorno.ErrorMSG.Substring(0, 9);
                                if (mensajeError != "DUPLICADO")
                                {
                                    MessageBox.Show(this, "Manifiesto " + apiElementosRndc.despacho.codigoDespachoPk + " " + retorno.ErrorMSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                                    
                                } else
                                {
                                    ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcasignar", "{\"codigoDespacho\":\"" + apiElementosRndc.despacho.codigoDespachoPk + "\",\"id\":\"" + apiElementosRndc.despacho.codigoDespachoPk + "\"}");
                                    MessageBox.Show(this, "Se transmitio correctamente el manifiesto", "Envio correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LlenarDatosApi();
                                }
                            } else {                                
                                ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcasignar", "{\"codigoDespacho\":\"" + apiElementosRndc.despacho.codigoDespachoPk + "\",\"id\":\"" + retorno.ingresoid + "\"}");
                                MessageBox.Show(this, "Se transmitio correctamente el manifiesto", "Envio correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LlenarDatosApi();
                            }
                        }
                    }
                }
            }
                    

        }

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            string codigo = DgDespachos.Rows[DgDespachos.CurrentRow.Index].Cells[0].Value.ToString();                        
            RespuestaRndc retorno = new RespuestaRndc();
            BPMServicesClient client = new BPMServicesClient();
            ApiControlador.ApiPost("/transporte/api/windows/despacho/rndcdescartar", "{\"codigoDespacho\":\"" + codigo + "\"}");
            LlenarDatosApi();
        }
    }
}
