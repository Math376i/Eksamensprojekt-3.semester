using Application.Interfaces;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IPizzaRepository, PizzaRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPizzaOrderRepository, PizzaOrderRepository>();

    }
}