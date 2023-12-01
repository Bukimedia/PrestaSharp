using System;
using System.Collections.Generic;
using System.Text;
using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductCustomizationFieldFactory : GenericFactory<customization_field>
    {
        protected override string singularEntityName { get { return "customization_fields"; } }
        protected override string pluralEntityName { get { return "product_customization_fields"; } }

        public ProductCustomizationFieldFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
