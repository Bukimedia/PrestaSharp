using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class product_supplier : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_product { get; set; }
        public long? id_product_attribute { get; set; }
        public long? id_supplier { get; set; }
        public long? id_currency { get; set; }
        public string product_supplier_reference { get; set; }
        public decimal? product_supplier_price_te { get; set; }
    }
}
