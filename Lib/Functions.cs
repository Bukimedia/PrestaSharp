using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Lib
{
    internal static class Functions
    {
        internal static string BuildLinkRewrite(string InputString)
        {
            Regex regex = new Regex("[^a-zA-Z0-9-]");
            
            return regex.Replace(InputString, "-").ToLower();
        }

        internal static string ReplaceFirstOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.IndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

        internal static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.LastIndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }
    }
}
