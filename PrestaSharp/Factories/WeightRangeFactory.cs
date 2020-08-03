using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class WeightRangeFactory : GenericFactory<weight_range>
    {
        protected override string singularEntityName { get { return "weight_range"; } }
        protected override string pluralEntityName { get { return "weight_ranges"; } }

        public WeightRangeFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
