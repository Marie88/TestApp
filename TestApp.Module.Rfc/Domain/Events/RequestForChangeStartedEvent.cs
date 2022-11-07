using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Rfc.Domain.Events
{
    internal class RequestForChangeStartedEvent : IDomainEvent
    {
        public string RfcKey { get; }

        public RequestForChangeStartedEvent(string rfcKey)
        {
            RfcKey = rfcKey;
        }
    }
}