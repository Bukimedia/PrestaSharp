using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class StateFactory : RestSharpFactory
    {
        public StateFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.state Get(long StateId)
        {
            RestRequest request = this.RequestForGet("states", StateId, "state");
            return this.Execute<Entities.state>(request);
        }

        public Entities.state Add(Entities.state State)
        {
            long? idAux = State.id;
            State.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(State);
            RestRequest request = this.RequestForAdd("states", Entities);
            Entities.state aux = this.Execute<Entities.state>(request);
            State.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.state State)
        {
            RestRequest request = this.RequestForUpdate("states", State.id, State);
            this.Execute<Entities.state>(request);
        }

        public void Delete(long StateId)
        {
            RestRequest request = this.RequestForDelete("states", StateId);
            this.Execute<Entities.state>(request);
        }

        public void Delete(Entities.state State)
        {
            this.Delete((long)State.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("states", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "state");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.state> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("states", "full", Filter, Sort, Limit, "states");
            return this.ExecuteForFilter<List<Entities.state>>(request);
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
            RestRequest request = this.RequestForFilter("states", "[id]", Filter, Sort, Limit, "states");
            List<PrestaSharp.Entities.FilterEntities.state> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.state>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all states.
        /// </summary>
        /// <returns>A list of states</returns>
        public List<Entities.state> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of states.
        /// </summary>
        /// <param name="States"></param>
        /// <returns></returns>
        public List<Entities.state> AddList(List<Entities.state> States)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.state state in States)
            {
                state.id = null;
                Entities.Add(state);
            }
            RestRequest request = this.RequestForAdd("states", Entities);
            return this.Execute<List<Entities.state>>(request);
        }        
    }
}
