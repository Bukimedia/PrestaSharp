using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class TaxRuleGroupFactory : GenericFactory<tax_rule_group>
    {
        protected override string singularEntityName { get { return "tax_rule_group"; } }
        protected override string pluralEntityName { get { return "tax_rule_groups"; } }

        public TaxRuleGroupFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
