using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ManufacturerFactory : GenericFactory<manufacturer>
    {
        protected override string singularEntityName { get { return "manufacturer"; } }
        protected override string pluralEntityName { get { return "manufacturers"; } }

        public ManufacturerFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
