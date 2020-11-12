using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class WarehouseFactory : GenericFactory<warehouse>
    {
        protected override string singularEntityName { get { return "warehouse"; } }
        protected override string pluralEntityName { get { return "warehouses"; } }

        public WarehouseFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
