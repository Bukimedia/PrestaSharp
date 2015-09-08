using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderCartRuleFactory : RestSharpFactory
    {
        public OrderCartRuleFactory(string BaseUrl, string Account, string SecretKey) 
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.order_cart_rule Get(long OrderCartRuleId)
        {
            RestRequest request = this.RequestForGet("order_discounts", OrderCartRuleId, "order_cart_rule");
            return this.Execute<Entities.order_cart_rule>(request);
        }

        public Entities.order_cart_rule Add(Entities.order_cart_rule OrderCartRule)
        {
            long? idAux = OrderCartRule.id; OrderCartRule.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(OrderCartRule); RestRequest request = this.RequestForAdd("order_discounts", Entities);
            Entities.order_cart_rule aux = this.Execute<Entities.order_cart_rule>(request);
            OrderCartRule.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.order_cart_rule OrderCartRule)
        {
            RestRequest request = this.RequestForUpdate("order_discounts", OrderCartRule.id, OrderCartRule);
            this.Execute<Entities.order_cart_rule>(request);
        }

        public void Delete(long OrderCartRuleId)
        {
            RestRequest request = this.RequestForDelete("order_discounts", OrderCartRuleId);
            this.Execute<Entities.order_cart_rule>(request);
        }

        public void Delete(Entities.order_cart_rule OrderCartRule)
        {
            this.Delete((long)OrderCartRule.id);
        }
        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("order_discounts", null, "order_cart_rules");
            return this.ExecuteForGetIds<List<long>>(request, "order_cart_rule");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use 
        /// </summary> 
        /// <param name="Filter">Example: key:name value:Apple</param> 
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param> 
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns> 
        public List<Entities.order_cart_rule> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("order_discounts", "full", Filter, Sort, Limit, "order_cart_rules");
            return this.ExecuteForFilter<List<Entities.order_cart_rule>>(request);
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
            RestRequest request = this.RequestForFilter("order_discounts", "[id]", Filter, Sort, Limit, "order_cart_rules");
            List<PrestaSharp.Entities.FilterEntities.order_cart_rule> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.order_cart_rule>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all order_discounts. 
        /// </summary> 
        /// <returns>A list of order_discounts</returns> 
        public List<Entities.order_cart_rule> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary> 
        /// Add a list of order_discounts. 
        /// </summary> 
        /// <param name="OrderStates"></param> 
        /// <returns></returns> 
        public List<Entities.order_cart_rule> AddList(List<Entities.order_cart_rule> OrderCartRules)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.order_cart_rule OrderCartRule in OrderCartRules)
            {
                OrderCartRule.id = null; Entities.Add(OrderCartRule);
            }
            RestRequest request = this.RequestForAdd("order_discounts", Entities); return this.Execute<List<Entities.order_cart_rule>>(request);
        }
    }
}