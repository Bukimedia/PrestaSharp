using Bukimedia.PrestaSharp.Entities.AuxEntities;
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
    public class attachment : PrestaShopEntity
    {
        public long id { get; set; }
        public string file { get; set; }
        public string file_name { get; set; }
        public long file_size { get; set; }
        public string mime { get; set; }
        public List<AuxEntities.language> name { get; set; }
        public List<AuxEntities.language> description { get; set; }
        public AssociationsAttachments associations { get; set; }

        public attachment()
        {
        }
    }
}