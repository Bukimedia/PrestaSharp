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
    public class OrderHistoryFactory : GenericFactory<order_history>
    {
        public OrderHistoryFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey, "order_histories", "order_history", "order_histories", PerformGetAfterAdd)
        {
        }

    }
}