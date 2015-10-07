using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderStateFactory : RestSharpFactory
    {
        public OrderStateFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.order_state Get(long OrderStateId)
        {
            RestRequest request = this.RequestForGet("order_states", OrderStateId, "order_state");
            return this.Execute<Entities.order_state>(request);
        }

        public Entities.order_state Add(Entities.order_state OrderState)
        {
            long? idAux = OrderState.id;
            OrderState.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(OrderState);
            RestRequest request = this.RequestForAdd("order_states", Entities);
            Entities.order_state aux = this.Execute<Entities.order_state>(request);
            OrderState.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.order_state OrderState)
        {
            RestRequest request = this.RequestForUpdate("order_states", OrderState.id, OrderState);
            this.Execute<Entities.order_state>(request);
        }

        public void Delete(long OrderStateId)
        {
            RestRequest request = this.RequestForDelete("order_states", OrderStateId);
            this.Execute<Entities.order_state>(request);
        }

        public void Delete(Entities.order_state OrderState)
        {
            this.Delete((long)OrderState.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("order_states", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "order_state");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.order_state> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("order_states", "full", Filter, Sort, Limit, "order_states");
            return this.ExecuteForFilter<List<Entities.order_state>>(request);
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
            RestRequest request = this.RequestForFilter("order_states", "[id]", Filter, Sort, Limit, "order_states");
            List<PrestaSharp.Entities.FilterEntities.order_state> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.order_state>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all order_states.
        /// </summary>
        /// <returns>A list of order_states</returns>
        public List<Entities.order_state> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of order_states.
        /// </summary>
        /// <param name="OrderStates"></param>
        /// <returns></returns>
        public List<Entities.order_state> AddList(List<Entities.order_state> OrderStates)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.order_state OrderState in OrderStates)
            {
                OrderState.id = null;
                Entities.Add(OrderState);
            }
            RestRequest request = this.RequestForAdd("order_states", Entities);
            return this.Execute<List<Entities.order_state>>(request);
        }        
    }
}
