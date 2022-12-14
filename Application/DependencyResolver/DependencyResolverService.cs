using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public class DependencyResolverService
{
    public static void RegisterApplicationLayer(IServiceCollection services)
    {
        services.AddScoped<IPizzaService, PizzaService>();
        services.AddScoped<IOrderService, OrderService>();
        
    }
}