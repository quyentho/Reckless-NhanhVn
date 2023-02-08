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
    public class OrderServices :NhanhServiceBase, IOrderServices
    {
        public OrderServices()
        {
        }

        protected override string Url { get => Config.GetRequiredSection("orderApiUrl").Value; }

        public async Task<Response<NhanhOrder>> GetOrdersByDateAsync(DateTime fromDate, DateTime toDate)
        {
            var orderRequestParams = new OrderRequestParams();
            orderRequestParams.FromDate = fromDate;
            orderRequestParams.ToDate = toDate;

            return await base.GetResponseAsync<Response<NhanhOrder>>(orderRequestParams);
        }

    }
}