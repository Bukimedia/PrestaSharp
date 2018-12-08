using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Lib
{
    /// <summary>
    /// Static class that chaches the PrastaShop API Credencials
    /// </summary>
    internal static class Credentials
    {
        /// <summary>
        /// The Presta shop api Url
        /// Ex: http://www.myweb.com/api
        /// </summary>
        public static string BaseUrl { get; set; }

        /// <summary>
        /// Presta shop api key
        /// </summary>
        public static string Account { get; set; }

        /// <summary>
        /// Always blank???
        /// </summary>
        public static string Password = ""; 

    }
}
