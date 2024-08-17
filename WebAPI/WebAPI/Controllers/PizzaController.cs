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
    }
}