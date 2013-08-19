using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Entities
{
    public class AssociationsProduct:PrestashopEntity
    {
        public List<category> categories { get; set; }
        public List<image> images { get; set; }
        public List<combination> combinations { get; set; }
        public List<product_option_values> product_option_values { get; set; }
        public List<tag> tags { get; set; }
        public List<stock_available> stock_availables { get; set; }
        public List<product> product_bundle { get; set; }
    }
}
