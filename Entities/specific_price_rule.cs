using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
	[XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
	public class specific_price_rule : PrestaShopEntity
	{
		public long? id { get; set; }
		public long? id_shop { get; set; }
		public long? id_country { get; set; }
		public long? id_currency { get; set; }
		public long? id_group { get; set; }
        public string name { get; set; }
        public int from_quantity { get; set; }
		public decimal price { get; set; }
		public decimal reduction { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int reduction_tax { get; set; }
        /// <summary>
        /// Reduction type is either "amount" or "percentage"
        /// </summary>
        public string reduction_type { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
		public string from { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
		public string to { get; set; }

		public specific_price_rule()
		{
			from = "0000-00-00 00:00:00";
			to = "0000-00-00 00:00:00";
		}
	}
}
