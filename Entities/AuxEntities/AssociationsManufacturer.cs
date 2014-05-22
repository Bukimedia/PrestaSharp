using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/AuxEntities")]
    public class AssociationsManufacturer : PrestaShopEntity
    {
        public List<AuxEntities.address> addresses { get; set; }

        public AssociationsManufacturer()
        {
            this.addresses = new List<address>();
        }
    }
}
