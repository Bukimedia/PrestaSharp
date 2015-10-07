using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class carrier : PrestaShopEntity
    {
        public long? id { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int deleted { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int is_module { get; set; }
        public long? id_tax_rules_group { get; set; }
        public long id_reference { get; set; }
        public string name { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int is_free { get; set; }
        /// <summary>
        /// Must be an url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int shipping_handling { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int shipping_external { get; set; }
        public int range_behavior { get; set; }
        public int shipping_method { get; set; }
        public int max_width { get; set; }
        public int max_height { get; set; }
        public int max_depth { get; set; }
        public decimal max_weight { get; set; }
        public int grade { get; set; }
        public string external_module_name { get; set; }
        public int need_range { get; set; }
        public int position { get; set; }
        public List<Entities.AuxEntities.language> delay { get; set; }

        public carrier()
        {
            this.delay = new List<AuxEntities.language>();
        }
    }
}
