using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductOptionValueFactory : RestSharpFactory
    {
        public ProductOptionValueFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.product_option_value Get(long ProductOptionValueId)
        {
            RestRequest request = this.RequestForGet("product_option_values", ProductOptionValueId, "product_option_value");
            return this.Execute<Entities.product_option_value>(request);
        }

        public Entities.product_option_value Add(Entities.product_option_value ProductOptionValue)
        {
            long? idAux = ProductOptionValue.id;
            ProductOptionValue.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(ProductOptionValue);
            RestRequest request = this.RequestForAdd("product_option_values", Entities);
            Entities.product_option_value aux = this.Execute<Entities.product_option_value>(request);
            ProductOptionValue.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.product_option_value ProductOptionValue)
        {
            RestRequest request = this.RequestForUpdate("product_option_values", ProductOptionValue.id, ProductOptionValue);
            this.Execute<Entities.product_option_value>(request);
        }

        public void Delete(long ProductOptionValueId)
        {
            RestRequest request = this.RequestForDelete("product_option_values", ProductOptionValueId);
            this.Execute<Entities.product_option_value>(request);
        }

        public void Delete(Entities.product_option_value ProductOptionValue)
        {
            this.Delete((long)ProductOptionValue.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("product_option_values", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "product_option_value");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product_option_value> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_option_values", "full", Filter, Sort, Limit, "product_option_values");
            return this.ExecuteForFilter<List<Entities.product_option_value>>(request);
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
            RestRequest request = this.RequestForFilter("product_option_values", "[id]", Filter, Sort, Limit, "product_option_values");
            List<PrestaSharp.Entities.FilterEntities.product_option_value> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.product_option_value>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all product_option_values.
        /// </summary>
        /// <returns>A list of product_option_values</returns>
        public List<Entities.product_option_value> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of product_option_values.
        /// </summary>
        /// <param name="ProductOptionValues"></param>
        /// <returns></returns>
        public List<Entities.product_option_value> AddList(List<Entities.product_option_value> ProductOptionValues)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.product_option_value ProductOptionValue in ProductOptionValues)
            {
                ProductOptionValue.id = null;
                Entities.Add(ProductOptionValue);
            }
            RestRequest request = this.RequestForAdd("product_option_values", Entities);
            return this.Execute<List<Entities.product_option_value>>(request);
        }
    }
}