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
    public class AddressFactory : GenericFactory<address>
    {
        protected override string singularEntityName { get { return "address"; } }
        protected override string pluralEntityName { get { return "addresses"; } }

        public AddressFactory(string BaseUrl, string Account, string SecretKey)
                : base(BaseUrl, Account, SecretKey)
        {
        }

        public AddressFactory()
                : base()
        {
        }

    }
}
