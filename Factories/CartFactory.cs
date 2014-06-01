using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CartFactory : RestSharpFactory
    {
        public CartFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.cart Get(long CartId)
        {
            RestRequest request = this.RequestForGet("carts", CartId, "cart");
            return this.Execute<Entities.cart>(request);
        }

        public Entities.cart Add(Entities.cart Cart)
        {
            long? idAux = Cart.id;
            Cart.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Cart);
            RestRequest request = this.RequestForAdd("carts", Entities);
            Entities.cart aux = this.Execute<Entities.cart>(request);
            Cart.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.cart Cart)
        {
            RestRequest request = this.RequestForUpdate("carts", Cart.id, Cart);
            this.Execute<Entities.cart>(request);
        }

        public void Delete(long CartId)
        {
            RestRequest request = this.RequestForDelete("carts", CartId);
            this.Execute<Entities.cart>(request);
        }

        public void Delete(Entities.cart Cart)
        {
            this.Delete((long)Cart.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("carts", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "cart");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.cart> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("carts", "full", Filter, Sort, Limit, "carts");
            return this.ExecuteForFilter<List<Entities.cart>>(request);
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
            RestRequest request = this.RequestForFilter("carts", "[id]", Filter, Sort, Limit, "carts");
            List<PrestaSharp.Entities.FilterEntities.cart> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.cart>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all carts.
        /// </summary>
        /// <returns>A list of carts</returns>
        public List<Entities.cart> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of carts.
        /// </summary>
        /// <param name="Carts"></param>
        /// <returns></returns>
        public List<Entities.cart> AddList(List<Entities.cart> Carts)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.cart Cart in Carts)
            {
                Cart.id = null;
                Entities.Add(Cart);
            }
            RestRequest request = this.RequestForAdd("carts", Entities);
            return this.Execute<List<Entities.cart>>(request);
        }        
    }
}
