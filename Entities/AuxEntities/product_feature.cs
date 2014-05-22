using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/AuxEntities")]
    public class product_feature:PrestaShopEntity
    {
        public long id { get; set; }
        public long id_feature_value { get; set; }
    }
}
