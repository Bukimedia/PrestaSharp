using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class SpecificPriceRuleFactory : GenericFactory<specific_price_rule>
    {
        protected override string singularEntityName { get { return "specific_price_rule"; } }
        protected override string pluralEntityName { get { return "specific_price_rules"; } }

        public SpecificPriceRuleFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
