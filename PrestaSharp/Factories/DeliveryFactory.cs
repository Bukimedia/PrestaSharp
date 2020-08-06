using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class DeliveryFactory : GenericFactory<delivery>
    {
        protected override string singularEntityName { get { return "delivery"; } }
        protected override string pluralEntityName { get { return "deliveries"; } }

        public DeliveryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
