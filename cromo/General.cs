﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cromo
{
	class General
	{
		private static string v_CodigoCliente = "";
		public static string codigoCliente
		{
			get { return v_CodigoCliente; }
			set { v_CodigoCliente = value; }
		}

		private static string v_CodigoCiudad = "";
		public static string codigoCiudad
		{
			get { return v_CodigoCiudad; }
			set { v_CodigoCiudad = value; }
		}
	}
}