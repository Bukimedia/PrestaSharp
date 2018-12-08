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
    public class SpecificPriceRuleFactory : GenericFactory<specific_price_rule>
	{
        protected override string singularEntityName { get { return "specific_price_rule"; } }
        protected override string pluralEntityName { get { return "specific_price_rules"; } }

        public SpecificPriceRuleFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public SpecificPriceRuleFactory()
            : base()
        {
        }
    }
}
