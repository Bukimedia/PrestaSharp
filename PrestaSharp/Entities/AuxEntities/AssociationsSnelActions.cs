using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsSnelAction : PrestaShopEntity
    {
        public List<snelRunDetail> snelRunDetails { get; set; }

        public AssociationsSnelAction()
        {
            this.snelRunDetails = new List<snelRunDetail>();
        }
    }
}