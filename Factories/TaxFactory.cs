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
    public class TaxFactory : GenericFactory<tax>
    {
        protected override string singularEntityName { get { return "tax"; } }
        protected override string pluralEntityName { get { return "taxes"; } }

        public TaxFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public TaxFactory()
            : base()
        {
        }
    }
}
