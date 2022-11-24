using Application;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new MapperConfiguration(conf =>
{
    conf.CreateMap<PizzaDTOs, Pizza>();
    conf.CreateMap<Pizza, PizzaDTOs>();
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
Application.DependencyResolver.DependencyResolverService.RegisterApplicationLayer(builder.Services);
Infrastructure.DependencyResolver.DependencyResolverService.RegisterInfrastructureLayer(builder.Services);

builder.Services.AddCors();


builder.Services.AddDbContext<PizzaDbContext>(options => options.UseSqlite(
    "Data source=db.db"
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyHeader();
        options.AllowAnyMethod();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();