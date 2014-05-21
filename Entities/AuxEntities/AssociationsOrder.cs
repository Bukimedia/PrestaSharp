using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/AuxEntities")]
    public class AssociationsOrder : PrestashopEntity
    {
        public List<order_row> order_rows { get; set; }

        public AssociationsOrder()
        {
            this.order_rows = new List<order_row>();
        }

    }
}
