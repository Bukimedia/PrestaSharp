using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CarrierFactory : GenericFactory<carrier>
    {
        protected override string singularEntityName { get { return "carrier"; } }
        protected override string pluralEntityName { get { return "carriers"; } }

        public CarrierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
