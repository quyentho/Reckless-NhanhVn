using System.Text.Json.Serialization;
using NhanhVn.Common.CustomJsonConverter;
using NhanhVn.Common.Enums;

namespace NhanhVn.Common.Models
{

    public class NhanhOrder : INhanhModel
    {
        public int? Id { get; set; }

        // kenh? ban Shopee, Lazada,...

        [JsonConverter(typeof(CustomEnumToStringConverter<SaleChannel>))]
        public SaleChannel? SaleChannel { get; set; }
        public string? MerchantTrackingNumber { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CreatedDateTime { get; set; }
        // id? kho hang
        public int? DepotId { get; set; }
        public string? DepotName { get; set; }
        public string? Type { get; set; }
        public int? TypeId { get; set; }
        public double? MoneyDiscount { get; set; }
        public double? MoneyDeposit { get; set; }
        public double? MoneyTransfer { get; set; }
        public int? CarrierId { get; set; }
        public string? CarrierName { get; set; }
        public int? ShipFee { get; set; }
        public int? CodFee { get; set; }
        public int? CustomerShipFee { get; set; }
        public int? ReturnFee { get; set; }
        public int? OverWeightShipFee { get; set; }
        public int? DeclaredFee { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerMobile { get; set; }
        public int? CustomerCityId { get; set; }
        public string? CustomerCity { get; set; }

        // Ngay? giao hang thanh cong
        public string? DeliveryDate { get; set; }
        public string? StatusName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatuses? StatusCode { get; set; }

        // Tong? thu khach
        public double? PreDiscount
        {
            get => Products.Sum(p => p.Price * p.Quantity);
        }
        public double? CalcTotalMoney { get; set; }
        public List<NhanhOrderProduct>? Products { get; set; }
    }

}
