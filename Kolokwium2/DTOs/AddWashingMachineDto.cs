namespace Kolokwium2.DTOs;

public class AddWashingMachineRequest
{
    public WMachineDto WashingMachine { get; set; } = null!;
    public List<AvailableProgramDto> AvailablePrograms { get; set; } = new();
}

public class WMachineDto
{
    public decimal MaxWeight { get; set; }
    public string SerialNumber { get; set; } = null!;
}

public class AvailableProgramDto
{
    public string ProgramName { get; set; } = null!;
    public decimal Price { get; set; }
}