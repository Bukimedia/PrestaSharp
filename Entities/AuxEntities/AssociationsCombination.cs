using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCombination : PrestashopEntity
    {
        public List<AuxEntities.product_option_value> product_option_values { get; set; }
        public List<AuxEntities.image> images { get; set; }
    }
}
