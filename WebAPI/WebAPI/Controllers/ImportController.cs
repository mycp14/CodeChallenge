using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.EFCore;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : TControllerBase
    {
        private readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService;
        }

        /// <summary>
        /// Import pizza types information
        /// </summary>
        /// <returns></returns>
        [HttpPost("ImportPizzaTypes")]
        public async Task<IActionResult> ImportPizzaTypes(IFormFile csvFile)
        {
            try
            {
                if (csvFile != null && csvFile.Length > 0)
                {
                    using (var stream = csvFile.OpenReadStream())
                    {
                        try
                        {
                            await _importService.ImportPizzaType(stream);
                        }
                        catch (ApplicationException ex)
                        {
                            ModelState.AddModelError(string.Empty, ex.Message);
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                        }
                    }
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Message = ApiConstants.ModelStateInvalid, Members = CompileModelStateError(ModelState) });
                }
                return Ok(new { Message = ApiConstants.SuccessResult, Result = ApiConstants.ImportResult });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Import pizzas information
        /// </summary>
        /// <returns></returns>
        [HttpPost("ImportPizzas")]
        public async Task<IActionResult> ImportPizzas(IFormFile csvFile)
        {
            try
            {
                if (csvFile != null && csvFile.Length > 0)
                {
                    using (var stream = csvFile.OpenReadStream())
                    {
                        try
                        {
                            await _importService.ImportPizzas(stream);
                        }
                        catch (ApplicationException ex)
                        {
                            ModelState.AddModelError(string.Empty, ex.Message);
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                        }
                    }
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Message = ApiConstants.ModelStateInvalid, Members = CompileModelStateError(ModelState) });
                }
                return Ok(new { Message = ApiConstants.SuccessResult, Result = ApiConstants.ImportResult });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Import orders information
        /// </summary>
        /// <returns></returns>
        [HttpPost("ImportOrders")]
        public async Task<IActionResult> ImportOrders(IFormFile csvFile)
        {
            try
            {
                if (csvFile != null && csvFile.Length > 0)
                {
                    using (var stream = csvFile.OpenReadStream())
                    {
                        try
                        {
                            await _importService.ImportOrders(stream);
                        }
                        catch (ApplicationException ex)
                        {
                            ModelState.AddModelError(string.Empty, ex.Message);
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                        }
                    }
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Message = ApiConstants.ModelStateInvalid, Members = CompileModelStateError(ModelState) });
                }
                return Ok(new { Message = ApiConstants.SuccessResult, Result = ApiConstants.ImportResult });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Import order details information
        /// </summary>
        /// <returns></returns>
        [HttpPost("ImportOrderDetails")]
        public async Task<IActionResult> ImportOrderDetails(IFormFile csvFile)
        {
            try
            {
                if (csvFile != null && csvFile.Length > 0)
                {
                    using (var stream = csvFile.OpenReadStream())
                    {
                        try
                        {
                            await _importService.ImportOrderDetails(stream);
                        }
                        catch (ApplicationException ex)
                        {
                            ModelState.AddModelError(string.Empty, ex.Message);
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                        }
                    }
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Message = ApiConstants.ModelStateInvalid, Members = CompileModelStateError(ModelState) });
                }
                return Ok(new { Message = ApiConstants.SuccessResult, Result = ApiConstants.ImportResult });
            }
            catch (AppException e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}