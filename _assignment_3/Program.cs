using Assignment3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  // Add controllers service
builder.Services.AddEndpointsApiExplorer();  // Swagger service
builder.Services.AddSwaggerGen();  // Swagger service

// Configure DbContext with SQL Server (or another database of your choice)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();  // Enables Swagger UI
}

app.UseHttpsRedirection();
app.MapControllers();  // Maps controllers

app.Run();
