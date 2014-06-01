using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomerFactory : RestSharpFactory
    {
		public CustomerFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.customer Get(long CustomerId)
        {
            RestRequest request = this.RequestForGet("customers", CustomerId, "customer");
            return this.Execute<Entities.customer>(request);
        }

        public Entities.customer Add(Entities.customer Customer)
        {
            long? idAux = Customer.id;
            Customer.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Customer);
            RestRequest request = this.RequestForAdd("customers", Entities);
            Entities.customer aux = this.Execute<Entities.customer>(request);
            Customer.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.customer Customer)
        {
            RestRequest request = this.RequestForUpdate("customers", Customer.id, Customer);
            this.Execute<Entities.customer>(request);
        }

        public void Delete(long CustomerId)
        {
            RestRequest request = this.RequestForDelete("customers", CustomerId);
            this.Execute<Entities.customer>(request);
        }

        public void Delete(Entities.customer Customer)
        {
            this.Delete((long)Customer.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("customers", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "customer");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.customer> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("customers", "full", Filter, Sort, Limit, "customers");
            return this.ExecuteForFilter<List<Entities.customer>>(request);
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
            RestRequest request = this.RequestForFilter("customers", "[id]", Filter, Sort, Limit, "customers");
            List<PrestaSharp.Entities.FilterEntities.customer> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.customer>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <returns>A list of customers</returns>
        public List<Entities.customer> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of customers.
        /// </summary>
        /// <param name="Customers"></param>
        /// <returns></returns>
        public List<Entities.customer> AddList(List<Entities.customer> Customers)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.customer Customer in Customers)
            {
                Customer.id = null;
                Entities.Add(Customer);
            }
            RestRequest request = this.RequestForAdd("customers", Entities);
            return this.Execute<List<Entities.customer>>(request);
        }        
    }
}
