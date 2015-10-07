using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class tax_rule : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_tax_rules_group { get; set; }
        public long? id_state { get; set; }
        public long? id_country { get; set; }
        public long? zipcode_from { get; set; }
        public long? zipcode_to { get; set; }
        public long? id_tax { get; set; }
        public long? behavior { get; set; }
        public string description { get; set; }

        public tax_rule()
        {
        }
    }
}
