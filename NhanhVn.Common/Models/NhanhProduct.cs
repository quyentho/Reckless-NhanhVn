using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NhanhVn.Common.CustomJsonConverter;
using NhanhVn.Common.Enums;

namespace NhanhVn.Common.Models
{
    public class NhanhProduct : INhanhModel
    {
        public string IdNhanh { get; set; }
        public string ParentId { get; set; }
        public string TypeId { get; set; }
        public string TypeName { get; set; }

        // gia goc
        public double AvgCost { get; set; }
        public string CategoryId { get; set; }

        // Sku
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string ImportPrice { get; set; }
        public double Price { get; set; }
        public double WholesalePrice { get; set; }
        public string Status { get; set; }
        public double Vat { get; set; }
        public string CreatedDateTime { get; set; }
        public NhanhProductInventory Inventory { get; set; }
        public string Unit { get; set; }
    }
}
