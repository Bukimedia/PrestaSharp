using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class LanguageFactory : GenericFactory<language>
    {
        protected override string singularEntityName { get { return "language"; } }
        protected override string pluralEntityName { get { return "languages"; } }

        public LanguageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}