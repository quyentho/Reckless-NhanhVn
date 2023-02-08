using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NhanhVn.Services.Models.Request
{
    public class Request
    {
        public string Version { get; set; }
        public string AppId { get; set; }
        public string BusinessId { get; set; }
        public string AccessToken { get; set; }
        public string Data { get; set; }

        public Request(IConfiguration configuration,IRequestParams requestParams)
        {
            Version = configuration.GetRequiredSection("Version").Value;
            AppId = configuration.GetRequiredSection("AppId").Value;
            BusinessId = configuration.GetRequiredSection("BusinessId").Value;
            AccessToken = configuration.GetRequiredSection("AccessToken").Value;

            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            string json = JsonSerializer.Serialize(requestParams, options);

            Data = json;
        }
    }
}
