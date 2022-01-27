using Bukimedia.PrestaSharp.Entities;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductStepFactory : GenericFactory<ProductStep>
    {
        protected override string singularEntityName { get { return "ProductStep"; } }
        protected override string pluralEntityName { get { return "ProductSteps"; } }

        public ProductStepFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }
    }
}
