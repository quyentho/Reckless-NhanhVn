// See https://aka.ms/new-console-template for more information
using EntityFrameworkWithPostgresPOC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NhanhVn.EntityFramework;
using NhanhVn.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.Console;

internal class Program
{
    private const string CronExpression = "30 23 * * *";

    private static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();

        // allow timestamp without UTC
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = config.GetConnectionString("Default");

        NhanhServiceParams nhanhServiceParams = new NhanhServiceParams(
            config.GetRequiredSection("Version").Value,
            config.GetRequiredSection("AppId").Value,
            config.GetRequiredSection("businessid").Value,
            config.GetRequiredSection("AccessToken").Value
        );


        var builder = Host.CreateDefaultBuilder()
                .ConfigureServices((cxt, services) =>
                {
                    services.AddHttpClient();
                    services.AddAutoMapper(typeof(Program));
                    services.AddSingleton<IConfiguration>(config);
                    services.AddSingleton(nhanhServiceParams);
                    services.AddDbContextFactory<ApplicationDbContext>(builder =>
                        builder.UseNpgsql(connectionString)
                        .UseSnakeCaseNamingConvention()
                    );
                    services.AddHangfire(config =>
                        config.UsePostgreSqlStorage(connectionString).UseColouredConsoleLogProvider(Hangfire.Logging.LogLevel.Info)
                    );
                    services.AddTransient<NhanhJob>(); // Register your job type
                }).Build();

        GlobalConfiguration.Configuration
            .UseActivator(new HangfireActivator(builder.Services));

        var job = builder.Services.GetRequiredService<NhanhJob>();

        var jobManager = builder.Services.GetRequiredService<IRecurringJobManager>();

        using (var server = new BackgroundJobServer())
        {
            Console.WriteLine("Hangfire Server started. Press any key to exit...");
            jobManager.AddOrUpdate("nhanh-job", () => job.Execute(), CronExpression, TimeZoneHelpers.GetVietnamTimeZone());
            Console.ReadKey();
        }
    }
}
