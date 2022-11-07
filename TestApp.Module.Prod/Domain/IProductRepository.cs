using System.Threading.Tasks;
using TestApp.BuildingBlocks.Domain;

namespace TestApp.Module.Prod.Domain
{
    internal interface IProductRepository : IRepository<Product>
    {
        Task CommitAsync();
    }
}
