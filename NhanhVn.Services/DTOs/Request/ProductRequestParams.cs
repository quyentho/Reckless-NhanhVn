using NhanhVn.Common.CustomJsonConverter;
using System;
using System.Text.Json.Serialization;

namespace NhanhVn.Services.Models.Request
{
    // reference https://apidocs.nhanh.vn/product/index
    public class ProductRequestParams : IRequestParams
    {
        public int? Icpp { get; set; } = 50;
        public int? Status { get; set; }
        public int? Page { get; set; } = 1;
    }
}
