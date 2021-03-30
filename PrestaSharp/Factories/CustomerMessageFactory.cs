using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomerMessageFactory : GenericFactory<customer_message>
    {
        protected override string singularEntityName { get { return "customer_message"; } }
        protected override string pluralEntityName { get { return "customer_messages"; } }

        public CustomerMessageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
