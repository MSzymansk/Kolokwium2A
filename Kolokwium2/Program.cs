using Kolokwium2.Data;
using Kolokwium2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IWashingMachineService, WashingMachineService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();