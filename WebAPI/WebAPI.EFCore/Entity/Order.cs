using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.EFCore
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int order_id { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
    }
}