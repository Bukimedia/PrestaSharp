using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class TagFactory : GenericFactory<tag>
    {
        protected override string singularEntityName { get { return "tag"; } }
        protected override string pluralEntityName { get { return "tags"; } }

        public TagFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
