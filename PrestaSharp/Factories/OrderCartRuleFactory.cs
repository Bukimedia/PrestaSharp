using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderCartRuleFactory : GenericFactory<order_cart_rule>
    {
        protected override string singularEntityName { get { return "order_cart_rule"; } }
        protected override string pluralEntityName { get { return "order_discounts"; } }

        public OrderCartRuleFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}