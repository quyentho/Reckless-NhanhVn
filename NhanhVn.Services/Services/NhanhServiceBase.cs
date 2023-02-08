using Microsoft.Extensions.Configuration;
using NhanhVn.Services.Helpers;
using NhanhVn.Services.Models.Request;
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

        protected NhanhServiceBase()
        {

        }


        protected async Task<T> GetResponseAsync<T>(OrderRequestParams orderRequestParams)
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            string json = JsonSerializer.Serialize(orderRequestParams, options);

            var request = new Request(_version, _appId, _businessId, _accessToken, json);

            var response = await HttpRequestHelpers.GetResponseAsync(Url, request);

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonHelpers.DeserializeFromCamalCaseContent<T>(responseContent, "data.orders");
        }
    }
}
