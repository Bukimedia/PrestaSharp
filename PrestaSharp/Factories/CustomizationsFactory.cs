
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomizationsFactory : GenericFactory<customization>
    {
        protected override string singularEntityName { get { return "customization"; } }
        protected override string pluralEntityName { get { return "customizations"; } }

        public CustomizationsFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}