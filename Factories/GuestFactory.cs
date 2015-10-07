using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class GuestFactory : RestSharpFactory
    {
        public GuestFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.guest Get(long GuestId)
        {
            RestRequest request = this.RequestForGet("guests", GuestId, "guest");
            return this.Execute<Entities.guest>(request);
        }

        public Entities.guest Add(Entities.guest Guest)
        {
            long? idAux = Guest.id;
            Guest.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Guest);
            RestRequest request = this.RequestForAdd("guests", Entities);
            Entities.guest aux = this.Execute<Entities.guest>(request);
            Guest.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.guest Guest)
        {
            RestRequest request = this.RequestForUpdate("guests", Guest.id, Guest);
            this.Execute<Entities.guest>(request);
        }

        public void Delete(long GuestId)
        {
            RestRequest request = this.RequestForDelete("guests", GuestId);
            this.Execute<Entities.guest>(request);
        }

        public void Delete(Entities.guest Guest)
        {
            this.Delete((long)Guest.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("guests", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "guest");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.guest> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("guests", "full", Filter, Sort, Limit, "guests");
            return this.ExecuteForFilter<List<Entities.guest>>(request);
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
            RestRequest request = this.RequestForFilter("guests", "[id]", Filter, Sort, Limit, "guests");
            List<PrestaSharp.Entities.FilterEntities.guest> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.guest>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all guests.
        /// </summary>
        /// <returns>A list of guests</returns>
        public List<Entities.guest> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of guests.
        /// </summary>
        /// <param name="Guests"></param>
        /// <returns></returns>
        public List<Entities.guest> AddList(List<Entities.guest> Guests)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.guest Guest in Guests)
            {
                Guest.id = null;
                Entities.Add(Guest);
            }
            RestRequest request = this.RequestForAdd("guests", Entities);
            return this.Execute<List<Entities.guest>>(request);
        }        
    }
}
