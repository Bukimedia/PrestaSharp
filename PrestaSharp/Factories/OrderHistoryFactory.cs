using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderHistoryFactory : GenericFactory<order_history>
    {
        protected override string singularEntityName { get { return "order_history"; } }
        protected override string pluralEntityName { get { return "order_histories"; } }

        public OrderHistoryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}