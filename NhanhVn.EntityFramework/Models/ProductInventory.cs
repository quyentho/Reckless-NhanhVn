namespace NhanhVn.EntityFramework.Models
{
    public class ProductInventory
    {
        public int Id { get; set; }
        // care
        public int Remain { get; set; }
        public int Shipping { get; set; }
        public int Damaged { get; set; }
        public int Holding { get; set; }
        // care
        public int Available { get; set; }
    }
}
