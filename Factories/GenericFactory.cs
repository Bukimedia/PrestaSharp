using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class GenericFactory<T> : RestSharpFactory where T : PrestaShopEntity, new() 
    {
        protected string Resource { get; set; }
        protected string RootElement { get; set; }
        protected string RootElementPlural { get; set; }
        public GenericFactory(string BaseUrl, string Account, string Password, string resource = "", string rootelement = "", string rootelementplural = "", bool PerformGetAfterAdd = true) 
            : base(BaseUrl, Account, Password, PerformGetAfterAdd)
        {
            this.Resource = resource;
            this.RootElement = rootelement;
            this.RootElementPlural = rootelementplural;
        }

        public T Add(T entity)
        {
            entity.id = null;
            var Entities = new List<PrestaShopEntity>() { entity };
            var request = this.RequestForAdd(this.Resource, Entities);
            var aux = this.Execute<T>(request);
            if (!PerformGetAfterAdd)
            {
                entity.id = aux.id;
                return entity;
            }
            return this.Get(aux.id);
        }

        public T Get(long? id)
        {
            var request = this.RequestForGet(this.Resource, id, this.RootElement);
            return this.Execute<T>(request);
        }

        public void Update(T entity)
        {
            var request = this.RequestForUpdate(this.Resource, entity.id, entity);
            this.Execute<T>(request);
        }

        public void Delete(long id)
        {
            var request = this.RequestForDelete(this.Resource, id);
            this.Execute<T>(request);
        }

        public void Delete(T entity)
        {
            if (entity.id != null) this.Delete((long)entity.id);
        }

        public List<long> GetIds()
        {
            var request = this.RequestForGet(this.Resource, null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, this.RootElement);
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
            var request = this.RequestForFilter(this.Resource, "full", Filter, Sort, Limit, this.RootElementPlural);
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
            var request = this.RequestForFilter(this.Resource, "[id]", Filter, Sort, Limit, this.RootElementPlural);
            //var aux = this.Execute<List<T>>(request);
            return this.ExecuteForGetIds<List<long>>(request, this.RootElement);
            //return aux.Where(x => x.id.HasValue).Select(x => x.id.Value).ToList();
        }
        public List<T> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of T.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<T> AddList(List<T> entities)
        {
            entities.ForEach(x => x.id = null);
            var request = this.RequestForAdd<T>(this.Resource, entities);
            return this.Execute<List<T>>(request);
        }
    }
}
