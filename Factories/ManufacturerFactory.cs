﻿using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ManufacturerFactory : GenericFactory<manufacturer>
    {
        public ManufacturerFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey, "manufacturers", "manufacturer", "manufacturers", PerformGetAfterAdd)
        {
        }

           
    }
}
