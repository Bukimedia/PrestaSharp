using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bukimedia.PrestaSharp.Lib;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class group : PrestaShopEntity
    {
        public long? id { get; set; }
        public decimal reduction { get; set; }
        public int price_display_method{get;set;}
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int show_prices { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }       
        public List<Entities.AuxEntities.language> name { get; set; }

        public group()
        {
            this.name = new List<AuxEntities.language>();
        }
    }
}
