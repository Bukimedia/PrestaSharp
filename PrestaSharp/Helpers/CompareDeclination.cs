
/* Modification non fusionnée à partir du projet 'PrestaSharp (net452)'
Avant :
using System;
Après :
using Bukimedia.PrestaSharp.Entities.FilterEntities;
using System;
*/
using Bukimedia.PrestaSharp.Entities.FilterEntities;
using System.
/* Modification non fusionnée à partir du projet 'PrestaSharp (net452)'
Avant :
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Entities.FilterEntities;
Après :
using System.Threading.Tasks;
*/
Collections.Generic;

namespace Bukimedia.PrestaSharp.Helpers
{
    public class CompareDeclination : IEqualityComparer<declination>
    {
        public bool Equals(declination x, declination y)
        {
            return x.id == y.id;
        }

        public int GetHashCode(declination obj)
        {
            return (int)obj.id; // Could cause overflow.
        }
    }
}
