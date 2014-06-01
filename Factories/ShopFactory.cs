using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ShopFactory : RestSharpFactory
    {
        public ShopFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.shop Get(long ShopId)
        {
            RestRequest request = this.RequestForGet("shops", ShopId, "shop");
            return this.Execute<Entities.shop>(request);
        }

        public Entities.shop Add(Entities.shop Shop)
        {
            long? idAux = Shop.id;
            Shop.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Shop);
            RestRequest request = this.RequestForAdd("shops", Entities);
            Entities.shop aux = this.Execute<Entities.shop>(request);
            Shop.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.shop Shop)
        {
            RestRequest request = this.RequestForUpdate("shops", Shop.id, Shop);
            this.Execute<Entities.shop>(request);
        }

        public void Delete(long ShopId)
        {
            RestRequest request = this.RequestForDelete("shops", ShopId);
            this.Execute<Entities.shop>(request);
        }

        public void Delete(Entities.shop Shop)
        {
            this.Delete((long)Shop.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("shops", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "shop");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.shop> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("shops", "full", Filter, Sort, Limit, "shops");
            return this.ExecuteForFilter<List<Entities.shop>>(request);
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
            RestRequest request = this.RequestForFilter("shops", "[id]", Filter, Sort, Limit, "shops");
            List<PrestaSharp.Entities.FilterEntities.shop> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.shop>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all shops.
        /// </summary>
        /// <returns>A list of shops</returns>
        public List<Entities.shop> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of shops.
        /// </summary>
        /// <param name="Shops"></param>
        /// <returns></returns>
        public List<Entities.shop> AddList(List<Entities.shop> Shops)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.shop Shop in Shops)
            {
                Shop.id = null;
                Entities.Add(Shop);
            }
            RestRequest request = this.RequestForAdd("shops", Entities);
            return this.Execute<List<Entities.shop>>(request);
        }
    }
}