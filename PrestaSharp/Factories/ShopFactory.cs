using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ShopFactory : GenericFactory<shop>
    {
        protected override string singularEntityName { get { return "shop"; } }
        protected override string pluralEntityName { get { return "shops"; } }

        public ShopFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}