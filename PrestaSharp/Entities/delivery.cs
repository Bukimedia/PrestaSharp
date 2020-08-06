using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class delivery : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long id_carrier { get; set; }
        public long id_range_price { get; set; }
        public long id_range_weight { get; set; }
        public long? id_zone { get; set; }
        public long? id_shop { get; set; }
        public long? id_shop_group { get; set; }
        public decimal price { get; set; }

        public delivery()
        {
        }
    }
}
