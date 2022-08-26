using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsAttachments : PrestaShopEntity
    {
        public List<AuxEntities.products> products { get; set; }
        public AssociationsAttachments()
        {
            products = new List<products>();
        }
    }
}
