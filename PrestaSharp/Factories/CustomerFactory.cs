using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomerFactory : GenericFactory<customer>
    {
        protected override string singularEntityName { get { return "customer"; } }
        protected override string pluralEntityName { get { return "customers"; } }

        public CustomerFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
