using Bukimedia.PrestaSharp.Factories;
using NUnit.Framework;

namespace Tests
{
    public class ManufacturerTests
    {

        private ManufacturerFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new ManufacturerFactory("", "", "");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}