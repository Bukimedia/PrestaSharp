using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
	[XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
	public class address : PrestaShopEntity
	{
		public long? id { get; set; }
        public long? id_customer { get; set; }
        public long? id_manufacturer { get; set; }
        public long? id_supplier { get; set; }
        public long? id_warehouse { get; set; }
        public long? id_country { get; set; }
        public long? id_state { get; set; }
        public string alias { get; set; }
        public string company { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string vat_number { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string other { get; set; }
        public string phone { get; set; }
        public string phone_mobile { get; set; }
        public string dni { get; set; }
        public int deleted { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
        public string date_add { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
        public string date_upd { get; set; }

		public address()
		{
		}
	}
}
