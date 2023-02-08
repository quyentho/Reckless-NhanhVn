using EntityFrameworkWithPostgresPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWithPostgresPOC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }

}
