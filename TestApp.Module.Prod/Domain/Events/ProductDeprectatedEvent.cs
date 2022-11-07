using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Prod.Domain.Events;

internal class ProductDeprecatedEvent :IDomainEvent
{
    public string ProductKey { get; }

    public ProductDeprecatedEvent(string productKey)
    {
        ProductKey = productKey;
    }

}