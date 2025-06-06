using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Program")]
public class _Program
{
    [Key] public int ProgramId { get; set; }
    [Required] [MaxLength(50)] public string Name { get; set; }
    [Required]  public int DurationMinutes { get; set; }
    [Required] public int TemperatureCelsius { get; set; }

    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = null!;

}