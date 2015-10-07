using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
	public class SpecificPriceFactory : RestSharpFactory
	{
		public SpecificPriceFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

		public Entities.specific_price Get(long SpecificPriceId)
        {
			RestRequest request = this.RequestForGet("specific_prices", SpecificPriceId, "specific_price");
			return this.Execute<Entities.specific_price>(request);
        }

		public Entities.specific_price Add(Entities.specific_price SpecificPrice)
        {
			long? idAux = SpecificPrice.id;
			SpecificPrice.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
			Entities.Add(SpecificPrice);
			RestRequest request = this.RequestForAdd("specific_prices", Entities);
			Entities.specific_price aux = this.Execute<Entities.specific_price>(request);
			SpecificPrice.id = idAux;
            return this.Get((long)aux.id);
        }

		public void Update(Entities.specific_price SpecificPrice)
        {
			RestRequest request = this.RequestForUpdate("specific_prices", SpecificPrice.id, SpecificPrice);
            this.Execute<Entities.specific_price>(request);
        }

		public void Delete(long SpecificPriceId)
        {
			RestRequest request = this.RequestForDelete("specific_prices", SpecificPriceId);
            this.Execute<Entities.specific_price>(request);
        }

		public void Delete(Entities.specific_price SpecificPrice)
        {
			this.Delete((long)SpecificPrice.id);
        }

        public List<long> GetIds()
        {
			RestRequest request = this.RequestForGet("specific_prices", null, "prestashop");
			return this.ExecuteForGetIds<List<long>>(request, "specific_price");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
		public List<Entities.specific_price> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
			RestRequest request = this.RequestForFilter("specific_prices", "full", Filter, Sort, Limit, "specific_prices");
            return this.ExecuteForFilter<List<Entities.specific_price>>(request);
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
			RestRequest request = this.RequestForFilter("specific_prices", "[id]", Filter, Sort, Limit, "specific_prices");
			List<PrestaSharp.Entities.FilterEntities.specific_price> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.specific_price>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
		/// Get all specific prices.
        /// </summary>
		/// <returns>A list of specific prices</returns>
        public List<Entities.specific_price> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
		/// Add a list of specific prices.
        /// </summary>
		/// <param name="SpecificPrices"></param>
        /// <returns></returns>
		public List<Entities.specific_price> AddList(List<Entities.specific_price> SpecificPrices)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
			foreach (Entities.specific_price SpecificPrice in SpecificPrices)
            {
				SpecificPrice.id = null;
				Entities.Add(SpecificPrice);
            }
			RestRequest request = this.RequestForAdd("specific_prices", Entities);
			return this.Execute<List<Entities.specific_price>>(request);
        }
	}
}
