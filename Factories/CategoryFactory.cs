using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CategoryFactory : RestSharpFactory
    {
        public CategoryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.category Get(long CategoryId)
        {
            RestRequest request = this.RequestForGet("categories", CategoryId, "category");
            return this.Execute<Entities.category>(request);
        }

        public Entities.category Add(Entities.category Category)
        {
            long? idAux = Category.id;
            Category.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Category);
            RestRequest request = this.RequestForAdd("categories", Entities);
            Entities.category aux = this.Execute<Entities.category>(request);
            Category.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.category Category)
        {
            RestRequest request = this.RequestForUpdate("categories", Category.id, Category);
            this.Execute<Entities.category>(request);
        }

        public void Delete(long CategoryId)
        {
            RestRequest request = this.RequestForDelete("categories", CategoryId);
            this.Execute<Entities.category>(request);
        }

        public void Delete(Entities.category Category)
        {
            this.Delete((long)Category.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("categories", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "category");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.category> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("categories", "full", Filter, Sort, Limit, "categories");
            return this.ExecuteForFilter<List<Entities.category>>(request);
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
            RestRequest request = this.RequestForFilter("categories", "[id]", Filter, Sort, Limit, "categories");
            List<PrestaSharp.Entities.FilterEntities.category> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.category>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>A list of categories</returns>
        public List<Entities.category> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of categories.
        /// </summary>
        /// <param name="Categories"></param>
        /// <returns></returns>
        public List<Entities.category> AddList(List<Entities.category> Categories)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.category Category in Categories)
            {
                Category.id = null;
                Entities.Add(Category);
            }
            RestRequest request = this.RequestForAdd("categories", Entities);
            return this.Execute<List<Entities.category>>(request);
        }
    }
}
