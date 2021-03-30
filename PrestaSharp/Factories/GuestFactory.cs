using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class GuestFactory : GenericFactory<guest>
    {
        protected override string singularEntityName { get { return "guest"; } }
        protected override string pluralEntityName { get { return "guests"; } }

        public GuestFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
