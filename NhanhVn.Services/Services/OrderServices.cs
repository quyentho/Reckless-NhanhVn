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
        public OrderServices(HttpClient httpClient, string url, NhanhServiceParams nhanhServiceParams) : base(httpClient,nhanhServiceParams)
        {
            Url = url;
        }
        protected override string Url { get; }

        public async Task<Response<NhanhOrder>> GetOrdersByDatesAsync(DateTime fromDate, DateTime toDate)
        {
            var orderRequestParams = new OrderRequestParams();
            orderRequestParams.FromDate = DateOnly.FromDateTime(fromDate);
            orderRequestParams.ToDate = DateOnly.FromDateTime(toDate);

            return await base.GetAllResponseAsync<OrderRequestParams, NhanhOrder>(orderRequestParams);
        }
    }
}