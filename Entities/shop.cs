using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class shop : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_shop_group { get; set; }
        public long? id_category { get; set; }
        public long? id_theme { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int deleted { get; set; }
        public string name { get; set; }

        public shop()
        {
        }
    }
}
