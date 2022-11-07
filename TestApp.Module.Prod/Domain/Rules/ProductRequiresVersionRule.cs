using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Prod.Domain.Rules
{
    internal class ProductRequiresVersionRule : IBusinessRule
    {
        private readonly string _version;

        public ProductRequiresVersionRule(string version)
        {
            _version = version;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(_version);
        }

        public string Message => "A product must have a version";
    }
}
