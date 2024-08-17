using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.EFCore
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_detail_id { get; set; }

        public int order_id { get; set; }
        [ForeignKey("order_id")]
        public Order Order { get; set; }

        public string pizza_id { get; set; }
        [ForeignKey("pizza_id")]
        public Pizza Pizza { get; set; }
        public string quantity { get; set; }
    }
}