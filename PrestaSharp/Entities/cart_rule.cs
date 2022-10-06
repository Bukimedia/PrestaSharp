using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class cart_rule : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        /// <summary>
        /// format="isUnsignedId"
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// format="isUnsignedId"
        /// </summary>
        public long? id_customer { get; set; }

        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// required="true" format="isDate"
        /// </summary>
        public string date_from { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// required="true" format="isDate"
        /// </summary>
        public string date_to { get; set; }

        /// <summary>
        /// maxSize="65534" format="isCleanHtml"
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// format="isUnsignedInt"
        /// </summary>
        public int? quantity { get; set; }

        /// <summary>
        /// format="isUnsignedInt"
        /// </summary>
        public int? quantity_per_user { get; set; }

        /// <summary>
        /// format="isUnsignedInt"
        /// </summary>
        public int? priority { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? partial_use { get; set; }

        /// <summary>
        /// maxSize="254" format="isCleanHtml"
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// format="isFloat"
        /// </summary>
        public decimal minimum_amount { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? minimum_amount_tax { get; set; }

        /// <summary>
        /// format="isInt"
        /// </summary>
        public int? minimum_amount_currency { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? minimum_amount_shipping { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? country_restriction { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? carrier_restriction { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? group_restriction { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? cart_rule_restriction { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? product_restriction { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? shop_restriction { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? free_shipping { get; set; }

        /// <summary>
        /// format="isPercentage"
        /// </summary>
        public decimal? reduction_percent { get; set; }

        /// <summary>
        /// format="isFloat"
        /// </summary>
        public decimal? reduction_amount { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? reduction_tax { get; set; }

        /// <summary>
        /// format="isUnsignedId"
        /// </summary>
        public int? reduction_currency { get; set; }

        /// <summary>
        /// format="isInt"
        /// </summary>
        public int? reduction_product { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? reduction_exclude_special { get; set; }

        /// <summary>
        /// format="isUnsignedId"
        /// </summary>
        public int? gift_product { get; set; }

        /// <summary>
        /// format="isUnsignedId"
        /// </summary>
        public int? gift_product_attribute { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? highlight { get; set; }

        /// <summary>
        /// It´s a logical bool.
        /// format="isBool"
        /// </summary>
        public int? active { get; set; }

        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// format="isDate"
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// format="isDate"
        /// </summary>
        public string date_upd { get; set; }

        /// <summary>
        /// required="true" maxSize="254"
        /// </summary>
        public List<Entities.AuxEntities.language> name { get; set; }

        public cart_rule()
        {
            this.name = new List<AuxEntities.language>();
        }
    }
}
