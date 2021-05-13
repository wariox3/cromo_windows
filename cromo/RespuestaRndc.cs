using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cromo
{
    [XmlRoot("root")]
    class RespuestaRndc
    {
        [XmlElement("ingresoid")]
        public string ingresoid { get; set; }

        [XmlElement("inseguridadqrgresoid")]
        public string inseguridadqrgresoid { get; set; }

        [XmlElement("observacionesqr")]
        public string observacionesqr { get; set; }

        [XmlElement("ErrorMSG")]
        public string ErrorMSG { get; set; }
        
    }
}
