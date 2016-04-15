using System.Collections.Generic;

namespace Bukimedia.PrestaSharp.Factories
{
    public class WarehouseFactory : RestSharpFactory
    {
        public WarehouseFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.warehouse> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestSharp.RestRequest request = this.RequestForFilter("warehouses", "full", Filter, Sort, Limit, "warehouses");
            return this.ExecuteForFilter<List<Entities.warehouse>>(request);
        }

        /// <summary>
        /// Get all warehouse.
        /// </summary>
        /// <returns>A list of warehouse</returns>
        public List<Entities.warehouse> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
