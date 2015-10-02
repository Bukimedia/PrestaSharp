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
    public class OrderCartRuleFactory : GenericFactory<order_cart_rule>
    {
        public OrderCartRuleFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true) 
            : base(BaseUrl, Account, SecretKey,"order_discounts", "order_cart_rule", "order_cart_rules", PerformGetAfterAdd)
        {
        }
    }
}