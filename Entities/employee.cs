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

        //<bo_color></bo_color>
        //<default_tab><![CDATA[1]]></default_tab>
        //<bo_theme><![CDATA[default]]></bo_theme>
        //<bo_css><![CDATA[admin-theme.css]]></bo_css>
        //<bo_width><![CDATA[0]]></bo_width>
        //<bo_menu><![CDATA[1]]></bo_menu>
        //<stats_compare_option><![CDATA[1]]></stats_compare_option>
        //<preselect_date_range></preselect_date_range>
        //<id_last_order><![CDATA[0]]></id_last_order>
        //<id_last_customer_message><![CDATA[0]]></id_last_customer_message>
        //<id_last_customer><![CDATA[0]]></id_last_customer>

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
