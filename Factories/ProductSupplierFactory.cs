using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductSupplierFactory : GenericFactory<product_supplier>
    {
        protected override string singularEntityName { get { return "product_supplier"; } }
        protected override string pluralEntityName { get { return "product_suppliers"; } }

        public ProductSupplierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
