using System.Text.Json.Serialization;

namespace NhanhVn.Services.Models.Request
{
    // reference https://apidocs.nhanh.vn/order/index
    public class OrderRequestParams : IRequestParams
    {
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? FromDate { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? ToDate { get; set; }
        public int? Statuses { get; set; }
    }
}
