using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderHistoryFactory : RestSharpFactory
    {
        public OrderHistoryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.order_history Get(long OrderHistoryId)
        {
            RestRequest request = this.RequestForGet("order_histories", OrderHistoryId, "order_history");
            return this.Execute<Entities.order_history>(request);
        }

        public Entities.order_history Add(Entities.order_history OrderHistory)
        {
            long? idAux = OrderHistory.id;
            OrderHistory.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(OrderHistory);
            RestRequest request = this.RequestForAddOrderHistory("order_histories", Entities);
            Entities.order_history aux = this.Execute<Entities.order_history>(request);
            OrderHistory.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.order_history OrderHistory)
        {
            RestRequest request = this.RequestForUpdate("order_histories", OrderHistory.id, OrderHistory);
            this.Execute<Entities.order_history>(request);
        }

        public void Delete(long OrderHistoryId)
        {
            RestRequest request = this.RequestForDelete("order_histories", OrderHistoryId);
            this.Execute<Entities.order_history>(request);
        }

        public void Delete(Entities.order_history OrderHistory)
        {
            this.Delete((long)OrderHistory.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("order_histories", null, "prestashop");
            return this.ExecuteForGetIds<long>(request, "order_history");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.order_history> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("order_histories", "full", Filter, Sort, Limit, "order_histories");
            return this.ExecuteForFilter<List<Entities.order_history>>(request);
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
            RestRequest request = this.RequestForFilter("order_histories", "[id]", Filter, Sort, Limit, "order_histories");
            List<PrestaSharp.Entities.FilterEntities.order_history> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.order_history>>(request);
            return (List<long>)(from t in aux select t.id).ToList();
        }

        /// <summary>
        /// Get all order histories.
        /// </summary>
        /// <returns>A list of order histories</returns>
        public List<Entities.order_history> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of order histories.
        /// </summary>
        /// <param name="OrderHistories"></param>
        /// <returns></returns>
        public List<Entities.order_history> AddList(List<Entities.order_history> OrderHistories)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.order_history OrderHistory in OrderHistories)
            {
                OrderHistory.id = null;
                Entities.Add(OrderHistory);
            }
            RestRequest request = this.RequestForAdd("order_histories", Entities);
            return this.Execute<List<Entities.order_history>>(request);
        }
    }
}