using Kolokwium2.DTOs;
using Kolokwium2.Models;

namespace Kolokwium2.Services;

public interface IWashingMachineService
{
    public Task addWashingMachine(AddWashingMachineRequest dto);
    
}