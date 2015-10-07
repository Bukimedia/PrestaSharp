using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class TagFactory : RestSharpFactory
    {
        public TagFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.tag Get(long TagId)
        {
            RestRequest request = this.RequestForGet("tags", TagId, "tag");
            return this.Execute<Entities.tag>(request);
        }

        public Entities.tag Add(Entities.tag Tag)
        {
            long? idAux = Tag.id;
            Tag.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Tag);
            RestRequest request = this.RequestForAdd("tags", Entities);
            Entities.tag aux = this.Execute<Entities.tag>(request);
            Tag.id = idAux;
            return this.Get((long)aux.id);
        }
        
        public void Update(Entities.tag Tag)
        {
            RestRequest request = this.RequestForUpdate("tags", Tag.id, Tag);
            this.Execute<Entities.tag>(request);
        }

        public void Delete(long TagId)
        {
            RestRequest request = this.RequestForDelete("tags", TagId);
            this.Execute<Entities.tag>(request);
        }

        public void Delete(Entities.tag Tag)
        {
            this.Delete((long)Tag.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("tags", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "tag");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.tag> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("tags", "full", Filter, Sort, Limit, "tags");
            return this.ExecuteForFilter<List<Entities.tag>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("tags", "[id]", Filter, Sort, Limit, "tags");
            List<PrestaSharp.Entities.FilterEntities.tag> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.tag>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all tags.
        /// </summary>
        /// <returns>A list of tags</returns>
        public List<Entities.tag> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of tags.
        /// </summary>
        /// <param name="Tags"></param>
        /// <returns></returns>
        public List<Entities.tag> AddList(List<Entities.tag> Tags)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.tag Tag in Tags)
            {
                Tag.id = null;
                Entities.Add(Tag);
            }
            RestRequest request = this.RequestForAdd("tags", Entities);
            return this.Execute<List<Entities.tag>>(request);
        }
    }
}
