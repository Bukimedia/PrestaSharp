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
    public class customer_message : PrestaShopEntity
    {
        public long? id { get; set; }
		public long? id_employee { get; set; }
        public long? id_customer_thread { get; set; }
        public string ip_address { get; set; }
        public string message { get; set; }
        public string file_name { get; set; }
        public string user_agent { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        [XmlElement(ElementName = "private")]
        public int Private { get; set; }
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int read { get; set; }

        public customer_message()
        {
        }
    }
}
