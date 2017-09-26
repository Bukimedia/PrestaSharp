using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderInvoiceFactory : GenericFactory<order_invoice>
    {
        protected override string singularEntityName { get { return "order_invoice"; } }
        protected override string pluralEntityName { get { return "order_invoices"; } }

        public OrderInvoiceFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}