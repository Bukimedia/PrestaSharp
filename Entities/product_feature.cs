using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Entities
{
    public class product_feature : PrestashopEntity
    {
        public long? id { get; set; }
        public int position { get; set; }
        public List<PrestaSharp.Entities.AuxEntities.language> name { get; set; }

        public product_feature()
        {
            this.name = new List<AuxEntities.language>();
        }
    }
}
