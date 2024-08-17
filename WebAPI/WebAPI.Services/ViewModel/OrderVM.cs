
namespace WebAPI.Services
{
    public class OrderVM
    {
        public int order_id { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
    }
}