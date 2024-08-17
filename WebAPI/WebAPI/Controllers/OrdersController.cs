using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : TControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Get all orders information
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllOrdersWithPagination/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllOrdersWithPagination(int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await _orderService.GetAllOrdersWithPagination(page, pageSize);
                return Ok(new { Message = ApiConstants.SuccessResult, page, pageSize, result.totalCount, result.orderDetails });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Get all order details information
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllOrderDetailsWithPagination/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllOrderDetailsWithPagination(int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await _orderService.GetAllOrderDetailsWithPagination(page, pageSize);
                return Ok(new { Message = ApiConstants.SuccessResult, page, pageSize, result.totalCount, result.orderDetails });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Get order information by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrderById{id}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            try
            {
                var result = await _orderService.GetOrderById(id);
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Get order detail information by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrderDetailById{id}")]
        public async Task<IActionResult> GetOrderDetailById(string id)
        {
            try
            {
                var result = await _orderService.GetOrderDetailById(id);
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }


        /// <summary>
        /// Get order detail information by order id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrderDetailByOrderId/{orderId}")]
        public async Task<IActionResult> GetOrderDetailByOrderId(string orderId)
        {
            try
            {
                var result = await _orderService.GetOrderDetailsByOrderId(orderId);
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Get order detail information by date
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrderDetailByDate/{date}")]
        public async Task<IActionResult> GetOrderDetailByDate(DateTime date)
        {
            try
            {
                var result = await _orderService.GetOrderDetailsByDate(date);
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
