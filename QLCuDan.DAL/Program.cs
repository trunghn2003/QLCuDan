using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLCuDan.DAL.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QLCuDanDALContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLCuDanDALContext") ?? throw new InvalidOperationException("Connection string 'QLCuDanDALContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
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
