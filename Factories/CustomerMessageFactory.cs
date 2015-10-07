using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomerMessageFactory : RestSharpFactory
    {
        public CustomerMessageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.customer_message Get(long CustomerMessageId)
        {
            RestRequest request = this.RequestForGet("customer_messages", CustomerMessageId, "customer_message");
            return this.Execute<Entities.customer_message>(request);
        }

        public Entities.customer_message Add(Entities.customer_message CustomerMessage)
        {
            long? idAux = CustomerMessage.id;
            CustomerMessage.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(CustomerMessage);
            RestRequest request = this.RequestForAdd("customer_messages", Entities);
            Entities.customer_message aux = this.Execute<Entities.customer_message>(request);
            CustomerMessage.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.customer_message CustomerMessage)
        {
            RestRequest request = this.RequestForUpdate("customer_messages", CustomerMessage.id, CustomerMessage);
            this.Execute<Entities.customer_message>(request);
        }

        public void Delete(long CustomerMessageId)
        {
            RestRequest request = this.RequestForDelete("customer_messages", CustomerMessageId);
            this.Execute<Entities.customer_message>(request);
        }

        public void Delete(Entities.customer_message CustomerMessage)
        {
            this.Delete((long)CustomerMessage.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("customer_messages", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "customer_message");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.customer_message> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("customer_messages", "full", Filter, Sort, Limit, "customer_messages");
            return this.ExecuteForFilter<List<Entities.customer_message>>(request);
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
            RestRequest request = this.RequestForFilter("customer_messages", "[id]", Filter, Sort, Limit, "customer_messages");
            List<PrestaSharp.Entities.FilterEntities.customer_message> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.customer_message>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all customer_messages.
        /// </summary>
        /// <returns>A list of customer_messages</returns>
        public List<Entities.customer_message> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of customer_messages.
        /// </summary>
        /// <param name="CustomerMessages"></param>
        /// <returns></returns>
        public List<Entities.customer_message> AddList(List<Entities.customer_message> CustomerMessages)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.customer_message CustomerMessage in CustomerMessages)
            {
                CustomerMessage.id = null;
                Entities.Add(CustomerMessage);
            }
            RestRequest request = this.RequestForAdd("customer_messages", Entities);
            return this.Execute<List<Entities.customer_message>>(request);
        }
    }
}
