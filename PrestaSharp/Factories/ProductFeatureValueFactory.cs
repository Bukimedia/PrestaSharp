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
    public class ProductFeatureValueFactory : GenericFactory<product_feature_value>
    {
        protected override string singularEntityName { get { return "product_feature_value"; } }
        protected override string pluralEntityName { get { return "product_feature_values"; } }

        public ProductFeatureValueFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}