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
    public class CarrierFactory : GenericFactory<carrier>
    {
        protected override string singularEntityName { get { return "carrier"; } }
        protected override string pluralEntityName { get { return "carriers"; } }

        public CarrierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public CarrierFactory()
            : base()
        {
        }
    }
}
