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
    public class NhanhProduct : INhanhModel
    {


        public string? IdNhanh { get; set; }
        [JsonConverter(typeof(DoubleConverter))]
        public double? Price { get; set; }

        // Sku?
        public string? Code { get; set; }
        public string? Barcode { get; set; }
        public string? Name { get; set; }

        public string? ParentId { get; set; }
        public string? TypeId { get; set; }
        public string? TypeName { get; set; }

        // gia goc
        [JsonConverter(typeof(DoubleConverter))]
        public double? AvgCost { get; set; }
        public string? CategoryId { get; set; }

        [JsonConverter(typeof(DoubleConverter))]
        public double? ImportPrice { get; set; }
        [JsonConverter(typeof(DoubleConverter))]
        public double? WholesalePrice { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductStatuses Status { get; set; }

        [JsonConverter(typeof(DoubleConverter))]
        public double? Vat { get; set; }
        public string? CreatedDateTime { get; set; }

        [JsonPropertyName("inventory")]
        public NhanhProductInventory? Inventory { get; set; }
        public string? Unit { get; set; }
    }
}
