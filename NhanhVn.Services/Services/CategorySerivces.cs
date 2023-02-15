using Microsoft.Extensions.Configuration;
using NhanhVn.Common.Enums;
using NhanhVn.Common.Models;
using NhanhVn.Services.DTOs.Request;
using NhanhVn.Services.DTOs.Response;
using NhanhVn.Services.Helpers;
using NhanhVn.Services.Models;
using NhanhVn.Services.Models.Request;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NhanhVn.Services.Services
{
    public class CategoryServices : NhanhServiceBase, ICategoryServices
    {
        public CategoryServices(HttpClient httpClient, string url, NhanhServiceParams nhanhServiceParams) : base(httpClient,nhanhServiceParams)
        {
            Url = url;
        }

        protected override string Url { get; }

        public async Task<Response<NhanhCategory>> GetAllCategoryAsync()
        {
            var categoryRequestParams = new CategoryRequestParams();

            return await base.GetResponseAsync<CategoryRequestParams, NhanhCategory>(categoryRequestParams,null);
        }
    }
}