using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    public class product_feature:PrestashopEntity
    {
        public long id { get; set; }
        public int id_feature_value { get; set; }
    }
}
