using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductStatusFactory : GenericFactory<productStatus>
    {
        protected override string singularEntityName { get { return "productStatus"; } }
        protected override string pluralEntityName { get { return "productStatusWS"; } }

        public ProductStatusFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
