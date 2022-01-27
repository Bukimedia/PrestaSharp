using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class ProductStep : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_product_setting { get; set; }
        public long id_shop { get; set; }
        public long? id_product { get; set; }
        public long? id_group { get; set; }
        public long step { get; set; }
        public long min { get; set; }
        public long max { get; set; }
        /// <summary>
        /// It´s a logical DateTime field. Format YYYY-MM-DD HH:MM:SS.
        /// It´s string because you can receive a string with no DateTime .Net format.
        /// </summary>
        public string added { get; set; }
    }
}
