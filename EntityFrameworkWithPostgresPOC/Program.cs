// See https://aka.ms/new-console-template for more information
using EntityFrameworkWithPostgresPOC;
using EntityFrameworkWithPostgresPOC.Models;
using NhanhVn.EntityFramework;
using NhanhVn.Services.Services;
using System.Text.Json;

var orderService = new OrderServices();
var orders = await orderService.GetOrdersByDateAsync(new DateTime(2023, 02, 09), new DateTime(2023, 02, 09));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

DbContextFactory dbContextFactory = new DbContextFactory();
ApplicationDbContext context = dbContextFactory.CreateDbContext(null) ;
foreach (var order in orders)
{
    var newOrder = new Order();
    newOrder.Date = order.Value.CreatedDateTime;
    newOrder.Data = order.Value;
    context.Orders.Add(newOrder);
}
context.SaveChanges();
Console.ReadKey();
