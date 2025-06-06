using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Washing_Machine")]
public class WashingMachine
{
    [Key] public int WashingMachineId { get; set; }
    [Required] [Column] public decimal MaxWeight { get; set; }
    [Required] [MaxLength(100)] public string SerialNumber { get; set; }

    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = null!;

}