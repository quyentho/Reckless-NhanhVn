using Microsoft.Extensions.Configuration;
using NhanhVn.Services.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NhanhVn.Services
{
    internal class HttpRequestHelper
    {
        public static async Task<HttpResponseMessage> GetResponseAsync(IConfiguration configuration,string url, IRequestParams orderRequest)
        {
            var request = new Request(configuration,orderRequest);
            using var client = new HttpClient();
            var content = GetFormDataContent(request);

            return await client.PostAsync(url, content);
        }

        private static MultipartFormDataContent GetFormDataContent(Request request)
        {
            var content = new MultipartFormDataContent();

            var properties = request.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(request);
                if(value != null)
                {
                    string propertyName = StringUtils.LowerFirstCharacter(property.Name);
                    content.Add(new StringContent(value.ToString()), propertyName.ToString());
                }
            }

            return content;
        }
    }
}
