using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductFeatureFactory : GenericFactory<product_feature>
    {
        protected override string singularEntityName { get { return "product_feature"; } }
        protected override string pluralEntityName { get { return "product_features"; } }

        public ProductFeatureFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}