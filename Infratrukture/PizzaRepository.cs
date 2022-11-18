using Application.Interfaces;

namespace Infrasturkture;

public class PizzaRepository : IPizzaRepository
{
    private PizzaDbContext _pizzaContext;
    
    public PizzaRepository(PizzaDbContext context)
    {
        _pizzaContext = context;
    }
    public void RebuildDB()
    {
        _pizzaContext.Database.EnsureDeleted();
        _pizzaContext.Database.EnsureCreated();
    }
}