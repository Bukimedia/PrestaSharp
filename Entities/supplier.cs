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
    public class supplier : PrestaShopEntity
    {
        public long? id { get; set; }
        public string name { get; set; }
        public string link_rewrite { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        public List<Entities.AuxEntities.language> description { get; set; }
        public List<Entities.AuxEntities.language> meta_title { get; set; }
        public List<Entities.AuxEntities.language> meta_description { get; set; }
        public List<Entities.AuxEntities.language> meta_keywords { get; set; }

        public supplier()
        {
            this.description = new List<AuxEntities.language>();
            this.meta_title = new List<AuxEntities.language>();
            this.meta_description = new List<AuxEntities.language>();
            this.meta_keywords = new List<AuxEntities.language>();
        }
    }
}
