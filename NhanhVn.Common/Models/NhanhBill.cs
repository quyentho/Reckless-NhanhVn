using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NhanhVn.Common.CustomJsonConverter;
using NhanhVn.Common.Enums;

namespace NhanhVn.Common.Models
{
    public class NhanhBill : INhanhModel
    {
        public string Id { get; set; }
        public string? DepotId { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedDateTime { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerMobile { get; set; }

        [JsonConverter(typeof(EnumToStringConverter<SaleChannel>))]
        public SaleChannel SaleChannel { get; set; } = SaleChannel.Retail;

        // when discount = 0, it returns number instead of string :))
        [JsonConverter(typeof(DoubleConverter))]
        public double? Discount { get; set; }

        // tong hoa don
        public double? Money { get; set; }
        public Dictionary<string,NhanhBillProduct>? Products { get; set; }
    }
}
