using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
{
    public class StockAvailableFactory : RestSharpFactory
    {
        public StockAvailableFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.stock_available Get(int StockAvailableId)
        {
            RestRequest request = this.RequestForGet("stock_availables", StockAvailableId, "stock_available");
            return this.Execute<Entities.stock_available>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("stock_availables", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "stock_available");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.stock_available> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("stock_availables", "full", Filter, Sort, Limit, "stock_availables");
            return this.Execute<List<Entities.stock_available>>(request);
        }

        /// <summary>
        /// Get all stock_availables.
        /// </summary>
        /// <returns>A list of stock_availables</returns>
        public List<Entities.stock_available> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}