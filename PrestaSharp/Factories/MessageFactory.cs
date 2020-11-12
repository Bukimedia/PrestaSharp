using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class MessageFactory : GenericFactory<message>
    {
        protected override string singularEntityName { get { return "message"; } }
        protected override string pluralEntityName { get { return "messages"; } }

        public MessageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
