using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhanhVn.EntityFramework.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int NhanhProductId { get; set; }
        public int Remain { get; set; }
        public int Shipping { get; set; }
        public int Damaged { get; set; }
        public int Holding { get; set; }
        public int Available { get; set; }
    }
}
