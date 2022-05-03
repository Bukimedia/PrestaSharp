using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using NUnit.Framework;

namespace PrestaSharp.IntegrationTests
{
    public class MessageTests : BaseTest
    {
        private MessageFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new MessageFactory(TestUrl, TestApiKey, null);

        }
        [Test]
        public void AddMessageTest()
        {
            message psMessage = new message();
            psMessage.id_order = 5;
            psMessage.id_cart = 5;
            psMessage.id_customer = 2;
            psMessage.Message = "TEST";
            psMessage.Private = 0;

            var effectiveResult = factory.Add(psMessage);

            Assert.IsNotNull(effectiveResult);
        }
    }
}
