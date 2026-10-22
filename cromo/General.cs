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

        private static string v_NombreDestinatario = "";
        public static string NombreDestinatario
        {
            get { return v_NombreDestinatario; }
            set { v_NombreDestinatario = value; }
        }

        private static string v_CodigoCiudad = "";
		public static string CodigoCiudad
		{
			get { return v_CodigoCiudad; }
			set { v_CodigoCiudad = value; }
		}

		private static int v_CodigoGuia = 0;
		public static int CodigoGuia
		{
			get { return v_CodigoGuia; }
			set { v_CodigoGuia = value; }
		}

		private static string v_UsuarioActivo = "";
		public static string UsuarioActivo
		{
			get { return v_UsuarioActivo; }
			set { v_UsuarioActivo = value; }
		}

		private static string v_CodigoCondicion = "";
		public static string CodigoCondicion
		{
			get { return v_CodigoCondicion; }
			set { v_CodigoCondicion = value; }
		}

        private static bool v_RestringirGuiaNueva = false;
        public static bool RestringirGuiaNueva
        {
            get { return v_RestringirGuiaNueva; }
            set { v_RestringirGuiaNueva = value; }
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

   
        private static double v_Descuento = 0;
        public static double Descuento
        {
            get { return v_Descuento; }
            set { v_Descuento = value; }
        }

        private static double v_Manejo = 0;
        public static double Manejo
        {
            get { return v_Manejo; }
            set { v_Manejo = value; }
        }

        private static double v_ManejoMinimoDespacho = 0;
        public static double ManejoMinimoDespacho
        {
            get { return v_ManejoMinimoDespacho; }
            set { v_ManejoMinimoDespacho = value; }
        }

        private static double v_ManejoMinimoUnidad = 0;
        public static double ManejoMinimoUnidad
        {
            get { return v_ManejoMinimoUnidad; }
            set { v_ManejoMinimoUnidad = value; }
        }

        private static double v_DescuentoPesoMaximo = 0;
        public static double DescuentoPesoMaximo
        {
            get { return v_DescuentoPesoMaximo; }
            set { v_DescuentoPesoMaximo = value; }
        }


    }

}
