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
    public class order_state : PrestaShopEntity
    {
        public long? id { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int unremovable { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int delivery { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int hidden { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int send_email { get; set; }
        public string module_name { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int invoice { get; set; }
        public string color { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int logable { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int shipped { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int paid { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int deleted { get; set; }
        public List<Entities.AuxEntities.language> name { get; set; }
        public List<Entities.AuxEntities.language> template { get; set; }

        public order_state()
        {
            this.name = new List<AuxEntities.language>();
            this.template = new List<AuxEntities.language>();
        }
    }
}
