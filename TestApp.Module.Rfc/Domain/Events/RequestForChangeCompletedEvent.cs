using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Rfc.Domain.Events
{
    internal class RequestForChangeCompletedEvent : IDomainEvent
    {
        public string RfcKey { get; }

        public RequestForChangeCompletedEvent(string rfcKey)
        {
            RfcKey = rfcKey;
        }
    }
}
