using Bukimedia.PrestaSharp.Factories;
using NUnit.Framework;

namespace PrestaSharp.IntegrationTests
{
    public class DeliveryTests : BaseTest
    {

        private DeliveryFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new DeliveryFactory(TestUrl, TestApiKey, null);
        }

        [Test]
        public void Listing()
        {
            var delvieries = factory.GetAll();

            Assert.IsNotNull(delvieries);
            Assert.AreEqual(4, delvieries.Count);
        }
    }
}