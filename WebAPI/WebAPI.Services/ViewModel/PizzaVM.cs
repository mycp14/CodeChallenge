
namespace WebAPI.Services
{
    public class PizzaVM : PizzaDetailsVM
    {
        public PizzaTypeVM PizzaType { get; set;}
    }

    public class PizzaDetailsVM
    {
        public string pizza_id { get; set; }
        public string pizza_type_id { get; set; }
        public string size { get; set; }
        public float price { get; set; }
    }
}