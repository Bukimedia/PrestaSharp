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

        public Entities.manufacturer GetManufacturer(int ManufacturerId)
        {
            var request = new RestRequest();
            request.Resource = "manufacturers/{id}";
            request.RootElement = "manufacturer";
            request.AddParameter("id", ManufacturerId, ParameterType.UrlSegment);
            return this.Execute<Entities.manufacturer>(request);
        }

        public void AddManufacturer(Entities.manufacturer Manufacturer)
        {
            Manufacturer.id = null;
            var request = new RestRequest();
            request.Resource = "manufacturers/";
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            string serialized = request.XmlSerializer.Serialize(Manufacturer);
            serialized = serialized.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<prestashop>");
            serialized += "\n</prestashop>";         
            request.AddParameter("xml", serialized);
            this.Execute<Entities.manufacturer>(request);
        }

        public void UpdateManufacturer(Entities.manufacturer Manufacturer)
        {
            var request = new RestRequest();
            request.RootElement = "prestashop";
            request.Resource = "manufacturers/{id}";
            request.AddParameter("id", Manufacturer.id, ParameterType.UrlSegment);
            request.Method = Method.PUT;            
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            request.AddBody(Manufacturer);
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("<manufacturer>","<prestashop>\n<manufacturer>");
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("</manufacturer>", "</manufacturer></prestashop>");
            try
            {
                this.Execute<Entities.manufacturer>(request);
            }
            catch (ApplicationException ex)
            {
                ex.ToString();
            }
        }

        public void DeleteManufacturer(Entities.manufacturer Manufacturer)
        {
            var request = new RestRequest();
            request.RootElement = "prestashop";
            request.Resource = "manufacturers/" + Manufacturer.id;
            request.Method = Method.DELETE;
            request.RequestFormat = DataFormat.Xml;
            request.AddBody(Manufacturer);
            this.Execute<Entities.manufacturer>(request);
        }


    }
}
