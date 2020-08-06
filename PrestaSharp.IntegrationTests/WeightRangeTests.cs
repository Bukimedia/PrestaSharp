using Bukimedia.PrestaSharp.Factories;
using NUnit.Framework;

namespace PrestaSharp.IntegrationTests
{
    public class WeightRangeTests : BaseTest
    {

        private WeightRangeFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new WeightRangeFactory(TestUrl, TestApiKey, null);
        }

        [Test]
        public void Listing()
        {
            var weightRanges = factory.GetAll();

            Assert.IsNotNull(weightRanges);
            Assert.AreEqual(1, weightRanges.Count);
        }
    }
}