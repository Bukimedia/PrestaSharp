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
    public class order_cart_rule : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_order { get; set; }
        public long? id_cart_rule { get; set; }
        public long? id_order_invoice { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
        public decimal value_tax_excl { get; set; }
        public int free_shipping { get; set; }

        public order_cart_rule()
        {
        }
    }
}