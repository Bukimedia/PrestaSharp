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
            string OutputString = InputString;
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

            OutputString = replace_a_Accents.Replace(OutputString, "a");
            OutputString = replace_e_Accents.Replace(OutputString, "e");
            OutputString = replace_i_Accents.Replace(OutputString, "i");
            OutputString = replace_o_Accents.Replace(OutputString, "o");
            OutputString = replace_u_Accents.Replace(OutputString, "u");
            OutputString = replace_s_Accents.Replace(OutputString, "s");
            OutputString = replace_c_Accents.Replace(OutputString, "c");
            OutputString = replace_r_Accents.Replace(OutputString, "r");
            OutputString = replace_z_Accents.Replace(OutputString, "z");
            OutputString = replace_y_Accents.Replace(OutputString, "y");
            OutputString = replace_t_Accents.Replace(OutputString, "t");
            OutputString = replace_d_Accents.Replace(OutputString, "d");
            OutputString = replace_n_Accents.Replace(OutputString, "n");
            return OutputString;
        }

        internal static string BuildLinkRewrite(string InputString)
        {
            string OutputString = InputString;
            OutputString = OutputString.ToLower();
            OutputString = RemoveAccents(OutputString);
            OutputString = OutputString.Replace(", ", "-");
            OutputString = OutputString.Replace(". ", "-");
            OutputString = OutputString.Replace(",", "-");
            OutputString = OutputString.Replace("& ", "-");
            OutputString = OutputString.Replace(": ", "-");
            OutputString = OutputString.Replace(" / ", "-");
            OutputString = OutputString.Replace(" % ", "-");
            OutputString = OutputString.Replace("% ", "-");
            OutputString = OutputString.Replace(": ", "-");
            OutputString = OutputString.Replace(" : ", "-");
            OutputString = OutputString.Replace(":", "-");
            OutputString = OutputString.Replace(".", "");
            OutputString = OutputString.Replace(" ", "-");
            OutputString = OutputString.Replace(" ", "-");
            OutputString = OutputString.Replace(" ", "-");
            OutputString = OutputString.Replace("/", "-");
            OutputString = OutputString.Replace("%", "-");
            OutputString = OutputString.Replace("%", "-");
            OutputString = OutputString.Replace("'", "-");
            OutputString = OutputString.Replace("'", "-");
            OutputString = OutputString.Replace("ß", "b");
            OutputString = OutputString.Replace("�", "-");
            OutputString = OutputString.Replace("&#39;", "-");
            return OutputString;
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
