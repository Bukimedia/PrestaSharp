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
    public class cart : PrestaShopEntity
    {
        public long? id { get; set; }
		public long? id_address_delivery { get; set; }
		public long? id_address_invoice { get; set; }
		public long? id_currency { get; set; }
		public long? id_guest { get; set; }
		public long? id_customer { get; set; }
        public long? id_lang { get; set; }
        public long? id_shop_group { get; set; }
        public long? id_shop { get; set; }
        public long? id_carrier { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int recyclable { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int gift { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int mobile_theme { get; set; }
        public string delivery_option { get; set; }
        public string secure_key { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int allow_seperated_package { get; set; }   
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        public AuxEntities.AssociationsCart associations { get; set; }

        public cart()
        {
            this.associations = new AuxEntities.AssociationsCart();
        }
    }
}
