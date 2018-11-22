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
    public class StockAvailableFactory : GenericFactory<stock_available>
    {
        protected override string singularEntityName { get { return "stock_available"; } }
        protected override string pluralEntityName { get { return "stock_availables"; } }

        public StockAvailableFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public StockAvailableFactory()
            : base()
        {
        }
    }
}