using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class StateFactory : GenericFactory<state>
    {
        protected override string singularEntityName { get { return "state"; } }
        protected override string pluralEntityName { get { return "states"; } }

        public StateFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
