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
    public class customer : PrestaShopEntity
    {
        public long? id { get; set; }
		public long? id_default_group { get; set; }
		public long? id_lang { get; set; }
		public long? id_shop { get; set; }
		public long? id_shop_group { get; set; }
		public long? id_risk { get; set; }
		public long? id_gender { get; set; }
		/// <summary>
		/// Required. MaxSize = 32. Default MinSize = 5 (can change depending on the shop settings)
		/// If you don't change the passwd after getting the entity, the password won't change when saving.
		/// </summary>
		public string passwd { get; set; }
		/// <summary>
		/// Required. MaxSize = 32.
		/// </summary>
        public string lastname { get; set; }
		/// <summary>
		/// Required. MaxSize = 32.
		/// </summary>
		public string firstname { get; set; }
		/// <summary>
		/// Required. MaxSize = 128. Must be an email.
		/// </summary>
		public string email { get; set; }
		/// <summary>
		/// Format YYYY-MM-DD
		/// </summary>
		public string birthday { get; set; }
		/// <summary>
		/// Must be an url
		/// </summary>
		public string website { get; set; }
		public string company { get; set; }
		public string siret { get; set; }
		public string ape { get; set; }
		public string ip_registration_newsletter { get; set; }
		public string secure_key { get; set; }
		public decimal outstanding_allow_amount { get; set; }
		public long max_payment_days { get; set; }
		/// <summary>
		/// Must be clean html. MaxSize = 65000.
		/// </summary>
		public string note { get; set; }
		/// <summary>
		/// It´s a logical bool.
		/// </summary>
		public int deleted { get; set; }
		/// <summary>
		/// It´s a logical bool.
		/// </summary>
		public int optin { get; set; }
		/// <summary>
		/// It´s a logical bool.
		/// </summary>
		public int newsletter { get; set; }
		/// <summary>
		/// It´s a logical bool.
		/// </summary>
		public int is_guest { get; set; }
		/// <summary>
		/// It´s a logical bool.
		/// </summary>
		public int show_public_prices { get; set; }
		/// <summary>
        /// It´s a logical bool.
        /// </summary>
		public int active { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
		public string newsletter_date_add { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
		public string last_passwd_gen { get; set; }
		/// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        public AuxEntities.AssociationsCustomer associations { get; set; }

        public customer()
        {
			this.associations = new AuxEntities.AssociationsCustomer();
        }
    }
}
