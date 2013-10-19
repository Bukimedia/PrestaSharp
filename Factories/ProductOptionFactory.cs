﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
{
    public class ProductOptionFactory : RestSharpFactory
    {
        public ProductOptionFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.product_option Get(int ProductOptionValueId)
        {
            RestRequest request = this.RequestForGet("product_options", ProductOptionValueId, "product_option");
            return this.Execute<Entities.product_option>(request);
        }

        public Entities.product_option Add(Entities.product_option ProductOption)
        {
            ProductOption.id = null;
            RestRequest request = this.RequestForAdd("product_options", ProductOption);
            return this.Execute<Entities.product_option>(request);
        }

        public void Update(Entities.product_option ProductOption)
        {
            RestRequest request = this.RequestForUpdate("product_options", ProductOption.id, ProductOption);
            this.Execute<Entities.product_option>(request);
        }

        public void Delete(Entities.product_option ProductOption)
        {
            RestRequest request = this.RequestForDelete("product_options", ProductOption.id);
            this.Execute<Entities.product_option>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("product_options", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "product_option");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product_option> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_options", "full", Filter, Sort, Limit, "product_options");
            return this.Execute<List<Entities.product_option>>(request);
        }

        /// <summary>
        /// Get all product_options.
        /// </summary>
        /// <returns>A list of product_options</returns>
        public List<Entities.product_option> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}