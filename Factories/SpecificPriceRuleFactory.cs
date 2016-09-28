using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
	public class SpecificPriceRuleFactory : RestSharpFactory
	{
		public SpecificPriceRuleFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

		public Entities.specific_price_rule Get(long SpecificPriceId)
        {
			RestRequest request = this.RequestForGet("specific_price_rules", SpecificPriceId, "specific_price_rule");
			return this.Execute<Entities.specific_price_rule>(request);
        }

		public Entities.specific_price_rule Add(Entities.specific_price_rule SpecificPriceRule)
        {
			long? idAux = SpecificPriceRule.id;
			SpecificPriceRule.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
			Entities.Add(SpecificPriceRule);
			RestRequest request = this.RequestForAdd("specific_price_rules", Entities);
			Entities.specific_price_rule aux = this.Execute<Entities.specific_price_rule>(request);
			SpecificPriceRule.id = idAux;
            return this.Get((long)aux.id);
        }

		public void Update(Entities.specific_price_rule SpecificPriceRule)
        {
			RestRequest request = this.RequestForUpdate("specific_price_rules", SpecificPriceRule.id, SpecificPriceRule);
            this.Execute<Entities.specific_price_rule>(request);
        }

		public void Delete(long SpecificPriceRuleId)
        {
			RestRequest request = this.RequestForDelete("specific_price_rules", SpecificPriceRuleId);
            this.Execute<Entities.specific_price_rule>(request);
        }

		public void Delete(Entities.specific_price_rule SpecificPriceRule)
        {
			this.Delete((long)SpecificPriceRule.id);
        }

        public List<long> GetIds()
        {
			RestRequest request = this.RequestForGet("specific_price_rules", null, "prestashop");
			return this.ExecuteForGetIds<List<long>>(request, "specific_price_rule");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
		public List<Entities.specific_price_rule> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
			RestRequest request = this.RequestForFilter("specific_price_rules", "full", Filter, Sort, Limit, "specific_price_rules");
            return this.ExecuteForFilter<List<Entities.specific_price_rule>>(request);
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
			RestRequest request = this.RequestForFilter("specific_price_rules", "[id]", Filter, Sort, Limit, "specific_price_rules");
			List<PrestaSharp.Entities.FilterEntities.specific_price_rule> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.specific_price_rule>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
		/// Get all specific price rules.
        /// </summary>
		/// <returns>A list of specific price rules</returns>
        public List<Entities.specific_price_rule> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
		/// Add a list of specific price rules.
        /// </summary>
		/// <param name="SpecificPriceRules"></param>
        /// <returns></returns>
		public List<Entities.specific_price_rule> AddList(List<Entities.specific_price_rule> SpecificPriceRules)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
			foreach (Entities.specific_price_rule SpecificPriceRule in SpecificPriceRules)
            {
				SpecificPriceRule.id = null;
				Entities.Add(SpecificPriceRule);
            }
			RestRequest request = this.RequestForAdd("specific_price_rules", Entities);
			return this.Execute<List<Entities.specific_price_rule>>(request);
        }
	}
}
