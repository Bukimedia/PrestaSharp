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
    public class currency : PrestaShopEntity
    {
        public long? id { get; set; }
        public string name { get; set; }
        public string iso_code { get; set; }
        public string iso_code_num { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int blank { get; set; }
        public string sign { get; set; }
        public int format { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int decimals { get; set; }
        public decimal conversion_rate { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int deleted { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }

        public currency()
        {
        }
    }
}
