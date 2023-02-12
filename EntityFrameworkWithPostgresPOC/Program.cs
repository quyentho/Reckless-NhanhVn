// See https://aka.ms/new-console-template for more information
using AutoMapper;
using EFCore.BulkExtensions;
using EntityFrameworkWithPostgresPOC.AutoMapper;
using NhanhVn.Common.Models;
using NhanhVn.EntityFramework;
using NhanhVn.EntityFramework.Models;
using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Services;

HttpClient client = new HttpClient();

// allow timestamp without UTC
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

DbContextFactory dbContextFactory = new DbContextFactory();
ApplicationDbContext context = dbContextFactory.CreateDbContext(null);


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new NhanhProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

//Get orders
var orderService = new OrderServices(client);
Response<NhanhOrder> orderResponses = await orderService.GetOrdersByDatesAsync(new DateTime(2023, 02, 09), new DateTime(2023, 02, 09));
var newOrders = mapper.Map<List<Order>>(orderResponses.Data.Select(d => d.Value));
await context.Orders.AddRangeAsync(newOrders);

// Get retail bill
var billservices = new BillServices(client);
Response<NhanhBill> billResponse = await billservices.GetRetailBillsByDatesAsync(new DateTime(2023, 02, 09), new DateTime(2023, 02, 09));
var newOrders2 = mapper.Map<List<Order>>(billResponse.Data.Select(d => d.Value));
await context.Orders.AddRangeAsync(newOrders2);

context.SaveChangesAsync();

// Get Products
var productServices = new ProductServices(client);
Response<NhanhProduct> productResponse = await productServices.GetAllProducts();

var products = mapper.Map<List<Product>>(productResponse.Data.Select(d => d.Value));

var updateByProperties = new List<string> { nameof(Product.IdNhanh) };

var bulkConfig = new BulkConfig { UpdateByProperties = updateByProperties };
await context.BulkInsertOrUpdateAsync(products, bulkConfig);
await context.BulkSaveChangesAsync();

Console.ReadKey();
