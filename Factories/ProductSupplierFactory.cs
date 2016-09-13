using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductSupplierFactory : RestSharpFactory
    {
        public ProductSupplierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.product_supplier Get(long ProductSupplierId)
        {
            RestRequest request = this.RequestForGet("product_suppliers", ProductSupplierId, "product_supplier");
            return this.Execute<Entities.product_supplier>(request);
        }

        public Entities.product_supplier Add(Entities.product_supplier ProductSupplier)
        {
            long? idAux = ProductSupplier.id;
            ProductSupplier.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(ProductSupplier);
            RestRequest request = this.RequestForAdd("product_suppliers", Entities);
            Entities.product_supplier aux = this.Execute<Entities.product_supplier>(request);
            ProductSupplier.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.product_supplier ProductSupplier)
        {
            RestRequest request = this.RequestForUpdate("product_suppliers", ProductSupplier.id, ProductSupplier);
            this.Execute<Entities.product_supplier>(request);
        }

        public void Delete(long ProductSupplierId)
        {
            RestRequest request = this.RequestForDelete("product_suppliers", ProductSupplierId);
            this.Execute<Entities.product_supplier>(request);
        }

        public void Delete(Entities.product_supplier ProductSupplier)
        {
            this.Delete((long)ProductSupplier.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("product_suppliers", null, "product_suppliers");
            return this.ExecuteForGetIds<List<long>>(request, "product_supplier");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product_supplier> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_suppliers", "full", Filter, Sort, Limit, "product_suppliers");
            return this.ExecuteForFilter<List<Entities.product_supplier>>(request);
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
            RestRequest request = this.RequestForFilter("product_suppliers", "[id]", Filter, Sort, Limit, "product_suppliers");
            List<PrestaSharp.Entities.FilterEntities.product_supplier> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.product_supplier>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all product suppliers.
        /// </summary>
        /// <returns>A list of product suppliers</returns>
        public List<Entities.product_supplier> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        public List<Entities.product_supplier> AddList(List<Entities.product_supplier> ProductSuppliers)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.product_supplier ProductSupplier in ProductSuppliers)
            {
                ProductSupplier.id = null;
                Entities.Add(ProductSupplier);
            }
            RestRequest request = this.RequestForAdd("product_suppliers", Entities);
            return this.Execute<List<Entities.product_supplier>>(request);
        }
    }
}
