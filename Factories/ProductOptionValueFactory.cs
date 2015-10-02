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
    public class ProductOptionValueFactory : GenericFactory<product_option_value>
    {
        public ProductOptionValueFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey,"product_option_values", "product_option_value", "product_option_values", PerformGetAfterAdd)
        {
        }

    }
}