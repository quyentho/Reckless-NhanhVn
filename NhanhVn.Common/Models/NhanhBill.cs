using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NhanhVn.Common.Models
{
    public class NhanhBill : INhanhModel
    {
        public string Id { get; set; }
        public string DepotId { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CreatedDateTime { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string Discount { get; set; }

        // tong hoa don
        public int Money { get; set; }
        public Dictionary<string,NhanhProduct> Products { get; set; }
    }
}
