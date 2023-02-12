using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NhanhVn.EntityFramework
{
    public class DbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var context = new ApplicationDbContext(
                builder
                .UseNpgsql("Host=localhost;Database=nhanhDb;Username=postgres;Password=password")
                .UseLowerCaseNamingConvention()
                .Options);

            return context;
        }

    }
}
