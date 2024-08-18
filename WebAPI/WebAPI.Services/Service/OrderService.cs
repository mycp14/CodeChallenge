
using AutoMapper;
using WebAPI.EFCore;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<(int totalCount, List<OrderVM> orderDetails)> GetAllOrdersWithPagination(int page, int pageSize)
        {
            var orders = await _orderRepository.GetAllWithPagination(page, pageSize);
            int totalCount = await _orderRepository.GetTotalCount();
            var listOfOrder = _mapper.Map<IEnumerable<Order>, List<OrderVM>>(orders);
            if (listOfOrder == null)
                throw new AppException($"No Order found.");

            return (totalCount, listOfOrder);
        }

        public async Task<(int totalCount,List<OrderDetailVM> orderDetails)> GetAllOrderDetailsWithPagination(int page, int pageSize)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailsWithPaginationIncludeOrderAndPizza(page, pageSize);
            int totalCount = await _orderDetailRepository.GetTotalCount();
            var listOfOrderDetails = _mapper.Map<IEnumerable<OrderDetail>, List<OrderDetailVM>>(orderDetails);
            if (listOfOrderDetails == null)
                throw new AppException($"No Order details found.");

            return (totalCount, listOfOrderDetails);
        }

        public async Task<OrderVM> GetOrderById(string id)
        {
            var order = await _orderRepository.Get(x => x.order_id == Convert.ToInt32(id));
            var orderVM = _mapper.Map<Order, OrderVM>(order);
            if (orderVM == null)
                throw new AppException($"No Order found by this id {id}.");

            return orderVM;
        }

        public async Task<OrderDetailVM> GetOrderDetailById(string id)
        {
            var orderDetail = await _orderDetailRepository.GetManyOrderDetailsIncludeOrderAndPizza(x => x.order_details_id == Convert.ToInt32(id));
            var orderDetailVM = _mapper.Map<OrderDetail, OrderDetailVM>(orderDetail.FirstOrDefault());
            if (orderDetailVM == null)
                throw new AppException($"No Order detail found by this id {id}.");

            return orderDetailVM;
        }

        public async Task<List<OrderDetailVM>> GetOrderDetailsByOrderId(string orderId)
        {
            var orderDetail = await _orderDetailRepository.GetManyOrderDetailsIncludeOrderAndPizza(x => x.order_id == Convert.ToInt32(orderId));
            var orderDetailVM = _mapper.Map<IEnumerable<OrderDetail>, List<OrderDetailVM>>(orderDetail);
            if (orderDetailVM == null)
                throw new AppException($"No Order detail found by this order id {orderId}.");

            return orderDetailVM;
        }

        public async Task<List<OrderDetailVM>> GetOrderDetailsByDate(DateTime date)
        {
            var orderDetail = await _orderDetailRepository.GetManyOrderDetailsIncludeOrderAndPizza(x => x.Order.date == DateOnly.FromDateTime(date));
            var orderDetailVM = _mapper.Map<IEnumerable<OrderDetail>, List<OrderDetailVM>>(orderDetail);
            if (orderDetailVM == null)
                throw new AppException($"No Order detail found by this date {date}.");

            return orderDetailVM;
        }
    }
}