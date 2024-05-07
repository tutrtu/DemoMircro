using CustomerWebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var dbHost = "ADMIN-PC\\SQLEXPRESS";
var dbName = "dms_customer";
var dbPassword = "123456789";
var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID = sa; Password={dbPassword}";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
