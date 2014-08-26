using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Lib
{
    public static class Functions
    {
        public static string RemoveAccents(string InputString)
        {
            string OutputString = InputString;
            Regex replace_a_Accents = new Regex("[á|à|ä|â|ą]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê|ě|ę]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô|ó]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û|ů]", RegexOptions.Compiled);

            Regex replace_s_Accents = new Regex("[š|ś]", RegexOptions.Compiled);
            Regex replace_c_Accents = new Regex("[č|ć]", RegexOptions.Compiled);
            Regex replace_r_Accents = new Regex("[ř]", RegexOptions.Compiled);
            Regex replace_z_Accents = new Regex("[ž|ź|ż]", RegexOptions.Compiled);
            Regex replace_y_Accents = new Regex("[ý]", RegexOptions.Compiled);
            Regex replace_t_Accents = new Regex("[ť]", RegexOptions.Compiled);
            Regex replace_d_Accents = new Regex("[ď]", RegexOptions.Compiled);
            Regex replace_n_Accents = new Regex("[ñ|ň|ń]", RegexOptions.Compiled);
            Regex replace_l_Accents = new Regex("[ł]", RegexOptions.Compiled);

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
            OutputString = replace_l_Accents.Replace(OutputString, "l");
            return OutputString;
        }

        public static string GetLinkRewrite(string InputString)
        {
            string OutputString = InputString;
            OutputString = RemoveAccents(OutputString);
            OutputString = OutputString.Replace(", ", "-");
            OutputString = OutputString.Replace(". ", "-");
            OutputString = OutputString.Replace("& ", "-");
            OutputString = OutputString.Replace("&amp;amp; ", "");
            OutputString = OutputString.Replace("&amp; ", "");
            OutputString = OutputString.Replace(": ", "-");
            OutputString = OutputString.Replace(" / ", "-");
            OutputString = OutputString.Replace(" % ", "-");
            OutputString = OutputString.Replace("% ", "-");
            OutputString = OutputString.Replace(": ", "-");
            OutputString = OutputString.Replace(" : ", "-");
            OutputString = OutputString.Replace(":", "-");
            OutputString = OutputString.Replace(".", "");
            OutputString = OutputString.Replace(",", "-");
            OutputString = OutputString.Replace("  ", "-");
            OutputString = OutputString.Replace(" ", "-");
            OutputString = OutputString.Replace(" ", "-");
            OutputString = OutputString.Replace(" ", "-");
            OutputString = OutputString.Replace("/", "-");
            OutputString = OutputString.Replace("%", "-");
            OutputString = OutputString.Replace("%", "-");
            OutputString = OutputString.Replace("ñ", "n");
            OutputString = OutputString.Replace("'", "-");
            OutputString = OutputString.Replace("'", "-");
            OutputString = OutputString.Replace("ß", "b");
            OutputString = OutputString.Replace("�", "-");
            OutputString = OutputString.Replace("&#39;", "-");
            OutputString = OutputString.Replace("!", "");
            OutputString = OutputString.Replace("¡", "");
            OutputString = OutputString.Replace("¿", "");
            OutputString = OutputString.Replace("?", "");
            OutputString = OutputString.Replace("(", "");
            OutputString = OutputString.Replace(")", "");
            OutputString = OutputString.Replace("+", "");
            OutputString = OutputString.Replace("*", "");
            OutputString = OutputString.Replace("&#39;", "-");
            OutputString = OutputString.Replace("ß", "b");
            OutputString = OutputString.Replace("Œ", "o");
            OutputString = OutputString.Replace("œ", "o");
            OutputString = OutputString.Replace("À", "A");
            OutputString = OutputString.Replace("Á", "A");
            OutputString = OutputString.Replace("Â", "A");
            OutputString = OutputString.Replace("Ã", "A");
            OutputString = OutputString.Replace("Ä", "A");
            OutputString = OutputString.Replace("Å", "A");
            OutputString = OutputString.Replace("à", "a");
            OutputString = OutputString.Replace("á", "a");
            OutputString = OutputString.Replace("â", "a");
            OutputString = OutputString.Replace("ã", "a");
            OutputString = OutputString.Replace("ä", "a");
            OutputString = OutputString.Replace("å", "a");
            OutputString = OutputString.Replace("Ā", "A");
            OutputString = OutputString.Replace("ā", "a");
            OutputString = OutputString.Replace("Ă", "A");
            OutputString = OutputString.Replace("ă", "a");
            OutputString = OutputString.Replace("Ą", "A");
            OutputString = OutputString.Replace("ą", "a");
            OutputString = OutputString.Replace("Ç", "C");
            OutputString = OutputString.Replace("ç", "c");
            OutputString = OutputString.Replace("Ć", "C");
            OutputString = OutputString.Replace("ć", "c");
            OutputString = OutputString.Replace("Ĉ", "C");
            OutputString = OutputString.Replace("ĉ", "c");
            OutputString = OutputString.Replace("Ċ", "C");
            OutputString = OutputString.Replace("ċ", "c");
            OutputString = OutputString.Replace("Č", "C");
            OutputString = OutputString.Replace("č", "c");
            OutputString = OutputString.Replace("Ð", "D");
            OutputString = OutputString.Replace("ð", "d");
            OutputString = OutputString.Replace("Ď", "D");
            OutputString = OutputString.Replace("ď", "d");
            OutputString = OutputString.Replace("Đ", "D");
            OutputString = OutputString.Replace("đ", "d");
            OutputString = OutputString.Replace("È", "E");
            OutputString = OutputString.Replace("É", "E");
            OutputString = OutputString.Replace("Ê", "E");
            OutputString = OutputString.Replace("Ë", "E");
            OutputString = OutputString.Replace("è", "e");
            OutputString = OutputString.Replace("é", "e");
            OutputString = OutputString.Replace("ê", "e");
            OutputString = OutputString.Replace("ë", "e");
            OutputString = OutputString.Replace("Ē", "E");
            OutputString = OutputString.Replace("ē", "e");
            OutputString = OutputString.Replace("Ĕ", "E");
            OutputString = OutputString.Replace("ĕ", "e");
            OutputString = OutputString.Replace("Ė", "E");
            OutputString = OutputString.Replace("ė", "e");
            OutputString = OutputString.Replace("Ę", "E");
            OutputString = OutputString.Replace("ę", "e");
            OutputString = OutputString.Replace("Ě", "E");
            OutputString = OutputString.Replace("ě", "e");
            OutputString = OutputString.Replace("Ĝ", "G");
            OutputString = OutputString.Replace("ĝ", "g");
            OutputString = OutputString.Replace("Ğ", "G");
            OutputString = OutputString.Replace("ğ", "g");
            OutputString = OutputString.Replace("Ġ", "G");
            OutputString = OutputString.Replace("ġ", "g");
            OutputString = OutputString.Replace("Ģ", "G");
            OutputString = OutputString.Replace("ģ", "g");
            OutputString = OutputString.Replace("Ĥ", "H");
            OutputString = OutputString.Replace("ĥ", "h");
            OutputString = OutputString.Replace("Ħ", "H");
            OutputString = OutputString.Replace("ħ", "h");
            OutputString = OutputString.Replace("Ì", "I");
            OutputString = OutputString.Replace("Í", "I");
            OutputString = OutputString.Replace("Î", "I");
            OutputString = OutputString.Replace("Ï", "I");
            OutputString = OutputString.Replace("ì", "i");
            OutputString = OutputString.Replace("í", "i");
            OutputString = OutputString.Replace("î", "i");
            OutputString = OutputString.Replace("ï", "i");
            OutputString = OutputString.Replace("Ĩ", "I");
            OutputString = OutputString.Replace("ĩ", "i");
            OutputString = OutputString.Replace("Ī", "I");
            OutputString = OutputString.Replace("ī", "i");
            OutputString = OutputString.Replace("Ĭ", "I");
            OutputString = OutputString.Replace("ĭ", "i");
            OutputString = OutputString.Replace("Į", "I");
            OutputString = OutputString.Replace("į", "i");
            OutputString = OutputString.Replace("İ", "I");
            OutputString = OutputString.Replace("ı", "i");
            OutputString = OutputString.Replace("Ĵ", "J");
            OutputString = OutputString.Replace("ĵ", "j");
            OutputString = OutputString.Replace("Ķ", "K");
            OutputString = OutputString.Replace("ķ", "k");
            OutputString = OutputString.Replace("ĸ", "k");
            OutputString = OutputString.Replace("Ĺ", "L");
            OutputString = OutputString.Replace("ĺ", "l");
            OutputString = OutputString.Replace("Ļ", "L");
            OutputString = OutputString.Replace("ļ", "l");
            OutputString = OutputString.Replace("Ľ", "L");
            OutputString = OutputString.Replace("ľ", "l");
            OutputString = OutputString.Replace("Ŀ", "L");
            OutputString = OutputString.Replace("ŀ", "l");
            OutputString = OutputString.Replace("Ł", "L");
            OutputString = OutputString.Replace("ł", "l");
            OutputString = OutputString.Replace("Ñ", "N");
            OutputString = OutputString.Replace("ñ", "n");
            OutputString = OutputString.Replace("Ń", "N");
            OutputString = OutputString.Replace("ń", "n");
            OutputString = OutputString.Replace("Ņ", "N");
            OutputString = OutputString.Replace("ņ", "n");
            OutputString = OutputString.Replace("Ň", "N");
            OutputString = OutputString.Replace("ň", "n");
            OutputString = OutputString.Replace("ŉ", "n");
            OutputString = OutputString.Replace("Ŋ", "N");
            OutputString = OutputString.Replace("ŋ", "n");
            OutputString = OutputString.Replace("Ò", "O");
            OutputString = OutputString.Replace("Ó", "O");
            OutputString = OutputString.Replace("Ô", "O");
            OutputString = OutputString.Replace("Õ", "O");
            OutputString = OutputString.Replace("Ö", "O");
            OutputString = OutputString.Replace("Ø", "O");
            OutputString = OutputString.Replace("ò", "o");
            OutputString = OutputString.Replace("ó", "o");
            OutputString = OutputString.Replace("ô", "o");
            OutputString = OutputString.Replace("õ", "o");
            OutputString = OutputString.Replace("ö", "o");
            OutputString = OutputString.Replace("ø", "o");
            OutputString = OutputString.Replace("Ō", "O");
            OutputString = OutputString.Replace("ō", "o");
            OutputString = OutputString.Replace("Ŏ", "O");
            OutputString = OutputString.Replace("ŏ", "o");
            OutputString = OutputString.Replace("Ő", "O");
            OutputString = OutputString.Replace("ő", "o");
            OutputString = OutputString.Replace("Ŕ", "R");
            OutputString = OutputString.Replace("ŕ", "r");
            OutputString = OutputString.Replace("Ŗ", "R");
            OutputString = OutputString.Replace("ŗ", "r");
            OutputString = OutputString.Replace("Ř", "R");
            OutputString = OutputString.Replace("ř", "r");
            OutputString = OutputString.Replace("Ś", "S");
            OutputString = OutputString.Replace("ś", "s");
            OutputString = OutputString.Replace("Ŝ", "S");
            OutputString = OutputString.Replace("ŝ", "s");
            OutputString = OutputString.Replace("Ş", "S");
            OutputString = OutputString.Replace("ş", "s");
            OutputString = OutputString.Replace("Š", "S");
            OutputString = OutputString.Replace("š", "s");
            OutputString = OutputString.Replace("ſ", "s");
            OutputString = OutputString.Replace("Ţ", "T");
            OutputString = OutputString.Replace("ţ", "t");
            OutputString = OutputString.Replace("Ť", "T");
            OutputString = OutputString.Replace("ť", "t");
            OutputString = OutputString.Replace("Ŧ", "T");
            OutputString = OutputString.Replace("ŧ", "t");
            OutputString = OutputString.Replace("Ù", "U");
            OutputString = OutputString.Replace("Ú", "U");
            OutputString = OutputString.Replace("Û", "U");
            OutputString = OutputString.Replace("Ü", "U");
            OutputString = OutputString.Replace("ù", "u");
            OutputString = OutputString.Replace("ú", "u");
            OutputString = OutputString.Replace("û", "u");
            OutputString = OutputString.Replace("ü", "u");
            OutputString = OutputString.Replace("Ũ", "U");
            OutputString = OutputString.Replace("ũ", "u");
            OutputString = OutputString.Replace("Ū", "U");
            OutputString = OutputString.Replace("ū", "u");
            OutputString = OutputString.Replace("Ŭ", "U");
            OutputString = OutputString.Replace("ŭ", "u");
            OutputString = OutputString.Replace("Ů", "U");
            OutputString = OutputString.Replace("ů", "u");
            OutputString = OutputString.Replace("Ű", "U");
            OutputString = OutputString.Replace("ű", "u");
            OutputString = OutputString.Replace("Ų", "U");
            OutputString = OutputString.Replace("ų", "u");
            OutputString = OutputString.Replace("Ŵ", "W");
            OutputString = OutputString.Replace("ŵ", "w");
            OutputString = OutputString.Replace("Ý", "Y");
            OutputString = OutputString.Replace("ý", "y");
            OutputString = OutputString.Replace("ÿ", "y");
            OutputString = OutputString.Replace("Ŷ", "Y");
            OutputString = OutputString.Replace("ŷ", "y");
            OutputString = OutputString.Replace("Ÿ", "Y");
            OutputString = OutputString.Replace("Ź", "Z");
            OutputString = OutputString.Replace("ź", "z");
            OutputString = OutputString.Replace("Ż", "Z");
            OutputString = OutputString.Replace("ż", "z");
            OutputString = OutputString.Replace("Ž", "Z");
            OutputString = OutputString.Replace("ž", "z");
            OutputString = OutputString.Replace("α", "a");
            OutputString = OutputString.Replace("β", "b");
            OutputString = OutputString.Replace("γ", "g");
            OutputString = OutputString.Replace("δ", "d");
            OutputString = OutputString.Replace("ε", "e");
            OutputString = OutputString.Replace("ζ", "z");
            OutputString = OutputString.Replace("η", "h");
            OutputString = OutputString.Replace("θ", "th");
            OutputString = OutputString.Replace("ι", "i");
            OutputString = OutputString.Replace("κ", "k");
            OutputString = OutputString.Replace("λ", "l");
            OutputString = OutputString.Replace("μ", "m");
            OutputString = OutputString.Replace("ν", "n");
            OutputString = OutputString.Replace("ξ", "x");
            OutputString = OutputString.Replace("ο", "o");
            OutputString = OutputString.Replace("π", "p");
            OutputString = OutputString.Replace("ρ", "r");
            OutputString = OutputString.Replace("σ", "s");
            OutputString = OutputString.Replace("τ", "t");
            OutputString = OutputString.Replace("υ", "y");
            OutputString = OutputString.Replace("φ", "f");
            OutputString = OutputString.Replace("χ", "ch");
            OutputString = OutputString.Replace("ψ", "ps");
            OutputString = OutputString.Replace("ω", "w");
            OutputString = OutputString.Replace("Α", "A");
            OutputString = OutputString.Replace("Β", "B");
            OutputString = OutputString.Replace("Γ", "G");
            OutputString = OutputString.Replace("Δ", "D");
            OutputString = OutputString.Replace("Ε", "E");
            OutputString = OutputString.Replace("Ζ", "Z");
            OutputString = OutputString.Replace("Η", "H");
            OutputString = OutputString.Replace("Θ", "Th");
            OutputString = OutputString.Replace("Ι", "I");
            OutputString = OutputString.Replace("Κ", "K");
            OutputString = OutputString.Replace("Λ", "L");
            OutputString = OutputString.Replace("Μ", "M");
            OutputString = OutputString.Replace("Ξ", "X");
            OutputString = OutputString.Replace("Ο", "O");
            OutputString = OutputString.Replace("Π", "P");
            OutputString = OutputString.Replace("Ρ", "R");
            OutputString = OutputString.Replace("Σ", "S");
            OutputString = OutputString.Replace("Τ", "T");
            OutputString = OutputString.Replace("Υ", "Y");
            OutputString = OutputString.Replace("Φ", "F");
            OutputString = OutputString.Replace("Χ", "Ch");
            OutputString = OutputString.Replace("Ψ", "Ps");
            OutputString = OutputString.Replace("Ω", "W");
            OutputString = OutputString.Replace("ά", "a");
            OutputString = OutputString.Replace("έ", "e");
            OutputString = OutputString.Replace("ή", "h");
            OutputString = OutputString.Replace("ί", "i");
            OutputString = OutputString.Replace("ό", "o");
            OutputString = OutputString.Replace("ύ", "y");
            OutputString = OutputString.Replace("ώ", "w");
            OutputString = OutputString.Replace("Ά", "A");
            OutputString = OutputString.Replace("Έ", "E");
            OutputString = OutputString.Replace("Ή", "H");
            OutputString = OutputString.Replace("Ί", "I");
            OutputString = OutputString.Replace("Ό", "O");
            OutputString = OutputString.Replace("Ύ", "Y");
            OutputString = OutputString.Replace("Ώ", "W");
            OutputString = OutputString.Replace("ϊ", "i");
            OutputString = OutputString.Replace("ΐ", "i");
            OutputString = OutputString.Replace("ϋ", "y");
            OutputString = OutputString.Replace("ς", "s");
            OutputString = OutputString.Replace("А", "A");
            OutputString = OutputString.Replace("Ӑ", "A");
            OutputString = OutputString.Replace("Ӓ", "A");
            OutputString = OutputString.Replace("Ә", "E");
            OutputString = OutputString.Replace("Ӛ", "E");
            OutputString = OutputString.Replace("Ӕ", "E");
            OutputString = OutputString.Replace("Б", "B");
            OutputString = OutputString.Replace("В", "V");
            OutputString = OutputString.Replace("Г", "G");
            OutputString = OutputString.Replace("Ґ", "G");
            OutputString = OutputString.Replace("Ѓ", "G");
            OutputString = OutputString.Replace("Ғ", "G");
            OutputString = OutputString.Replace("Ӷ", "G");
            OutputString = OutputString.Replace("y", "Y");
            OutputString = OutputString.Replace("Д", "D");
            OutputString = OutputString.Replace("Е", "E");
            OutputString = OutputString.Replace("Ѐ", "E");
            OutputString = OutputString.Replace("Ё", "YO");
            OutputString = OutputString.Replace("Ӗ", "E");
            OutputString = OutputString.Replace("Ҽ", "E");
            OutputString = OutputString.Replace("Ҿ", "E");
            OutputString = OutputString.Replace("Є", "YE");
            OutputString = OutputString.Replace("Ж", "ZH");
            OutputString = OutputString.Replace("Ӂ", "DZH");
            OutputString = OutputString.Replace("Җ", "ZH");
            OutputString = OutputString.Replace("Ӝ", "DZH");
            OutputString = OutputString.Replace("З", "Z");
            OutputString = OutputString.Replace("Ҙ", "Z");
            OutputString = OutputString.Replace("Ӟ", "DZ");
            OutputString = OutputString.Replace("Ӡ", "DZ");
            OutputString = OutputString.Replace("Ѕ", "DZ");
            OutputString = OutputString.Replace("И", "I");
            OutputString = OutputString.Replace("Ѝ", "I");
            OutputString = OutputString.Replace("Ӥ", "I");
            OutputString = OutputString.Replace("Ӣ", "I");
            OutputString = OutputString.Replace("І", "I");
            OutputString = OutputString.Replace("Ї", "JI");
            OutputString = OutputString.Replace("Ӏ", "I");
            OutputString = OutputString.Replace("Й", "Y");
            OutputString = OutputString.Replace("Ҋ", "Y");
            OutputString = OutputString.Replace("Ј", "J");
            OutputString = OutputString.Replace("К", "K");
            OutputString = OutputString.Replace("Қ", "Q");
            OutputString = OutputString.Replace("Ҟ", "Q");
            OutputString = OutputString.Replace("Ҡ", "K");
            OutputString = OutputString.Replace("Ӄ", "Q");
            OutputString = OutputString.Replace("Ҝ", "K");
            OutputString = OutputString.Replace("Л", "L");
            OutputString = OutputString.Replace("Ӆ", "L");
            OutputString = OutputString.Replace("Љ", "L");
            OutputString = OutputString.Replace("М", "M");
            OutputString = OutputString.Replace("Ӎ", "M");
            OutputString = OutputString.Replace("Н", "N");
            OutputString = OutputString.Replace("Ӊ", "N");
            OutputString = OutputString.Replace("Ң", "N");
            OutputString = OutputString.Replace("Ӈ", "N");
            OutputString = OutputString.Replace("Ҥ", "N");
            OutputString = OutputString.Replace("Њ", "N");
            OutputString = OutputString.Replace("О", "O");
            OutputString = OutputString.Replace("Ӧ", "O");
            OutputString = OutputString.Replace("Ө", "O");
            OutputString = OutputString.Replace("Ӫ", "O");
            OutputString = OutputString.Replace("Ҩ", "O");
            OutputString = OutputString.Replace("П", "P");
            OutputString = OutputString.Replace("Ҧ", "PF");
            OutputString = OutputString.Replace("Р", "P");
            OutputString = OutputString.Replace("Ҏ", "P");
            OutputString = OutputString.Replace("С", "S");
            OutputString = OutputString.Replace("Ҫ", "S");
            OutputString = OutputString.Replace("Т", "T");
            OutputString = OutputString.Replace("Ҭ", "TH");
            OutputString = OutputString.Replace("Ћ", "T");
            OutputString = OutputString.Replace("Ќ", "K");
            OutputString = OutputString.Replace("У", "U");
            OutputString = OutputString.Replace("Ў", "U");
            OutputString = OutputString.Replace("Ӳ", "U");
            OutputString = OutputString.Replace("Ӱ", "U");
            OutputString = OutputString.Replace("Ӯ", "U");
            OutputString = OutputString.Replace("Ү", "U");
            OutputString = OutputString.Replace("Ұ", "U");
            OutputString = OutputString.Replace("Ф", "F");
            OutputString = OutputString.Replace("Х", "H");
            OutputString = OutputString.Replace("Ҳ", "H");
            OutputString = OutputString.Replace("Һ", "H");
            OutputString = OutputString.Replace("Ц", "TS");
            OutputString = OutputString.Replace("Ҵ", "TS");
            OutputString = OutputString.Replace("Ч", "CH");
            OutputString = OutputString.Replace("Ӵ", "CH");
            OutputString = OutputString.Replace("Ҷ", "CH");
            OutputString = OutputString.Replace("Ӌ", "CH");
            OutputString = OutputString.Replace("Ҹ", "CH");
            OutputString = OutputString.Replace("Џ", "DZ");
            OutputString = OutputString.Replace("Ш", "SH");
            OutputString = OutputString.Replace("Щ", "SHT");
            OutputString = OutputString.Replace("Ъ", "A");
            OutputString = OutputString.Replace("Ы", "Y");
            OutputString = OutputString.Replace("Ӹ", "Y");
            OutputString = OutputString.Replace("Ь", "Y");
            OutputString = OutputString.Replace("Ҍ", "Y");
            OutputString = OutputString.Replace("Э", "E");
            OutputString = OutputString.Replace("Ӭ", "E");
            OutputString = OutputString.Replace("Ю", "YU");
            OutputString = OutputString.Replace("Я", "YA");
            OutputString = OutputString.Replace("а", "a");
            OutputString = OutputString.Replace("ӑ", "a");
            OutputString = OutputString.Replace("ӓ", "a");
            OutputString = OutputString.Replace("ә", "e");
            OutputString = OutputString.Replace("ӛ", "e");
            OutputString = OutputString.Replace("ӕ", "e");
            OutputString = OutputString.Replace("б", "b");
            OutputString = OutputString.Replace("в", "v");
            OutputString = OutputString.Replace("г", "g");
            OutputString = OutputString.Replace("ґ", "g");
            OutputString = OutputString.Replace("ѓ", "g");
            OutputString = OutputString.Replace("ғ", "g");
            OutputString = OutputString.Replace("ӷ", "g");
            OutputString = OutputString.Replace("y", "y");
            OutputString = OutputString.Replace("д", "d");
            OutputString = OutputString.Replace("е", "e");
            OutputString = OutputString.Replace("ѐ", "e");
            OutputString = OutputString.Replace("ё", "yo");
            OutputString = OutputString.Replace("ӗ", "e");
            OutputString = OutputString.Replace("ҽ", "e");
            OutputString = OutputString.Replace("ҿ", "e");
            OutputString = OutputString.Replace("є", "ye");
            OutputString = OutputString.Replace("ж", "zh");
            OutputString = OutputString.Replace("ӂ", "dzh");
            OutputString = OutputString.Replace("җ", "zh");
            OutputString = OutputString.Replace("ӝ", "dzh");
            OutputString = OutputString.Replace("з", "z");
            OutputString = OutputString.Replace("ҙ", "z");
            OutputString = OutputString.Replace("ӟ", "dz");
            OutputString = OutputString.Replace("ӡ", "dz");
            OutputString = OutputString.Replace("ѕ", "dz");
            OutputString = OutputString.Replace("и", "i");
            OutputString = OutputString.Replace("ѝ", "i");
            OutputString = OutputString.Replace("ӥ", "i");
            OutputString = OutputString.Replace("ӣ", "i");
            OutputString = OutputString.Replace("і", "i");
            OutputString = OutputString.Replace("ї", "ji");
            OutputString = OutputString.Replace("Ӏ", "i");
            OutputString = OutputString.Replace("й", "y");
            OutputString = OutputString.Replace("ҋ", "y");
            OutputString = OutputString.Replace("ј", "j");
            OutputString = OutputString.Replace("к", "k");
            OutputString = OutputString.Replace("қ", "q");
            OutputString = OutputString.Replace("ҟ", "q");
            OutputString = OutputString.Replace("ҡ", "k");
            OutputString = OutputString.Replace("ӄ", "q");
            OutputString = OutputString.Replace("ҝ", "k");
            OutputString = OutputString.Replace("л", "l");
            OutputString = OutputString.Replace("ӆ", "l");
            OutputString = OutputString.Replace("љ", "l");
            OutputString = OutputString.Replace("м", "m");
            OutputString = OutputString.Replace("ӎ", "m");
            OutputString = OutputString.Replace("н", "n");
            OutputString = OutputString.Replace("ӊ", "n");
            OutputString = OutputString.Replace("ң", "n");
            OutputString = OutputString.Replace("ӈ", "n");
            OutputString = OutputString.Replace("ҥ", "n");
            OutputString = OutputString.Replace("њ", "n");
            OutputString = OutputString.Replace("о", "o");
            OutputString = OutputString.Replace("ӧ", "o");
            OutputString = OutputString.Replace("ө", "o");
            OutputString = OutputString.Replace("ӫ", "o");
            OutputString = OutputString.Replace("ҩ", "o");
            OutputString = OutputString.Replace("п", "p");
            OutputString = OutputString.Replace("ҧ", "pf");
            OutputString = OutputString.Replace("р", "p");
            OutputString = OutputString.Replace("ҏ", "p");
            OutputString = OutputString.Replace("с", "s");
            OutputString = OutputString.Replace("ҫ", "s");
            OutputString = OutputString.Replace("т", "t");
            OutputString = OutputString.Replace("ҭ", "th");
            OutputString = OutputString.Replace("ћ", "t");
            OutputString = OutputString.Replace("ќ", "k");
            OutputString = OutputString.Replace("у", "u");
            OutputString = OutputString.Replace("ў", "u");
            OutputString = OutputString.Replace("ӳ", "u");
            OutputString = OutputString.Replace("ӱ", "u");
            OutputString = OutputString.Replace("ӯ", "u");
            OutputString = OutputString.Replace("ү", "u");
            OutputString = OutputString.Replace("ұ", "u");
            OutputString = OutputString.Replace("ф", "f");
            OutputString = OutputString.Replace("х", "h");
            OutputString = OutputString.Replace("ҳ", "h");
            OutputString = OutputString.Replace("һ", "h");
            OutputString = OutputString.Replace("ц", "ts");
            OutputString = OutputString.Replace("ҵ", "ts");
            OutputString = OutputString.Replace("ч", "ch");
            OutputString = OutputString.Replace("ӵ", "ch");
            OutputString = OutputString.Replace("ҷ", "ch");
            OutputString = OutputString.Replace("ӌ", "ch");
            OutputString = OutputString.Replace("ҹ", "ch");
            OutputString = OutputString.Replace("џ", "dz");
            OutputString = OutputString.Replace("ш", "sh");
            OutputString = OutputString.Replace("щ", "sht");
            OutputString = OutputString.Replace("ъ", "a");
            OutputString = OutputString.Replace("ы", "y");
            OutputString = OutputString.Replace("ӹ", "y");
            OutputString = OutputString.Replace("ь", "y");
            OutputString = OutputString.Replace("ҍ", "y");
            OutputString = OutputString.Replace("э", "e");
            OutputString = OutputString.Replace("ӭ", "e");
            OutputString = OutputString.Replace("ю", "yu");
            OutputString = OutputString.Replace("я", "ya");
            OutputString = OutputString.ToLowerInvariant();
            OutputString = GetUTF8String(OutputString);
            return OutputString;
        }

        public static string GetUTF8String(string InputString)
        {
            string OutputString = "";
            if (InputString != null)
            {
                OutputString = InputString;
                byte[] bytes = Encoding.Default.GetBytes(OutputString);
                OutputString = Encoding.UTF8.GetString(bytes);
                OutputString = OutputString.Replace("?", "");
            }
            return OutputString;
        }

        public static string GetPrestaShopName(string InputString)
        {
            string OutputString = "";
            if (InputString != null)
            {
                OutputString = InputString;
                OutputString = OutputString.Replace("&amp;amp;", "&");
                OutputString = OutputString.Replace("&amp;", "&");
                OutputString = OutputString.Replace("# ", "");
                OutputString = OutputString.Replace("#", "");
                OutputString = OutputString.Replace("¿", "");
                OutputString = OutputString.Replace("?", "");
                OutputString = OutputString.Replace(";", "");
            }
            return OutputString;
        }

        public static string GetPrestaShopDescriptionShort(string InputString)
        {
            string OutputString = "";
            if (InputString != null)
            {
                OutputString = InputString;
                if (OutputString.Length > 800)
                {
                    OutputString = OutputString.Substring(0, 796);
                    OutputString += "...";
                }
            }
            return OutputString;
        }

        public static string GetPrestaShopMetaDescription(string InputString)
        {
            string OutputString = "";
            if (InputString != null)
            {
                OutputString = InputString;
                if (OutputString.Length > 255)
                {
                    OutputString = OutputString.Substring(0, 251);
                    OutputString += "...";
                }
            }
            return OutputString;
        }

        public static decimal GetPrestaShopPrice(decimal value)
        {
            return Functions.TruncateDecimal(Math.Round(value, 2, MidpointRounding.AwayFromZero), 2);
        }

        private static decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            int tmp = (int)Math.Truncate(step * value);
            return tmp / step;
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
