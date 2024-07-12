using RepoPatternAPI.Models;
using RepoPatternAPI.Services.Interface;

namespace RepoPatternAPI.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Company> Companies { get; }
        IRepository<Warehouse> Warehouses { get; }
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Order> Orders { get; }
        Task<int> CompleteAsync();
    }

}
