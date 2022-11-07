using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Prod.Domain.Rules
{
    internal class ProductCanOnlyBeApprovedForUseWhenInDraftRule : IBusinessRule
    {
        private readonly string _currentStatus;

        public ProductCanOnlyBeApprovedForUseWhenInDraftRule(string currentStatus)
        {
            _currentStatus = currentStatus;
        }

        public bool IsBroken()
        {
            return _currentStatus != "DRAFT";
        }

        public string Message => "Product can only be approved for use from draft";
    }
}
