using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    public class manufacturer:prestashopentity
    {
        public int? id { get; set; }
        public name name { get; set; }
        public DateTime date_add { get; set; }
        public DateTime date_upd { get; set; }
        public int active { get; set; }
        public List<Entities.language> description { get; set; }
        public List<Entities.language> short_description { get; set; }
        public List<Entities.language> meta_title { get; set; }
        public List<Entities.language> meta_description { get; set; }
        public List<Entities.language> meta_keywords { get; set; }
        public associations associations { get; set; }
    }
}
