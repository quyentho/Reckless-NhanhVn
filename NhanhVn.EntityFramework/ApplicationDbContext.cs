using EntityFrameworkWithPostgresPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace NhanhVn.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }

}
