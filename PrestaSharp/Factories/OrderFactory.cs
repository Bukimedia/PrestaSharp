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
    public class OrderFactory : GenericFactory<order>
    {
        protected override string singularEntityName { get { return "order"; } }
        protected override string pluralEntityName { get { return "orders"; } }

        public OrderFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }      
    }
}
