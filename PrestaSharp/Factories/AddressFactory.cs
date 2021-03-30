using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class AddressFactory : GenericFactory<address>
    {
        protected override string singularEntityName { get { return "address"; } }
        protected override string pluralEntityName { get { return "addresses"; } }

        public AddressFactory(string BaseUrl, string Account, string SecretKey)
                : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
