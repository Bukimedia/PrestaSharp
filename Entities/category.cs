using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Entities
{
    public class category : PrestashopEntity
    {
        public long? id { get; set; }
        public long? id_parent { get; set; }
        public long id_shop_default { get; set; }
        public byte level_depth { get; set; }
        public long nleft { get; set; }
        public long nright { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary
        public int active { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_upd { get; set; }
        public long position { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary
        public int is_root_category { get; set; }
        public List<Entities.language> name { get; set; }
        public List<Entities.language> link_rewrite { get; set; }
        public List<Entities.language> description { get; set; }
        public List<Entities.language> meta_title { get; set; }
        public List<Entities.language> meta_description { get; set; }
        public List<Entities.language> meta_keywords { get; set; }
        public AssociationsCategory associations { get; set; }
    }
}
