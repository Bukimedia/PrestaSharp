using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    public class name
    {
        [XmlAttribute(AttributeName = "required")]
        public bool required = true;
        [XmlText]
        public string value { get; set; }
    }
}
