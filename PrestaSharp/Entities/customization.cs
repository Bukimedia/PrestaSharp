using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class customization : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_address_delivery { get; set; }
        public long? id_cart { get; set; }
        public long? id_product { get; set; }
        public long? id_product_attribute { get; set; }
        public int quantity { get; set; }
        public int quantity_refunded { get; set; }
        public int quantity_return { get; set; }
        public int in_cart { get; set; }
        public AuxEntities.AssociationsCustomized associations { get; set; }

        public customization()
        {
            this.associations = new AuxEntities.AssociationsCustomized();
        }
    }
}