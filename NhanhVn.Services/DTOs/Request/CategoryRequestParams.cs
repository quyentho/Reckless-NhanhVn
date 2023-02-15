using NhanhVn.Services.Models.Request;

namespace NhanhVn.Services.Services
{
    public class CategoryRequestParams : IRequestParams
    {
        public int? Page
        {
            get; set;
        }
    }
}