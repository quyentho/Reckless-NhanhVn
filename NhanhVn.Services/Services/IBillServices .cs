using NhanhVn.Common.Models;
using NhanhVn.Services.DTOs.Response;

namespace NhanhVn.Services.Services
{
    public interface IBillServices
    {
        Task<Response<NhanhBill>> GetRetailBillsByDatesAsync(DateTime fromDate, DateTime toDate);
    }
}