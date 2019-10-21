using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsProduct : PrestaShopEntity
    {
        public List<AuxEntities.category> categories { get; set; }
        public List<AuxEntities.image> images { get; set; }
        public List<AuxEntities.combinations> combinations { get; set; }
        public List<AuxEntities.product_option_value> product_option_values { get; set; }
        public List<AuxEntities.product_feature> product_features { get; set; }
        public List<AuxEntities.tag> tags { get; set; }
        public List<AuxEntities.stock_available> stock_availables { get; set; }
        public List<AuxEntities.products> product_bundle { get; set; }
        public List<AuxEntities.product> accessories { get; set; }

        public AssociationsProduct()
        {
            this.categories = new List<category>();
            this.images = new List<image>();
            this.combinations = new List<combinations>();
            this.product_option_values = new List<product_option_value>();
            this.product_features = new List<product_feature>();
            this.tags = new List<tag>();
            this.stock_availables = new List<stock_available>();
            this.product_bundle = new List<products>();
            this.accessories = new List<product>();
        }
    }
}
