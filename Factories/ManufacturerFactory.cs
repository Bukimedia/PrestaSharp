using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Serializers
{
    public class ManufacturerFactory : RestSharpFactory
    {
        public ManufacturerFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.manufacturer Get(int ManufacturerId)
        {
            RestRequest request = this.RequestForGet("manufacturers", ManufacturerId, "manufacturer");
            return this.Execute<Entities.manufacturer>(request);
        }

        public void Add(Entities.manufacturer Manufacturer)
        {
            Manufacturer.id=null;
            RestRequest request = this.RequestForAdd("manufacturers", Manufacturer);
            this.Execute<Entities.manufacturer>(request);
        }

        public void Update(Entities.manufacturer Manufacturer)
        {
            RestRequest request = this.RequestForUpdate("manufacturers", Manufacturer.id, Manufacturer);
            try
            {
                this.Execute<Entities.manufacturer>(request);
            }
            catch (ApplicationException ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Entities.manufacturer Manufacturer)
        {
            RestRequest request = this.RequestForDelete("manufacturers", Manufacturer.id);
            this.Execute<Entities.manufacturer>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("manufacturers", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "manufacturer");
        }

    }
}
