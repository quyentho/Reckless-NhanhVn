// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using NhanhVn.Services.Services;
using System.Text.Json;

var orderService = new OrderServices();
var orders = await orderService.GetOrdersByDateAsync(new DateTime(2022, 09, 25),new DateTime(2022, 09, 25));

Console.ReadKey();
