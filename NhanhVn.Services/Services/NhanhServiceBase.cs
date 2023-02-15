using Microsoft.Extensions.Configuration;
using NhanhVn.Common.CustomJsonConverter;
using NhanhVn.Common.Models;
using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Helpers;
using NhanhVn.Services.Models.Request;
using System.Security.AccessControl;
using System.Text.Json;

namespace NhanhVn.Services.Services
{
    public abstract class NhanhServiceBase
    {
        private readonly string _version;
        private readonly string _appId;
        private readonly string _businessId;
        private readonly string _accessToken;
        private readonly HttpClient _httpClient;

        protected abstract string Url { get; }


        protected NhanhServiceBase(HttpClient httpClient,NhanhServiceParams nhanhServiceParams)
        {
            this._httpClient = httpClient;
            _version = nhanhServiceParams.Version;
            _appId = nhanhServiceParams.AppId;
            _businessId = nhanhServiceParams.BusinessId;
            _accessToken = nhanhServiceParams.AccessToken;
        }

        protected async Task<Response<ResponseType>> GetAllResponseAsync<RequestParamsType, ResponseType>(IRequestParams orderRequestParams)
            where ResponseType : INhanhModel
            where RequestParamsType : IRequestParams
        {
            var firstPageResponse = await GetResponseAsync<RequestParamsType, ResponseType>(orderRequestParams);

            if (firstPageResponse.TotalPages == 1)
            {
                return firstPageResponse;
            }

            // there is more than one page, keep request for more data
            List<Task<Response<ResponseType>>> tasks = new List<Task<Response<ResponseType>>>();
            for (int page = 2; page <= firstPageResponse.TotalPages; page++)
            {
                orderRequestParams.Page = page;
                tasks.Add(GetResponseAsync<RequestParamsType, ResponseType>(orderRequestParams));
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

        public async Task<Response<ResponseType>> GetResponseAsync<RequestParamsType, ResponseType>(IRequestParams orderRequestParams, string? dataKeyPath = "data")
            where ResponseType : INhanhModel
            where RequestParamsType : IRequestParams

        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                   new TypeMappingConverter<IRequestParams, RequestParamsType>(),
                }
            };

            string json = JsonSerializer.Serialize(orderRequestParams, options);

            var request = new Request(_version, _appId, _businessId, _accessToken, json);

            var response = await HttpRequestHelpers.GetResponseAsync(_httpClient, Url, request);

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonHelpers.DeserializeByPath<Response<ResponseType>>(responseContent, dataKeyPath, options);
        }
    }
}
