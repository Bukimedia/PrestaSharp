using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bukimedia.PrestaSharp.Lib;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class employee : PrestaShopEntity
    {
        public long? id { get; set; }
        public string id_lang { get; set; }

        public string last_passwd_gen { get; set; }
        public string stats_date_from { get; set; }
        public string stats_date_to { get; set; }
        public string stats_compare_from { get; set; }
        public string stats_compare_to { get; set; }
        public string passwd { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public int active { get; set; }
        public int optin { get; set; }
        public int id_profile { get; set; }
        public string bo_color { get; set; }
        public int default_tab { get; set; }
        public string bo_theme { get; set; }
        public string bo_css { get; set; }
        public int bo_width { get; set; }
        public int bo_menu { get; set; }
        public int stats_compare_option { get; set; }
        public string preselect_date_range { get; set; }
        public int id_last_order { get; set; }
        public int id_last_customer_message { get; set; }
        public int id_last_customer { get; set; }

        public employee()
        {

        }

        public void AddLinkRewrite(Entities.AuxEntities.language Language)
        {
            Language.Value = Functions.GetLinkRewrite(Language.Value);
            //this.link_rewrite.Add(Language);
        }

        public void AddName(Entities.AuxEntities.language Language)
        {
            Language.Value = Functions.GetPrestaShopName(Language.Value);
            //this.name.Add(Language);
        }
    }
}
