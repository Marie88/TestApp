using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Prod.Domain.Rules;

internal class ProductCanOnlyBeDraftedWhenInApprovedForUseRule: IBusinessRule
{
    private readonly string _currentStatus;

    public ProductCanOnlyBeDraftedWhenInApprovedForUseRule(string currentStatus)
    {
        _currentStatus = currentStatus;
    }

    public bool IsBroken()
    {
        return _currentStatus != "APPROVEDFORUSE";
    }

    public string Message => "Product can only be drafted when it is in approved for use status";
}