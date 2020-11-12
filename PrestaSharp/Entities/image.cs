using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class image : PrestaShopEntity
    {
        public long id { get; set; }

        public image()
        {
        }
    }
}