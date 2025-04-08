
using Entity_Framework_LINQ.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_LINQ
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testBd;Username=postgres;Password=root");
        }
    }
}