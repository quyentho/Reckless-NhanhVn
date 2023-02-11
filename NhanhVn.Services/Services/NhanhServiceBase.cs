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
        public static IConfiguration Config { get; set; }
        private static readonly string _version;
        private static readonly string _appId;
        private static readonly string _businessId;
        private static readonly string _accessToken;
        private readonly HttpClient _httpClient;

        protected abstract string Url { get; }

        static NhanhServiceBase()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
                .Build();

            Config = config;
            _version = config.GetRequiredSection("Version").Value;
            _appId = config.GetRequiredSection("AppId").Value;
            _businessId = config.GetRequiredSection("businessid").Value;
            _accessToken = config.GetRequiredSection("AccessToken").Value;
        }

        protected NhanhServiceBase(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        protected async Task<Response<ResponseType>> GetResponseAsync<RequestParamsType, ResponseType>(IRequestParams orderRequestParams)
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

            return JsonHelpers.DeserializeByPath<Response<ResponseType>>(responseContent, "data", options);
        }
    }
}
