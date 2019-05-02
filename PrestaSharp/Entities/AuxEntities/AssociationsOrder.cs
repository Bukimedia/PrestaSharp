using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsOrder : PrestaShopEntity
    {
        public List<order_row> order_rows { get; set; }

        public AssociationsOrder()
        {
            this.order_rows = new List<order_row>();
        }

    }
}
