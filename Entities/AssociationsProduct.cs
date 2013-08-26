using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Entities
{
    public class AssociationsProduct : PrestashopEntity
    {
        public List<GenericAssociation> categories { get; set; }
        public List<GenericAssociation> images { get; set; }
        public List<GenericAssociation> combinations { get; set; }
        public List<GenericAssociation> product_option_values { get; set; }
        public List<product_feature> product_features { get; set; }
        public List<GenericAssociation> tags { get; set; }
        public List<stock_available> stock_availables { get; set; }
        public List<products> product_bundle { get; set; }
    }
}
