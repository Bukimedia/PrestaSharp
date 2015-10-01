using System;
using RestSharp;
using RestSharp.Deserializers;

namespace Bukimedia.PrestaSharp.Deserializers
{
    public class PrestaSharpTextErrorDeserializer : IDeserializer
    {
        public T Deserialize<T>(IRestResponse response)
        {
            throw new Exception("Prestashop failed to serve XML response instead got text: " + response.Content);
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
    }
}