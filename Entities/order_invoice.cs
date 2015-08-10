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
    public class order_invoice : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_order { get; set; }
        public long? number { get; set; }
        public long? delivery_number { get; set; }
        public string delivery_date { get; set; }
        public decimal total_discount_tax_excl { get; set; }
        public decimal total_discount_tax_incl { get; set; }
        public decimal total_paid_tax_excl { get; set; }
        public decimal total_paid_tax_incl { get; set; }
        public decimal total_products { get; set; }
        public decimal total_products_wt { get; set; }
        public decimal total_shipping_tax_excl { get; set; }
        public decimal total_shipping_tax_incl { get; set; }
        public long? shipping_tax_computation_method { get; set; }
        public decimal total_wrapping_tax_excl { get; set; }
        public decimal total_wrapping_tax_incl { get; set; }
        public string shop_address { get; set; }
        public string invoice_address { get; set; }
        public string delivery_address { get; set; }
        public string company_address { get; set; }
        public string note { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
    }
}