using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<_Program> Programs { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }


    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer()
            {
                CustomerId = 1,
                FirstName = "James",
                LastName = "Bond",
                PhoneNumber = "08888888888"
            });

        modelBuilder.Entity<_Program>();

        modelBuilder.Entity<WashingMachine>().HasData(
            new WashingMachine()
            {
                MaxWeight = 25,
                SerialNumber = "wwww2222",
                WashingMachineId = 1
            });

        modelBuilder.Entity<PurchaseHistory>().HasData(
            new PurchaseHistory()
            {
                CustomerId = 1,
                PurchaseDate = DateTime.Now,
                Rating = 9
            });

        modelBuilder.Entity<AvailableProgram>().HasData(
            new AvailableProgram()
            {
                ProgramId = 1,
                AvailableProgramId = 1,
                Price = 100
            });
    }
}