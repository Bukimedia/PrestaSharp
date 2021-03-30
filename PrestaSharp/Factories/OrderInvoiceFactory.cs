
/* Modification non fusionnée à partir du projet 'PrestaSharp (net452)'
Avant :
using RestSharp;
Après :
using Bukimedia.PrestaSharp.Entities;
using RestSharp;
*/
using
/* Modification non fusionnée à partir du projet 'PrestaSharp (net452)'
Avant :
using System.Xml.Serialization;
using Bukimedia.PrestaSharp.Entities;
Après :
using System.Xml.Serialization;
*/
Bukimedia.PrestaSharp.Entities;

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