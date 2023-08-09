using EmployeeManager.Api.IoC;
using EmployeeManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dbContext
builder.Services.AddDbContext<EmployeeManagerContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//cors
builder.Services.AddCors();
//DI
IoC.RegisterServices(builder.Services);


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
