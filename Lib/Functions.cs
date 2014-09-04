using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Lib
{
    public class Functions
    {
        public static string BuildLinkRewrite(string InputString)
        {
            Regex regex = new Regex("[^a-zA-Z0-9-]");
            
            return regex.Replace(InputString, "-").ToLower();
        }
    }
}
