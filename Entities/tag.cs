using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    [XmlType(Namespace = "PrestaSharp/Entities")]
    public class tag : PrestashopEntity
    {
        public long? id { get; set; }
        public long? id_lang { get; set; }
        public string name { get; set; }
    }
}
