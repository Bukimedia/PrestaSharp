using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsWarehouse : PrestaShopEntity
    {
        public List<AuxEntities.shop> shops { get; set; }
        public List<AuxEntities.carrier> carries { get; set; }
        public List<AuxEntities.stock> stocks { get; set; }

        public AssociationsWarehouse()
        {
            this.shops = new List<shop>();
            this.carries = new List<carrier>();
            this.stocks = new List<stock>();
        }
    }
}
