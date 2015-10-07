using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class CombinationFactory : RestSharpFactory
    {
        public CombinationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.combination Get(long CombinationId)
        {
            RestRequest request = this.RequestForGet("combinations", CombinationId, "combination");
            return this.Execute<Entities.combination>(request);
        }

        public Entities.combination Add(Entities.combination Combination)
        {
            long? idAux = Combination.id;
            Combination.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Combination);
            RestRequest request = this.RequestForAdd("combinations", Entities);
            Entities.combination aux = this.Execute<Entities.combination>(request);
            Combination.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.combination Combination)
        {
            RestRequest request = this.RequestForUpdate("combinations", Combination.id, Combination);
            this.Execute<Entities.combination>(request);
        }

        public void Delete(long CombinationId)
        {
            RestRequest request = this.RequestForDelete("combinations", CombinationId);
            this.Execute<Entities.combination>(request);
        }

        public void Delete(Entities.combination Combination)
        {
            this.Delete((long)Combination.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("combinations", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "combination");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.combination> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("combinations", "full", Filter, Sort, Limit, "combinations");
            return this.ExecuteForFilter<List<Entities.combination>>(request);
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
            RestRequest request = this.RequestForFilter("combinations", "[id]", Filter, Sort, Limit, "combinations");
            List<PrestaSharp.Entities.FilterEntities.combination> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.combination>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all combinations.
        /// </summary>
        /// <returns>A list of combinations</returns>
        public List<Entities.combination> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of combinations.
        /// </summary>
        /// <param name="Combinations"></param>
        /// <returns></returns>
        public List<Entities.combination> AddList(List<Entities.combination> Combinations)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.combination Combination in Combinations)
            {
                Combination.id = null;
                Entities.Add(Combination);
            }
            RestRequest request = this.RequestForAdd("combinations", Entities);
            return this.Execute<List<Entities.combination>>(request);
        }
    }
}