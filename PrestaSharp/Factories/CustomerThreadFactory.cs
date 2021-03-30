using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomerThreadFactory : GenericFactory<customer_thread>
    {
        protected override string singularEntityName { get { return "customer_thread"; } }
        protected override string pluralEntityName { get { return "customer_threads"; } }

        public CustomerThreadFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
