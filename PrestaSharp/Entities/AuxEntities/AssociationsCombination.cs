using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCombination : PrestaShopEntity
    {
        public List<AuxEntities.product_option_value> product_option_values { get; set; }
        public List<AuxEntities.image> images { get; set; }

        public AssociationsCombination()
        {
            this.product_option_values = new List<product_option_value>();
            this.images = new List<image>();
        }
    }
}
