using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NhanhVn.Common.CustomJsonConverter;

namespace NhanhVn.Common.Models
{
    public class NhanhBill : INhanhModel
    {
        public string Id { get; set; }
        public string? DepotId { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? CreatedDateTime { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerMobile { get; set; }

        // when discount = 0, it returns number instead of string :))
        [JsonConverter(typeof(CustomDoubleConverter))]
        public double? Discount { get; set; }

        // tong hoa don
        public double? Money { get; set; }
        public Dictionary<string,NhanhBillProduct>? Products { get; set; }
    }
}
