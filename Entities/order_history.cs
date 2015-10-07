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
    public class order_history : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_order_state { get; set; }
        public long? id_order { get; set; }
        public long? id_employee { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
    }
}