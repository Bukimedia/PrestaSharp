using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class products : PrestaShopEntity
    {
        public long id { get; set; }
        public int quantity { get; set; }
    }
}
