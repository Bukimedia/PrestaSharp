using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities.FilterEntities
{
    [XmlType(Namespace = "PrestaSharp/Entities/FilterEntities")]
    public class GenericFilterEntity:PrestashopEntity
    {
        public long id { get; set; }
    }
}
