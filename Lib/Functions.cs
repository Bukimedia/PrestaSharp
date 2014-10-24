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
        internal static string RemoveAccents(string InputString)
        {
            Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê|ě]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û|ů]", RegexOptions.Compiled);

            Regex replace_s_Accents = new Regex("[š]", RegexOptions.Compiled);
            Regex replace_c_Accents = new Regex("[č]", RegexOptions.Compiled);
            Regex replace_r_Accents = new Regex("[ř]", RegexOptions.Compiled);
            Regex replace_z_Accents = new Regex("[ž]", RegexOptions.Compiled);
            Regex replace_y_Accents = new Regex("[ý]", RegexOptions.Compiled);
            Regex replace_t_Accents = new Regex("[ť]", RegexOptions.Compiled);
            Regex replace_d_Accents = new Regex("[ď]", RegexOptions.Compiled);
            Regex replace_n_Accents = new Regex("[ñ|ň]", RegexOptions.Compiled);

            InputString = replace_a_Accents.Replace(InputString, "a");
            InputString = replace_e_Accents.Replace(InputString, "e");
            InputString = replace_i_Accents.Replace(InputString, "i");
            InputString = replace_o_Accents.Replace(InputString, "o");
            InputString = replace_u_Accents.Replace(InputString, "u");
            InputString = replace_s_Accents.Replace(InputString, "s");
            InputString = replace_c_Accents.Replace(InputString, "c");
            InputString = replace_r_Accents.Replace(InputString, "r");
            InputString = replace_z_Accents.Replace(InputString, "z");
            InputString = replace_y_Accents.Replace(InputString, "y");
            InputString = replace_t_Accents.Replace(InputString, "t");
            InputString = replace_d_Accents.Replace(InputString, "d");
            InputString = replace_n_Accents.Replace(InputString, "n");
            return InputString;
        }

        internal static string BuildLinkRewrite(string InputString)
        {
            InputString = InputString.ToLower();
            InputString = RemoveAccents(InputString);
            InputString = InputString.Replace(", ", "-");
            InputString = InputString.Replace(",", "-");
            InputString = InputString.Replace("& ", "-");
            InputString = InputString.Replace(": ", "-");
            InputString = InputString.Replace(" / ", "-");
            InputString = InputString.Replace(" % ", "-");
            InputString = InputString.Replace("% ", "-");
            InputString = InputString.Replace(": ", "-");
            InputString = InputString.Replace(" : ", "-");
            InputString = InputString.Replace(":", "-");
            InputString = InputString.Replace(".", "");
            InputString = InputString.Replace(" ", "-");
            InputString = InputString.Replace(" ", "-");
            InputString = InputString.Replace("/", "-");
            InputString = InputString.Replace("%", "-");
            InputString = InputString.Replace("%", "-");
            InputString = InputString.Replace("'", "-");
            InputString = InputString.Replace("'", "-");
            InputString = InputString.Replace("&#39;", "-");
            return InputString;
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
