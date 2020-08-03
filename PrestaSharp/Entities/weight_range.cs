using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class weight_range : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_carrier { get; set; }
        public float delimiter1 { get; set; }
        public float delimiter2 { get; set; }
        public weight_range() { }
    }
}
