using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductFeatureValueFactory : RestSharpFactory
    {
        public ProductFeatureValueFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.product_feature_value Get(long ProductFeatureValueId)
        {
            RestRequest request = this.RequestForGet("product_feature_values", ProductFeatureValueId, "product_feature_value");
            return this.Execute<Entities.product_feature_value>(request);
        }

        public Entities.product_feature_value Add(Entities.product_feature_value ProductFeatureValue)
        {
            long? idAux = ProductFeatureValue.id;
            ProductFeatureValue.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(ProductFeatureValue);
            RestRequest request = this.RequestForAdd("product_feature_values", Entities);
            Entities.product_feature_value aux = this.Execute<Entities.product_feature_value>(request);
            ProductFeatureValue.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.product_feature_value ProductFeatureValue)
        {
            RestRequest request = this.RequestForUpdate("product_feature_values", ProductFeatureValue.id, ProductFeatureValue);
            this.Execute<Entities.product_feature_value>(request);
        }

        public void Delete(long ProductFeatureValueId)
        {
            RestRequest request = this.RequestForDelete("product_feature_values", ProductFeatureValueId);
            this.Execute<Entities.product_feature_value>(request);
        }

        public void Delete(Entities.product_feature_value ProductFeature)
        {
            this.Delete((long)ProductFeature.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("product_feature_values", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "product_feature_value");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product_feature_value> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_feature_values", "full", Filter, Sort, Limit, "product_feature_values");
            return this.ExecuteForFilter<List<Entities.product_feature_value>>(request);
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
            RestRequest request = this.RequestForFilter("product_feature_values", "[id]", Filter, Sort, Limit, "product_feature_values");
            List<PrestaSharp.Entities.FilterEntities.product_feature_value> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.product_feature_value>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all product_feature_values.
        /// </summary>
        /// <returns>A list of product_feature_values</returns>
        public List<Entities.product_feature_value> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of product_feature_values.
        /// </summary>
        /// <param name="ProductFeatureValues"></param>
        /// <returns></returns>
        public List<Entities.product_feature_value> AddList(List<Entities.product_feature_value> ProductFeatureValues)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.product_feature_value ProductFeatureValue in ProductFeatureValues)
            {
                ProductFeatureValue.id = null;
                Entities.Add(ProductFeatureValue);
            }
            RestRequest request = this.RequestForAdd("product_feature_values", Entities);
            return this.Execute<List<Entities.product_feature_value>>(request);
        }
    }
}