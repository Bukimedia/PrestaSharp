using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductFactory : GenericFactory<product>
    {
        protected override string singularEntityName { get { return "product"; } }
        protected override string pluralEntityName { get { return "products"; } }

        public ProductFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        /// <summary>
        /// Gets from eshop product final price with tax
        /// and price rules (discount) applied
        /// Entities.product.final_price
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entities.product</returns>
        public Entities.product GetFinalPrice(long id)
        {
            RestRequest request = base.RequestForGet(pluralEntityName, id, singularEntityName);
            request.Resource += "?price[final_price][use_tax]=1";
            return base.Execute<Entities.product>(request);
        }

        /// <summary>
        /// Gets from eshop product final price with tax
        /// and price rules (discount) applied
        /// Entities.product.final_price
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entities.product</returns>
        public async Task<Entities.product> GetFinalPriceAsync(long id)
        {
            RestRequest request = base.RequestForGet(pluralEntityName, id, singularEntityName);
            request.Resource += "?price[final_price][use_tax]=1";
            return await base.ExecuteAsync<Entities.product>(request);
        }
    }
}
