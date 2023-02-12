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
    public class ProductServices : NhanhServiceBase, IProductServices
    {
        public ProductServices(HttpClient httpClient) : base(httpClient) { }

        protected override string Url { get => Config.GetRequiredSection("productApiUrl").Value; }

        public async Task<Response<NhanhProduct>> GetAllProducts()
        {
            var productRequestParams = new ProductRequestParams();
            return await base.GetAllResponseAsync<ProductRequestParams, NhanhProduct>(productRequestParams);
        }
    }
}