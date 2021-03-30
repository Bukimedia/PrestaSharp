using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CountryFactory : GenericFactory<country>
    {
        protected override string singularEntityName { get { return "country"; } }
        protected override string pluralEntityName { get { return "countries"; } }

        public CountryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
