using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CombinationFactory : GenericFactory<combination>
    {
        protected override string singularEntityName { get { return "combination"; } }
        protected override string pluralEntityName { get { return "combinations"; } }

        public CombinationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}