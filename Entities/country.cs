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
    public class country : PrestaShopEntity
    {
        public long? id { get; set; }
		public long? id_zone { get; set; }
		public long? id_currency { get; set; }
		public int? call_prefix { get; set; }
		/// <summary>
		/// Required. maxSize = 3
		/// </summary>
		public string iso_code { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
		public int active { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
		public int contains_states { get; set; }
		/// <summary>
		/// Required
		/// </summary>
		public int need_identification_number { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
		public int need_zip_code { get; set; }
		/// <summary>
		/// Must be like "NNNNN" or "LNL NLN" where N=Number and L=Letter
		/// </summary>
		public string zip_code_format { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
		public int display_tax_label { get; set; }
		/// <summary>
		/// Required. Maxsize = 64
		/// </summary>
        public List<Entities.AuxEntities.language> name { get; set; }

        public country()
        {
            this.name = new List<AuxEntities.language>();
        }
    }
}
