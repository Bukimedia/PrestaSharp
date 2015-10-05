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
        public ProductFeatureValueFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey, "product_feature_values", "product_feature_value", "product_feature_values",PerformGetAfterAdd)
        {
        }

    }
}