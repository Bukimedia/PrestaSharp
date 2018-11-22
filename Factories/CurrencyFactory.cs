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
    public class CurrencyFactory : GenericFactory<currency>
    {
        protected override string singularEntityName { get { return "currency"; } }
        protected override string pluralEntityName { get { return "currencies"; } }

        public CurrencyFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public CurrencyFactory()
            : base()
        {
        }
    }
}
