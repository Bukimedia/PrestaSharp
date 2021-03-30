using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductOptionValueFactory : GenericFactory<product_option_value>
    {
        protected override string singularEntityName { get { return "product_option_value"; } }
        protected override string pluralEntityName { get { return "product_option_values"; } }

        public ProductOptionValueFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}