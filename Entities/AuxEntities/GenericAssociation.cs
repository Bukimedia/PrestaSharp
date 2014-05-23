using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class GenericAssociation : PrestaShopEntity
    {
        public long id { get; set; }

        public GenericAssociation()
        {
        }

        public GenericAssociation(long id)
        {
            this.id = id;
        }
    }
}
