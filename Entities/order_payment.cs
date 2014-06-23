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
    public class order_payment : PrestaShopEntity
    {
        public long? id { get; set; }
		public string order_reference { get; set; }
        public long? id_currency { get; set; }
        public decimal amount { get; set; }
        public string payment_method { get; set; }
        public decimal conversion_rate { get; set; }
        public string transaction_id { get; set; }
        public string card_number { get; set; }
        public string card_brand { get; set; }
         /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string card_expiration { get; set; }
        public string card_holder { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }

        public order_payment()
        {
        }
    }
}
