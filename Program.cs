using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var computer = Environment.MachineName;
//DESKTOP-6PE5SC4\\SQLEXPRESS01
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlite("Server=" + computer + "\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=true"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
