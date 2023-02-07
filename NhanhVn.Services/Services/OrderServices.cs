using Microsoft.Extensions.Configuration;
using NhanhVn.Services.Models.Request;
using System.Text;
using System.Text.Json.Serialization;

namespace NhanhVn.Services.Services
{
    public class OrderServices
    {
        private readonly IConfiguration _config;
        private readonly string _orderUrl;

        public OrderServices()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.development.json", optional: false, reloadOnChange: true)
                .Build();

            _config = config;
            _orderUrl = _config.GetRequiredSection("orderApiUrl").Value;
        }
        public async Task GetOrdersByDateAsync(DateTime fromDate, DateTime toDate)
        {
            var orderRequest = new OrderRequestParams();
            orderRequest.FromDate = fromDate;
            orderRequest.ToDate = toDate;

            var response = await HttpRequestHelper.GetResponseAsync(_config, _orderUrl, orderRequest);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }

    }
}