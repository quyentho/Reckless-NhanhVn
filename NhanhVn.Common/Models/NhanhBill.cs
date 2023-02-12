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

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? CreatedDateTime { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerMobile { get; set; }

        [JsonConverter(typeof(CustomEnumToStringConverter<SaleChannel>))]
        public SaleChannel SaleChannel { get; set; } = SaleChannel.Retail;

        // when discount = 0, it returns number instead of string :))
        [JsonConverter(typeof(CustomDoubleConverter))]
        public double? Discount { get; set; }
        public double? PreDiscount
        {
            get => Products.Values.Sum(p => p.Price * p.Quantity);
        }

        // tong hoa don
        public double? Money { get; set; }
        public Dictionary<string,NhanhBillProduct>? Products { get; set; }
    }
}
