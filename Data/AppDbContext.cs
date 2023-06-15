using Microsoft.EntityFrameworkCore;
using W4Assessment.Model;

namespace W4Assessment.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

        public DbSet<Products> Products { get; set; }

       // public DbSet<User>Users { get; set; }
    }
}
