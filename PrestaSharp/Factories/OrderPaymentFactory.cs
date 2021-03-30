using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderPaymentFactory : GenericFactory<order_payment>
    {
        protected override string singularEntityName { get { return "order_payment"; } }
        protected override string pluralEntityName { get { return "order_payments"; } }

        public OrderPaymentFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
