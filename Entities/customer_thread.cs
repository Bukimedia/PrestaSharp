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
    public class customer_thread : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_lang { get; set; }
        public long? id_shop { get; set; }
        public long? id_customer { get; set; }
        public long? id_order { get; set; }
        public long? id_product { get; set; }
        public long? id_contact { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public string status { get; set; }
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public AuxEntities.AssociationsCustomerThread associations { get; set; }

        public customer_thread()
        {
            this.associations = new AuxEntities.AssociationsCustomerThread();
        }
    }
}
