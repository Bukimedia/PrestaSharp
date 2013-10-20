using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
{
    public class ManufacturerFactory : RestSharpFactory
    {
        public ManufacturerFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.manufacturer Get(long ManufacturerId)
        {
            RestRequest request = this.RequestForGet("manufacturers", ManufacturerId, "manufacturer");
            return this.Execute<Entities.manufacturer>(request);
        }

        public Entities.manufacturer Add(Entities.manufacturer Manufacturer)
        {
            Manufacturer.id=null;
            RestRequest request = this.RequestForAdd("manufacturers", Manufacturer);
            return this.Execute<Entities.manufacturer>(request);
        }


        public void Update(Entities.manufacturer Manufacturer)
        {
            RestRequest request = this.RequestForUpdate("manufacturers", Manufacturer.id, Manufacturer);
            this.Execute<Entities.manufacturer>(request);
        }

        public void Delete(Entities.manufacturer Manufacturer)
        {
            RestRequest request = this.RequestForDelete("manufacturers", Manufacturer.id);
            this.Execute<Entities.manufacturer>(request);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("manufacturers", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "manufacturer");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.manufacturer> GetByFilter(Dictionary<string,string>Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("manufacturers", "full", Filter, Sort, Limit, "manufacturers");
            return this.Execute<List<Entities.manufacturer>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.manufacturer> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }


    }
}
