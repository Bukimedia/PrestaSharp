using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestaSharp.Entities.AuxEntities
{
    public class AssociationsProductOption : PrestashopEntity
    {
        public List<AuxEntities.product_option_value> product_option_values { get; set; }
    }
}
