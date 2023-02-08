using Microsoft.Extensions.Configuration;
using NhanhVn.Services.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NhanhVn.Services.Helpers
{
    internal class HttpRequestHelpers
    {
        private static readonly HttpClient _client;

        static HttpRequestHelpers()
        {
            // https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            // use Singleton HttpClient for now, may try to implement IHttpFactory instead.
            _client = new HttpClient();
        }
        public static async Task<HttpResponseMessage> GetResponseAsync(IConfiguration configuration, string url, IRequestParams orderRequest)
        {
            var request = new Request(configuration, orderRequest);
            var content = GetFormDataContent(request);

            return await _client.PostAsync(url, content);
        }

        private static MultipartFormDataContent GetFormDataContent(Request request)
        {
            var content = new MultipartFormDataContent();

            var properties = request.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(request);
                if (value != null)
                {
                    string propertyName = StringHelpers.LowerFirstCharacter(property.Name);
                    content.Add(new StringContent(value.ToString()), propertyName.ToString());
                }
            }

            return content;
        }
    }
}
