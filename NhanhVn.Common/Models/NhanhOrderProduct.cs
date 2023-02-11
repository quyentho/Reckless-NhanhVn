using System.Text.Json.Serialization;
using NhanhVn.Common.CustomJsonConverter;

namespace NhanhVn.Common.Models
{
    public class NhanhOrderProduct: INhanhModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductBarcode { get; set; }

        // some how the bill api returns string instead of number and cannot be deserialized.
        [JsonConverter(typeof(CustomDoubleConverter))]
        public double Price { get; set; }

        [JsonConverter(typeof(CustomIntConverter))]
        public int Quantity { get; set; }

        [JsonConverter(typeof(CustomDoubleConverter))]
        public double Discount { get; set; }
    }
}
