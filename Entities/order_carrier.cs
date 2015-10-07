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
    public class order_carrier : PrestaShopEntity
    {
        public long? id { get; set; }
		public long? id_order { get; set; }
        public long? id_carrier { get; set; }
        public long? id_order_invoice { get; set; }
        public decimal weight { get; set; }
        public decimal shipping_cost_tax_excl { get; set; }
        public decimal shipping_cost_tax_incl { get; set; }
        public string tracking_number { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }

        public order_carrier()
        {
        }
    }
}
