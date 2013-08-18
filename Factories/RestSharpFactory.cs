using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrestaSharp.Serializers
{
    public abstract class RestSharpFactory
    {

        protected string BaseUrl{get;set;}
        protected string Account{get;set;}
        protected string Password{get;set;}

        public RestSharpFactory(string BaseUrl, string Account, string Password)
        {
            this.BaseUrl = BaseUrl;
            this.Account = Account;
            this.Password = Password;
        }

        protected T Execute<T>(RestRequest Request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = this.BaseUrl;
            client.Authenticator = new HttpBasicAuthenticator(this.Account, this.Password);
            Request.AddParameter("Account", this.Account, ParameterType.UrlSegment); // used on every request
            var response = client.Execute<T>(Request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var Exception = new ApplicationException(message, response.ErrorException);
                throw Exception;
            }
            return response.Data;
        }

        protected void ExecuteAsync<T>(RestRequest Request) where T : new()
        {
            var client = new RestClient(this.BaseUrl);
            try
            {
                client.ExecuteAsync(Request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine(response.ToString());
                    }
                    else
                    {
                        Console.WriteLine(response.ToString());
                    }
                });
            }
            catch (Exception error)
            {
                error.ToString();
            }
        }

        protected RestRequest RequestForGet(string Resource, int? Id, string RootElement)
        {
            var request = new RestRequest();
            request.Resource = Resource + "/" + Id;
            request.RootElement = RootElement;
            return request;
        }

        protected List<int> ExecuteForGetIds<T>(RestRequest Request, string RootElement) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = this.BaseUrl;
            client.Authenticator = new HttpBasicAuthenticator(this.Account, this.Password);
            Request.AddParameter("Account", this.Account, ParameterType.UrlSegment);
            var response = client.Execute<T>(Request);
            XDocument xDcoument = XDocument.Parse(response.Content);
            var ids = (from doc in xDcoument.Descendants(RootElement)
                       select int.Parse(doc.Attribute("id").Value)).ToList();
            return ids;
        }

        protected RestRequest RequestForAdd(string Resource, Entities.PrestashopEntity Entity)
        {
            var request = new RestRequest();
            request.Resource = Resource;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            string serialized = request.XmlSerializer.Serialize(Entity);
            serialized = serialized.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<prestashop>");
            serialized += "\n</prestashop>";
            request.AddParameter("xml", serialized);
            return request;
        }

        /// <summary>
        /// More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="Resource"></param>
        /// <param name="Id"></param>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        protected RestRequest RequestForAddImage(string Resource, int Id, string ImagePath)
        {
            var request = new RestRequest();
            request.Resource = "/images/" + Resource + "/" + Id;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            byte[] ImgBytes = ImageToBinary(ImagePath);
            request.AddParameter("images", ImgBytes);
            return request;
        }

        protected RestRequest RequestForUpdate(string Resource, long? Id, Entities.PrestashopEntity PrestashopEntity)
        {
            if (Id == null)
            {
                throw new ApplicationException("Id is required to update something.");
            }
            var request = new RestRequest();
            request.RootElement = "prestashop";
            request.Resource = Resource;
            request.AddParameter("id", Id, ParameterType.UrlSegment);
            request.Method = Method.PUT;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            request.AddBody(PrestashopEntity);
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("<" + PrestashopEntity.GetType().Name+">", "<prestashop>\n<" + PrestashopEntity.GetType().Name + ">");
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("</" + PrestashopEntity.GetType().Name + ">", "</" + PrestashopEntity.GetType().Name + "></prestashop>");
            return request;
        }

        protected RestRequest RequestForDelete(string Resource, long? Id)
        {
            if (Id == null)
            {
                throw new ApplicationException("Id is required to delete something.");
            }
            var request = new RestRequest();
            request.RootElement = "prestashop";
            request.Resource = Resource + "/" + Id;
            request.Method = Method.DELETE;
            request.RequestFormat = DataFormat.Xml;
            return request;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Resource"></param>
        /// <param name="Display"></param>
        /// <param name="Filter"></param>
        /// <param name="Sort"></param>
        /// <param name="Limit"></param>
        /// <param name="RootElement"></param>
        /// <returns></returns>
        protected RestRequest RequestForFilter(string Resource, string Display, Dictionary<string,string> Filter, string Sort, string Limit, string RootElement)
        {
            var request = new RestRequest();
            request.Resource = Resource;
            request.RootElement = RootElement;
            if (Display != null)
            {
                request.AddParameter("display", Display);
            }
            if (Filter != null)
            {
                foreach (string Key in Filter.Keys)
                {
                    request.AddParameter("filter[" + Key + "]", Filter[Key]);
                }
            }
            if (Sort != null)
            {
                request.AddParameter("sort", Sort);
            }
            if (Limit != null)
            {
                request.AddParameter("limit", Limit);
            }
            return request;
        }

        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            return buffer;
        }

    }
}
