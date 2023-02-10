using Microsoft.Extensions.Configuration;
using NhanhVn.Common.Models;
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
    public class OrderServices : NhanhServiceBase, IOrderServices
    {
        public OrderServices(HttpClient httpClient) : base(httpClient) { }

        protected override string Url { get => Config.GetRequiredSection("orderApiUrl").Value; }

        public async Task<Response<NhanhOrder>> GetOrdersByDatesAsync(DateTime fromDate, DateTime toDate)
        {
            var orderRequestParams = new OrderRequestParams();
            orderRequestParams.FromDate = DateOnly.FromDateTime(fromDate);
            orderRequestParams.ToDate = DateOnly.FromDateTime(toDate);

            var firstPageResponse = await base.GetResponseAsync<OrderRequestParams, NhanhOrder>(orderRequestParams);

            if (firstPageResponse.TotalPages == 1)
            {
                return firstPageResponse;
            }

            // there is more than one page, keep request for more data
            List<Task<Response<NhanhOrder>>> tasks = new List<Task<Response<NhanhOrder>>>();
            for (int page = 2; page <= firstPageResponse.TotalPages; page++)
            {
                orderRequestParams.Page = page;
                tasks.Add(base.GetResponseAsync<OrderRequestParams, NhanhOrder>(orderRequestParams));
            }

            await Task.WhenAll(tasks);


            foreach (var task in tasks)
            {
                var nextPageResponse = await task;
                firstPageResponse.Data = firstPageResponse.Data.Concat(nextPageResponse.Data)
                                           .ToDictionary(x => x.Key, x => x.Value);
            }

            return firstPageResponse; 
        }

    }
}