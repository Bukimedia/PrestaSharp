using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCustomer : PrestaShopEntity
    {
        public List<AuxEntities.group> groups { get; set; }

        public AssociationsCustomer()
        {
            this.groups = new List<group>();
        }
    }
}
