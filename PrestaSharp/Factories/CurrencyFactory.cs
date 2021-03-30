using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CurrencyFactory : GenericFactory<currency>
    {
        protected override string singularEntityName { get { return "currency"; } }
        protected override string pluralEntityName { get { return "currencies"; } }

        public CurrencyFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
