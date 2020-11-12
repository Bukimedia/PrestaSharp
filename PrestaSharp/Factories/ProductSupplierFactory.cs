
/* Modification non fusionnée à partir du projet 'PrestaSharp (net452)'
Avant :
using System;
Après :
using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
*/
using
/* Modification non fusionnée à partir du projet 'PrestaSharp (net452)'
Avant :
using System.Threading.Tasks;
using RestSharp;
using Bukimedia.PrestaSharp.Entities;
Après :
using System.Threading.Tasks;
*/
Bukimedia.PrestaSharp.Entities;

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
