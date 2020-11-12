using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class product_feature : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public int position { get; set; }
        public List<PrestaSharp.Entities.AuxEntities.language> name { get; set; }

        public product_feature()
        {
            this.name = new List<AuxEntities.language>();
        }
    }
}
