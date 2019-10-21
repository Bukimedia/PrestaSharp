using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsProductOption : PrestaShopEntity
    {
        public List<AuxEntities.product_option_value> product_option_values { get; set; }

        public AssociationsProductOption()
        {
            this.product_option_values = new List<product_option_value>();
        }
    }
}
