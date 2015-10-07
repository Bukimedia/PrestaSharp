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
    public class guest : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_customer { get; set; }
        public long? id_operating_system { get; set; }
        public long? id_web_browser { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int javascript { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int screen_resolution_x { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int screen_resolution_y { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int screen_color { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int sun_java { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int adobe_flash { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int adobe_director { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int apple_quicktime { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int real_player { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int windows_media { get; set; }
        public string accept_language { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int mobile_theme { get; set; }

        public guest()
        {
        }
    }
}
