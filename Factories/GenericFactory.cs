using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Factories
{
    public abstract class GenericFactory<T> : RestSharpFactory where T : PrestaShopEntity, IPrestaShopFactoryEntity, new()
    {
        protected abstract string singularEntityName { get; }
        protected abstract string pluralEntityName { get; }

        public GenericFactory(string BaseUrl, string Account, string Password) : base(BaseUrl, Account, Password)
        {
        }

        public GenericFactory()
        {

        }

        public T Get(long id)
        {
            RestRequest request = this.RequestForGet(pluralEntityName, id, singularEntityName);
            return this.Execute<T>(request);
        }

        public T Add(T Entity)
        {
            long? idAux = Entity.id;
            Entity.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Entity);
            RestRequest request = this.RequestForAdd(pluralEntityName, Entities);
            T aux = this.Execute<T>(request);
            Entity.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(T Entity)
        {
            RestRequest request = this.RequestForUpdate(pluralEntityName, Entity.id, Entity);
            this.Execute<T>(request);
        }

        public List<T> UpdateList(List<T> Entities)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> EntitiesToAdd = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (T Entity in Entities)
            {
                EntitiesToAdd.Add(Entity);
            }

            RestRequest request = this.RequestForUpdateList(singularEntityName, EntitiesToAdd);

            return this.Execute<List<T>>(request);
        }

        public void Delete(long id)
        {
            RestRequest request = this.RequestForDelete(pluralEntityName, id);
            this.Execute<T>(request);
        }

        public void Delete(T Entity)
        {
            this.Delete((long)Entity.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet(pluralEntityName, null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, singularEntityName);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<T> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter(pluralEntityName, "full", Filter, Sort, Limit, pluralEntityName);
            return this.ExecuteForFilter<List<T>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param> 
        /// <param name="Display">Fields to display Example: ["id", "reference"]</param>
        /// <returns></returns>
        public List<T> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit, List<string> Display)
        {
            string disp = FilterFactory.DispalyToString(Display);
            RestRequest request = this.RequestForFilter(pluralEntityName, disp, Filter, Sort, Limit, pluralEntityName);
            return this.ExecuteForFilter<List<T>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<T> GetByFilter(FilterFactory filter)
        {
            RestRequest request = this.RequestForFilter(
                                    pluralEntityName,
                                    filter,
                                    pluralEntityName
                                  );
            return this.ExecuteForFilter<List<T>>(request);
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
            RestRequest request = this.RequestForFilter(pluralEntityName, "[id]", Filter, Sort, Limit, pluralEntityName);
            List<T> aux = this.Execute<List<T>>(request);
            return (from t in aux where t.id.HasValue select t.id.Value).ToList();
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// Display in FilterFactory doesn't apply to this Method, 
        /// because allways display field id
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>        
        public List<long> GetIdsByFilter(FilterFactory filter)
        {
            RestRequest request = this.RequestForFilter(
                                    pluralEntityName,
                                    "[id]",
                                    filter.Filter,
                                    filter.Sort,
                                    filter.Limit,
                                    pluralEntityName
                                   );
            List<T> aux = this.Execute<List<T>>(request);
            return (from t in aux where t.id.HasValue select t.id.Value).ToList();
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>A list of entities</returns>
        public List<T> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of entities.
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public List<T> AddList(List<T> Entities)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> EntitiesToAdd = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (T Entity in Entities)
            {
                Entity.id = null;
                Entities.Add(Entity);
            }
            RestRequest request = this.RequestForAdd(pluralEntityName, EntitiesToAdd);
            return this.Execute<List<T>>(request);
        }

        /// <summary>
        /// Verify if the Item exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(long id)
        {
            Dictionary<string, string> filter = new Dictionary<string, string>();
            filter.Add("id", id.ToString());
            return this.GetByFilter(filter, "id_asc", "1").Count == 0
                ? false : true;
        }
        
    }
}
