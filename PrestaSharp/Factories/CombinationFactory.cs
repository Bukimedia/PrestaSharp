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
    public class CombinationFactory : GenericFactory<combination>
    {
        protected override string singularEntityName { get { return "combination"; } }
        protected override string pluralEntityName { get { return "combinations"; } }

        public CombinationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}