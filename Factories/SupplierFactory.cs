using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public SupplierFactory()
            : base()
        {
        }
    }
}
