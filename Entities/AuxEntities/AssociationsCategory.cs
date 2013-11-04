using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCategory : PrestashopEntity
    {
        public List<AuxEntities.category> categories { get; set; }
        public List<AuxEntities.product> products { get; set; }

        public AssociationsCategory()
        {
            this.categories = new List<category>();
            this.products = new List<product>();
        }

    }
}
