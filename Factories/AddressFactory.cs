using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
	public class AddressFactory : GenericFactory<address>
	{
		public AddressFactory(string BaseUrl, string Account, string SecretKey, bool PerformGetAfterAdd = true)
            : base(BaseUrl, Account, SecretKey, "addresses", "address", "addresses", PerformGetAfterAdd)
        {
        }

        /*public Entities.address Get(long AddressId)
        {
            return this.Get<address>(AddressId);
        }*/

        //public Entities.address Add(Entities.address Address)
        //{
        //    return Add<Entities.address>(Address);
        //}

        //public void Update(Entities.address Address)
        //{
        //    Update<address>(Address);
        //    RestRequest request = this.RequestForUpdate("addresses", Address.id, Address);
        //    this.Execute<Entities.address>(request);
        //}

        //public void Delete(long AddressId)
        //{
        //    RestRequest request = this.RequestForDelete("addresses", AddressId);
        //    this.Execute<Entities.address>(request);
        //}

        //public void Delete(Entities.address Address)
        //{
        //    this.Delete((long)Address.id);
        //}

        //public List<long> GetIds()
        //{
        //    RestRequest request = this.RequestForGet("addresses", null, "prestashop");
        //    return this.ExecuteForGetIds<List<long>>(request, "address");
        //}
        
        
        //public List<Entities.address> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        //{
        //    RestRequest request = this.RequestForFilter("addresses", "full", Filter, Sort, Limit, "addresses");
        //    return this.ExecuteForFilter<List<Entities.address>>(request);
        //}

        
        //public List<long> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        //{
        //    RestRequest request = this.RequestForFilter("addresses", "[id]", Filter, Sort, Limit, "addresses");
        //    List<PrestaSharp.Entities.FilterEntities.address> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.address>>(request);
        //    return (List<long>)(from t in aux select t.id).ToList<long>();
        //}

        /// <summary>
		/// Get all addresses.
        /// </summary>
		/// <returns>A list of addresses</returns>
        //public List<Entities.address> GetAll()
        //{
        //    return this.GetByFilter(null, null, null);
        //}

        /// <summary>
		/// Add a list of addresses.
        /// </summary>
		/// <param name="Addresses"></param>
        /// <returns></returns>
        //public List<Entities.address> AddList(List<Entities.address> Addresses)
        //{
        //    List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
        //    foreach (Entities.address Address in Addresses)
        //    {
        //        Address.id = null;
        //        Entities.Add(Address);
        //    }
        //    RestRequest request = this.RequestForAdd("addresses", Entities);
        //    return this.Execute<List<Entities.address>>(request);
        //}
	}
}
