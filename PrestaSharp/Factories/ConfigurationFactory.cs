using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ConfigurationFactory : GenericFactory<configuration>
    {
        protected override string singularEntityName { get { return "configuration"; } }
        protected override string pluralEntityName { get { return "configurations"; } }

        public ConfigurationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
