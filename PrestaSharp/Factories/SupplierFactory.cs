using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class SupplierFactory : GenericFactory<supplier>
    {
        protected override string singularEntityName { get { return "supplier"; } }
        protected override string pluralEntityName { get { return "suppliers"; } }

        public SupplierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
