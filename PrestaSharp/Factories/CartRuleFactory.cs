using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CartRuleFactory : GenericFactory<cart_rule>
    {
        protected override string singularEntityName { get { return "cart_rule"; } }
        protected override string pluralEntityName { get { return "cart_rules"; } }

        public CartRuleFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
