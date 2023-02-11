using NhanhVn.Common.CustomJsonConverter;
using System;
using System.Text.Json.Serialization;

namespace NhanhVn.Services.Models.Request
{
    // reference https://apidocs.nhanh.vn/order/index
    public class OrderRequestParams : IRequestParams
    {
        [JsonConverter(typeof(CustomDateOnlyConverter))]
        public DateOnly? FromDate { get; set; }
        [JsonConverter(typeof(CustomDateOnlyConverter))]
        public DateOnly? ToDate { get; set; }
        public int? Statuses { get; set; }
        public int? Page { get; set; } = 1;
    }
}
