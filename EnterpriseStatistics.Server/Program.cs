using EnterpriseStatistics.Application;
using EnterpriseStatistics.Domain;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration["ConnectionStrings:mysql"];
builder.Services.AddDbContext<EnterpriseStatisticsDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddTransient<IRepository<Enterprise, ulong>, EnterpriseRepository>();
builder.Services.AddTransient<IRepository<Supplier, int>, SupplierRepository>();
builder.Services.AddTransient<IRepository<Supply, int>, SupplyRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
