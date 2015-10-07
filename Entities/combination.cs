using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [Serializable]
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class combination : PrestaShopEntity
    {

        public long? id { get; set; }
        public long? id_product { get; set; }
        public string location { get; set; }
        public string ean13 { get; set; }
        public string upc { get; set; }
        public int quantity { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public decimal wholesale_price { get; set; }
        public decimal price { get; set; }
        public decimal ecotax { get; set; }
        public decimal weight { get; set; }
        public decimal unit_price_impact { get; set; }
        public long? minimal_quantity { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int? default_on { get; set; }
        /// <summary>
        /// It´s a logical DateTime field. Format YYYY-MM-DD HH:MM:SS.
        /// It´s string because you can receive a string with no DateTime .Net format.
        /// </summary>
        public string available_date { get; set; }
        public AuxEntities.AssociationsCombination associations { get; set; }

        public combination()
        {
            this.associations = new AuxEntities.AssociationsCombination();
        }
    }
}

