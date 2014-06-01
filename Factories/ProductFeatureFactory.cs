using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductFeatureFactory : RestSharpFactory
    {
        public ProductFeatureFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.product_feature Get(long ProductFeatureId)
        {
            RestRequest request = this.RequestForGet("product_features", ProductFeatureId, "product_feature");
            return this.Execute<Entities.product_feature>(request);
        }

        public Entities.product_feature Add(Entities.product_feature ProductFeature)
        {
            long? idAux = ProductFeature.id;
            ProductFeature.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(ProductFeature);
            RestRequest request = this.RequestForAdd("product_features", Entities);
            Entities.product_feature aux = this.Execute<Entities.product_feature>(request);
            ProductFeature.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.product_feature ProductFeature)
        {
            RestRequest request = this.RequestForUpdate("product_features", ProductFeature.id, ProductFeature);
            this.Execute<Entities.product_feature>(request);
        }

        public void Delete(long ProducFeaturetId)
        {
            RestRequest request = this.RequestForDelete("product_features", ProducFeaturetId);
            this.Execute<Entities.product_feature>(request);
        }

        public void Delete(Entities.product_feature ProductFeature)
        {
            this.Delete((long)ProductFeature.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("product_features", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "product_feature");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product_feature> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_features", "full", Filter, Sort, Limit, "product_features");
            return this.ExecuteForFilter<List<Entities.product_feature>>(request);
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
            RestRequest request = this.RequestForFilter("product_features", "[id]", Filter, Sort, Limit, "product_features");
            List<PrestaSharp.Entities.FilterEntities.product_feature> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.product_feature>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all product_features.
        /// </summary>
        /// <returns>A list of product_features</returns>
        public List<Entities.product_feature> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of product_features.
        /// </summary>
        /// <param name="ProductFeatures"></param>
        /// <returns></returns>
        public List<Entities.product_feature> AddList(List<Entities.product_feature> ProductFeatures)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.product_feature ProductFeature in ProductFeatures)
            {
                ProductFeature.id = null;
                Entities.Add(ProductFeature);
            }
            RestRequest request = this.RequestForAdd("product_features", Entities);
            return this.Execute<List<Entities.product_feature>>(request);
        }
    }
}