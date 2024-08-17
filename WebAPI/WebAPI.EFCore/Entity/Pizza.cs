using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.EFCore
{
    public class Pizza
    {
        [Key]
        public string pizza_id { get; set; }
        public string pizza_type_id { get; set; }
        [ForeignKey("pizza_type_id")]
        public PizzaType PizzaType { get; set; }
        public string size { get; set; }
        public float price { get; set; }

    }
}