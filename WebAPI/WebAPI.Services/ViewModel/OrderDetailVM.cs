
using WebAPI.EFCore;

namespace WebAPI.Services
{
    public class OrderDetailVM : OrdersInfoVM
    {
        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
    }

    public class OrdersInfoVM
    {
        public int order_details_id { get; set; }
        public int order_id { get; set; }
        public string pizza_id { get; set; }
        public string quantity { get; set; }
    }
}