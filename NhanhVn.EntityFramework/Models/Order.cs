using NhanhVn.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhanhVn.EntityFramework.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int NhanhId { get; set; }

        // kenh? ban Shopee, Lazada,...

        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public SaleChannel? SaleChannel { get; set; }
        public string? MerchantTrackingNumber { get; set; }
        public DateTime CreatedDateTime { get; set; }
        // id? kho hang
        public int? DepotId { get; set; }
        public string? DepotName { get; set; }
        public string? Type { get; set; }
        public int? TypeId { get; set; }

        // tong discount tren hoa don
        public double MoneyDiscount { get; set; }
        public double MoneyDeposit { get; set; }
        public double MoneyTransfer { get; set; }
        public int? CarrierId { get; set; }
        public string? CarrierName { get; set; }
        public int ShipFee { get; set; }
        public int CodFee { get; set; }
        public int CustomerShipFee { get; set; }
        public int ReturnFee { get; set; }
        public int OverWeightShipFee { get; set; }
        public int DeclaredFee { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerMobile { get; set; }
        public int? CustomerCityId { get; set; }
        public string? CustomerCity { get; set; }

        // Ngay? giao hang thanh cong
        public string? DeliveryDate { get; set; }
        public string? StatusName { get; set; }

        public OrderStatuses? StatusCode { get; set; }

        // Tong? thu khach
        public double CalcTotalMoney { get; set; }


        [Column(TypeName = "jsonb")]
        public List<OrderProduct>? Products { get; set; }
    }
}
