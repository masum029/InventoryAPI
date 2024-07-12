using RepoPatternAPI.Models;
using RepoPatternAPI.Services.Implement;
using RepoPatternAPI.Services.Interface;

namespace RepoPatternAPI.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryContext _context;

        public UnitOfWork(InventoryContext context)
        {
            _context = context;
            Companies = new Repository<Company>(_context);
            Warehouses = new Repository<Warehouse>(_context);
            Products = new Repository<Product>(_context);
            Categories = new Repository<Category>(_context);
            Orders = new Repository<Order>(_context);
        }

        public IRepository<Company> Companies { get; private set; }
        public IRepository<Warehouse> Warehouses { get; private set; }
        public IRepository<Product> Products { get; private set; }
        public IRepository<Category> Categories { get; private set; }
        public IRepository<Order> Orders { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
