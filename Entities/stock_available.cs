using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class stock_available : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_product { get; set; }
        public long? id_product_attribute { get; set; }
        public long? id_shop { get; set; }
        public long? id_shop_group { get; set; }
        public int quantity { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int depends_on_stock { get; set; }
        public int out_of_stock { get; set; }
        public stock_available()
        {
        }
    }
}
