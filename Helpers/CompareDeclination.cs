using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Entities.FilterEntities;

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
