using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using RestSharp.Serializers;
using System.Runtime.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [Serializable]
    [DataContract]
    public class language: PrestashopEntity
    {
        public language()
        {
        }

        public language(long id, string Value)
        {
            this.id = id;
            this.Value = Value;
        }


        [XmlAttribute]
        [DataMember]
        public long id { get; set; }

        // Value is reserved word from RestSharp for loading the CDATA content from the XML file.
        [XmlTextAttribute]
        [DataMember]
        public string Value { get; set; }

    }
}
