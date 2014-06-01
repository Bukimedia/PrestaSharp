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
    public class cart_row : PrestaShopEntity
    {
        public long? id_product { get; set; }
		public long? id_product_attribute { get; set; }
        public long? id_address_delivery { get; set; }
        public int quantity { get; set; }

        public cart_row()
        {
        }
    }
}
