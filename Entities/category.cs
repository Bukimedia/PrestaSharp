using Bukimedia.PrestaSharp.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class category : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_parent { get; set; }
        public long id_shop_default { get; set; }
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
        public List<Entities.AuxEntities.language> name { get; set; }
        public List<Entities.AuxEntities.language> link_rewrite { get; set; }
        public List<Entities.AuxEntities.language> description { get; set; }
        public List<Entities.AuxEntities.language> meta_title { get; set; }
        public List<Entities.AuxEntities.language> meta_description { get; set; }
        public List<Entities.AuxEntities.language> meta_keywords { get; set; }
        public AuxEntities.AssociationsCategory associations { get; set; }

        public category()
        {
            this.name = new List<AuxEntities.language>();
            this.link_rewrite = new List<AuxEntities.language>();
            this.description = new List<AuxEntities.language>();
            this.meta_title = new List<AuxEntities.language>();
            this.meta_description = new List<AuxEntities.language>();
            this.meta_keywords = new List<AuxEntities.language>();
            this.associations = new AuxEntities.AssociationsCategory();
        }

        public void AddName(Entities.AuxEntities.language Language)
        {
            Language.Value = Functions.GetPrestaShopName(Language.Value);
            lock (this.name)
            {
                this.name.Add(Language);
            }
        }
        public void AddLinkRewrite(Entities.AuxEntities.language Language)
        {
            Language.Value = Functions.GetLinkRewrite(Language.Value);
            lock (this.link_rewrite)
            {
                this.link_rewrite.Add(Language);
            }
        }

        public void AddDescription(Entities.AuxEntities.language Language)
        {
            lock (this.description)
            {
                this.description.Add(Language);
            }
        }

        public void AddMetaTitle(Entities.AuxEntities.language Language)
        {
            lock (this.meta_title)
            {
                this.meta_title.Add(Language);
            }
        }

        public void AddMetaDescription(Entities.AuxEntities.language Language)
        {
            lock (this.meta_description)
            {
                this.meta_description.Add(Language);
            }
        }

        public void AddMetaKeywords(Entities.AuxEntities.language Language)
        {
            lock (this.meta_keywords)
            {
                this.meta_keywords.Add(Language);
            }
        }
    }
}
