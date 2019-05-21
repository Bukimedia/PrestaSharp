using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class image : PrestaShopEntity
    {
        public long id { get; set; }
        public long? id_product { get; set; }
        public int? position { get; set; }
        public int? cover { get; set; }

        public List<Entities.AuxEntities.language> legend { get; set; }
        //        <id_product><![CDATA[1]]></id_product>
        //<position><![CDATA[1]]></position>
        //<cover><![CDATA[1]]></cover>
        //<legend><language id = "1" xlink:href="https://shop.spaziobattibaleno.it/api/languages/1"><![CDATA[]]></language><language id = "2" xlink:href="https://shop.spaziobattibaleno.it/api/languages/2"><![CDATA[]]></language></legend>
        //</image>
        public image()
        {
        }
    }
}