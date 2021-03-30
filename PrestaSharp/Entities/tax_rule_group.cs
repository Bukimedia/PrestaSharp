using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class tax_rule_group : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public string name { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }

        public tax_rule_group()
        {
        }
    }
}
