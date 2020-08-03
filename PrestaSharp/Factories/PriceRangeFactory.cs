using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class PriceRangeFactory : GenericFactory<price_range>
    {
        protected override string singularEntityName { get { return "price_range"; } }
        protected override string pluralEntityName { get { return "price_ranges"; } }

        public PriceRangeFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
