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

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double Discount { get; set; }
    }
}