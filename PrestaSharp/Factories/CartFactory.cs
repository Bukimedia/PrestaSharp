using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CartFactory : GenericFactory<cart>
    {
        protected override string singularEntityName { get { return "cart"; } }
        protected override string pluralEntityName { get { return "carts"; } }

        public CartFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
