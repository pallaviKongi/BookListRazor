using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Model
{
    public class ApplicationDbContext : DbContext
    {
        // Pass the options to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Book { get; set; }
    }
}