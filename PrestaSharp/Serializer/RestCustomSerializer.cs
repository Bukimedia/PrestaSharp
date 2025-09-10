using Bukimedia.PrestaSharp.Serializer;
using RestSharp;
using RestSharp.Serializers;
using System;

namespace Bukimedia.PrestaSharp.Serializer
{
    public class RestCustomSerializer : IRestSerializer
    {
        private XMLSerializer sharpSerializer = new XMLSerializer();
        public string? Serialize(object? obj) => obj == null ? null : sharpSerializer.Serialize(obj);
        public string? Serialize(Parameter bodyParameter) => Serialize(bodyParameter.Value);
        private XMLDeserializer sharpDeserializer = new XMLDeserializer();
        public T? Deserialize<T>(RestResponse response) => sharpDeserializer.Deserialize<T>(response);
        public ContentType ContentType { get; set; } = ContentType.Xml;
        public ISerializer Serializer => new XMLSerializer();
        public IDeserializer Deserializer => new XMLDeserializer();
        public DataFormat DataFormat => DataFormat.Xml;
        public string[] AcceptedContentTypes => ContentType.XmlAccept;
        public SupportsContentType SupportsContentType
            => contentType => contentType.Value.EndsWith("xml", StringComparison.InvariantCultureIgnoreCase);
    }
}
