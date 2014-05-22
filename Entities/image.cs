using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    [XmlType(Namespace = "PrestaSharp/Entities")]
    public class image : PrestaShopEntity
    {
        public long id { get; set; }
    }
}