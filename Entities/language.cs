using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class language: PrestaShopEntity
    {
        public long? id { get; set; }
        public string name { get; set; }
        public string iso_code { get; set; }
        public string language_code { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int is_rtl { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_format_lite { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_format_full { get; set; }

        public language()
        {
        }
    }
}
