using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomerThreadFactory : RestSharpFactory
    {
        public CustomerThreadFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.customer_thread Get(long CustomerThreadId)
        {
            RestRequest request = this.RequestForGet("customer_threads", CustomerThreadId, "customer_thread");
            return this.Execute<Entities.customer_thread>(request);
        }

        public Entities.customer_thread Add(Entities.customer_thread CustomerThread)
        {
            long? idAux = CustomerThread.id;
            CustomerThread.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(CustomerThread);
            RestRequest request = this.RequestForAdd("customer_threads", Entities);
            Entities.customer_thread aux = this.Execute<Entities.customer_thread>(request);
            CustomerThread.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.customer_thread CustomerThread)
        {
            RestRequest request = this.RequestForUpdate("customer_threads", CustomerThread.id, CustomerThread);
            this.Execute<Entities.customer_thread>(request);
        }

        public void Delete(long CustomerThreadId)
        {
            RestRequest request = this.RequestForDelete("customer_threads", CustomerThreadId);
            this.Execute<Entities.customer_thread>(request);
        }

        public void Delete(Entities.customer_thread CustomerThread)
        {
            this.Delete((long)CustomerThread.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("customer_threads", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "customer_thread");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.customer_thread> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("customer_threads", "full", Filter, Sort, Limit, "customer_threads");
            return this.ExecuteForFilter<List<Entities.customer_thread>>(request);
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
            RestRequest request = this.RequestForFilter("customer_threads", "[id]", Filter, Sort, Limit, "customer_threads");
            List<PrestaSharp.Entities.FilterEntities.customer_thread> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.customer_thread>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all customer_threads.
        /// </summary>
        /// <returns>A list of customer_threads</returns>
        public List<Entities.customer_thread> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of customer_threads.
        /// </summary>
        /// <param name="CustomerThreads"></param>
        /// <returns></returns>
        public List<Entities.customer_thread> AddList(List<Entities.customer_thread> CustomerThreads)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.customer_thread CustomerThread in CustomerThreads)
            {
                CustomerThread.id = null;
                Entities.Add(CustomerThread);
            }
            RestRequest request = this.RequestForAdd("customer_threads", Entities);
            return this.Execute<List<Entities.customer_thread>>(request);
        }
    }
}
