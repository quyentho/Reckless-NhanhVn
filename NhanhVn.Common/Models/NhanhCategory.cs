namespace NhanhVn.Common.Models
{

    public class NhanhCategory : INhanhModel
    {
        public string Id { get; set; }
        public object ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<NhanhCategory> Childs { get; set; }
    }

}
