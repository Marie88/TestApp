using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Prod.Domain.Events
{
    internal class ProductApprovedForUseEvent :IDomainEvent
    {
        public string ProductKey { get; }

        public ProductApprovedForUseEvent(string productKey)
        {
            ProductKey = productKey;
        }

    }
}
