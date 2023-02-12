using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NhanhVn.Common.Enums;
using NhanhVn.EntityFramework.Models;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Order>()
                .Property(d => d.StatusCode)
                .HasConversion(new EnumToStringConverter<OrderStatuses>());
            modelBuilder
                .Entity<Order>()
                .Property(d => d.SaleChannel)
                .HasConversion(new EnumToStringConverter<SaleChannel>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }

}
