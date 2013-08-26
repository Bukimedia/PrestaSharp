using PrestaSharp.Factories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
{
    public class ProductFactory : RestSharpFactory
    {
        public ProductFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
            
        }

        public Entities.product Get(int ProductId)
        {
            RestRequest request = this.RequestForGet("products", ProductId, "product");
            return this.Execute<Entities.product>(request);
        }

        public Entities.product Add(Entities.product Product)
        {
            Product.id=null;
            RestRequest request = this.RequestForAdd("products", Product);
            return this.Execute<Entities.product>(request);
        }

        public Entities.product Update(Entities.product Product)
        {
            RestRequest request = this.RequestForUpdate("products", Product.id, Product);
            return this.Execute<Entities.product>(request);
        }

        public void Delete(Entities.product Product)
        {
            RestRequest request = this.RequestForDelete("products", Product.id);
            this.Execute<Entities.product>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("products", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "product");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product> GetByFilter(Dictionary<string,string>Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("products", "full", Filter, Sort, Limit, "products");
            return this.Execute<List<Entities.product>>(request);
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Entities.product> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
