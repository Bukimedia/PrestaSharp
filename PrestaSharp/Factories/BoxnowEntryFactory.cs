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
    public class BoxnowEntryFactory : GenericFactory<boxnow_entry>
    {
        protected override string singularEntityName { get { return "boxnow_entry"; } }
        protected override string pluralEntityName { get { return "boxnow_entries"; } }

        public BoxnowEntryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }    
    }
}
