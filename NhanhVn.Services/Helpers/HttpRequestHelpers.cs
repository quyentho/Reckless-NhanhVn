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
        public static async Task<HttpResponseMessage> GetResponseAsync(HttpClient httpClient,string url, Request request)
        {
            var content = GetFormDataContent(request);

            return await httpClient.PostAsync(url, content);
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
