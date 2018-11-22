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
    public class ProductFeatureFactory : GenericFactory<product_feature>
    {
        protected override string singularEntityName { get { return "product_feature"; } }
        protected override string pluralEntityName { get { return "product_features"; } }

        public ProductFeatureFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public ProductFeatureFactory()
            : base()
        {
        }
    }
}