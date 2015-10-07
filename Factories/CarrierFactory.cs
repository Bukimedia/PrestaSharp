using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CarrierFactory : RestSharpFactory
    {
        public CarrierFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.carrier Get(long CarrierId)
        {
            RestRequest request = this.RequestForGet("carriers", CarrierId, "carrier");
            return this.Execute<Entities.carrier>(request);
        }

        public Entities.carrier Add(Entities.carrier Carrier)
        {
            long? idAux = Carrier.id;
            Carrier.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Carrier);
            RestRequest request = this.RequestForAdd("carriers", Entities);
            Entities.carrier aux = this.Execute<Entities.carrier>(request);
            Carrier.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.carrier Carrier)
        {
            RestRequest request = this.RequestForUpdate("carriers", Carrier.id, Carrier);
            this.Execute<Entities.carrier>(request);
        }

        public void Delete(long CarrierId)
        {
            RestRequest request = this.RequestForDelete("carriers", CarrierId);
            this.Execute<Entities.carrier>(request);
        }

        public void Delete(Entities.carrier Carrier)
        {
            this.Delete((long)Carrier.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("carriers", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "carrier");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.carrier> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("carriers", "full", Filter, Sort, Limit, "carriers");
            return this.ExecuteForFilter<List<Entities.carrier>>(request);
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
            RestRequest request = this.RequestForFilter("carriers", "[id]", Filter, Sort, Limit, "carriers");
            List<PrestaSharp.Entities.FilterEntities.carrier> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.carrier>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all carriers.
        /// </summary>
        /// <returns>A list of carriers</returns>
        public List<Entities.carrier> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of carriers.
        /// </summary>
        /// <param name="Carriers"></param>
        /// <returns></returns>
        public List<Entities.carrier> AddList(List<Entities.carrier> Carriers)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.carrier Carrier in Carriers)
            {
                Carrier.id = null;
                Entities.Add(Carrier);
            }
            RestRequest request = this.RequestForAdd("carriers", Entities);
            return this.Execute<List<Entities.carrier>>(request);
        }        
    }
}
