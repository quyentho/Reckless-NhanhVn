using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Models;

namespace NhanhVn.Services.Services
{
    public interface IOrderServices
    {
        Task<Response<Order>> GetOrdersByDateAsync(DateTime fromDate, DateTime toDate);
    }
}