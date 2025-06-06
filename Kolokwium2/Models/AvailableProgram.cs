using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    [Key] public int AvailableProgramId { get; set; }
    [ForeignKey(nameof(WashingMachine))] public int WashingMachineId { get; set; }
    [ForeignKey(nameof(Program))] public int ProgramId { get; set; }
    [Required] public decimal Price { get; set; }

    public WashingMachine WashingMachine { get; set; } = null!;
    public _Program Program { get; set; } = null!;

    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = null!;
}