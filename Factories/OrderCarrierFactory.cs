using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderCarrierFactory : RestSharpFactory
    {
        public OrderCarrierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.order_carrier Get(long OrderCarrierId)
        {
            RestRequest request = this.RequestForGet("order_carriers", OrderCarrierId, "order_carrier");
            return this.Execute<Entities.order_carrier>(request);
        }

        public Entities.order_carrier Add(Entities.order_carrier OrderCarrier)
        {
            long? idAux = OrderCarrier.id;
            OrderCarrier.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(OrderCarrier);
            RestRequest request = this.RequestForAdd("order_carriers", Entities);
            Entities.order_carrier aux = this.Execute<Entities.order_carrier>(request);
            OrderCarrier.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.order_carrier OrderCarrier)
        {
            RestRequest request = this.RequestForUpdate("order_carriers", OrderCarrier.id, OrderCarrier);
            this.Execute<Entities.order_carrier>(request);
        }

        public void Delete(long OrderCarrierId)
        {
            RestRequest request = this.RequestForDelete("order_carriers", OrderCarrierId);
            this.Execute<Entities.order_carrier>(request);
        }

        public void Delete(Entities.order_carrier OrderCarrier)
        {
            this.Delete((long)OrderCarrier.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("order_carriers", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "order_carrier");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.order_carrier> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("order_carriers", "full", Filter, Sort, Limit, "order_carriers");
            return this.ExecuteForFilter<List<Entities.order_carrier>>(request);
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
            RestRequest request = this.RequestForFilter("order_carriers", "[id]", Filter, Sort, Limit, "order_carriers");
            List<PrestaSharp.Entities.FilterEntities.order_carrier> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.order_carrier>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all order_carriers.
        /// </summary>
        /// <returns>A list of order_carriers</returns>
        public List<Entities.order_carrier> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of order_carriers.
        /// </summary>
        /// <param name="OrderCarriers"></param>
        /// <returns></returns>
        public List<Entities.order_carrier> AddList(List<Entities.order_carrier> OrderCarriers)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.order_carrier OrderCarrier in OrderCarriers)
            {
                OrderCarrier.id = null;
                Entities.Add(OrderCarrier);
            }
            RestRequest request = this.RequestForAdd("order_carriers", Entities);
            return this.Execute<List<Entities.order_carrier>>(request);
        }        
    }
}
