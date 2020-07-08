using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bukimedia.PrestaSharp.Deserializers.Tests
{

    class FakeObject
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public decimal DecimalProperty { get; set; }
    }

    [TestClass()]
    public class PrestaSharpDeserializerTests
    {
        [TestMethod()]
        public void MapTest()
        {
            PrestaSharpDeserializer instanceUnderTest = new PrestaSharpDeserializer();
            string fileContent = System.IO.File.ReadAllText("FakeObject.xml");
            System.Xml.Linq.XDocument xmlDocument = XDocument.Parse(fileContent);
            var rootElement = xmlDocument.Root.Descendants().FirstOrDefault();

            FakeObject objectToMap = Activator.CreateInstance<FakeObject>();

            instanceUnderTest.Map(objectToMap, rootElement);

            Assert.IsTrue(objectToMap.StringProperty == "This is my value");
            Assert.IsTrue(objectToMap.IntProperty == 42);
            Assert.IsTrue(objectToMap.DecimalProperty == 1.2m);
        }
    }
}