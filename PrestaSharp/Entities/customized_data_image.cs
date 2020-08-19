using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class customized_data_image : PrestaShopEntity
    {
        public long? id { get; set; }
        public long id_customization_field { get; set; }
        public string value { get; set; }

        public customized_data_image()
        {

        }
    }
}