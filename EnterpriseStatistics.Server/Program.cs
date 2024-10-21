using AutoMapper;
using EnterpriseStatistics.Application;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddSingleton<IRepository<Enterprise, ulong>, EnterpriseRepository>();
builder.Services.AddSingleton<IRepository<Supplier, int>, SupplierRepository>();
builder.Services.AddSingleton<IRepository<Supply, int>, SupplyRepository>();

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
