using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class WarehouseFactory : RestSharpFactory
    {
        public WarehouseFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.warehouse Get(long WarehouseId)
        {
            RestRequest request = this.RequestForGet("warehouses", WarehouseId, "warehouse");
            return this.Execute<Entities.warehouse>(request);
        }

        public Entities.warehouse Add(Entities.warehouse Warehouse)
        {
            long? idAux = Warehouse.id;
            Warehouse.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Warehouse);
            RestRequest request = this.RequestForAdd("warehouses", Entities);
            Entities.warehouse aux = this.Execute<Entities.warehouse>(request);
            Warehouse.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.warehouse Warehouse)
        {
            RestRequest request = this.RequestForUpdate("warehouses", Warehouse.id, Warehouse);
            this.Execute<Entities.warehouse>(request);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("warehouses", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "warehouse");
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

        /// <summary>
        /// Add a list of warehouses.
        /// </summary>
        /// <param name="Warehouses"></param>
        /// <returns></returns>
        public List<Entities.warehouse> AddList(List<Entities.warehouse> Warehouses)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.warehouse Warehouse in Warehouses)
            {
                Warehouse.id = null;
                Entities.Add(Warehouse);
            }
            RestRequest request = this.RequestForAdd("warehouses", Entities);
            return this.Execute<List<Entities.warehouse>>(request);
        }
    }
}
