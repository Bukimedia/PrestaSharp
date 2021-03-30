using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class SpecificPriceFactory : GenericFactory<specific_price>
    {
        protected override string singularEntityName { get { return "specific_price"; } }
        protected override string pluralEntityName { get { return "specific_prices"; } }

        public SpecificPriceFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
