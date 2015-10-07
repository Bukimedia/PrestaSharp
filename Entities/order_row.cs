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
    public class order_row : PrestaShopEntity
    {
        public long? id { get; set; }
		public long? product_id { get; set; }
        public long? product_attribute_id { get; set; }
        public int product_quantity { get; set; }
        public string product_name { get; set; }
        public string product_reference { get; set; }
        public string product_ean13 { get; set; }
        public string product_upc { get; set; }
        public decimal product_price { get; set; }
        public decimal unit_price_tax_incl { get; set; }
        public decimal unit_price_tax_excl { get; set; }

        public order_row()
        {
        }
    }
}
