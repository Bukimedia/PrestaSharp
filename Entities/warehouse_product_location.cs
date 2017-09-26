using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Entities
{
    public class warehouse_product_location : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_product { get; set; }
        public long? id_product_attribute { get; set; }
        public long id_warehouse { get; set; }
        public string location { get; set; }
    }
}
