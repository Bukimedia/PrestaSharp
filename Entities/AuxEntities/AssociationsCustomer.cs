using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCustomer : PrestaShopEntity
    {
        public List<AuxEntities.group> groups { get; set; }

		public AssociationsCustomer()
        {
			this.groups = new List<group>();
        }
    }
}
