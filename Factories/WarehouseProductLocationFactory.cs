using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Factories
{
    public class WarehouseProductLocationFactory : RestSharpFactory
    {
        public WarehouseProductLocationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.warehouse_product_location Get(long WarehouseProductLocationId)
        {
            RestRequest request = this.RequestForGet("warehouse_product_locations", WarehouseProductLocationId, "warehouse_product_location");
            return this.Execute<Entities.warehouse_product_location>(request);
        }

        public Entities.warehouse_product_location Add(Entities.warehouse_product_location WarehouseProductLocation)
        {
            long? idAux = WarehouseProductLocation.id; WarehouseProductLocation.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(WarehouseProductLocation); RestRequest request = this.RequestForAdd("warehouse_product_locations", Entities);
            Entities.warehouse_product_location aux = this.Execute<Entities.warehouse_product_location>(request);
            WarehouseProductLocation.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.warehouse_product_location WarehouseProductLocation)
        {
            RestRequest request = this.RequestForUpdate("warehouse_product_locations", WarehouseProductLocation.id, WarehouseProductLocation);
            this.Execute<Entities.warehouse_product_location>(request);
        }

        public void Delete(long WarehouseProductLocation)
        {
            RestRequest request = this.RequestForDelete("warehouse_product_locations", WarehouseProductLocation);
            this.Execute<Entities.warehouse_product_location>(request);
        }

        public void Delete(Entities.warehouse_product_location WarehouseProductLocation)
        {
            this.Delete((long)WarehouseProductLocation.id);
        }
        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("warehouse_product_locations", null, "warehouse_product_locations");
            return this.ExecuteForGetIds<List<long>>(request, "warehouse_product_location");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use 
        /// </summary> 
        /// <param name="Filter">Example: key:name value:Apple</param> 
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param> 
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns> 
        public List<Entities.warehouse_product_location> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("warehouse_product_locations", "full", Filter, Sort, Limit, "warehouse_product_locations");
            return this.ExecuteForFilter<List<Entities.warehouse_product_location>>(request);
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
            RestRequest request = this.RequestForFilter("warehouse_product_locations", "[id]", Filter, Sort, Limit, "warehouse_product_locations");
            List<PrestaSharp.Entities.FilterEntities.warehouse_product_location> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.warehouse_product_location>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all warehouse_product_locations. 
        /// </summary> 
        /// <returns>A list of order_details</returns> 
        public List<Entities.warehouse_product_location> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary> 
        /// Add a list of warehouse_product_locations. 
        /// </summary> 
        /// <param name="OrderStates"></param> 
        /// <returns></returns> 
        public List<Entities.warehouse_product_location> AddList(List<Entities.warehouse_product_location> WarehouseProductLocations)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.warehouse_product_location OrderDetail in WarehouseProductLocations)
            {
                OrderDetail.id = null; Entities.Add(OrderDetail);
            }
            RestRequest request = this.RequestForAdd("warehouse_product_locations", Entities); return this.Execute<List<Entities.warehouse_product_location>>(request);
        }
    }
}
