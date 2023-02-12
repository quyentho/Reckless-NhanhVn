using NhanhVn.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhanhVn.EntityFramework.Models
{
    public class Product : INhanhModel
    {
        public int Id { get; set; }
        public string? IdNhanh { get; set; }
        public double? Price { get; set; }

        // Sku?
        public string? Code { get; set; }
        public string? Barcode { get; set; }
        public string? Name { get; set; }

        public string? ParentId { get; set; }
        public string? TypeId { get; set; }
        public string? TypeName { get; set; }

        // gia goc
        public double? AvgCost { get; set; }
        public string? CategoryId { get; set; }
        public string? ImportPrice { get; set; }
        public double? WholesalePrice { get; set; }
        public string? Status { get; set; }
        public double? Vat { get; set; }
        public string? CreatedDateTime { get; set; }

        [Column(TypeName = "jsonb")]
        public ProductInventory? Inventory { get; set; }
        public string? Unit { get; set; }
    }
}
