using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class snelRunDetailFactory : GenericFactory<snelRunDetail>
    {
        protected override string singularEntityName { get { return "snelRunDetail"; } }
        protected override string pluralEntityName { get { return "snelRunDetails"; } }

        public snelRunDetailFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
