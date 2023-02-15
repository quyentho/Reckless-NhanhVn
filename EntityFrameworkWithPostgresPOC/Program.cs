// See https://aka.ms/new-console-template for more information
using AutoMapper;
using EFCore.BulkExtensions;
using EntityFrameworkWithPostgresPOC.AutoMapper;
using Microsoft.Extensions.Configuration;
using NhanhVn.Common.Models;
using NhanhVn.EntityFramework;
using NhanhVn.EntityFramework.Models;
using NhanhVn.Services;
using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Services;

HttpClient client = new HttpClient();

// allow timestamp without UTC
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

DbContextFactory dbContextFactory = new DbContextFactory();
ApplicationDbContext context = dbContextFactory.CreateDbContext(null);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
    .Build();

NhanhServiceParams nhanhServiceParams = new NhanhServiceParams(
    config.GetRequiredSection("Version").Value,
    config.GetRequiredSection("AppId").Value,
    config.GetRequiredSection("businessid").Value,
    config.GetRequiredSection("AccessToken").Value
);


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new NhanhProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

TimeZoneInfo vietnamZone;
try
{
    vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
}
catch (TimeZoneNotFoundException)
{
    vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
}
//GlobalConfiguration.Configuration.UsePostgreSqlStorage("");

//var now = TimeZoneInfo.ConvertTime(DateTime.Now, vietnamZone);
for (var date = new DateTime(2023, 2, 1); date <= new DateTime(2023, 2, 15); date = date.AddDays(1))
{
    await FetchNhanhDataAndSave(client, context, mapper, date,config, nhanhServiceParams);
}

Console.ReadKey();

static async Task FetchNhanhDataAndSave(HttpClient client, ApplicationDbContext context, IMapper mapper, DateTime date, IConfigurationRoot? config, NhanhServiceParams nhanhServiceParams)
{

    Console.WriteLine("fetching orders");
    ////Get orders
    var orderService = new OrderServices(client, config.GetRequiredSection("orderApiUrl").Value, nhanhServiceParams);
    Response<NhanhOrder> orderResponses = await orderService.GetOrdersByDatesAsync(date, date);
    var newOrders = mapper.Map<List<Order>>(orderResponses.Data.Select(d => d.Value));
    await context.BulkInsertAsync(newOrders);

    Console.WriteLine("fetching bills");
    // Get retail bill
    var billservices = new BillServices(client, config.GetRequiredSection("billApiUrl").Value, nhanhServiceParams);
    Response<NhanhBill> billResponse = await billservices.GetRetailBillsByDatesAsync(date, date);
    var newOrders2 = mapper.Map<List<Order>>(billResponse.Data.Select(d => d.Value));
    await context.BulkInsertAsync(newOrders2);


    Console.WriteLine("fetching products");
    // Get Products
    var productServices = new ProductServices(client, config.GetRequiredSection("productApiUrl").Value, nhanhServiceParams);
    Response<NhanhProduct> productResponse = await productServices.GetAllProducts();

    var products = mapper.Map<List<Product>>(productResponse.Data.Select(d => d.Value));

    var updateByProperties = new List<string> { nameof(Product.IdNhanh) };

    var bulkConfig = new BulkConfig { UpdateByProperties = updateByProperties };
    await context.BulkInsertOrUpdateAsync(products, bulkConfig);

    Console.WriteLine("fetching categories");
    var categoryServices = new CategoryServices(client, config.GetRequiredSection("categoryApiUrl").Value, nhanhServiceParams);
    Response<NhanhCategory> categoryResponse = await categoryServices.GetAllCategoryAsync();

    var categories = mapper.Map<List<Category>>(categoryResponse.Category);
    categories.AddRange(categories.SelectMany(c => c.Childs).ToList());


    await context.BulkInsertOrUpdateAsync(categories);
    await context.BulkSaveChangesAsync();
}