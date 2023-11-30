using System;
using System.Collections.Generic;
using System.Text;
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CustomizationFieldFactory : GenericFactory<customization_field>
    {
        protected override string singularEntityName { get { return "customization_field"; } }
        protected override string pluralEntityName { get { return "customization_fields"; } }

        public CustomizationFieldFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
