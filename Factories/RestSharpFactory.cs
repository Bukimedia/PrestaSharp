using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Bukimedia.PrestaSharp.Deserializers;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Serializers;
using RestSharp;

namespace Bukimedia.PrestaSharp.Factories
{
    public abstract class RestSharpFactory
    {
        protected string BaseUrl { get; set; }
        protected string Account { get; set; }
        protected string Password { get; set; }

        public RestSharpFactory(string baseUrl, string account, string password)
        {
            BaseUrl = baseUrl;
            Account = account;
            Password = password;
        }

        #region Privates

        private void AddWsKey(RestRequest request)
        {
            request.AddParameter("ws_key", Account, ParameterType.QueryString); // used on every request
        }

        private void AddBody(RestRequest request, IEnumerable<PrestaShopEntity> entities)
        {
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new PrestaSharpSerializer();
            var serialized = string.Empty;
            foreach (var entity in entities)
            serialized += ((PrestaSharpSerializer) request.XmlSerializer).PrestaSharpSerialize(entity);
            serialized = "<prestashop>\n" + serialized + "\n</prestashop>";
            request.AddParameter("application/xml", serialized, ParameterType.RequestBody);
        }

        private void AddBody(RestRequest request, PrestaShopEntity entity)
        {
            AddBody(request, new PrestaShopEntity[] { entity });
        }

        private void AddHandlers(RestClient client, string rootElement)
        {
            client.ClearHandlers();
            client.AddHandler("text/xml", () => new PrestaSharpDeserializer { RootElement = rootElement });
            client.AddHandler("text/html", () => new PrestaSharpTextErrorDeserializer { RootElement = rootElement });
        }
        private void AddAuth(RestClient client)
        {
            client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(Account, Password);
        }

        #endregion

        #region Protected

        protected void CheckResponse(IRestResponse response, RestRequest request)
        {
            if (response.StatusCode == HttpStatusCode.InternalServerError
                            || response.StatusCode == HttpStatusCode.ServiceUnavailable
                            || response.StatusCode == HttpStatusCode.BadRequest
                            || response.StatusCode == HttpStatusCode.Unauthorized
                            || response.StatusCode == HttpStatusCode.MethodNotAllowed
                            || response.StatusCode == HttpStatusCode.Forbidden
                            || response.StatusCode == HttpStatusCode.NotFound
                            || response.StatusCode == 0 || response.ResponseStatus == ResponseStatus.Error)
            {
                var requestBody = string.Join(Environment.NewLine, request.Parameters.Where(x => x.Type == ParameterType.RequestBody).Select(x => x.Value));
                var errMex = string.IsNullOrWhiteSpace(response.ErrorMessage) ?
                    string.Join(Environment.NewLine, XDocument.Parse(response.Content).Descendants("error").Select(x => $"code: {x.Element("code").Value}, message: {x.Element("message").Value}"))
                    : response.ErrorMessage;
                throw new PrestaSharpException(requestBody, response.Content, errMex, response.StatusCode, response.ErrorException);
            }
        }

        #endregion

        protected T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(BaseUrl);
            AddHandlers(client, request.RootElement);
            var response = client.Execute<T>(request);
            CheckResponse(response, request);
            return response.Data;
        }

        protected void ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(BaseUrl);
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                        System.Diagnostics.Trace.WriteLine(response.ToString());
                    else
                        System.Diagnostics.Trace.WriteLine(response.ToString());
                });
            }
            catch (Exception error)
            {
                error.ToString();
            }
        }

        protected List<long> ExecuteForGetIds<T>(RestRequest request, string rootElement) where T : new()
        {
            var client = new RestClient(BaseUrl);
            var response = client.Execute<T>(request);
            CheckResponse(response, request);
            var xDcoument = XDocument.Parse(response.Content);
            var ids = xDcoument.Descendants(rootElement).Select(doc=> long.Parse(doc.Attribute("id").Value)).ToList();
            return ids;
        }

        protected byte[] ExecuteForImage(RestRequest request)
        {
            var client = new RestClient(BaseUrl);
            var response = client.Execute(request);
            CheckResponse(response, request);
            return response.RawBytes;
        }

        #region TaskAsync

        protected async Task<T> ExecuteTaskAsync<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(BaseUrl);
            AddHandlers(client, request.RootElement);
            var response = await client.ExecuteTaskAsync<T>(request);
            CheckResponse(response, request);
            return response.Data;
        }

        protected async Task<List<long>> ExecuteForGetIdsTaskAsync<T>(RestRequest request, string rootElement) where T : new()
        {
            var client = new RestClient(BaseUrl);
            var response = await client.ExecuteTaskAsync<T>(request);
            CheckResponse(response, request);
            var xDcoument = XDocument.Parse(response.Content);
            var ids = xDcoument.Descendants(rootElement).Select(doc => long.Parse(doc.Attribute("id").Value)).ToList();
            return ids;
        }
        protected async Task<byte[]> ExecuteForImageTask(RestRequest request)
        {
            var client = new RestClient(BaseUrl);
            var response = await client.ExecuteTaskAsync(request);
            CheckResponse(response, request);
            return response.RawBytes;
        }

        #endregion

        protected RestRequest RequestForGet(string resource, long? id, string rootElement)
        {
            var request = new RestRequest
            {
                Resource = resource + "/" + id,
                RootElement = rootElement
            };
            AddWsKey(request);
            return request;
        }

        protected RestRequest RequestForGetType(string resource, string id, string rootElement)
        {
            var request = new RestRequest
            {
                Resource = resource + "/" + id,
                RootElement = rootElement
            };
            AddWsKey(request);
            return request;
        }

        protected RestRequest RequestForAdd(string resource, IEnumerable<PrestaShopEntity> entities)
        {
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.POST
            };
            AddBody(request, entities);
            AddWsKey(request);
            return request;
        }

        /// <summary>
        ///     More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        protected RestRequest RequestForAddImage(string resource, long? id, string imagePath)
        {
            if (id == null) throw new ApplicationException("The Id field cannot be null.");

            var request = new RestRequest
            {
                Resource = "/images/" + resource + "/" + id,
                Method = Method.POST,
                RequestFormat = DataFormat.Xml
            };
            request.AddFile("image", imagePath);
            AddWsKey(request);
            return request;
        }

        /// <summary>
        ///     More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <param name="image"></param>
        /// <param name="imageFileName"></param>
        /// <returns></returns>
        protected RestRequest RequestForAddImage(string resource, long? id, byte[] image, string imageFileName = null)
        {
            if (id == null) throw new ApplicationException("The Id field cannot be null.");

            var request = new RestRequest
            {
                Resource = "/images/" + resource + "/" + id,
                Method = Method.POST,
                RequestFormat = DataFormat.Xml
            };
            request.AddFile("image", image, string.IsNullOrWhiteSpace(imageFileName) ? "dummy.png" : imageFileName);
            AddWsKey(request);
            return request;
        }

        /// <summary>
        ///     More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        protected RestRequest RequestForUpdateImage(string resource, long id, string imagePath)
        {
            var request = new RestRequest
            {
                Resource = "/images/" + resource + "/" + id,
                Method = Method.PUT,
                RequestFormat = DataFormat.Xml
            };

            // BUG

            request.AddFile("image", imagePath);
            AddWsKey(request);
            return request;
        }

        protected RestRequest RequestForUpdate(string resource, long? id, PrestaShopEntity prestashopEntity)
        {
            if (id == null) throw new ApplicationException("Id is required to update something.");

            var request = new RestRequest
            {
                RootElement = "prestashop",
                Resource = resource,
                Method = Method.PUT
            };
            request.AddParameter("id", id, ParameterType.UrlSegment);
            AddBody(request, prestashopEntity);
            AddWsKey(request);
            return request;
        }

        protected RestRequest RequestForUpdateList(string resource, IEnumerable<PrestaShopEntity> entities)
        {
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.PUT
            };
            AddBody(request, entities);
            AddWsKey(request);
            return request;
        }

        protected RestRequest RequestForDeleteImage(string resource, long? resourceId, long? imageId)
        {
            if (resourceId == null) throw new ApplicationException("Id is required to delete something.");
            var request = new RestRequest
            {
                RootElement = "prestashop",
                Resource = "/images/" + resource + "/" + resourceId,
                Method = Method.DELETE,
                RequestFormat = DataFormat.Xml
            };
            if (imageId != null) request.Resource += "/" + imageId;
            AddWsKey(request);
            return request;
        }

        protected RestRequest RequestForDelete(string resource, long? id)
        {
            if (id == null) throw new ApplicationException("Id is required to delete something.");
            var request = new RestRequest
            {
                RootElement = "prestashop",
                Resource = resource + "/" + id,
                Method = Method.DELETE,
                RequestFormat = DataFormat.Xml
            };
            AddWsKey(request);
            return request;
        }

        /// <summary>
        ///     More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="display"></param>
        /// <param name="filter"></param>
        /// <param name="sort"></param>
        /// <param name="limit"></param>
        /// <param name="rootElement"></param>
        /// <returns></returns>
        protected RestRequest RequestForFilter(string resource, string display, Dictionary<string, string> filter,
            string sort, string limit, string rootElement)
        {
            var request = new RestRequest
            {
                Resource = resource,
                RootElement = rootElement
            };
            if (display != null) request.AddParameter("display", display);
            if (filter != null)
                foreach (var key in filter.Keys)
                    request.AddParameter("filter[" + key + "]", filter[key]);
            if (!string.IsNullOrEmpty(sort)) request.AddParameter("sort", sort);
            if (!string.IsNullOrEmpty(limit)) request.AddParameter("limit", limit);
            // Support for filter by date range
            request.AddParameter("date", "1");
            AddWsKey(request);
            return request;
        }

        protected RestRequest RequestForAddOrderHistory(string resource, IEnumerable<PrestaShopEntity> entities)
        {
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.POST
            };
            AddBody(request, entities);
            request.AddParameter("sendemail", 1);
            AddWsKey(request);
            return request;
        }

        public static byte[] ImageToBinary(string imagePath)
        {
            var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            var buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            return buffer;
        }

    }
}