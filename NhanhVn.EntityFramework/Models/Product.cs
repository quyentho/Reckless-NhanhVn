using NhanhVn.Common.CustomJsonConverter;
using System.Text.Json.Serialization;

namespace EntityFrameworkWithPostgresPOC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int NhanhProductId { get; set; }

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