using HTTProject.BLL.Abstract;
using HTTProject.BLL.Abstract.ViewModels;
using HTTProject.DAL.DB;
using HTTProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTProject.BLL.Logic
{
    public class ProductRepository : IRepository<ProductVM>
    {
        protected BlogContext _db;
        public DbSet<Product> Set { get; private set; }

        public ProductRepository(BlogContext db)
        {
            _db = db;
            var set = _db.Set<Product>();
            set.Load();
            Set = set;
        }
        public async Task<ProductVM> Get(int id)
        {
            var product = await Set.Join(_db.Categories, p => p.CategoryId, c => c.Id, (p, c) => new ProductVM()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                InStock = p.InStock,
                Category = c.Name
            }).FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<ProductVM>> GetAll()
        {
            return await Set.OrderBy(p => p.Price).
                Join(_db.Categories, p => p.CategoryId, c => c.Id, (p,c) => new ProductVM() {Id = p.Id, Name = p.Name, Price = p.Price, 
                    InStock = p.InStock, Category = c.Name })
                .ToListAsync();
        }

        public async Task<ProductVM> GetByName(string Name)
        {
            var product = await Set.Join(_db.Categories, p => p.CategoryId, c => c.Id, (p, c) => new ProductVM()
            { 
                Id = p.Id, 
                Name = p.Name, 
                Price = p.Price, 
                InStock = p.InStock, 
                Category = c.Name
            }).FirstOrDefaultAsync(p => p.Name == Name);
            return product;
        }
    }
}