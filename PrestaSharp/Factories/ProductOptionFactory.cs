using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductOptionFactory : GenericFactory<product_option>
    {
        protected override string singularEntityName { get { return "product_option"; } }
        protected override string pluralEntityName { get { return "product_options"; } }

        public ProductOptionFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}