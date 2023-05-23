using System;
using System.Collections.Generic;
using System.Text;
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
        public long? quantity { get; set; }
        public long? quantity_refunded { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary
        public int in_cart { get; set; }
        public AuxEntities.AssociationsCustomization associations { get; set; }

        public customization()
        {
            this.associations = new AuxEntities.AssociationsCustomization();
        }
    }
}
