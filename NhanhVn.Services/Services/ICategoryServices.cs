using NhanhVn.Common.Models;
using NhanhVn.Services.DTOs.Response;

namespace NhanhVn.Services.Services
{
    public interface ICategoryServices
    {
        Task<Response<NhanhCategory>> GetAllCategoryAsync();
    }
}