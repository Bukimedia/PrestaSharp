using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class TaxFactory : GenericFactory<tax>
    {
        protected override string singularEntityName { get { return "tax"; } }
        protected override string pluralEntityName { get { return "taxes"; } }

        public TaxFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
