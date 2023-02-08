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

        public Request(string version, string appId, string businessId, string accessToken, string data)
        {
            Version = version;
            AppId = appId;
            BusinessId = businessId;
            AccessToken = accessToken;
            Data = data;
        }
    }
}
