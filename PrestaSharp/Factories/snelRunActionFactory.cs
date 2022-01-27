using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class snelRunActionFactory : GenericFactory<snelRunAction>
    {
        protected override string singularEntityName { get { return "snelRunAction"; } }
        protected override string pluralEntityName { get { return "snelRunActions"; } }

        public snelRunActionFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
