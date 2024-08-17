
namespace WebAPI.Services
{
    public class OrderDetailVM
    {
        public int order_details_id { get; set; }
        public int order_id { get; set; }
        public string pizza_id { get; set; }
        public string quantity { get; set; }
    }
}