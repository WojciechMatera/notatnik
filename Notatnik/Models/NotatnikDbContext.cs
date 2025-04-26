using Microsoft.EntityFrameworkCore;

namespace Notatnik.Models
{
    public class NotatnikDbContext : DbContext
    {
        public NotatnikDbContext(DbContextOptions<NotatnikDbContext>options): base(options) {}

        public DbSet<Product> Products { get; set;}
    }
}