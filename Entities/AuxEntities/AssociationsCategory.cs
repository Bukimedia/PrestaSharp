using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Entities.AuxEntities
{
    public class AssociationsCategory : PrestashopEntity
    {
        public List<AuxEntities.category> categories { get; set; }
        public List<AuxEntities.product> products { get; set; }
    }
}
