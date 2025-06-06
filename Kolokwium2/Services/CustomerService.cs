using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Lab11.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class CustomerService : ICustomerService
{
    private readonly DatabaseContext _context;

    public CustomerService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task<CustomerPurchasesDto> GetPurchases(int id)
    {
        var purchases = await _context.Customers
            .Where(c => c.CustomerId == id)
            .Select(c => new CustomerPurchasesDto
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Purchases = c.PurchaseHistory.Select(p => new PurchaseDto()
                {
                    Date = p.PurchaseDate,
                    Rating = p.Rating,
                    Price = p.AvailableProgram.Price,
                    WashingMachine = new WashingMachineDto()
                    {
                        MaxWeight = p.AvailableProgram.WashingMachine.MaxWeight,
                        Serial = p.AvailableProgram.WashingMachine.SerialNumber
                    },
                    Program = new ProgramDto()
                    {
                        Name = p.AvailableProgram.Program.Name,
                        Duration = p.AvailableProgram.Program.DurationMinutes
                    }
                }).ToList()
            }).FirstOrDefaultAsync();

        if (purchases is null)
        {
            throw new NotFoundException("Not found");
        }
        
        return purchases;
    }
}