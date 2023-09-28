using HTTProject.BLL.Abstract;
using HTTProject.DAL.DB;
using HTTProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTProject.BLL.Logic
{
    public class CategoryRepository : IRepository<Category>
    {
        protected BlogContext _db;
        public DbSet<Category> Set { get; private set; }

        public CategoryRepository(BlogContext db)
        {
            _db = db;
            var set = _db.Set<Category>();
            set.Load();
            Set = set;
        }
        public async Task<Category> Get(int id)
        {
            var category = await Set.FindAsync(id);
            category.Products = _db.Products.Where(x => x.CategoryId == id).ToList();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await Set.ToListAsync();
            foreach (var category in categories)
            {
                category.Products = _db.Products.Where(x => x.CategoryId == category.Id).ToList();
            }
            return categories;
        }

        public async Task<Category> GetByName(string Name)
        {
            var category = await Set.FirstOrDefaultAsync(c => c.Name == Name);
            category.Products = _db.Products.Where(x => x.CategoryId == category.Id).ToList();
            return category;
        }
    }
}
