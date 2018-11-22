using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public TagFactory()
            : base()
        {
        }
    }
}
