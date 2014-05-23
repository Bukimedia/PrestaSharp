using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class product_option : PrestaShopEntity
    {
        public long? id { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int is_color_group { get; set; }
        public string group_type { get; set; }
        public int position { get; set; }
        public List<PrestaSharp.Entities.AuxEntities.language> name { get; set; }
        public List<PrestaSharp.Entities.AuxEntities.language> public_name { get; set; }
        public AuxEntities.AssociationsProductOption associations { get; set; }

        public product_option()
        {
            this.name = new List<AuxEntities.language>();
            this.public_name = new List<AuxEntities.language>();
            this.associations = new AuxEntities.AssociationsProductOption();
        }
    }
}
