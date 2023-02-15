using NhanhVn.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NhanhVn.Services.DTOs.Response
{
    public class CategoryResponse<T> : IResponse where T : INhanhModel 
    {
        [JsonPropertyName("data")]
        public List<NhanhCategory> Data { get; set; }
    }
}
