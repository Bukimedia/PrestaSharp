using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderDetailFactory : RestSharpFactory
    {
        public OrderDetailFactory(string BaseUrl, string Account, string SecretKey) 
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.order_detail Get(long OrderDetailId)
        {
            RestRequest request = this.RequestForGet("order_details", OrderDetailId, "order_detail");
            return this.Execute<Entities.order_detail>(request);
        }

        public Entities.order_detail Add(Entities.order_detail OrderDetail)
        {
            long? idAux = OrderDetail.id; OrderDetail.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(OrderDetail); RestRequest request = this.RequestForAdd("order_details", Entities);
            Entities.order_detail aux = this.Execute<Entities.order_detail>(request);
            OrderDetail.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.order_detail OrderDetail)
        {
            RestRequest request = this.RequestForUpdate("order_details", OrderDetail.id, OrderDetail);
            this.Execute<Entities.order_detail>(request);
        }

        public void Delete(long OrderDetailId)
        {
            RestRequest request = this.RequestForDelete("order_details", OrderDetailId);
            this.Execute<Entities.order_detail>(request);
        }

        public void Delete(Entities.order_detail OrderDetail)
        {
            this.Delete((long)OrderDetail.id);
        }
        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("order_details", null, "order_details");
            return this.ExecuteForGetIds<List<long>>(request, "order_detail");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use 
        /// </summary> 
        /// <param name="Filter">Example: key:name value:Apple</param> 
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param> 
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns> 
        public List<Entities.order_detail> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("order_details", "full", Filter, Sort, Limit, "order_details");
            return this.ExecuteForFilter<List<Entities.order_detail>>(request);
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
            RestRequest request = this.RequestForFilter("order_details", "[id]", Filter, Sort, Limit, "order_details");
            List<PrestaSharp.Entities.FilterEntities.order_detail> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.order_detail>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all order_details. 
        /// </summary> 
        /// <returns>A list of order_details</returns> 
        public List<Entities.order_detail> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary> 
        /// Add a list of order_details. 
        /// </summary> 
        /// <param name="OrderStates"></param> 
        /// <returns></returns> 
        public List<Entities.order_detail> AddList(List<Entities.order_detail> OrderDetails)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.order_detail OrderDetail in OrderDetails)
            {
                OrderDetail.id = null; Entities.Add(OrderDetail);
            }
            RestRequest request = this.RequestForAdd("order_details", Entities); return this.Execute<List<Entities.order_detail>>(request);
        }
    }
}