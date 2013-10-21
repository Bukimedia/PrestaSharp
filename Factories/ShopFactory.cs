using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
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
            Shop.id = null;
            RestRequest request = this.RequestForAdd("shops", Shop);

            /*
             * Bug in the serializer with the serialization of id_shop_group, id_category and id_theme.
             * It´s needed to write again the value of id_shop_group, id_category and id_theme with the same value of the object Combination.
             */
            Entities.shop aux = this.Execute<Entities.shop>(request);
            aux.id_shop_group = Shop.id_shop_group;
            aux.id_category = Shop.id_category;
            aux.id_theme = Shop.id_theme;
            return aux;
        }


        public void Update(Entities.shop Shop)
        {
            RestRequest request = this.RequestForUpdate("shops", Shop.id, Shop);
            this.Execute<Entities.shop>(request);
        }

        public void Delete(Entities.shop Shop)
        {
            RestRequest request = this.RequestForDelete("shops", Shop.id);
            this.Execute<Entities.shop>(request);
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
            return this.Execute<List<Entities.shop>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long?> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("shops", "id", Filter, Sort, Limit, "shops");
            return this.Execute<List<long?>>(request);
        }

        /// <summary>
        /// Get all shops.
        /// </summary>
        /// <returns>A list of shops</returns>
        public List<Entities.shop> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}