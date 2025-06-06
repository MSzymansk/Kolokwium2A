using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Lab11.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class WashingMachineService : IWashingMachineService
{
    private readonly DatabaseContext _context;

    public WashingMachineService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task addWashingMachine(AddWashingMachineRequest dto)
    {
        if (dto.WashingMachine.MaxWeight < 8)
        {
            throw new ConflictException("Max Weight must be greater than 8");
        }

        if (dto.AvailablePrograms.Any(p => p.Price > 25))
        {
            throw new ConflictException("Price must be lower than 25");
        }

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var exists = await _context.WashingMachines.AnyAsync(
                wm => wm.SerialNumber == dto.WashingMachine.SerialNumber);

            if (exists)
            {
                throw new ConflictException("Washing machine already exists");
            }
            
            var washingMachine = new WashingMachine
            {
                MaxWeight = dto.WashingMachine.MaxWeight,
                SerialNumber = dto.WashingMachine.SerialNumber
            };
            _context.WashingMachines.Add(washingMachine);
            await _context.SaveChangesAsync();

            var programNames = dto.AvailablePrograms.Select(p => p.ProgramName).ToList();
            var programs = _context.Programs.Where(p => programNames.Contains(p.Name)).ToList();

            if (programs.Count != 0)
            {
                throw new NotFoundException("Program not found");
            }

            var availablePrograms = dto.AvailablePrograms.Select(apDto =>
            {
                var program = programs.First(p => p.Name == apDto.ProgramName);
                return new AvailableProgram
                {
                    WashingMachineId = washingMachine.WashingMachineId,
                    ProgramId = program.ProgramId,
                    Price = apDto.Price
                };
            }).ToList();
                
            _context.AvailablePrograms.AddRange(availablePrograms);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}