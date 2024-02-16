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
    public class boxnow_entry : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_cart { get; set; }
		public long? id_order { get; set; }
        public long? locker_id { get; set; }
        public string locker_name { get; set; }
        public string locker_address { get; set; }
        public string locker_post_code { get; set; }

        public boxnow_entry()
        {
        }
    }
}
