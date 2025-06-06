using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface ICustomerService
{
    public Task<CustomerPurchasesDto> GetPurchases(int id);
}