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
    public class configuration : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_shop_group { get; set; }
        public long? id_shop { get; set; }
        public string name { get; set; }
        /// <summary>
        /// Must be clean html. MaxSize = 65000.
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }

        public configuration()
        {
        }       
    }
}
