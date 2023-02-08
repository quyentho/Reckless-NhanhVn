using NhanhVn.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkWithPostgresPOC.Models
{
    public class Order
    {
        public  int Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "jsonb")]
        public NhanhOrder Orders { get; set; }
    }
}
