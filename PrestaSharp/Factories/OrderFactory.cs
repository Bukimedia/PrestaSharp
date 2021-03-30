using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderFactory : GenericFactory<order>
    {
        protected override string singularEntityName { get { return "order"; } }
        protected override string pluralEntityName { get { return "orders"; } }

        public OrderFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
