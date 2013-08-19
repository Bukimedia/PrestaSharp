using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    public class product:PrestashopEntity
    {

        public long? id { get; set; }
        public long? id_supplier { get; set; }
        public long? id_manufacturer { get; set; }
        public long? id_category_default { get; set; }
        public long id_shop_default { get; set; }
        public long id_tax_rules_group { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int on_sale { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int online_only { get; set; }
        public string ean13 { get; set; }
        public string upc { get; set; }
        public decimal ecotax { get; set; }
        public long minimal_quantity { get; set; }
        public decimal price { get; set; }
        public decimal wholesale_price { get; set; }
        public string unity { get; set; }
        public decimal unit_price_ratio { get; set; }
        public decimal additional_shipping_cost { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public string location { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal depth { get; set; }
        public decimal weight { get; set; }
        public long out_of_stock { get; set; }
        public int? quantity_discount { get; set; }
        public sbyte customizable { get; set; }
        public sbyte uploadable_files { get; set; }
        public sbyte text_fields { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        public string redirect_type { get; set; }
        public long id_product_redirected { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int available_for_order { get; set; }
        /// <summary>
        /// It´s a logical DateTime field. Format YYYY-MM-DD HH:MM:SS.
        /// It´s string because you can receive a string with no DateTime .Net format.
        /// </summary>
        public string available_date { get; set; }
        public string condition { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int show_price { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int indexed { get; set; }
        public string visibility { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int cache_is_pack { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int cache_has_attachments { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int is_virtual { get; set; }
        public long? cache_default_attribute { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int advanced_stock_management { get; set; }
        public List<Entities.language> meta_description { get; set; }
        public List<Entities.language> meta_keywords { get; set; }
        public List<Entities.language> meta_title { get; set; }
        public List<Entities.language> link_rewrite { get; set; }
        public List<Entities.language> name { get; set; }
        public List<Entities.language> description { get; set; }
        public List<Entities.language> description_short { get; set; }
        public List<Entities.language> available_now { get; set; }
        public List<Entities.language> available_later { get; set; }
        public AssociationsProduct associations { get; set; }

    }
}
