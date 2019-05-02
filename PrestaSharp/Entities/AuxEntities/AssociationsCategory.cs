using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCategory : PrestaShopEntity
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
