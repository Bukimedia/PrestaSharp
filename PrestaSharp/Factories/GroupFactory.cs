using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class GroupFactory : GenericFactory<group>
    {
        protected override string singularEntityName { get { return "group"; } }
        protected override string pluralEntityName { get { return "groups"; } }

        public GroupFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
