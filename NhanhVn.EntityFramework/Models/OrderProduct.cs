namespace NhanhVn.EntityFramework.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public string NhanhProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductBarcode { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double Discount { get; set; }
    }
}