using System.ComponentModel.DataAnnotations.Schema;
using TestApp.BuildingBlocks.Domain;
using TestApp.Module.Prod.Domain.Events;
using TestApp.Module.Prod.Domain.Rules;

namespace TestApp.Module.Prod.Domain
{
    [Table("Product", Schema = "prd")]
    internal class Product : Entity, IAggregateRoot
    {
        private const string DRAFT = "DRAFT";
        private const string APPROVEDFORUSE = "APPROVEDFORUSE";
        private const string DEPRECATED = "DEPRECATED";

        public string Key { get; }
        public string Title { get; }
        public string Version { get; }
        public string Status { get; private set; }

        public Product(string key, string title, string version)
        {
            Key = key;
            Title = title;
            Version = version;
            Status = DRAFT;
        }

        public static Product Create(string key, string title, string version)
        {
            CheckRule(new ProductRequiresKeyRule(key));
            CheckRule(new ProductRequiresTitleRule(title));
            CheckRule(new ProductRequiresVersionRule(version));

            var product = new Product(key, title, version);
            return product;
        }

        public void ApproveForUse()
        {
            CheckRule(new ProductCanOnlyBeApprovedForUseWhenInDraftRule(Status));

            Status = APPROVEDFORUSE;

            AddDomainEvent(new ProductApprovedForUseEvent(Key));
        }
        
        public void Deprecate()
        {
            CheckRule(new ProductCanOnlyBeDeprecatedWhenInApprovedForUseRule(Status));

            Status = DEPRECATED;

            AddDomainEvent(new ProductDeprecatedEvent(Key));
        }
        
        public void Draft()
        {
            CheckRule(new ProductCanOnlyBeDraftedWhenInApprovedForUseRule(Status));

            Status = DRAFT;

            AddDomainEvent(new ProductDraftedEvent(Key));
        }

    }
}
