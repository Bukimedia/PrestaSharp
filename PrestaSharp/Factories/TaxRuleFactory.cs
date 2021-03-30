using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class TaxRuleFactory : GenericFactory<tax_rule>
    {
        protected override string singularEntityName { get { return "tax_rule"; } }
        protected override string pluralEntityName { get { return "tax_rules"; } }

        public TaxRuleFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
