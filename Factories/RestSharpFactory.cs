using Bukimedia.PrestaSharp.Deserializers;
using Bukimedia.PrestaSharp.Lib;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RestSharp.Authenticators;

namespace Bukimedia.PrestaSharp.Factories
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
            client.AddHandler("text/html", new PrestaSharpTextErrorDeserializer());
            client.BaseUrl = new Uri(this.BaseUrl);
            //client.Authenticator = new HttpBasicAuthenticator(this.Account, this.Password);
            Request.AddParameter("ws_key", this.Account, ParameterType.QueryString); // used on every request
            if (Request.Method == Method.GET)
            {
                client.ClearHandlers();
                client.AddHandler("text/xml", new Bukimedia.PrestaSharp.Deserializers.PrestaSharpDeserializer());
            }
            var response = client.Execute<T>(Request);
            if (response.StatusCode == HttpStatusCode.InternalServerError
                || response.StatusCode == HttpStatusCode.ServiceUnavailable
                || response.StatusCode == HttpStatusCode.BadRequest
                || response.StatusCode == HttpStatusCode.Unauthorized
                || response.StatusCode == HttpStatusCode.MethodNotAllowed
                || response.StatusCode == HttpStatusCode.Forbidden
                || response.StatusCode == HttpStatusCode.NotFound
                || response.StatusCode == 0)
            {
                string RequestParameters = Environment.NewLine;
                foreach (RestSharp.Parameter Parameter in Request.Parameters)
                {
                    RequestParameters += Parameter.Value + Environment.NewLine + Environment.NewLine;
                }
                var Exception = new PrestaSharpException(RequestParameters + response.Content, response.ErrorMessage, response.StatusCode, response.ErrorException);
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

        protected T ExecuteForFilter<T>(RestRequest Request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(this.BaseUrl);
            //client.Authenticator = new HttpBasicAuthenticator(this.Account, this.Password);
            Request.AddParameter("ws_key", this.Account, ParameterType.QueryString); // used on every request
            client.ClearHandlers();
            client.AddHandler("text/xml", new Bukimedia.PrestaSharp.Deserializers.PrestaSharpDeserializer());
            var response = client.Execute<T>(Request);
            if (response.StatusCode == HttpStatusCode.InternalServerError
                || response.StatusCode == HttpStatusCode.ServiceUnavailable
                || response.StatusCode == HttpStatusCode.BadRequest
                || response.StatusCode == HttpStatusCode.Unauthorized
                || response.StatusCode == HttpStatusCode.MethodNotAllowed
                || response.StatusCode == HttpStatusCode.Forbidden
                || response.StatusCode == HttpStatusCode.NotFound
                || response.StatusCode == 0)
            {
                string RequestParameters = Environment.NewLine;
                foreach (RestSharp.Parameter Parameter in Request.Parameters)
                {
                    RequestParameters += Parameter.Value + Environment.NewLine + Environment.NewLine;
                }
                var Exception = new PrestaSharpException(RequestParameters + response.Content, response.ErrorMessage, response.StatusCode, response.ErrorException);
                throw Exception;
            }
            return response.Data;
        }

        protected List<long> ExecuteForGetIds<T>(RestRequest Request, string RootElement) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(this.BaseUrl);
            //client.Authenticator = new HttpBasicAuthenticator(this.Account, this.Password);
            Request.AddParameter("ws_key", this.Account, ParameterType.QueryString);
            var response = client.Execute<T>(Request);
            XDocument xDcoument = XDocument.Parse(response.Content);
            var ids = (from doc in xDcoument.Descendants(RootElement)
                       select long.Parse(doc.Attribute("id").Value)).ToList();
            return ids;
        }

        protected byte[] ExecuteForImage(RestRequest Request)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(this.BaseUrl);
            //client.Authenticator = new HttpBasicAuthenticator(this.Account, this.Password);
            Request.AddParameter("ws_key", this.Account, ParameterType.QueryString);
            var response = client.Execute(Request);
            if (response.StatusCode == HttpStatusCode.InternalServerError
                || response.StatusCode == HttpStatusCode.ServiceUnavailable
                || response.StatusCode == HttpStatusCode.BadRequest
                || response.StatusCode == HttpStatusCode.Unauthorized
                || response.StatusCode == HttpStatusCode.MethodNotAllowed
                || response.StatusCode == HttpStatusCode.Forbidden
                || response.StatusCode == HttpStatusCode.NotFound
                || response.StatusCode == 0)
            {
                string RequestParameters = Environment.NewLine;
                foreach (RestSharp.Parameter Parameter in Request.Parameters)
                {
                    RequestParameters += Parameter.Value + Environment.NewLine + Environment.NewLine;
                }
                var Exception = new PrestaSharpException(RequestParameters + response.Content, response.ErrorMessage, response.StatusCode, response.ErrorException);
                throw Exception;
            }
            return response.RawBytes;
        }

        protected RestRequest RequestForGet(string Resource, long? Id, string RootElement)
        {
            var request = new RestRequest();
            request.Resource = Resource + "/" + Id;
            request.RootElement = RootElement;
            return request;
        }

        protected RestRequest RequestForAdd(string Resource, List<Entities.PrestaShopEntity> Entities)
        {
            var request = new RestRequest();
            request.Resource = Resource;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            //Hack implementation in PrestaSharpSerializer to serialize PrestaSharp.Entities.AuxEntities.language
            request.XmlSerializer = new Serializers.PrestaSharpSerializer();
            string serialized = "";
            foreach (Entities.PrestaShopEntity Entity in Entities)
            {
                serialized += ((Serializers.PrestaSharpSerializer)request.XmlSerializer).PrestaSharpSerialize(Entity);
            }
            serialized = "<prestashop>\n" + serialized + "\n</prestashop>";
            request.AddParameter("application/xml", serialized, ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="Resource"></param>
        /// <param name="Id"></param>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        protected RestRequest RequestForAddImage(string Resource, long? Id, string ImagePath)
        {
            if (Id == null)
            {
                throw new ApplicationException("The Id field cannot be null.");
            }
            var request = new RestRequest();
            request.Resource = "/images/" + Resource + "/" + Id;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.AddFile("image", ImagePath);
            return request;
        }
        
        /// <summary>
        /// More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="Resource"></param>
        /// <param name="Id"></param>
        /// <param name="Image"></param>
        /// <returns></returns>
        protected RestRequest RequestForAddImage(string Resource, long? Id, byte[] Image)
        {
            if (Id == null)
            {
                throw new ApplicationException("The Id field cannot be null.");
            }
            var request = new RestRequest();
            request.Resource = "/images/" + Resource + "/" + Id;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.AddFile("image", Image, "dummy.png");
            return request;
        }

        /// <summary>
        /// More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="Resource"></param>
        /// <param name="Id"></param>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        protected RestRequest RequestForUpdateImage(string Resource, long Id, string ImagePath)
        {
            var request = new RestRequest();
            request.Resource = "/images/" + Resource + "/" + Id;

            // BUG

            request.Method = Method.PUT;
            request.RequestFormat = DataFormat.Xml;
            request.AddFile("image", ImagePath);
            return request;
        }

        protected RestRequest RequestForUpdate(string Resource, long? Id, Entities.PrestaShopEntity PrestashopEntity)
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
            //issue #81, #54 fixed
            request.Parameters[1].Value = Functions.ReplaceFirstOccurrence(request.Parameters[1].Value.ToString(), "<" + PrestashopEntity.GetType().Name + ">", "<prestashop>\n<" + PrestashopEntity.GetType().Name + ">");
            request.Parameters[1].Value = Functions.ReplaceLastOccurrence(request.Parameters[1].Value.ToString(), "</" + PrestashopEntity.GetType().Name + ">", "</" + PrestashopEntity.GetType().Name + ">\n</prestashop>");
            //issue #36 fixed
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("xmlns=\"Bukimedia/PrestaSharp/Entities\"", "xmlns=\"\"");
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("xmlns=\"Bukimedia/PrestaSharp/Entities/AuxEntities\"", "xmlns=\"\"");
            return request;
        }
       // For Update List Of Products - start
        protected RestRequest RequestForUpdateList(string Resource, List<Entities.PrestaShopEntity> Entities)
        {
            var request = new RestRequest();
            request.Resource = Resource;
            request.Method = Method.PUT;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new Serializers.PrestaSharpSerializer();
            string serialized = "";
            foreach (Entities.PrestaShopEntity Entity in Entities)
            {
                serialized += ((Serializers.PrestaSharpSerializer)request.XmlSerializer).PrestaSharpSerialize(Entity);
            }
            serialized = "<prestashop>\n" + serialized + "\n</prestashop>";
            request.AddParameter("application/xml", serialized, ParameterType.RequestBody);
            return request;
        }
        // For Update List Of Products - end
        protected RestRequest RequestForDeleteImage(string Resource, long? ResourceId, long? ImageId)
        {
            if (ResourceId == null)
            {
                throw new ApplicationException("Id is required to delete something.");
            }
            var request = new RestRequest();
            request.RootElement = "prestashop";
            request.Resource = "/images/" + Resource + "/" + ResourceId;
            if (ImageId != null)
            {
                request.Resource += "/" + ImageId;
            }
            request.Method = Method.DELETE;
            request.RequestFormat = DataFormat.Xml;
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
            if (!string.IsNullOrEmpty(Sort))
            {
                request.AddParameter("sort", Sort);
            }
            if (!string.IsNullOrEmpty(Limit))
            {
                request.AddParameter("limit", Limit);
            }
            // Support for filter by date range
            request.AddParameter("date", "1");
            return request;
        }

        protected RestRequest RequestForAddOrderHistory(string Resource, List<Entities.PrestaShopEntity> Entities)
        {
            var request = new RestRequest();
            request.Resource = Resource;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new Serializers.PrestaSharpSerializer();
            string serialized = "";
            foreach (Entities.PrestaShopEntity Entity in Entities)
            {
                serialized += ((Serializers.PrestaSharpSerializer)request.XmlSerializer).PrestaSharpSerialize(Entity);
            }
            serialized = "<prestashop>\n" + serialized + "\n</prestashop>";
            request.AddParameter("application/xml", serialized);
            request.AddParameter("sendemail", 1);
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
