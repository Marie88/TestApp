using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Prod.Domain.Rules;

internal class ProductCanOnlyBeDeprecatedWhenInApprovedForUseRule : IBusinessRule
{
    private readonly string _currentStatus;

    public ProductCanOnlyBeDeprecatedWhenInApprovedForUseRule(string currentStatus)
    {
        _currentStatus = currentStatus;
    }

    public bool IsBroken()
    {
        return _currentStatus != "APPROVEDFORUSE";
    }

    public string Message => "Product can only be deprecated when it is in approved for use status";
}