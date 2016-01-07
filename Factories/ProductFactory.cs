using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductFactory : RestSharpFactory
    {
        public ProductFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {            
        }

        public Entities.product Get(long ProductId)
        {
            RestRequest request = this.RequestForGet("products", ProductId, "product");
            return this.Execute<Entities.product>(request);
        }

        public Entities.product Add(Entities.product Product)
        {
            long? idAux = Product.id;
            Product.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Product);
            RestRequest request = this.RequestForAdd("products", Entities);
            Entities.product aux = this.Execute<Entities.product>(request);
            Product.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.product Product)
        {
            RestRequest request = this.RequestForUpdate("products", Product.id, Product);
            this.Execute<Entities.product>(request);
        }
        // For Update List Of Product - Start
        public List<Entities.product> UpdateList(List<Entities.product> Products)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.product Product in Products)
            {
                Entities.Add(Product);
            }
            RestRequest request = this.RequestForUpdateList("products", Entities);
            Console.WriteLine(request);
            return this.Execute<List<Entities.product>>(request);
        }
        // For Update List Of Product - End
        public void Delete(long ProductId)
        {
            RestRequest request = this.RequestForDelete("products", ProductId);
            this.Execute<Entities.product>(request);
        }

        public void Delete(Entities.product Product)
        {
            this.Delete((long)Product.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("products", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "product");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("products", "full", Filter, Sort, Limit, "products");
            return this.ExecuteForFilter<List<Entities.product>>(request);
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
            RestRequest request = this.RequestForFilter("products", "[id]", Filter, Sort, Limit, "products");
            List<PrestaSharp.Entities.FilterEntities.product> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.product>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Entities.product> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of products.
        /// </summary>
        /// <param name="Products"></param>
        /// <returns></returns>
        public List<Entities.product> AddList(List<Entities.product> Products)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.product Product in Products)
            {
                Product.id = null;
                Entities.Add(Product);
            }
            RestRequest request = this.RequestForAdd("products", Entities);
            return this.Execute<List<Entities.product>>(request);
        }
    }
}
