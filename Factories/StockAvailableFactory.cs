using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class StockAvailableFactory : RestSharpFactory
    {
        public StockAvailableFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.stock_available Get(long StockAvailableId)
        {
            RestRequest request = this.RequestForGet("stock_availables", StockAvailableId, "stock_available");
            return this.Execute<Entities.stock_available>(request);
        }

        public void Update(Entities.stock_available StockAvailable)
        {
            RestRequest request = this.RequestForUpdate("stock_availables", StockAvailable.id, StockAvailable);
            this.Execute<Entities.stock_available>(request);
        }

        public void Delete(long StockAvailableId)
        {
            RestRequest request = this.RequestForDelete("stock_availables", StockAvailableId);
            this.Execute<Entities.stock_available>(request);
        }

        public void Delete(Entities.stock_available StockAvailable)
        {
            this.Delete((long)StockAvailable.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("stock_availables", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "stock_available");
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
            return this.ExecuteForFilter<List<Entities.stock_available>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("stock_availables", "[id]", Filter, Sort, Limit, "stock_availables");
            List<PrestaSharp.Entities.FilterEntities.stock_available> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.stock_available>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all stock_availables.
        /// </summary>
        /// <returns>A list of stock_availables</returns>
        public List<Entities.stock_available> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of stock_vailables.
        /// </summary>
        /// <param name="StockAvailables"></param>
        /// <returns></returns>
        public List<Entities.stock_available> AddList(List<Entities.stock_available> StockAvailables)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.stock_available StockAvailable in StockAvailables)
            {
                StockAvailable.id = null;
                Entities.Add(StockAvailable);
            }
            RestRequest request = this.RequestForAdd("stock_availables", Entities);
            return this.Execute<List<Entities.stock_available>>(request);
        }
    }
}