using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.FilterEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/FilterEntities")]
    public class GenericFilterEntity : PrestaShopEntity
    {
        public long id { get; set; }
    }
}
