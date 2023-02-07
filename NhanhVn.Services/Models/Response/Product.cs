namespace NhanhVn.Services.Models.Response
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductBarcode { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }

}
