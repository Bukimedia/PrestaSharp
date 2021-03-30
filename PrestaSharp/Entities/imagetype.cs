using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class imagetype : PrestaShopEntity
    {
        public long id { get; set; }
        public string name { get; set; }

        public imagetype()
        {
        }
    }
}