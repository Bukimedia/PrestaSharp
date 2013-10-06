using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    [Serializable]
    public class language : PrestashopEntity
    {
        public language()
        {
        }

        public language(int id, string Value)
        {
            this.id = id;
            this.Value = Value;
        }


        [XmlAttribute]
        public int id { get; set; }

        // Value is reserved word from RestSharp for loading the CDATA content from the XML file.
        [XmlTextAttribute]
        public string Value { get; set; }

    }
}
