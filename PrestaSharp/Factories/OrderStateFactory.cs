using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderStateFactory : GenericFactory<order_state>
    {
        protected override string singularEntityName { get { return "order_state"; } }
        protected override string pluralEntityName { get { return "order_states"; } }

        public OrderStateFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
