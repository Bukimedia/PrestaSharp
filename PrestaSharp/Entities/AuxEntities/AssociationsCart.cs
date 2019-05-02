using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCart : PrestaShopEntity
    {
        public List<cart_row> cart_rows { get; set; }

        public AssociationsCart()
        {
            this.cart_rows = new List<cart_row>();
        }

    }
}
