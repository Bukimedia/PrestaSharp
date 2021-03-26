using System;
using System.Collections.Generic;
using System.Text;
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
    class snelRunDetailFactory : GenericFactory<snelRunDetail>
    {
        protected override string singularEntityName { get { return "snelRunDetail"; } }
        protected override string pluralEntityName { get { return "snelRunDetails"; } }

        public snelRunDetailFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
