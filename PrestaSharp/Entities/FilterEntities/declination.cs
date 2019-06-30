using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.FilterEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/FilterEntities")]
    public class declination : GenericFilterEntity
    {

        public override bool Equals(object obj)
        {
            return this.id == ((PrestaSharp.Entities.FilterEntities.declination)obj).id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
