namespace NhanhVn.Common.Models
{

    public class Category : INhanhModel
    {
        public string Id { get; set; }
        public string? ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Category> Childs { get; set; }
    }

}
