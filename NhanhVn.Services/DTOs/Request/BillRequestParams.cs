﻿using NhanhVn.Common.CustomJsonConverter;
using NhanhVn.Services.Models.Request;
using System.Text.Json.Serialization;

namespace NhanhVn.Services.DTOs.Request
{
    public class BillRequestParams: IRequestParams
    { 
        [JsonConverter(typeof(CustomDateOnlyConverter))]
        public DateOnly? FromDate { get; set; }
        [JsonConverter(typeof(CustomDateOnlyConverter))]
        public DateOnly? ToDate { get; set; }
        public int? Type { get; set; }
        public int? Mode { get; set; }
        public int? Page { get; set; } = 1;
    }
}
