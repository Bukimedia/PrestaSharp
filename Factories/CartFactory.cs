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
    public class CartFactory : GenericFactory<cart>
    {
        protected override string singularEntityName { get { return "cart"; } }
        protected override string pluralEntityName { get { return "carts"; } }

        public CartFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public CartFactory()
            : base()
        {
        }
    }
}
