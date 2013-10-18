using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RestSharp.Extensions;
using System.Collections;

namespace PrestaSharp.Serializers
{
    class PrestaSharpSerializer : XmlSerializer 
    {
        public PrestaSharpSerializer()
            : base()
        {
        }

        public PrestaSharpSerializer(string @namespace)
            : base(@namespace)
        {
        }

        /// <summary>
        /// Serialize the object as XML
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>XML as string</returns>
        public string PrestaSharpSerialize(object obj)
        {
            var doc = new XDocument();

            var t = obj.GetType();
            var name = t.Name;

            var options = t.GetAttribute<SerializeAsAttribute>();
            if (options != null)
            {
                name = options.TransformName(options.Name ?? name);
            }

            var root = new XElement(name.AsNamespaced(Namespace));

            if (obj is IList)
            {
                var itemTypeName = "";
                foreach (var item in (IList)obj)
                {
                    var type = item.GetType();
                    var opts = type.GetAttribute<SerializeAsAttribute>();
                    if (opts != null)
                    {
                        itemTypeName = opts.TransformName(opts.Name ?? name);
                    }
                    if (itemTypeName == "")
                    {
                        itemTypeName = type.Name;
                    }
                    var instance = new XElement(itemTypeName);
                    Map(instance, item);
                    root.Add(instance);
                }
            }
            else
                Map(root, obj);

            if (RootElement.HasValue())
            {
                var wrapper = new XElement(RootElement.AsNamespaced(Namespace), root);
                doc.Add(wrapper);
            }
            else
            {
                doc.Add(root);
            }

            return doc.ToString();
        }

        private void Map(XElement root, object obj)
        {
            var objType = obj.GetType();

            var props = from p in objType.GetProperties()
                        let indexAttribute = p.GetAttribute<SerializeAsAttribute>()
                        where p.CanRead && p.CanWrite
                        orderby indexAttribute == null ? int.MaxValue : indexAttribute.Index
                        select p;

            var globalOptions = objType.GetAttribute<SerializeAsAttribute>();

            foreach (var prop in props)
            {
                var name = prop.Name;
                var rawValue = prop.GetValue(obj, null);

                //Hack to serialize PrestaSharp.Entities.AuxEntities.language
                if (obj.GetType().FullName.Equals("PrestaSharp.Entities.AuxEntities.language") && root.Name.LocalName.Equals("language") && name.Equals("id"))
                {

                    root.Add(new XAttribute(XName.Get("id"), rawValue));
                    continue;
                }
                else if (obj.GetType().FullName.Equals("PrestaSharp.Entities.AuxEntities.language") && root.Name.LocalName.Equals("language") && name.Equals("Value"))
                {
                    XText xtext = new XText(rawValue.ToString());
                    root.Add(xtext);
                    continue;

                }

                if (rawValue == null)
                {
                    continue;
                }

                var value = GetSerializedValue(rawValue);
                var propType = prop.PropertyType;

                var useAttribute = false;
                var settings = prop.GetAttribute<SerializeAsAttribute>();
                if (settings != null)
                {
                    name = settings.Name.HasValue() ? settings.Name : name;
                    useAttribute = settings.Attribute;
                }

                var options = prop.GetAttribute<SerializeAsAttribute>();
                if (options != null)
                {
                    name = options.TransformName(name);
                }
                else if (globalOptions != null)
                {
                    name = globalOptions.TransformName(name);
                }

                var nsName = name.AsNamespaced(Namespace);
                var element = new XElement(nsName);

                if (propType.IsPrimitive || propType.IsValueType || propType == typeof(string))
                {
                    if (useAttribute)
                    {
                        root.Add(new XAttribute(name, value));
                        continue;
                    }

                    element.Value = value;
                }
                else if (rawValue is IList)
                {
                    var itemTypeName = "";
                    foreach (var item in (IList)rawValue)
                    {
                        if (itemTypeName == "")
                        {
                            var type = item.GetType();
                            var setting = type.GetAttribute<SerializeAsAttribute>();
                            itemTypeName = setting != null && setting.Name.HasValue()
                                    ? setting.Name
                                    : type.Name;
                        }
                        var instance = new XElement(itemTypeName);
                        Map(instance, item);
                        element.Add(instance);
                    }
                }
                else
                {
                    Map(element, rawValue);
                }

                root.Add(element);
            }
        }

        private string GetSerializedValue(object obj)
        {
            var output = obj;

            if (obj is DateTime && DateFormat.HasValue())
            {
                output = ((DateTime)obj).ToString(DateFormat);
            }
            if (obj is bool)
            {
                output = obj.ToString().ToLower();
            }

            return output.ToString();
        }
        
    }
}
