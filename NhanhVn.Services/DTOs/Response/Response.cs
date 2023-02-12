using NhanhVn.Common.Models;
using NhanhVn.Services.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NhanhVn.Services.DTOs.Response
{
    public class Response<T> : IResponse where T : INhanhModel 
    {
        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        public int Page { get; set; }

        // this is for product api
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get => Page; set { Page = value; } }

        [JsonPropertyName("orders")]
        public Dictionary<string,T> Data { get; set; }

        //https://stackoverflow.com/a/43715009/11309214
        // the trick to allow multiple json property name
        [JsonPropertyName("bill")]
        public Dictionary<string, T>  Bill { get => Data;  set { Data = value; } }
    }
}