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
    public class tax : PrestaShopEntity
    {
        public long? id { get; set; }
        public decimal rate { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        public int deleted { get; set; }
        
        public List<Entities.AuxEntities.language> name { get; set; }

        public tax()
        {
        	this.name = new List<AuxEntities.language>();
        }
    }
}
