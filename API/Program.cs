
using System.Text;
using Application.DTOs;
using Application.Helpers;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new MapperConfiguration(conf =>
{
    conf.CreateMap<PizzaDTOs, Pizza>();
    conf.CreateMap<Pizza, PizzaDTOs>();
    conf.CreateMap<OrderDTOs, Order>();
    conf.CreateMap<Order, OrderDTOs>();
    conf.CreateMap<PizzaUpdateDTOs, Pizza>();
    conf.CreateMap<Pizza, PizzaUpdateDTOs>();
    
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Appsettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("AppSettings:Secret")))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PizzamandPolicy", (policy) => { policy.RequireRole("pizzamand");});

});

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
        options.SetIsOriginAllowed(origin => true);
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowCredentials();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();