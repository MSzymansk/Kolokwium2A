using Kolokwium2.Services;
using Lab11.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet("{id}/purchases")]
        public async Task<IActionResult> GetPurchases(int id)
        {
            try
            {
                var result = await _customerService.GetPurchases(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
    }
}
