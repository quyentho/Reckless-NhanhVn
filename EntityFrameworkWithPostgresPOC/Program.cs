// See https://aka.ms/new-console-template for more information
using AutoMapper;
using EFCore.BulkExtensions;
using EntityFrameworkWithPostgresPOC;
using EntityFrameworkWithPostgresPOC.AutoMapper;
using EntityFrameworkWithPostgresPOC.Models;
using NhanhVn.Common.Models;
using NhanhVn.EntityFramework;
using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Services;
using System.Text.Json;

HttpClient client = new HttpClient();
var orderService = new OrderServices(client);
Response<NhanhOrder> orderResponses = await orderService.GetOrdersByDatesAsync(new DateTime(2023, 02, 09), new DateTime(2023, 02, 09));

// allow
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

DbContextFactory dbContextFactory = new DbContextFactory();
ApplicationDbContext context = dbContextFactory.CreateDbContext(null) ;
context.ChangeTracker.AutoDetectChangesEnabled = false;


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new NhanhProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

var newOrder = mapper.Map<List<Order>>(orderResponses.Data.Select(d=>d.Value));
await context.BulkInsertAsync(newOrder);
context.SaveChangesAsync();
Console.ReadKey();
