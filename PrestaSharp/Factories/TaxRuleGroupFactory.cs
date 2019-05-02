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
    public class TaxRuleGroupFactory : GenericFactory<tax_rule_group>
    {
        protected override string singularEntityName { get { return "tax_rule_group"; } }
        protected override string pluralEntityName { get { return "tax_rule_groups"; } }

        public TaxRuleGroupFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }     
    }
}
