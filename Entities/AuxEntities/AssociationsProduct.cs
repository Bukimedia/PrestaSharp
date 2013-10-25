using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/AuxEntities")]
    public class AssociationsProduct : PrestashopEntity
    {
        public List<AuxEntities.category> categories { get; set; }
        public List<AuxEntities.image> images { get; set; }
        public List<AuxEntities.combinations> combinations { get; set; }
        public List<AuxEntities.product_option_value> product_option_values { get; set; }
        public List<AuxEntities.product_feature> product_features { get; set; }
        public List<AuxEntities.tag> tags { get; set; }
        public List<AuxEntities.stock_available> stock_availables { get; set; }
        public List<AuxEntities.products> product_bundle { get; set; }
    }
}
