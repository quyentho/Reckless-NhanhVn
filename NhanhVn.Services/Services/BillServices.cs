using Microsoft.Extensions.Configuration;
using NhanhVn.Common.Enums;
using NhanhVn.Common.Models;
using NhanhVn.Services.DTOs.Request;
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
    public class BillServices : NhanhServiceBase, IBillServices
    {
        public BillServices(HttpClient httpClient) : base(httpClient) { }

        protected override string Url { get => Config.GetRequiredSection("billApiUrl").Value; }

        public async Task<Response<NhanhBill>> GetRetailBillsByDatesAsync(DateTime fromDate, DateTime toDate)
        {
            var billRequestParams = new BillRequestParams();
            billRequestParams.FromDate = DateOnly.FromDateTime(fromDate);
            billRequestParams.ToDate = DateOnly.FromDateTime(toDate);

            billRequestParams.Mode = (int)InventoryMode.Retail;
            billRequestParams.Type = (int)InventoryType.OUT;

            return await GetAllResponse(billRequestParams);
        }

        private async Task<Response<NhanhBill>> GetAllResponse(BillRequestParams billRequestParams)
        {
            var firstPageResponse = await base.GetResponseAsync<BillRequestParams, NhanhBill>(billRequestParams);

            if (firstPageResponse.TotalPages == 1)
            {
                return firstPageResponse;
            }

            // there is more than one page, keep request for more data
            List<Task<Response<NhanhBill>>> tasks = new List<Task<Response<NhanhBill>>>();
            for (int page = 2; page <= firstPageResponse.TotalPages; page++)
            {
                billRequestParams.Page = page;
                tasks.Add(base.GetResponseAsync<BillRequestParams, NhanhBill>(billRequestParams));
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