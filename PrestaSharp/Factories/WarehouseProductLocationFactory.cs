using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class WarehouseProductLocationFactory : GenericFactory<warehouse_product_location>
    {
        protected override string singularEntityName { get { return "warehouse_product_location"; } }
        protected override string pluralEntityName { get { return "warehouse_product_locations"; } }

        public WarehouseProductLocationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
