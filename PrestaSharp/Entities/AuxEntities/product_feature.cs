using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class product_feature : PrestaShopEntity
    {
        public long id { get; set; }
        public long id_feature_value { get; set; }
    }
}
