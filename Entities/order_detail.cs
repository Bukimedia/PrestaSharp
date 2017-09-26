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
    public class order_detail : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_order { get; set; }
        public long? product_id { get; set; }
        public long? product_attribute_id { get; set; }
        public int product_quantity_reinjected { get; set; }
        public decimal group_reduction { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int discount_quantity_applied { get; set; }
        public string download_hash { get; set; }
        /// <summary>
        /// It´s a logical DateTime field. Format YYYY-MM-DD HH:MM:SS.
        /// It´s string because you can receive a string with no DateTime .Net format.
        /// </summary>
        public string download_deadline { get; set; }
        public long? id_order_invoice { get; set; }
        public long? id_warehouse { get; set; }
        public long? id_shop { get; set; }
        public string product_name { get; set; }
        public int product_quantity { get; set; }
        public int product_quantity_in_stock { get; set; }
        public int product_quantity_return { get; set; }
        public int product_quantity_refunded { get; set; }
        public decimal product_price { get; set; }
        public decimal reduction_percent { get; set; }
        public decimal reduction_amount { get; set; }
        public decimal reduction_amount_tax_incl { get; set; }
        public decimal reduction_amount_tax_excl { get; set; }
        public decimal product_quantity_discount { get; set; }
        public string product_ean13 { get; set; }
        public string product_upc { get; set; }
        public string product_reference { get; set; }
        public string product_supplier_reference { get; set; }
        public decimal product_weight { get; set; }
        public int tax_computation_method { get; set; }
        public int id_tax_rules_group { get; set; }
        public decimal ecotax { get; set; }
        public decimal ecotax_tax_rate { get; set; }
        public int download_nb { get; set; }
        public decimal unit_price_tax_incl { get; set; }
        public decimal unit_price_tax_excl { get; set; }
        public decimal total_price_tax_incl { get; set; }
        public decimal total_price_tax_excl { get; set; }
        public decimal total_shipping_price_tax_excl { get; set; }
        public decimal total_shipping_price_tax_incl { get; set; }
        public decimal purchase_supplier_price { get; set; }
        public decimal original_product_price { get; set; }
        public decimal original_wholesale_price { get; set; }

        public order_detail()
        {
        }
    }
}
