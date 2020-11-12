using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class productStatus : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_employee { get; set; }
        public long? id_product_state { get; set; }
        public string added { get; set; }
        public long? id_order_detail { get; set; }
        public long? id_order_ref { get; set; }
        public long? id_history { get; set; }

        public productStatus()
        {
        }
    }
}