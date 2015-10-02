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
    public class CategoryFactory : GenericFactory<category>
    {
        public CategoryFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey, "categories", "category", "categories", PerformGetAfterAdd)
        {
        }

    }
}
