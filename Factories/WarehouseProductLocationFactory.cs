using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public WarehouseProductLocationFactory()
            : base()
        {
        }
    }
}
