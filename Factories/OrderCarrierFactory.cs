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
    public class OrderCarrierFactory : GenericFactory<order_carrier>
    {
        protected override string singularEntityName { get { return "order_carrier"; } }
        protected override string pluralEntityName { get { return "order_carriers"; } }

        public OrderCarrierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public OrderCarrierFactory()
            : base()
        {
        }
    }
}
