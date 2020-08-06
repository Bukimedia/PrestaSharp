using Bukimedia.PrestaSharp.Factories;
using NUnit.Framework;

namespace PrestaSharp.IntegrationTests
{
    public class PriceRangeTests : BaseTest
    {

        private PriceRangeFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new PriceRangeFactory(TestUrl, TestApiKey, null);
        }

        [Test]
        public void Listing()
        {
            var priceRanges = factory.GetAll();

            Assert.IsNotNull(priceRanges);
            Assert.AreEqual(1, priceRanges.Count);
        }
    }
}