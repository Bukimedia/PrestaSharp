using System;
using System.Collections.Generic;
using System.Text;
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomizationFactory : GenericFactory<customization>
    {
        protected override string singularEntityName { get { return "customization"; } }
        protected override string pluralEntityName { get { return "customizations"; } }

        public CustomizationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
