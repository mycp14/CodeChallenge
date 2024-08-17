using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : TControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        /// <summary>
        /// Get all pizza types information
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPizzaTypes")]
        public async Task<IActionResult> GetAllPizzaTypes()
        {
            try
            {
                var result = await _pizzaService.GetAllPizzaTypes();
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Get all pizzas information
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPizzas")]
        public async Task<IActionResult> GetAllPizzas()
        {
            try
            {
                var result = await _pizzaService.GetAllPizzas();
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Get pizza types information by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPizzaTypeById/{id}")]
        public async Task<IActionResult> GetPizzaTypeById(string id)
        {
            try
            {
                var result = await _pizzaService.GetPizzaTypeById(id);
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Get pizza information by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPizzaById/{id}")]
        public async Task<IActionResult> GetPizzaById(string id)
        {
            try
            {
                var result = await _pizzaService.GetPizzaById(id);
                return Ok(new { Message = ApiConstants.SuccessResult, result });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}