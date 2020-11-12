using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CategoryFactory : GenericFactory<category>
    {
        protected override string singularEntityName { get { return "category"; } }
        protected override string pluralEntityName { get { return "categories"; } }

        public CategoryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
