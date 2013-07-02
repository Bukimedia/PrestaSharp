using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    public class language
    {
        [XmlAttribute]
        public int id { get; set; }
        public string value { get; set; }
    }
}
