using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderDetailFactory : GenericFactory<order_detail>
    {
        protected override string singularEntityName { get { return "order_detail"; } }
        protected override string pluralEntityName { get { return "order_details"; } }

        public OrderDetailFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}