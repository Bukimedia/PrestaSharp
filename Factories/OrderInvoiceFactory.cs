using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderInvoiceFactory : RestSharpFactory
    {
        public OrderInvoiceFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.order_invoice Get(long OrderInvoiceId)
        {
            RestRequest request = this.RequestForGet("order_invoices", OrderInvoiceId, "order_invoice");
            return this.Execute<Entities.order_invoice>(request);
        }

        public Entities.order_invoice Add(Entities.order_invoice OrderInvoice)
        {
            long? idAux = OrderInvoice.id;
            OrderInvoice.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(OrderInvoice);
            RestRequest request = this.RequestForAddOrderHistory("order_invoices", Entities);
            Entities.order_invoice aux = this.Execute<Entities.order_invoice>(request);
            OrderInvoice.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.order_history OrderInvoice)
        {
            RestRequest request = this.RequestForUpdate("order_invoices", OrderInvoice.id, OrderInvoice);
            this.Execute<Entities.order_invoice>(request);
        }

        public void Delete(long OrderInvoiceId)
        {
            RestRequest request = this.RequestForDelete("order_invoices", OrderInvoiceId);
            this.Execute<Entities.order_history>(request);
        }

        public void Delete(Entities.order_invoice OrderInvoice)
        {
            this.Delete((long)OrderInvoice.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("order_invoices", null, "prestashop");
            return this.ExecuteForGetIds<long>(request, "order_invoice");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.order_invoice> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("order_invoices", "full", Filter, Sort, Limit, "order_invoices");
            return this.ExecuteForFilter<List<Entities.order_invoice>>(request);
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
            RestRequest request = this.RequestForFilter("order_invoices", "[id]", Filter, Sort, Limit, "order_invoices");
            List<PrestaSharp.Entities.FilterEntities.order_invoice> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.order_invoice>>(request);
            return (List<long>)(from t in aux select t.id).ToList();
        }

        /// <summary>
        /// Get all order histories.
        /// </summary>
        /// <returns>A list of order histories</returns>
        public List<Entities.order_invoice> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of order histories.
        /// </summary>
        /// <param name="OrderHistories"></param>
        /// <returns></returns>
        public List<Entities.order_invoice> AddList(List<Entities.order_invoice> OrderInvoices)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.order_invoice OrderInvoice in OrderInvoices)
            {
                OrderInvoice.id = null;
                Entities.Add(OrderInvoice);
            }
            RestRequest request = this.RequestForAdd("order_invoices", Entities);
            return this.Execute<List<Entities.order_invoice>>(request);
        }
    }
}