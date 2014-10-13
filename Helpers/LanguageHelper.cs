using Bukimedia.PrestaSharp.Entities.AuxEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Helpers
{
    public static class LanguageHelper
    {
        public static string GetString(IEnumerable<language> LanguageValues)
        {
            return string.Join("/", LanguageValues.Select(n => n.Value));
        }
    }
}
