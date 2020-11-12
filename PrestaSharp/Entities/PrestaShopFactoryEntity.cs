using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public interface IPrestaShopFactoryEntity
    {
        long? id { get; set; }
    }
}
