using Microsoft.Extensions.Configuration;
using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Helpers;
using NhanhVn.Services.Models;
using NhanhVn.Services.Models.Request;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NhanhVn.Services.Services
{
    public class OrderServices : IOrderServices
    {
        private static readonly IConfiguration _config;
        private static readonly string _orderUrl;

        static OrderServices()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
                .Build();

            _config = config;
            _orderUrl = _config.GetRequiredSection("orderApiUrl").Value;
        }
        public OrderServices()
        {
        }

        public async Task<Response<Order>> GetOrdersByDateAsync(DateTime fromDate, DateTime toDate)
        {
            var orderRequestParams = new OrderRequestParams();
            orderRequestParams.FromDate = fromDate;
            orderRequestParams.ToDate = toDate;

            var response = await HttpRequestHelpers.GetResponseAsync(_config, _orderUrl, orderRequestParams);

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonHelpers.DeserializeFromCamalCaseContent<Response<Order>>(responseContent, "data.orders");
        }

    }
}