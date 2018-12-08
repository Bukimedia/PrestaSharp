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
        protected override string singularEntityName { get { return "order_cart_rule"; } }
        protected override string pluralEntityName { get { return "order_discounts"; } }

        public OrderCartRuleFactory(string BaseUrl, string Account, string SecretKey) 
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public OrderCartRuleFactory()
            : base()
        {
        }
    }
}