using Bukimedia.PrestaSharp.Factories;
using NUnit.Framework;

namespace PrestaSharp.IntegrationTests
{
    public class ManufacturerTests : BaseTest
    {

        private ManufacturerFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new ManufacturerFactory(TestUrl, TestApiKey, null);
        }

        [Test]
        public void Listing()
        {
            var manufacturers = factory.GetAll();

            Assert.AreEqual(2, manufacturers.Count);
            Assert.AreEqual("Studio Design", manufacturers[0].name);
            Assert.AreEqual("Graphic Corner", manufacturers[1].name);
        }
    }
}