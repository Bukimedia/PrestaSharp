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
        public TaxRuleGroupFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey,"tax_rule_groups", "tax_rule_group", "tax_rule_groups", PerformGetAfterAdd)
        {
        }

       
    }
}
