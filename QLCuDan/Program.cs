using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Core.Types;
using QLCuDan.DAL.Data;
using QLCuDan.DAL.Model;
using QLCuDan.DAL.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QLCuDanDALContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLCuDanDALContext") ?? throw new InvalidOperationException("Connection string 'QLCuDanDALContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IRepository<Apartment>, Repository<Apartment>>();
builder.Services.AddTransient<IRepository<Citizen>, Repository<Citizen>>();
builder.Services.AddTransient<IRepository<CitizenApartment>, Repository<CitizenApartment>>();
builder.Services.AddTransient<UnitOfWork>();

builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<ICitizenService, CitizenService>();
//builder.Services.AddScoped<ICitizenApartmentService, CitizenApartmentService>();

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
