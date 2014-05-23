using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class product_feature_value : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_feature { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int custom { get; set; }
        public List<PrestaSharp.Entities.AuxEntities.language> value { get; set; }

        public product_feature_value()
        {
            this.value = new List<AuxEntities.language>();
        }
    }
}
