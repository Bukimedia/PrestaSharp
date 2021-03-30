using Bukimedia.PrestaSharp.Entities;

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
    }
}
