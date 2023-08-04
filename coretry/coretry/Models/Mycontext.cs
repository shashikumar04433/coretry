using Microsoft.EntityFrameworkCore;

namespace coretry.Models
{
    public class Mycontext : DbContext
    {
        public Mycontext(DbContextOptions<Mycontext> options)
       : base(options)
        { }

        public DbSet<Book>Books { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}

