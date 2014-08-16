using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCustomerThread
    {
        public List<AuxEntities.customer_message> customer_messages { get; set; }

        public AssociationsCustomerThread()
        {
			this.customer_messages = new List<customer_message>();
        }
    }
}
