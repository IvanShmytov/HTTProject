using HTTProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace HTTProject.DAL.DB
{
    public class BlogContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}