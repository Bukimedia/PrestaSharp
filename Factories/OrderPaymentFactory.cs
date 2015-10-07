using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderPaymentFactory : RestSharpFactory
    {
        public OrderPaymentFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.order_payment Get(long OrderPaymentId)
        {
            RestRequest request = this.RequestForGet("order_payments", OrderPaymentId, "order_payment");
            return this.Execute<Entities.order_payment>(request);
        }

        public Entities.order_payment Add(Entities.order_payment OrderPayment)
        {
            long? idAux = OrderPayment.id;
            OrderPayment.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(OrderPayment);
            RestRequest request = this.RequestForAdd("order_payments", Entities);
            Entities.order_payment aux = this.Execute<Entities.order_payment>(request);
            OrderPayment.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.order_payment OrderPayment)
        {
            RestRequest request = this.RequestForUpdate("order_payments", OrderPayment.id, OrderPayment);
            this.Execute<Entities.order_payment>(request);
        }

        public void Delete(long OrderPaymentId)
        {
            RestRequest request = this.RequestForDelete("order_payments", OrderPaymentId);
            this.Execute<Entities.order_payment>(request);
        }

        public void Delete(Entities.order_payment OrderPayment)
        {
            this.Delete((long)OrderPayment.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("order_payments", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "order_payment");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.order_payment> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("order_payments", "full", Filter, Sort, Limit, "order_payments");
            return this.ExecuteForFilter<List<Entities.order_payment>>(request);
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
            RestRequest request = this.RequestForFilter("order_payments", "[id]", Filter, Sort, Limit, "order_payments");
            List<PrestaSharp.Entities.FilterEntities.order_payment> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.order_payment>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all order_payments.
        /// </summary>
        /// <returns>A list of order_payments</returns>
        public List<Entities.order_payment> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of order_payments.
        /// </summary>
        /// <param name="OrderPayments"></param>
        /// <returns></returns>
        public List<Entities.order_payment> AddList(List<Entities.order_payment> OrderPayments)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.order_payment OrderPayment in OrderPayments)
            {
                OrderPayment.id = null;
                Entities.Add(OrderPayment);
            }
            RestRequest request = this.RequestForAdd("order_payments", Entities);
            return this.Execute<List<Entities.order_payment>>(request);
        }        
    }
}
