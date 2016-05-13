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

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("product_suppliers", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "product_supplier");
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
