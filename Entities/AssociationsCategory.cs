using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Entities
{
    public class AssociationsCategory : PrestashopEntity
    {
        public List<GenericAssociation> categories { get; set; }
        public List<GenericAssociation> products { get; set; }
    }
}
