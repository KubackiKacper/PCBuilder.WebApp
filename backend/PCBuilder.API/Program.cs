using Microsoft.EntityFrameworkCore;
using PCBuilder.Application.Interfaces;
using PCBuilder.Application.Services;
using PCBuilder.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IContactRequestRepository, ContactRequestRepository>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
