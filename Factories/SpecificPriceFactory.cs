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
	public class SpecificPriceFactory : GenericFactory<specific_price>
	{
		public SpecificPriceFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey, "specific_prices", "specific_price", "specific_prices", PerformGetAfterAdd)
        {
        }		
	}
}
