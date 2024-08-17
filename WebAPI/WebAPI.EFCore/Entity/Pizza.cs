using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.EFCore
{
    public class Pizza
    {
        [Key]
        public string PizzaId { get; set; }
        public string PizzaTypeId { get; set; }
        [ForeignKey("PizzaTypeId")]
        public PizzaType PizzaType { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }

    }
}