using Azure_uppgift1_API.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Azure_uppgift1_API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }

       public DbSet<Product> Products { get; set; }
    }
}
