using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class PizzaOrderRepository : IPizzaOrderRepository
{
    private PizzaDbContext _pizzaContext;

    public PizzaOrderRepository(PizzaDbContext context)
    {
        _pizzaContext = context;
    }

    public List<Pizza> PizzaToOrder(Pizza pizza)
    {
        _pizzaContext.PizzaOrderTable.Add(pizza);
        _pizzaContext.SaveChanges();
        return PizzaToOrder(pizza);
    }

    
}