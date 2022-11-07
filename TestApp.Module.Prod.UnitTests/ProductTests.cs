using FluentAssertions;
using TestApp.BuildingBlocks.Domain;
using TestApp.Module.Prod.Domain;
using AutoFixture;


namespace TestApp.Module.Prod.UnitTests
{
    public class ProductTests
    {
        private readonly Fixture _fixture = new Fixture();
        private const string Draft = "DRAFT";
        private const string ApprovedForUse = "APPROVEDFORUSE";
        private const string Deprecated = "DEPRECATED";
        
        [Theory]
        [MemberData(nameof(ProductContructorTestData))]
        public void Create_ShouldRequireKey_Title_Version(string key, string title, string version)
        {
            // Arrange & Act
            Action createProduct = () => Product.Create(key, title, version);
            
            // Assert
            createProduct.Should().Throw<BusinessRuleValidationException>();
        }
        
        public static IEnumerable<object[]> ProductContructorTestData()
        {
            yield return new object[] { "", "", "" };
            yield return new object[] { " ", " ", " " };
            yield return new object[] { null, null, null };
            yield return new object[] { "", "title", " " };
            yield return new object[] { " ", "title", "2.0" };
            yield return new object[] { "P-1", " ", "" };
            yield return new object[] { "key", "", "3.0" };
            yield return new object[] { "key", " ", null };
        }

        [Fact]
        public void Create_ShouldSuccessfullyGenerateProduct_WhenRequiredParametersAreNotNullOrWhitespace()
        {
            // Arrange
            var key = _fixture.Create<string>();
            var title = _fixture.Create<string>();
            var version = _fixture.Create<string>();
            
            // Act
            var product = Product.Create(key, title, version);
            
            // Assert
            product.Key.Should().Be(key);
            product.Title.Should().Be(title);
            product.Version.Should().Be(version);
            product.Status.Should().Be(Draft);
        }
        
        [Fact]
        public void ApproveForUse_ShouldAssignNewlyCreatedProductApprovedForUseState()
        {
            // Arrange
            var key = _fixture.Create<string>();
            var title = _fixture.Create<string>();
            var version = _fixture.Create<string>();
            var product = Product.Create(key, title, version);
            
            // Act
            product.ApproveForUse();

            // Assert
            product.Status.Should().Be(ApprovedForUse);
        }
        
        [Fact]
        public void ApproveForUse_ShouldFail_WhenProductIsInADifferentStateThanDraft()
        {
            // Arrange
            var key = _fixture.Create<string>();
            var title = _fixture.Create<string>();
            var version = _fixture.Create<string>();
            var product = Product.Create(key, title, version);
            
            // Act
            product.ApproveForUse();
            product.Deprecate();
            Action approveForUse = () => product.ApproveForUse();

            // Assert
            approveForUse.Should().Throw<BusinessRuleValidationException>();
        }
        
        [Fact]
        public void Deprecate_ShouldAssignProductDeprecatedState()
        {
            // Arrange
            var key = _fixture.Create<string>();
            var title = _fixture.Create<string>();
            var version = _fixture.Create<string>();
            var product = Product.Create(key, title, version);
            
            // Act
            product.ApproveForUse();
            product.Deprecate();

            // Assert
            product.Status.Should().Be(Deprecated);
        }
        
        [Fact]
        public void Deprecate_ShouldFail_WhenProductIsInADifferentStateThanApprovedForUse()
        {
            // Arrange
            var key = _fixture.Create<string>();
            var title = _fixture.Create<string>();
            var version = _fixture.Create<string>();
            var product = Product.Create(key, title, version);
            
            // Act
            Action deprecate = () => product.Deprecate();

            // Assert
            deprecate.Should().Throw<BusinessRuleValidationException>();
        }
        
        [Fact]
        public void Draft_ShouldAssignProductDraftState()
        {
            // Arrange
            var key = _fixture.Create<string>();
            var title = _fixture.Create<string>();
            var version = _fixture.Create<string>();
            var product = Product.Create(key, title, version);
            
            // Act
            product.ApproveForUse();
            product.Draft();

            // Assert
            product.Status.Should().Be(Draft);
        }
        
        [Fact]
        public void Draft_ShouldFail_WhenProductIsInADifferentStateThanApprovedForUse()
        {
            // Arrange
            var key = _fixture.Create<string>();
            var title = _fixture.Create<string>();
            var version = _fixture.Create<string>();
            var product = Product.Create(key, title, version);
            
            // Act
            product.ApproveForUse();
            product.Deprecate();
            Action deprecate = () => product.Draft();

            // Assert
            deprecate.Should().Throw<BusinessRuleValidationException>();
        }
    }
}