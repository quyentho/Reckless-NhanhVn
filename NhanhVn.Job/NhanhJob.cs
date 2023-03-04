using AutoMapper;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NhanhVn.Common.Models;
using NhanhVn.EntityFramework;
using NhanhVn.EntityFramework.Models;
using NhanhVn.Services;
using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Services;

namespace EntityFrameworkWithPostgresPOC
{

    public class NhanhJob
    {
        private readonly HttpClient client;
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly NhanhServiceParams nhanhServiceParams;

        public NhanhJob(HttpClient client, IDbContextFactory<ApplicationDbContext> context, IMapper mapper, IConfiguration config, NhanhServiceParams nhanhServiceParams)
        {
            this.client = client;
            this.dbContext = context.CreateDbContext();
            this.mapper = mapper;
            this.config = config;
            this.nhanhServiceParams = nhanhServiceParams;
        }
        public async Task ExecuteFromDate(DateTime? dateTime)
        {
            if (dateTime is not null)
            {
                for (DateTime date = dateTime.Value; date < DateTime.Now; date = date.AddDays(1))
                {
                    await Execute(date);
                }
            }
        }
        public async Task Execute(DateTime? dateTime = null)
        {
            var now = dateTime ?? DateTime.UtcNow;
            Console.WriteLine("Running MyJob at " + now + " utc time");
            now = TimeZoneInfo.ConvertTime(now, TimeZoneHelpers.GetVietnamTimeZone());
            Console.WriteLine("Running MyJob at " + now + " Vietnam time");

            now = now.AddDays(config.GetValue<int>("DaysToAdd"));
            Console.WriteLine("Getting data for " + now.Date);

            Console.WriteLine("fetching orders");
            ////Get orders
            var orderService = new OrderServices(client, config.GetRequiredSection("orderApiUrl").Value, nhanhServiceParams);
            Response<NhanhOrder> orderResponses = await orderService.GetOrdersByDatesAsync(now, now);
            var newOrders = mapper.Map<List<Order>>(orderResponses.Data.Select(d => d.Value));
            await dbContext.BulkInsertAsync(newOrders);

            Console.WriteLine("fetching bills");
            // Get retail bill
            var billservices = new BillServices(client, config.GetRequiredSection("billApiUrl").Value, nhanhServiceParams);
            Response<NhanhBill> billResponse = await billservices.GetRetailBillsByDatesAsync(now, now);
            var newOrders2 = mapper.Map<List<Order>>(billResponse.Data.Select(d => d.Value));
            await dbContext.BulkInsertAsync(newOrders2);


            Console.WriteLine("fetching products");
            // Get Products
            var productServices = new ProductServices(client, config.GetRequiredSection("productApiUrl").Value, nhanhServiceParams);
            Response<NhanhProduct> productResponse = await productServices.GetAllProducts();

            var products = mapper.Map<List<Product>>(productResponse.Data.Select(d => d.Value));

            var updateByProperties = new List<string> { nameof(Product.IdNhanh) };

            var bulkConfig = new BulkConfig { UpdateByProperties = updateByProperties };
            await dbContext.BulkInsertOrUpdateAsync(products, bulkConfig);

            Console.WriteLine("fetching categories");
            var categoryServices = new CategoryServices(client, config.GetRequiredSection("categoryApiUrl").Value, nhanhServiceParams);
            Response<NhanhCategory> categoryResponse = await categoryServices.GetAllCategoryAsync();

            var categories = mapper.Map<List<Category>>(categoryResponse.Category);
            categories.AddRange(categories.SelectMany(c => c.Childs).ToList());


            await dbContext.BulkInsertOrUpdateAsync(categories);
            await dbContext.BulkSaveChangesAsync();
        }
    }
}
