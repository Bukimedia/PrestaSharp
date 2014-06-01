using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ZoneFactory : RestSharpFactory
    {
        public ZoneFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.zone Get(long ZoneId)
        {
            RestRequest request = this.RequestForGet("zones", ZoneId, "zone");
            return this.Execute<Entities.zone>(request);
        }

        public Entities.zone Add(Entities.zone Zone)
        {
            long? idAux = Zone.id;
            Zone.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Zone);
            RestRequest request = this.RequestForAdd("zones", Entities);
            Entities.zone aux = this.Execute<Entities.zone>(request);
            Zone.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.zone Zone)
        {
            RestRequest request = this.RequestForUpdate("zones", Zone.id, Zone);
            this.Execute<Entities.zone>(request);
        }

        public void Delete(long ZoneId)
        {
            RestRequest request = this.RequestForDelete("zones", ZoneId);
            this.Execute<Entities.zone>(request);
        }

        public void Delete(Entities.zone Zone)
        {
            this.Delete((long)Zone.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("zones", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "zone");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.zone> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("zones", "full", Filter, Sort, Limit, "zones");
            return this.ExecuteForFilter<List<Entities.zone>>(request);
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
            RestRequest request = this.RequestForFilter("zones", "[id]", Filter, Sort, Limit, "zones");
            List<PrestaSharp.Entities.FilterEntities.zone> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.zone>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all zones.
        /// </summary>
        /// <returns>A list of zones</returns>
        public List<Entities.zone> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of zones.
        /// </summary>
        /// <param name="Zones"></param>
        /// <returns></returns>
        public List<Entities.zone> AddList(List<Entities.zone> Zones)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.zone Zone in Zones)
            {
                Zone.id = null;
                Entities.Add(Zone);
            }
            RestRequest request = this.RequestForAdd("zones", Entities);
            return this.Execute<List<Entities.zone>>(request);
        }        
    }
}
