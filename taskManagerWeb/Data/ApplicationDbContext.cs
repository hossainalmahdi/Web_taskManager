using Microsoft.EntityFrameworkCore;
using taskManagerWeb.Models;

namespace taskManagerWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Catagories { get; set; }
    }
}
