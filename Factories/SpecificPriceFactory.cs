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
    public class SpecificPriceFactory : GenericFactory<specific_price>
	{
        protected override string singularEntityName { get { return "specific_price"; } }
        protected override string pluralEntityName { get { return "specific_prices"; } }

        public SpecificPriceFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public SpecificPriceFactory()
            : base()
        {
        }
    }
}
