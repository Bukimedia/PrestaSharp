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
    public class manufacturer : PrestaShopEntity
    {
        public long? id { get; set; }
        public string name { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        public List<Entities.AuxEntities.language> description { get; set; }
        public List<Entities.AuxEntities.language> short_description { get; set; }
        public List<Entities.AuxEntities.language> meta_title { get; set; }
        public List<Entities.AuxEntities.language> meta_description { get; set; }
        public List<Entities.AuxEntities.language> meta_keywords { get; set; }
        public AuxEntities.AssociationsManufacturer associations { get; set; }

        public manufacturer()
        {
            this.description = new List<AuxEntities.language>();
            this.short_description = new List<AuxEntities.language>();
            this.meta_title = new List<AuxEntities.language>();
            this.meta_description = new List<AuxEntities.language>();
            this.meta_keywords = new List<AuxEntities.language>();
            this.associations = new AuxEntities.AssociationsManufacturer();
        }
    }
}
