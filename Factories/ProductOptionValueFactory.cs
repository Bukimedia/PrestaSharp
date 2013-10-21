using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
{
    public class ProductOptionValueFactory : RestSharpFactory
    {
        public ProductOptionValueFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.product_option_value Get(long ProductOptionValueId)
        {
            RestRequest request = this.RequestForGet("product_option_values", ProductOptionValueId, "product_option_value");
            return this.Execute<Entities.product_option_value>(request);
        }

        public Entities.product_option_value Add(Entities.product_option_value ProductOptionValue)
        {
            ProductOptionValue.id = null;
            RestRequest request = this.RequestForAdd("product_option_values", ProductOptionValue);

            /*
             * Bug in the serializer with the serialization of id_attribute_group.
             * It´s needed to write again the value of id_attribute_group with the same value of the object ProductOptionValue.
             */
            Entities.product_option_value aux = this.Execute<Entities.product_option_value>(request);
            aux.id_attribute_group = ProductOptionValue.id_attribute_group;
            return aux;
        }


        public void Update(Entities.product_option_value ProductOptionValue)
        {
            RestRequest request = this.RequestForUpdate("product_option_values", ProductOptionValue.id, ProductOptionValue);
            this.Execute<Entities.product_option_value>(request);
        }

        public void Delete(Entities.product_option_value ProductOptionValue)
        {
            RestRequest request = this.RequestForDelete("product_option_values", ProductOptionValue.id);
            this.Execute<Entities.product_option_value>(request);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("product_option_values", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "product_option_value");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product_option_value> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_option_values", "full", Filter, Sort, Limit, "product_option_values");
            return this.Execute<List<Entities.product_option_value>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long?> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_option_values", "id", Filter, Sort, Limit, "product_option_values");
            return this.Execute<List<long?>>(request);
        }

        /// <summary>
        /// Get all product_option_values.
        /// </summary>
        /// <returns>A list of product_option_values</returns>
        public List<Entities.product_option_value> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}