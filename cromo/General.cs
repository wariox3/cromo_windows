using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace cromo
{
	class General
	{
        private static string v_UrlServicio = "";
        public static string UrlServicio
        {
            get { return v_UrlServicio; }
            set { v_UrlServicio = value; }
        }

        private static string v_CodigoCliente = "";
		public static string CodigoCliente
		{
			get { return v_CodigoCliente; }
			set { v_CodigoCliente = value; }
		}

        private static string v_CodigoAsesor = "";
        public static string CodigoAsesor
        {
            get { return v_CodigoAsesor; }
            set { v_CodigoAsesor = value; }
        }

        private static string v_CodigoDestinatario = "";
		public static string CodigoDestinatario
		{
			get { return v_CodigoDestinatario; }
			set { v_CodigoDestinatario = value; }
		}

        private static string v_CodigoRemitente = "";
        public static string CodigoRemitente
        {
            get { return v_CodigoRemitente; }
            set { v_CodigoRemitente = value; }
        }

        private static string v_CodigoCiudad = "";
		public static string CodigoCiudad
		{
			get { return v_CodigoCiudad; }
			set { v_CodigoCiudad = value; }
		}

		private static string v_CodigoCiudadDestino = "";
		public static string CodigoCiudadDestino
		{
			get { return v_CodigoCiudadDestino; }
			set { v_CodigoCiudadDestino = value; }
		}

		private static int v_CodigoGuia = 0;
		public static int CodigoGuia
		{
			get { return v_CodigoGuia; }
			set { v_CodigoGuia = value; }
		}

		private static int v_NumeroGuia = 0;
		public static int NumeroGuia
		{
			get { return v_NumeroGuia; }
			set { v_NumeroGuia = value; }
		}

		private static int v_CodigoReporte = 0;
		public static int CodigoReporte
		{
			get { return v_CodigoReporte; }
			set { v_CodigoReporte = value; }
		}

		private static string v_Sql = "";
		public static string Sql
		{
			get { return v_Sql; }
			set { v_Sql = value; }
		}

		private static string v_UsuarioActivo = "";
		public static string UsuarioActivo
		{
			get { return v_UsuarioActivo; }
			set { v_UsuarioActivo = value; }
		}

		private static string v_DocumentoCliente = "";
		public static string DocumentoCliente
		{
			get { return v_DocumentoCliente; }
			set { v_DocumentoCliente = value; }
		}

		private static string v_CodigoCondicion = "";
		public static string CodigoCondicion
		{
			get { return v_CodigoCondicion; }
			set { v_CodigoCondicion = value; }
		}

		private static int v_CodigoPrecio = 0;
		public static int CodigoPrecio
		{
			get { return v_CodigoPrecio; }
			set { v_CodigoPrecio = value; }
		}

		private static double v_VrFlete = 0;
		public static double VrFlete
		{
			get { return v_VrFlete; }
			set { v_VrFlete = value; }
		}

		private static int v_Peso = 0;
		public static int Peso
		{
			get { return v_Peso; }
			set { v_Peso = value; }
		}

		private static int v_Volumen = 0;
		public static int Volumen
		{
			get { return v_Volumen; }
			set { v_Volumen = value; }
		}

		private static int v_PesoFacturar = 0;
		public static int PesoFacturar
		{
			get { return v_PesoFacturar; }
			set { v_PesoFacturar = value; }
		}

		private static int v_Unidades = 0;
		public static int Unidades
		{
			get { return v_Unidades; }
			set { v_Unidades = value; }
		}

		private static bool v_NumeroUnicoGuia = false;
		public static bool NumeroUnicoGuia
		{
			get { return v_NumeroUnicoGuia; }
			set { v_NumeroUnicoGuia = value; }
		}

        private static int v_CodigoPrecioGeneral = 0;
        public static int CodigoPrecioGeneral
        {
            get { return v_CodigoPrecioGeneral; }
            set { v_CodigoPrecioGeneral = value; }
        }

        private static int v_CodigoCondicionGeneral = 0;
        public static int CodigoCondicionGeneral
        {
            get { return v_CodigoCondicionGeneral; }
            set { v_CodigoCondicionGeneral = value; }
        }

        private static string v_CodigoFormatoGuia = "";
        public static string CodigoFormatoGuia
        {
            get { return v_CodigoFormatoGuia; }
            set { v_CodigoFormatoGuia = value; }
        }

        private static ImprimirFormato v_Formato;
        public static ImprimirFormato Formato
        {
            get { return v_Formato; }
            set { v_Formato = value; }
        }

        private static string v_CodigoCiudadOrigenParametro = "";
        public static string CodigoCiudadOrigenParametro
        {
            get { return v_CodigoCiudadOrigenParametro; }
            set { v_CodigoCiudadOrigenParametro = value; }
        }

        private static string v_CodigoOperacionIngreso = "";
        public static string CodigoOperacionIngreso
        {
            get { return v_CodigoOperacionIngreso; }
            set { v_CodigoOperacionIngreso = value; }
        }

        private static string v_CodigoOperacionCargo = "";
        public static string CodigoOperacionCargo
        {
            get { return v_CodigoOperacionCargo; }
            set { v_CodigoOperacionCargo = value; }
        }

    }

}
