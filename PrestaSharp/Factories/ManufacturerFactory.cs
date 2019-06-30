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
    public class ManufacturerFactory : GenericFactory<manufacturer>
    {
        protected override string singularEntityName { get { return "manufacturer"; } }
        protected override string pluralEntityName { get { return "manufacturers"; } }

        public ManufacturerFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }       
    }
}
