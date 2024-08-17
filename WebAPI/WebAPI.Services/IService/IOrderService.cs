
namespace WebAPI.Services
{
    public interface IOrderService
    {
        Task<(int totalCount, List<OrderVM> orderDetails)> GetAllOrdersWithPagination(int page, int pageSize);
        Task<(int totalCount, List<OrderDetailVM> orderDetails)> GetAllOrderDetailsWithPagination(int page, int pageSize);
        Task<OrderVM> GetOrderById(string id);
        Task<OrderDetailVM> GetOrderDetailById(string id);
        Task<List<OrderDetailVM>> GetOrderDetailsByOrderId(string orderId);
        Task<List<OrderDetailVM>> GetOrderDetailsByDate(DateTime date);
    }
}