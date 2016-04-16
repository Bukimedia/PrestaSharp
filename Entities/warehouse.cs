using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class warehouse : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_address { get; set; }
        public long? id_employee { get; set; }
        public long? id_currency { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int deleted { get; set; }
        public string reference { get; set; }
        public string name { get; set; }

        /// <summary>
        /// enum('WA', 'FIFO', 'LIFO')
        /// </summary>
        public string management_type { get; set; }

        public AuxEntities.AssociationsWarehouse associations { get; set; }

        public warehouse() { }
    }
}
