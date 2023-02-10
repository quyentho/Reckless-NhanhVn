using NhanhVn.Common.Models;
using NhanhVn.Services.DTOs.Response;

namespace NhanhVn.Services.Services
{
    public interface IOrderServices
    {
        Task<Response<NhanhOrder>> GetOrdersByDatesAsync(DateTime fromDate, DateTime toDate);
    }
}