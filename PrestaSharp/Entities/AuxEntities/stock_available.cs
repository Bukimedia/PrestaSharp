using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class stock_available : PrestaShopEntity
    {
        public long id { get; set; }
        public long id_product_attribute { get; set; }
    }
}