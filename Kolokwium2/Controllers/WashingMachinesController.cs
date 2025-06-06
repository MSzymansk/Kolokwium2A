using Kolokwium2.DTOs;
using Kolokwium2.Services;
using Lab11.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [Route("api/washing-machines")]
    [ApiController]
    public class WashingMachinesController : ControllerBase
    {
        private readonly IWashingMachineService _washingMachineService;

        public WashingMachinesController(IWashingMachineService washingMachineService)
        {
            _washingMachineService = washingMachineService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWashingMachine([FromBody] AddWashingMachineRequest washingMachine)
        {
            try
            {
                await _washingMachineService.addWashingMachine(washingMachine);
                return Created();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ConflictException e)
            {
                return Conflict(e.Message);
            }
        }
        
    }
}