using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ZoneFactory : GenericFactory<zone>
    {
        protected override string singularEntityName { get { return "zone"; } }
        protected override string pluralEntityName { get { return "zones"; } }

        public ZoneFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
