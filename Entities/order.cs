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
    public class order : PrestaShopEntity
    {
        public long? id { get; set; }
		public long? id_address_delivery { get; set; }
		public long? id_address_invoice { get; set; }
		public long? id_cart { get; set; }
		public long? id_currency { get; set; }
		public long? id_lang { get; set; }
		public long? id_customer { get; set; }
        public long? id_carrier { get; set; }
        public long? current_state { get; set; }
        public string module { get; set; }
        public long invoice_number { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string invoice_date { get; set; }
        public long delivery_number { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string delivery_date { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int valid { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        public long id_shop_group { get; set; }
        public long id_shop { get; set; }
        public string secure_key { get; set; }
        public string payment { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int recyclable { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int gift { get; set; }
        public string gift_message { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int mobile_theme { get; set; }
        public decimal total_discounts { get; set; }
        public decimal total_discounts_tax_incl { get; set; }
        public decimal total_discounts_tax_excl { get; set; }
        public decimal total_paid { get; set; }
        public decimal total_paid_tax_incl { get; set; }
        public decimal total_paid_tax_excl { get; set; }
        public decimal total_paid_real { get; set; }
        public decimal total_products { get; set; }
        public decimal total_products_wt { get; set; }
        public decimal total_shipping { get; set; }
        public decimal total_shipping_tax_incl { get; set; }
        public decimal total_shipping_tax_excl { get; set; }
        public decimal carrier_tax_rate { get; set; }
        public decimal total_wrapping { get; set; }
        public decimal total_wrapping_tax_incl { get; set; }
        public decimal total_wrapping_tax_excl { get; set; }
        public string shipping_number { get; set; }
        public decimal conversion_rate { get; set; }
        public string reference { get; set; }
        public AuxEntities.AssociationsOrder associations { get; set; }

        public order()
        {
            this.associations = new AuxEntities.AssociationsOrder();
        }
    }
}
